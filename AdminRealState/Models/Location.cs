using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblLocation")]
    public class Location
    {
        public int Id { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string AddressLine2 { get; set; }
        [Required, Display(Name = "City")]
        public int CityId { get; set; }
        public int ProjectId { get; set; }

        LocationRepository objLocationRepository = new LocationRepository();
        public bool FillLocation(Project objProject)
        {
            bool isFilled = objLocationRepository.FillLocation(objProject);
            return isFilled;
        }

        public bool GetLocationByProjectId(int projectId, ref Project objProject)
        {
            bool isRetrieved = objLocationRepository.GetLocationByProjectId(projectId, ref objProject);
            return isRetrieved;
        }
        public bool DeleteLocationByProjectId(int projectId)
        {
            bool isDeleted = objLocationRepository.DeleteLocationByProjectId(projectId);
            return isDeleted;
        }
        public bool EditLocation(Project objProject)
        {
            bool isEdited = objLocationRepository.EditLocation(objProject);
            return isEdited;
        }
    }
}