using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class MasterAmenityRepository
    {
        public List<MasterAmenity> GetAllData()
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                List<tblMasterAmenity> datatblMasterAmenity = new List<tblMasterAmenity>();
                datatblMasterAmenity = db.tblMasterAmenities.ToList();
                List<MasterAmenity> dataMasterAmenity = new List<MasterAmenity>();

                for (var i = 0; i < datatblMasterAmenity.Count; i++)
                {
                    dataMasterAmenity.Add(new MasterAmenity() { Id = datatblMasterAmenity[i].Id, Name = datatblMasterAmenity[i].Name });
                }
                return dataMasterAmenity;
            }
        }
        public bool AddNewMasterAmenity(MasterAmenity objMasterAmenity)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblMasterAmenity objtblMasterAmenity = new tblMasterAmenity();
                    if (objMasterAmenity.Id == 0)
                    {
                        objtblMasterAmenity.Name = objMasterAmenity.Name;
                        db.tblMasterAmenities.AddObject(objtblMasterAmenity);
                        db.SaveChanges();
                    }
                    else
                    {
                        objtblMasterAmenity.Id = objMasterAmenity.Id;
                        objtblMasterAmenity.Name = objMasterAmenity.Name;
                        db.tblMasterAmenities.Attach(objtblMasterAmenity);
                        db.ObjectStateManager.ChangeObjectState(objtblMasterAmenity, EntityState.Modified);
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
        public bool DeleteMasterAmenityById(int id)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblMasterAmenity objtblMasterAmenity = new tblMasterAmenity();
                    objtblMasterAmenity = db.tblMasterAmenities.FirstOrDefault(data => data.Id == id);
                    db.tblMasterAmenities.DeleteObject(objtblMasterAmenity);
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