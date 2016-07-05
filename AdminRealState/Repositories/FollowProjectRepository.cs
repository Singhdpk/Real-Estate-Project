using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class FollowProjectRepository
    {
        public bool DeleteFollowProjectByProjectId(int projectId)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblFollowProject> followProject = db.tblFollowProjects.Where(data => data.ProjectId == projectId);
                    foreach (tblFollowProject objtblFollowProject in followProject.ToList())
                    {
                        db.tblFollowProjects.DeleteObject(objtblFollowProject);
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