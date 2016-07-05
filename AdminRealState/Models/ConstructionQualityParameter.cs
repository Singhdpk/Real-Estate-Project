using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblConstructionQualityParameter")]
    public class ConstructionQualityParameter
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int MasterConstructionQualityParameterId { get; set; }
        [Required]
        public string Value { get; set; }

        ConstructionQualityParameterRepository objConstructionQualityParameterRepository = new ConstructionQualityParameterRepository();
        public bool FillConstructionQualityParameter(Project objProject)
        {
            bool isFilled = objConstructionQualityParameterRepository.FillConstructionQualityParameter(objProject);
            return isFilled;
        }
        public bool GetConstructionQualityParameterByProjectId(int projectId, ref Project objProject)
        {
            bool isRetrieved = objConstructionQualityParameterRepository.GetConstructionQualityParameterByProjectId(projectId, ref objProject);
            return isRetrieved;
        }
        public bool DeleteConstructionQualityParameterByProjectId(int projectId)
        {
            bool isDeleted = objConstructionQualityParameterRepository.DeleteConstructionQualityParameterByProjectId(projectId);
            return isDeleted;
        }
        public bool EditConstructionQualityParameter(Project objProject)
        {
            bool isEdited = objConstructionQualityParameterRepository.EditConstructionQualityParameter(objProject);
            return isEdited;
        }
    }
}