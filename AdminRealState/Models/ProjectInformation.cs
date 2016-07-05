using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblProjectInformation")]
    public class ProjectInformation
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int MasterProjectInformationId { get; set; }
        [Required]
        public string Value { get; set; }

        ProjectInformationRepository objProjectInformationRepository = new ProjectInformationRepository();
        public bool FillProjectInformation(Project objProject)
        {
            bool isFilled = objProjectInformationRepository.FillProjectInformation(objProject);
            return isFilled;
        }
        public bool GetProjectInformationByProjectId(int projectId, ref Project objProject)
        {
            bool isRetrieved = objProjectInformationRepository.GetProjectInformationByProjectId(projectId, ref objProject);
            return isRetrieved;
        }
        public bool DeleteProjectInformationByProjectId(int projectId)
        {
            bool isDeleted = objProjectInformationRepository.DeleteProjectInformationByProjectId(projectId);
            return isDeleted;
        }
        public bool EditProjectInformation(Project objProject)
        {
            bool isEdited = objProjectInformationRepository.EditProjectInformation(objProject);
            return isEdited;
        }
    }
}