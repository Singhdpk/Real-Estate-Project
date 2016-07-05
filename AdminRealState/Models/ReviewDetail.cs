using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblReviewDetail")]
    public class ReviewDetail
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public int ReviewedUserId { get; set; }
        public bool Helpful { get; set; }
        public bool SayThanks { get; set; }

        ReviewDetailRepository objReviewDetailRepository = new ReviewDetailRepository();
        public bool DeleteReviewDetailByReviewId(int reviewId)
        {
            bool isDeleted = objReviewDetailRepository.DeleteReviewDetailByReviewId(Id);
            return isDeleted;
        }
    }
}