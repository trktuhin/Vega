using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vega.Persistence;
using Vega.Models;

namespace Vega.Persistence
{
    public class PhotoRepository:IPhotoRepository
    {
        private readonly VegaDbContext context;
        public PhotoRepository(VegaDbContext context)
        {
            this.context = context;
        }
       public IEnumerable<Photo> GetPhotos(int vehicleId)
        {
            return context.Photos.Where(photo=>photo.VehicleId==vehicleId).ToList();
        }
    }
}