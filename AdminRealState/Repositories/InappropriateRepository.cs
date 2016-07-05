using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class InappropriateRepository
    {
        public bool DeleteInappropriateByReviewId(int reviewId)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblInappropriate> inappropriate = db.tblInappropriates.Where(data => data.ReviewId == reviewId);
                    foreach (tblInappropriate objtblInappropriate in inappropriate.ToList())
                    {
                        bool isDeleted = DeleteInappropriateById(objtblInappropriate.Id);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool DeleteInappropriateById(int id)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblInappropriate inappropriate = db.tblInappropriates.FirstOrDefault(data => data.Id == id);

                    db.tblInappropriates.DeleteObject(inappropriate);
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