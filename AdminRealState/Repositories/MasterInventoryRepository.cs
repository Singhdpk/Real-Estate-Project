using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class MasterInventoryRepository
    {
        public List<MasterInventory> GetAllData()
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                List<tblMasterInventory> datatblMasterInventory = new List<tblMasterInventory>();
                datatblMasterInventory = db.tblMasterInventories.ToList();
                List<MasterInventory> dataMasterInventory = new List<MasterInventory>();

                for (var i = 0; i < datatblMasterInventory.Count; i++)
                {
                    dataMasterInventory.Add(new MasterInventory() { Id = datatblMasterInventory[i].Id, Name = datatblMasterInventory[i].Name });
                }
                return dataMasterInventory;
            }
        }

        public bool AddNewMasterInventory(MasterInventory objMasterInventory)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblMasterInventory objtblMasterInventory = new tblMasterInventory();
                    if (objMasterInventory.Id == 0)
                    {
                        objtblMasterInventory.Name = objMasterInventory.Name;
                        db.tblMasterInventories.AddObject(objtblMasterInventory);
                        db.SaveChanges();
                    }
                    else
                    {
                        objtblMasterInventory.Id = objMasterInventory.Id;
                        objtblMasterInventory.Name = objMasterInventory.Name;
                        db.tblMasterInventories.Attach(objtblMasterInventory);
                        db.ObjectStateManager.ChangeObjectState(objtblMasterInventory, EntityState.Modified);
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
        public bool DeleteMasterInventoryById(int id)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblMasterInventory objtblMasterInventory = new tblMasterInventory();
                    objtblMasterInventory = db.tblMasterInventories.FirstOrDefault(data => data.Id == id);
                    db.tblMasterInventories.DeleteObject(objtblMasterInventory);
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