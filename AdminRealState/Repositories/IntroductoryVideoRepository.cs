using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class IntroductoryVideoRepository
    {
        public bool FillIntroductoryVideoRepository(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblIntroductoryVideo objtblIntroductoryVideo = new tblIntroductoryVideo()
                    {
                        ProjectId = objProject.Id,
                        Link = objProject.IntroDuctoryVideosDetails.FileName,
                        Time = DateTime.Now, //Value to be assigned to Time attribute of IntroductoryVideos

                };

                    string physicalPath = System.Web.HttpContext.Current.Server.MapPath(("IntroductoryVideo") + "\\" + objProject.IntroDuctoryVideosDetails.FileName);
                    objProject.IntroDuctoryVideosDetails.SaveAs(physicalPath);
                    db.tblIntroductoryVideos.AddObject(objtblIntroductoryVideo);
                    db.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public bool DeleteIntroductoryVideoByProjectId(int projectId)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblIntroductoryVideo> introductoryVideo = db.tblIntroductoryVideos.Where(data => data.ProjectId == projectId);
                    foreach (tblIntroductoryVideo objtblIntroductoryVideo in introductoryVideo.ToList())
                    {
                        db.tblIntroductoryVideos.DeleteObject(objtblIntroductoryVideo);
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
        public bool GetIntroductoryVideoByProjectId(int projectId, ref Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {

                    tblIntroductoryVideo objtblIntroductoryVideo = db.tblIntroductoryVideos.FirstOrDefault(data => data.ProjectId == projectId);
                    objProject.IntroductoryVideos = new IntroductoryVideo()
                    {
                        Id = objtblIntroductoryVideo.Id,
                        Link = objtblIntroductoryVideo.Link,
                        Time = objtblIntroductoryVideo.Time,
                        ProjectId = objtblIntroductoryVideo.ProjectId,

                    };

                    return true;
                }

                catch (Exception ex)
                {

                    return false;
                }
            }
        }
        public bool EditIntroductoryVideo(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblIntroductoryVideo objtblIntroductoryVideo = new tblIntroductoryVideo()
                    {
                        Id = objProject.IntroductoryVideos.Id,
                        ProjectId = objProject.IntroductoryVideos.ProjectId,
                        Link = objProject.IntroductoryVideos.Link,
                        Time = objProject.IntroductoryVideos.Time,
                    };
                    if (objProject.IntroDuctoryVideosDetails != null)
                    {
                        string physicalPathDelete = System.Web.HttpContext.Current.Server.MapPath("~\\"+("IntroductoryVideo") + "\\" + objProject.IntroductoryVideos.Link);
                        System.IO.File.Delete(physicalPathDelete);
                        objProject.IntroductoryVideos.Link = objProject.IntroDuctoryVideosDetails.FileName;
                        string physicalPath = System.Web.HttpContext.Current.Server.MapPath("~\\"+("IntroductoryVideo") + "\\" + objProject.IntroDuctoryVideosDetails.FileName);
                        objProject.IntroDuctoryVideosDetails.SaveAs(physicalPath);

                    }


                    db.tblIntroductoryVideos.Attach(objtblIntroductoryVideo);
                    db.ObjectStateManager.ChangeObjectState(objtblIntroductoryVideo, EntityState.Modified);
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
