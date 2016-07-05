using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblUpdatedVideo")]
    public class UpdatedVideo
    {
        
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Link { get; set; }
        public System.DateTime Time { get; set; }

        UpdatedVideoRepository objUpdatedVideoRepository = new UpdatedVideoRepository();
        public bool DeleteUpdatedVideoByProjectId(int projectId)
        {
            bool isDeleted = objUpdatedVideoRepository.DeleteUpdatedVideoByProjectId(projectId);
            return isDeleted;
        }
    }
}