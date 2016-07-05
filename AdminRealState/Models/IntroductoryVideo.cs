using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblIntroductoryVideo")]
    public class IntroductoryVideo
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        [Required]
        public string Link { get; set; }
        public System.DateTime Time { get; set; }
        IntroductoryVideoRepository objIntroductoryVideoRepository = new IntroductoryVideoRepository();
        public bool FillIntroductoryVideo(Project objProject)
        {
            bool isFilled = objIntroductoryVideoRepository.FillIntroductoryVideoRepository(objProject);
            return isFilled;
        }
        public bool GetIntroductoryVideoByProjectId(int projectId, ref Project objProject)
        {
            bool isRetrieved = objIntroductoryVideoRepository.GetIntroductoryVideoByProjectId(projectId, ref objProject);
            return isRetrieved;
        }
        public bool DeleteIntroductoryVideoByProjectId(int projectId)
        {
            bool isDeleted = objIntroductoryVideoRepository.DeleteIntroductoryVideoByProjectId(projectId);
            return isDeleted;
        }
        public bool EditIntroductoryVideo(Project objProject)
        {
            bool isEdited = objIntroductoryVideoRepository.EditIntroductoryVideo(objProject);
            return isEdited;
        }
    }
}