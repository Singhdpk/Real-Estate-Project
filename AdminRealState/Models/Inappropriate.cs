using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    public class Inappropriate
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public string Reason { get; set; }
        public bool IsDeleted { get; set; }

        InappropriateRepository objInappropriateRepository = new InappropriateRepository();

            public bool DeleteInappropriateByReviewId(int reviewId)
        {
            bool isDeleted = objInappropriateRepository.DeleteInappropriateByReviewId(Id);
            return isDeleted;
        }
    }
}