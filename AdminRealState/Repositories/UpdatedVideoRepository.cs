using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class UpdatedVideoRepository
    {
        public bool DeleteUpdatedVideoByProjectId(int projectId)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblUpdatedVideo> updatedVideo = db.tblUpdatedVideos.Where(data => data.ProjectId == projectId);
                    foreach (tblUpdatedVideo objtblUpdatedVideo in updatedVideo.ToList())
                    {
                        db.tblUpdatedVideos.DeleteObject(objtblUpdatedVideo);
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