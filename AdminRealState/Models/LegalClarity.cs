using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblLegalClarity")]
    public class LegalClarity
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int MasterLegalClarityId { get; set; }
        [Required]
        public string Value { get; set; }

        LegalClarityRepository objLegalClarityRepository = new LegalClarityRepository();
        public bool FillLegalClarity(Project objProject)
        {
            bool isFilled = objLegalClarityRepository.FillLegalClarity(objProject);
            return isFilled;
        }
        public bool GetLegalClarityByProjectId(int projectId, ref Project objProject)
        {
            bool isRetrieved = objLegalClarityRepository.GetLegalClarityByProjectId(projectId, ref objProject);
            return isRetrieved;
        }
        public bool DeleteLegalClarityByProjectId(int projectId)
        {
            bool isDeleted = objLegalClarityRepository.DeleteLegalClarityByProjectId(projectId);
            return isDeleted;
        }
        public bool EditLegalClarity(Project objProject)
        {
            bool isEdited = objLegalClarityRepository.EditLegalClarity(objProject);
            return isEdited;
        }
    }
}