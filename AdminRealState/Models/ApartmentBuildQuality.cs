using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblApartmentBuildQuality")]
    public class ApartmentBuildQuality
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
      
        public int MasterApartmentBuildQualityId { get; set; }
        
        public string Name { get; set; }
        [Required]
        public string Value { get; set; }

        ApartmentBuildQualityRepository objApartmentBuildQualityRepository = new ApartmentBuildQualityRepository();
        public bool FillApartmentBuildQuality(Project objProject)
        {
            bool isFilled = objApartmentBuildQualityRepository.FillApartmentBuildQuality(objProject);
            return isFilled;
        }
        public bool GetApartmentbuildQualityByProjectId(int projectId, ref Project objProject)
        {
            bool isRetrieved = objApartmentBuildQualityRepository.GetApartmentbuildQualityByProjectId(projectId, ref objProject);
            return isRetrieved;
        }
        public bool DeleteApartmentBuildQualityByProjectId(int projectId)
        {
            bool isDeleted = objApartmentBuildQualityRepository.DeleteApartmentBuildQualityByProjectId(projectId);
            return isDeleted;
        }
        public bool EditApartmentBuildQuality(Project objProject)
        {
            bool isEdited = objApartmentBuildQualityRepository.EditApartmentBuildQuality(objProject);
            return isEdited;
        }
    }
}