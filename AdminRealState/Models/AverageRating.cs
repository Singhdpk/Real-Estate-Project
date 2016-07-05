using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminRealState.Models
{
    public class AverageRating
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public float Amenity { get; set; }
        public float ApartmentBuildQuality { get; set; }
        public float BuilderProfile { get; set; }
        public float ConstructionQualityParameter { get; set; }
        public float Inventory { get; set; }
        public float LegalClarity { get; set; }
        public float Livability { get; set; }


    }
}