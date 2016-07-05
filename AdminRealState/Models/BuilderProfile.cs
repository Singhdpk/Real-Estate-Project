using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblBuilderProfile")]
    public class BuilderProfile
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int MasterBuilderProfileId { get; set; }
        [Required]
        public string Value { get; set; }

        BuilderProfileRepository objBuilderProfileRepository = new BuilderProfileRepository();
        public bool FillBuilderProfile(Project objProject)
        {
            bool isFilled = objBuilderProfileRepository.FillBuilderProfile(objProject);
            return isFilled;
        }

        public bool GetBuilderProfileByProjectId(int projectId, ref Project objProject)
        {
            bool isRetrieved = objBuilderProfileRepository.GetBuilderProfileByProjectId(projectId, ref objProject);
            return isRetrieved;
        }
        public bool DeleteBuilderProfileByProjectId(int projectId)
        {
            bool isDeleted = objBuilderProfileRepository.DeleteBuilderProfileByProjectId(projectId);
            return isDeleted;
        }
        public bool EditBuilderProfile(Project objProject)
        {
            bool isEdited = objBuilderProfileRepository.EditBuilderProfile(objProject);
            return isEdited;
        }
    }
}