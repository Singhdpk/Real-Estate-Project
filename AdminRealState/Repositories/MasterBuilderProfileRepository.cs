using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace AdminRealState.Repositories
{
    public class MasterBuilderProfileRepository
    {
        public List<MasterBuilderProfile> GetAllData()
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                List<tblMasterBuilderProfile> datatblMasterBuilderProfile = new List<tblMasterBuilderProfile>();
                datatblMasterBuilderProfile = db.tblMasterBuilderProfiles.ToList();
                List<MasterBuilderProfile> dataMasterBuilderProfile = new List<MasterBuilderProfile>();

                for (var i = 0; i < datatblMasterBuilderProfile.Count; i++)
                {
                    dataMasterBuilderProfile.Add(new MasterBuilderProfile() { Id = datatblMasterBuilderProfile[i].Id, Name = datatblMasterBuilderProfile[i].Name });
                }
                return dataMasterBuilderProfile;
            }
        }

        public bool AddNewMasterBuilderProfile(MasterBuilderProfile objMasterBuilderProfile)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblMasterBuilderProfile objtbltMasterBuilderProfile = new tblMasterBuilderProfile();
                    if (objMasterBuilderProfile.Id == 0)
                    {
                        objtbltMasterBuilderProfile.Name = objMasterBuilderProfile.Name;
                        db.tblMasterBuilderProfiles.AddObject(objtbltMasterBuilderProfile);
                        db.SaveChanges();
                    }
                    else
                    {
                        objtbltMasterBuilderProfile.Id = objMasterBuilderProfile.Id;
                        objtbltMasterBuilderProfile.Name = objMasterBuilderProfile.Name;
                        db.tblMasterBuilderProfiles.Attach(objtbltMasterBuilderProfile);
                        db.ObjectStateManager.ChangeObjectState(objtbltMasterBuilderProfile, EntityState.Modified);
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
        public bool DeleteMasterBuilderProfileById(int id)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblMasterBuilderProfile objtbltMasterBuilderProfile = new tblMasterBuilderProfile();
                    objtbltMasterBuilderProfile = db.tblMasterBuilderProfiles.FirstOrDefault(data => data.Id == id);
                    db.tblMasterBuilderProfiles.DeleteObject(objtbltMasterBuilderProfile);
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