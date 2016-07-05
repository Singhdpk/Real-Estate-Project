using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblReviewy")]
    public class Review
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public double AverageValue { get; set; }
        public string Text { get; set; }
        public int Helpful { get; set; }
        public System.DateTime Time { get; set; }
        public bool IsReviewed { get; set; }
       public Project projects { get; set; }
        public User users { get; set; }
        public ReviewDetail reviewDetails { get; set; }
        public DateTime LastVisited { get; set; }

        ReviewRepository objReviewRepository = new ReviewRepository();
        public List<Review> GetReviewDataForViewAllReview()
        {
            List<Review> reviewData = objReviewRepository.GetReviewDataForViewAllReview();
            return reviewData;
        }
        public bool DeleteReviewByProjectId(int projectId)
        {
            bool isDeleted = objReviewRepository.DeleteReviewByProjectId(projectId);
            return isDeleted;
        }
        public bool DeleteReviewById(int id)
        {
            bool isDeleted = objReviewRepository.DeleteReviewById(id);
            return isDeleted;
        }
    }
}