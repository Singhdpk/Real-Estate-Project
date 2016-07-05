using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblReviewRatingDetail")]
    public class ReviewRatingDetail
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public int MasterReviewId { get; set; }
        public double Value { get; set; }

        ReviewRatingDetailRepository objReviewRatingDetailRepository = new ReviewRatingDetailRepository();
        public bool DeleteReviewRatingDetailByReviewId(int reviewId)
        {
            bool isDeleted = objReviewRatingDetailRepository.DeleteReviewRatingDetailByReviewId(Id);
            return isDeleted;
        }
    }
}