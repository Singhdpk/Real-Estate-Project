using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblFollowProject")]
    public class FollowProject
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }

        FollowProjectRepository objFollowProjectRepository = new FollowProjectRepository();
        public bool DeleteFollowProjectByProjectId(int projectId)
        {
            bool isDeleted = objFollowProjectRepository.DeleteFollowProjectByProjectId(projectId);
            return isDeleted;
        }
    }
}