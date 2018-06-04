using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Vega.Controllers.Resources;
using Vega.Models;
using Vega.Persistence;

namespace Vega.Controllers
{
    [Route("/api/vehicles/{vId}/photos")]
    public class PhotosController : Controller
    {
        private readonly IHostingEnvironment host;
        private readonly IVehicleRepository repository;
        private readonly IMapper mapper;

        private readonly IUnitOfWork unitOfWork;
        private readonly PhotoSettings photoSettings;
        private readonly IPhotoRepository photoRepository;
        
        public PhotosController(
        IHostingEnvironment host, 
        IVehicleRepository repository,
        IUnitOfWork unitOfWork, 
        IPhotoRepository photoRepository,
        IOptionsSnapshot<PhotoSettings> options,
        IMapper mapper)
        {
            this.photoSettings=options.Value;
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork=unitOfWork;
            this.host = host;
            this.photoRepository=photoRepository;
    }
    [HttpPost]
    public async Task<IActionResult> Upload(int vId,IFormFile fileStream)
    {
        var vehicle = await this.repository.GetVehicle(vId, hasAdditional: false);
        if (vehicle == null)
            return NotFound();
        var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads");
        if (!Directory.Exists(uploadsFolderPath))
            Directory.CreateDirectory(uploadsFolderPath);
        
        if(fileStream==null) return BadRequest("null file");
        if(fileStream.Length==0) return BadRequest("Empty file");
        if(fileStream.Length>=photoSettings.MaxBytes) return BadRequest("Max file size exceeded");
        if(!photoSettings.IsSupported(fileStream.FileName)) return BadRequest("Invalid file type");

        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileStream.FileName);
        var filePath = Path.Combine(uploadsFolderPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await fileStream.CopyToAsync(stream);
            }
        var photo = new Photo { FileName = fileName };
        vehicle.Photos.Add(photo);
        await unitOfWork.CompleteAsync();
        return Ok(mapper.Map<Photo,PhotoResource>(photo));
    }
    
    [HttpGet]
    public IEnumerable<PhotoResource> GetPhotos(int vId){
       var photos= photoRepository.GetPhotos(vId);
        return mapper.Map<IEnumerable<Photo>,IEnumerable<PhotoResource>>(photos);
    }
}
}