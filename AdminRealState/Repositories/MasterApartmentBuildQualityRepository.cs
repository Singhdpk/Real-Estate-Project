using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class MasterApartmentBuildQualityRepository
    {
        public List<MasterApartmentBuildQuality> GetAllData()
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                List<tblMasterApartmentBuildQuality> datatblMasterApartmentBuildQuality = new List<tblMasterApartmentBuildQuality>();
                datatblMasterApartmentBuildQuality = db.tblMasterApartmentBuildQualities.ToList();
                List<MasterApartmentBuildQuality> dataMasterApartmentBuildQuality = new List<MasterApartmentBuildQuality>();

                for (var i = 0; i < datatblMasterApartmentBuildQuality.Count; i++)
                {
                    dataMasterApartmentBuildQuality.Add(new MasterApartmentBuildQuality() { Id = datatblMasterApartmentBuildQuality[i].Id, Name = datatblMasterApartmentBuildQuality[i].Name });
                }
                return dataMasterApartmentBuildQuality;
            }
        }
        public bool AddNewMasterApartmentBuildQuality(MasterApartmentBuildQuality objMasterApartmentBuildQuality)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblMasterApartmentBuildQuality objtblMasterApartmentBuildQuality = new tblMasterApartmentBuildQuality();
                    if (objMasterApartmentBuildQuality.Id == 0)
                    {
                        objtblMasterApartmentBuildQuality.Name = objMasterApartmentBuildQuality.Name;
                        db.tblMasterApartmentBuildQualities.AddObject(objtblMasterApartmentBuildQuality);
                        db.SaveChanges();
                    }
                    else
                    {
                        objtblMasterApartmentBuildQuality.Id = objMasterApartmentBuildQuality.Id;
                        objtblMasterApartmentBuildQuality.Name = objMasterApartmentBuildQuality.Name;
                        db.tblMasterApartmentBuildQualities.Attach(objtblMasterApartmentBuildQuality);
                        db.ObjectStateManager.ChangeObjectState(objtblMasterApartmentBuildQuality, System.Data.Entity.EntityState.Modified);
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
        public bool DeleteMasterApartmentBuildQualityById(int id)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblMasterApartmentBuildQuality objtblMasterApartmentBuildQuality = new tblMasterApartmentBuildQuality();
                    objtblMasterApartmentBuildQuality = db.tblMasterApartmentBuildQualities.FirstOrDefault(data => data.Id == id);
                    db.tblMasterApartmentBuildQualities.DeleteObject(objtblMasterApartmentBuildQuality);
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