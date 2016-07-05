using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblImage")]
    public class Images /*Changed: Class cannot have same name as attribute*/
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        [Required]
        public string Image { get; set; }

        public int Likes { get; set; }
        public int DisLikes { get; set; }

        ImagesRepository objImagesRepository = new ImagesRepository();
        public bool FillImages(Project objProject)
        {
            bool isFilled = objImagesRepository.FillImages(objProject);
            return isFilled;
        }
        public bool GetImageByProjectId(int projectId, ref Project objProject)
        {
            bool isRetrieved = objImagesRepository.GetImageByProjectId(projectId, ref objProject);
            return isRetrieved;
        }
        public bool DeleteImagesByProjectId(int projectId)
        {
            bool isDeleted = objImagesRepository.DeleteImagesByProjectId(projectId);
            return isDeleted;
        }
        public bool EditImages(Project objProject)
        {
            bool isEdited = objImagesRepository.EditImages(objProject);
            return isEdited;
        }

      
    }
}