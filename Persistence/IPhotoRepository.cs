using System.Collections.Generic;
using System.Threading.Tasks;
using Vega.Models;

namespace Vega.Persistence
{
    public interface IPhotoRepository
    {
         IEnumerable<Photo> GetPhotos(int vehicleId);
    }
}