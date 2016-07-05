using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class RecentlyViewedRepository
    {
        public bool DeleteRecentlyViewedByProjectId(int projectId)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblRecentlyViewed> recentlyViewed = db.tblRecentlyVieweds.Where(data => data.ProjectId == projectId);
                    foreach (tblRecentlyViewed objtblRecentlyViewed in recentlyViewed.ToList())
                    {
                        db.tblRecentlyVieweds.DeleteObject(objtblRecentlyViewed);
                        db.SaveChanges();
                    }
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