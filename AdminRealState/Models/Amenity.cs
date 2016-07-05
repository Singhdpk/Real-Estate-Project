using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblAmenity")]
    public class Amenity
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        [Required]public int MasterAmenityId { get; set; }

        [Required]
        public string Value { get; set; }

        AmenityRepository objAmenityRepository = new AmenityRepository();
        public bool FillAmenity(Project objProject)
        {
            bool isFilled = objAmenityRepository.FillAmenity(objProject);
            return isFilled;
        }

        public bool GetAmenityByProjectId(int projectId, ref Project objProject)
        {
            bool isRetrieved = objAmenityRepository.GetAmenityByProjectId(projectId, ref objProject);
            return isRetrieved;
        }
        public bool DeleteAmenityByProjectId(int projectId)
        {
            bool isDeleted = objAmenityRepository.DeleteAmenityByProjectId(projectId);
            return isDeleted;
        }

        public bool EditAmenity(Project objProject)
        {
            bool isEdited = objAmenityRepository.EditAmenity(objProject);
            return isEdited;
        }
    }
}