using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class ReviewRatingDetailRepository
    {
        public bool DeleteReviewRatingDetailByReviewId(int reviewId)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblReviewRatingDetail> reviewDetail = db.tblReviewRatingDetails.Where(data => data.ReviewId == reviewId);
                    foreach (tblReviewRatingDetail objtblReviewRatingDetail in reviewDetail.ToList())
                    {
                        bool isDeleted = DeleteReviewRatingDetailById(objtblReviewRatingDetail.Id);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public bool DeleteReviewRatingDetailById(int id)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblReviewRatingDetail reviewRatingDetail = db.tblReviewRatingDetails.FirstOrDefault(data => data.Id == id);

                    db.tblReviewRatingDetails.DeleteObject(reviewRatingDetail);
                    db.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}