using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class LocationRepository
    {
        public bool FillLocation(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblLocation objtblLocation = new tblLocation()
                    {
                        ProjectId = objProject.Id,
                        AddressLine1 = objProject.Locations.AddressLine1,
                        AddressLine2 = objProject.Locations.AddressLine2,
                        CityId = objProject.Locations.CityId,
                };
                db.tblLocations.AddObject(objtblLocation);
                db.SaveChanges();
                return true;
            }
                catch (Exception ex)
            {
                return false;

            }

        }
    }
    public bool DeleteLocationByProjectId(int projectId)
    {
        using (dbRealEstateEntities db = new dbRealEstateEntities())
        {
            try
            {
                IEnumerable<tblLocation> location = db.tblLocations.Where(data => data.ProjectId == projectId);
                foreach (tblLocation objtblLocation in location.ToList())
                {
                    db.tblLocations.DeleteObject(objtblLocation);
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
    public bool GetLocationByProjectId(int projectId, ref Project objProject)
    {
        using (dbRealEstateEntities db = new dbRealEstateEntities())
        {
            try
            {

                tblLocation objtbllocation = db.tblLocations.FirstOrDefault(data => data.ProjectId == projectId);
                objProject.Locations = new Location()
                {
                    Id = objtbllocation.Id,
                    AddressLine1 = objtbllocation.AddressLine1,
                    AddressLine2 = objtbllocation.AddressLine2,
                    ProjectId = objtbllocation.ProjectId,
                    CityId = objtbllocation.CityId
                };

                return true;
            }

            catch (Exception ex)
            {

                return false;
            }
        }
    }
    public bool EditLocation(Project objProject)
    {
        using (dbRealEstateEntities db = new dbRealEstateEntities())
        {
            try
            {
                tblLocation objtblLocation = new tblLocation()
                {
                    Id = objProject.Locations.Id,
                    AddressLine1 = objProject.Locations.AddressLine1,
                    AddressLine2 = objProject.Locations.AddressLine2,
                    CityId = objProject.Locations.CityId,
                    ProjectId = objProject.Locations.ProjectId,
                };
                if (objtblLocation != null)
                {
                    db.tblLocations.Attach(objtblLocation);
                    db.ObjectStateManager.ChangeObjectState(objtblLocation, EntityState.Modified);
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
