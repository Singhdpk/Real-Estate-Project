using AdminRealState.Repositories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.Models
{
    [Table("tblMasterInventory")]
    public class MasterInventory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        MasterInventoryRepository objMasterInventoryRepository = new MasterInventoryRepository();
        public List<MasterInventory> GetAllData()
        {
            List<MasterInventory> DataMasterInventory = objMasterInventoryRepository.GetAllData();
            return DataMasterInventory;
        }
        public bool AddNewMasterInventory(MasterInventory objMasterInventory)
        {
            bool isAdded = objMasterInventoryRepository.AddNewMasterInventory(objMasterInventory);
            return isAdded;
        }

        public bool DeleteMasterInventoryById(int id)
        {
            bool isDeleted = objMasterInventoryRepository.DeleteMasterInventoryById(id);
            return isDeleted;
        }
    }
}