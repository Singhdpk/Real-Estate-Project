using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class ReviewRepository
    {
        public object ReviewDetail { get; private set; }

        public bool DeleteReviewByProjectId(int projectId)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblReview> review = db.tblReviews.Where(data => data.ProjectId == projectId);
                    foreach (tblReview objtblReview in review.ToList())
                    {
                        bool isDeleted = DeleteReviewById(objtblReview.Id);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool DeleteReviewById(int id)
        {
            ReviewDetail objReviewDetail = new ReviewDetail();
            ReviewRatingDetail objReviewRatingDetail = new ReviewRatingDetail();
            Inappropriate objInappropriate = new Inappropriate();

            bool reviewDetailIsDeleted = objReviewDetail.DeleteReviewDetailByReviewId(id);
            bool reviewRatingDetailIsDeleted = objReviewRatingDetail.DeleteReviewRatingDetailByReviewId(id);
            bool inappropriateIsDeleted = objInappropriate.DeleteInappropriateByReviewId(id);

            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblReview review = db.tblReviews.FirstOrDefault(data => data.Id == id);

                    db.tblReviews.DeleteObject(review);
                    db.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public List<Review> GetReviewDataForViewAllReview()
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                List<Review> reviewData = new List<Review>();
                List<tblReview> tblReviewData = new List<tblReview>();
                tblReviewData = db.tblReviews.ToList();
                for (var i = 0; i < tblReviewData.Count; i++)
                {
                    reviewData.Add(new Review()
                    {
                        Id = tblReviewData[i].Id,
                        ProjectId = tblReviewData[i].ProjectId,
                        UserId = tblReviewData[i].UserId,
                        AverageValue = tblReviewData[i].AverageValue,
                        Text = tblReviewData[i].Text,
                        Helpful = tblReviewData[i].Helpful,
                        Time = tblReviewData[i].Time,
                        IsReviewed = tblReviewData[i].IsReviewed

                    });
                    tblReviewDetail objtblReviewDetail = new tblReviewDetail();
                    int reviewId = reviewData[i].Id;
                    objtblReviewDetail = db.tblReviewDetails.FirstOrDefault(data => data.ReviewId == reviewId);
                    reviewData[i].reviewDetails = new ReviewDetail()
                    {
                        ReviewedUserId = objtblReviewDetail.ReviewedUserId,
                        Helpful = objtblReviewDetail.Helpful,
                        SayThanks = objtblReviewDetail.SayThanks,
                    };
                    tblProject objtblProject = new tblProject();
                    int projectId = reviewData[i].ProjectId;
                    objtblProject = db.tblProjects.FirstOrDefault(data => data.Id == projectId);
                    reviewData[i].projects = new Project()
                    {
                        Name = objtblProject.Name,
                    };
                    tblUser objtblUser = new tblUser();
                    int userId = reviewData[i].UserId;
                    objtblUser = db.tblUsers.FirstOrDefault(data => data.Id == userId);
                    reviewData[i].users = new User()
                    {
                        FirstName = objtblUser.FirstName,
                        LastName = objtblUser.LastName,
                        EmailId = objtblUser.EmailId,
                    };
                }
                return reviewData;
            }

        }
    }
}