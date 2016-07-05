using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class BuilderProfileRepository
    {
        public bool FillBuilderProfile(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {

                    for (var i = 0; i < objProject.BuilderProfiles.Count; i++)
                    {
                        tblBuilderProfile objtblBuilderProfile = new tblBuilderProfile()
                        {
                            //ProjectId = objProject.Id,
                            MasterBuilderProfileId = objProject.BuilderProfiles[i].MasterBuilderProfileId,
                            Value = objProject.BuilderProfiles[i].Value,
                        };
                        db.tblBuilderProfiles.AddObject(objtblBuilderProfile);
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

        public bool DeleteBuilderProfileByProjectId(int? projectId)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    //IEnumerable<tblBuilderProfile> builderProfiles = db.tblBuilderProfiles.Where(data => data.ProjectId == projectId);
                   //foreach (tblBuilderProfile objtblBuilderProfile in builderProfiles.ToList())
                   // {
                   //     db.tblBuilderProfiles.DeleteObject(objtblBuilderProfile);
                   //     db.SaveChanges();
                   // }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool GetBuilderProfileByProjectId(int projectId, ref Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    //IEnumerable<tblBuilderProfile> builderProfiles = db.tblBuilderProfiles.Where(data => data.ProjectId == projectId);
                    //int i = 0;
                    //objProject.BuilderProfiles = new List<BuilderProfile>();
                    //foreach (tblBuilderProfile objtblBuilderProfile in builderProfiles)
                    //{
                    //    objProject.BuilderProfiles.Add(new BuilderProfile() { Id = objtblBuilderProfile.Id, MasterBuilderProfileId = objtblBuilderProfile.MasterBuilderProfileId, ProjectId = objtblBuilderProfile.ProjectId, Value = objtblBuilderProfile.Value });
                    //}

                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }
        public bool EditBuilderProfile(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    for (var i = 0; i < objProject.BuilderProfiles.Count; i++)
                    {
                        tblBuilderProfile objtblBuilderProfile = new tblBuilderProfile()
                        {
                            Id = objProject.BuilderProfiles[i].Id,
                            //ProjectId = objProject.BuilderProfiles[i].ProjectId,
                            MasterBuilderProfileId = objProject.BuilderProfiles[i].MasterBuilderProfileId,
                            Value = objProject.ApartmentBuildQualities[i].Value,
                        };
                        if (objtblBuilderProfile != null)
                        {
                            db.tblBuilderProfiles.Attach(objtblBuilderProfile);
                            db.ObjectStateManager.ChangeObjectState(objtblBuilderProfile, EntityState.Modified);
                            db.SaveChanges();
                        }
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