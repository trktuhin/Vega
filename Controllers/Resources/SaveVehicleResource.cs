using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Vega.Controllers.Resources
{
    public partial class SaveVehicleResource
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool isRegistered { get; set; }
        [Required]
        public ContactResource Contact { get; set; }
        public ICollection<int> Features { get; set; }
        public DateTime LastUpdated {get;set;}
        
        public SaveVehicleResource()
        {
            Features=new Collection<int>();
        }
    }
}