using AdminRealState.Repositories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.Models
{
    [Table("tblMasterLegalClarity")]
    public class MasterLegalClarity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        MasterLegalClarityRepository objMasterLegalClarityRepository = new MasterLegalClarityRepository();
        public List<MasterLegalClarity> GetAllData()
        {
            List<MasterLegalClarity> DataMasterLegalClarity = objMasterLegalClarityRepository.GetAllData();
            return DataMasterLegalClarity;
        }

        public bool AddNewMasterLegalClarity(MasterLegalClarity objMasterLegalClarity)
        {
            bool isAdded = objMasterLegalClarityRepository.AddNewMasterLegalClarity(objMasterLegalClarity);
            return isAdded;
        }

        public bool DeleteMasterLegalClarityById(int id)
        {
            bool isDeleted = objMasterLegalClarityRepository.DeleteMasterLegalClarityById(id);
            return isDeleted;
        }
    }
}
