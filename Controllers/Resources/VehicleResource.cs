using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using vega.Controllers.Resources;

namespace Vega.Controllers.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }
        public KeyValuePairResource Model { get; set; }
        public bool isRegistered { get; set; }
        public KeyValuePairResource Make { get; set; }
        public ContactResource Contact { get; set; }
        public DateTime LastUpdated{get;set;}

        public ICollection<KeyValuePairResource> Features { get; set; }
        public VehicleResource()
        {
            this.Features=new Collection<KeyValuePairResource>();
        }
    }
}