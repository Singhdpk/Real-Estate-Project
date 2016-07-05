using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class AmenityRepository
    {
        public bool FillAmenity(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {

                    for (var i = 0; i < objProject.Amenities.Count; i++)
                    {
                        tblAmenity objtblAmenity = new tblAmenity()
                        {
                            ProjectId = objProject.Id,
                            MasterAmenityId = objProject.Amenities[i].MasterAmenityId,
                            Value = objProject.Amenities[i].Value,
                        };
                        db.tblAmenities.AddObject(objtblAmenity);
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

        public bool DeleteAmenityByProjectId(int projectId)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblAmenity> amenities = db.tblAmenities.Where(data => data.ProjectId == projectId);
                    foreach (tblAmenity objtblAmenity in amenities.ToList())
                    {
                        db.tblAmenities.DeleteObject(objtblAmenity);
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

        public bool GetAmenityByProjectId(int projectId, ref Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblAmenity> amenities = db.tblAmenities.Where(data => data.ProjectId == projectId);
                    int i = 0;
                    objProject.Amenities = new List<Amenity>();
                    foreach (tblAmenity objtblAmenity in amenities)
                    {
                        objProject.Amenities.Add(new Amenity() { Id = objtblAmenity.Id, MasterAmenityId = objtblAmenity.MasterAmenityId, ProjectId = objtblAmenity.ProjectId, Value = objtblAmenity.Value });
                    }

                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }

        public bool EditAmenity(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    for (var i = 0; i < objProject.Amenities.Count; i++)
                    {
                        tblAmenity objtblAmenity = new tblAmenity()
                        {
                            Id = objProject.Amenities[i].Id,
                            ProjectId = objProject.Amenities[i].ProjectId,
                            MasterAmenityId = objProject.Amenities[i].MasterAmenityId,
                            Value = objProject.Amenities[i].Value,
                        };
                        if (objtblAmenity != null)
                        {
                            db.tblAmenities.Attach(objtblAmenity);
                            db.ObjectStateManager.ChangeObjectState(objtblAmenity, EntityState.Modified);
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