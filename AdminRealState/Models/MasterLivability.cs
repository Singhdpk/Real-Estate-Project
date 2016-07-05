using AdminRealState.Repositories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.Models
{
    [Table("tblMasterLivability")]
    public class MasterLivability
    {
        public int Id { get; set; }
        public string Name { get; set; }

        MasterLivabilityRepository objMasterLivabilityRepository = new MasterLivabilityRepository();
        public List<MasterLivability> GetAllData()
        {
            List<MasterLivability> DataMasterLivability = objMasterLivabilityRepository.GetAllData();
            return DataMasterLivability;
        }

        public bool AddNewMasterLivability(MasterLivability objMasterLivability)
        {
            bool isAdded = objMasterLivabilityRepository.AddNewMasterLivability(objMasterLivability);
            return isAdded;
        }

        public bool DeleteMasterLivabilityById(int id)
        {
            bool isDeleted = objMasterLivabilityRepository.DeleteMasterLivabilityById(id);
            return isDeleted;
        }
    }
}