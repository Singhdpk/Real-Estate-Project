using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class InventoryRepository
    {
        public bool FillInventory(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {

                    for (var i = 0; i < objProject.Inventories.Count; i++)
                    {
                        tblInventory objtblInventory = new tblInventory()
                        {
                            ProjectId = objProject.Id,
                            MasterInventoryId = objProject.Inventories[i].MasterInventoryId,
                            Value = objProject.Inventories[i].Value,
                        };
                        db.tblInventories.AddObject(objtblInventory);
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

        public bool DeleteInventoryByProjectId(int projectId)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblInventory> inventory = db.tblInventories.Where(data => data.ProjectId == projectId);
                    foreach (tblInventory objtblInventory in inventory.ToList())
                    {
                        db.tblInventories.DeleteObject(objtblInventory);
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

        public bool GetInventoryByProjectId(int projectId, ref Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    IEnumerable<tblInventory> inventories = db.tblInventories.Where(data => data.ProjectId == projectId);
                    objProject.Inventories = new List<Inventory>();
                    foreach (tblInventory objtblInventory in inventories)
                    {
                        objProject.Inventories.Add(new Inventory() { Id = objtblInventory.Id, MasterInventoryId = objtblInventory.MasterInventoryId, Value = objtblInventory.Value });
                    }

                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }
        public bool EditInventory(Project objProject)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    for (var i = 0; i < objProject.Inventories.Count; i++)
                    {
                        tblInventory objtblInventory = new tblInventory()
                        {
                            Id = objProject.Inventories[i].Id,
                            ProjectId = objProject.Id,
                            MasterInventoryId = objProject.Inventories[i].MasterInventoryId,
                            Value = objProject.Inventories[i].Value,
                        };
                        if (objtblInventory != null)
                        {
                            db.tblInventories.Attach(objtblInventory);
                            db.ObjectStateManager.ChangeObjectState(objtblInventory, EntityState.Modified);
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