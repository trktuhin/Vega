using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers
{
    public class MakesController : Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;
        public MakesController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }
        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> getMakes()
        {
            var makes= await this.context.Makes.Include(m => m.Models).ToListAsync();
            return mapper.Map<List<Make>,List<MakeResource>>(makes);
        }
        [HttpGet("/api/features")]
        public async Task<IEnumerable<FeatureResource>> getFeatures()
        {
            var features= await this.context.Features.ToListAsync();
            return mapper.Map<List<Feature>,List<FeatureResource>>(features);
        }

    }
}