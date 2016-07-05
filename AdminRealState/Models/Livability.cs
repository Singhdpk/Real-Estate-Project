using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblLivability")]
    public class Livability
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int MasterLivabilityId { get; set; }
        public string Name { get; set; }
        [Required]
        public double Value { get; set; }

        LivabilityRepository objLivabilityRepository = new LivabilityRepository();

        public bool FillLivability(Project objProject)
        {
            bool isFilled = objLivabilityRepository.FillLivability(objProject);
            return isFilled;
        }
        public bool GetLivabilityByProjectId(int projectId, ref Project objProject)
        {
            bool isRetrieved = objLivabilityRepository.GetLivabilityByProjectId(projectId, ref objProject);
            return isRetrieved;
        }
        public bool DeleteLivabilityByProjectId(int projectId)
        {
            bool isDeleted = objLivabilityRepository.DeleteLivabilityByProjectId(projectId);
            return isDeleted;
        }
        public bool EditLivability(Project objProject)
        {
            bool isEdited = objLivabilityRepository.EditLivability(objProject);
            return isEdited;
        }
    }
   
}