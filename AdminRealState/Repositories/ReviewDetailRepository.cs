using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class ReviewDetailRepository
    {
        public bool DeleteReviewDetailByReviewId(int reviewId)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblReviewDetail> reviewDetail = db.tblReviewDetails.Where(data => data.ReviewId == reviewId);
                    foreach (tblReviewDetail objtblReviewDetail in reviewDetail.ToList())
                    {
                        bool isDeleted = DeleteReviewDetailById(objtblReviewDetail.Id);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool DeleteReviewDetailById(int id)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblReviewDetail reviewDetail = db.tblReviewDetails.FirstOrDefault(data => data.Id == id);

                    db.tblReviewDetails.DeleteObject(reviewDetail);
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