using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class ApartmentBuildQualityRepository
    {
        public bool FillApartmentBuildQuality(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {

                    for (var i = 0; i < objProject.ApartmentBuildQualities.Count; i++)
                    {
                        tblApartmentBuildQuality objtblApartmentBuildQuality = new tblApartmentBuildQuality()
                        {
                            ProjectId = objProject.Id,
                            MasterApartmentBuildQualityId = objProject.ApartmentBuildQualities[i].MasterApartmentBuildQualityId,
                            Name = objProject.ApartmentBuildQualities[i].Name,
                            Value = objProject.ApartmentBuildQualities[i].Value,
                        };
                    db.tblApartmentBuildQualities.AddObject(objtblApartmentBuildQuality);
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

    public bool DeleteApartmentBuildQualityByProjectId(int? projectId)
    {
        using (dbRealEstateEntities db = new dbRealEstateEntities())
        {
            try
            {
                IEnumerable<tblApartmentBuildQuality> apartmentBuildQualities = db.tblApartmentBuildQualities.Where(data => data.ProjectId == projectId);
                foreach (tblApartmentBuildQuality objtblApartmentBuildQuality in apartmentBuildQualities.ToList())
                {
                    db.tblApartmentBuildQualities.DeleteObject(objtblApartmentBuildQuality);
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

    public bool GetApartmentbuildQualityByProjectId(int projectId, ref Project objProject)
    {
        using (dbRealEstateEntities db = new dbRealEstateEntities())
        {
            try
            {
                IEnumerable<tblApartmentBuildQuality> apartmentBuildQualities = db.tblApartmentBuildQualities.Where(data => data.ProjectId == projectId);
                int i = 0;
                objProject.ApartmentBuildQualities = new List<ApartmentBuildQuality>();
                foreach (tblApartmentBuildQuality objtblApartmentBuildQuality in apartmentBuildQualities)
                {
                    objProject.ApartmentBuildQualities.Add(new ApartmentBuildQuality() { Id = objtblApartmentBuildQuality.Id, MasterApartmentBuildQualityId = objtblApartmentBuildQuality.MasterApartmentBuildQualityId, ProjectId = objtblApartmentBuildQuality.ProjectId,Name=objtblApartmentBuildQuality.Name,Value = objtblApartmentBuildQuality.Value });
                }

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
    public bool EditApartmentBuildQuality(Project objProject)
    {
        using (dbRealEstateEntities db = new dbRealEstateEntities())
        {
            try
            {
                for (var i = 0; i < objProject.ApartmentBuildQualities.Count; i++)
                {
                    tblApartmentBuildQuality objtblApartmentBuildQuality = new tblApartmentBuildQuality()
                    {
                        Id = objProject.ApartmentBuildQualities[i].Id,
                        ProjectId = objProject.ApartmentBuildQualities[i].ProjectId,
                        MasterApartmentBuildQualityId = objProject.ApartmentBuildQualities[i].MasterApartmentBuildQualityId,
                        Name = objProject.ApartmentBuildQualities[i].Name,
                        Value = objProject.ApartmentBuildQualities[i].Value,
                    };
                    if (objtblApartmentBuildQuality != null)
                    {
                        db.tblApartmentBuildQualities.Attach(objtblApartmentBuildQuality);
                        db.ObjectStateManager.ChangeObjectState(objtblApartmentBuildQuality, EntityState.Modified);
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