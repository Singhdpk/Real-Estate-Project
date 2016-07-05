using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblRecentlyViewed")]
    public class RecentlyViewed
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public System.DateTime Time { get; set; }

        RecentlyViewedRepository objRecentlyViewedRepository = new RecentlyViewedRepository();
        public bool DeleteRecentlyViewedByProjectId(int projectId)
        {
            bool isDeleted = objRecentlyViewedRepository.DeleteRecentlyViewedByProjectId(projectId);
            return isDeleted;
        }
    }
}