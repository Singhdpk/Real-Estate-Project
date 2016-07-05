using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblInventory")]
    public class Inventory
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int MasterInventoryId { get; set; }
        [Required]
        public double Value { get; set; }

        InventoryRepository objInventoryRepository = new InventoryRepository();
        public bool FillInventory(Project objProject)
        {
            bool isFilled = objInventoryRepository.FillInventory(objProject);
            return isFilled;
        }
        public bool GetInventoryByProjectId(int projectId, ref Project objProject)
        {
            bool isRetrieved = objInventoryRepository.GetInventoryByProjectId(projectId, ref objProject);
            return isRetrieved;
        }
        public bool DeleteInventoryByProjectId(int projectId)
        {
            bool isDeleted = objInventoryRepository.DeleteInventoryByProjectId(projectId);
            return isDeleted;
        }
        public bool EditInventory(Project objProject)
        {
            bool isEdited = objInventoryRepository.EditInventory(objProject);
            return isEdited;
        }
    }

}