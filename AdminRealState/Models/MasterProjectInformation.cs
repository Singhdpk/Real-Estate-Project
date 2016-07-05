using AdminRealState.Repositories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.Models
{
    [Table("tblMasterProjectInformation")]
    public class MasterProjectInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }

        MasterProjectInformationRepository objMasterProjectInformationRepository = new MasterProjectInformationRepository();
        public List<MasterProjectInformation> GetAllData()
        {
            List<MasterProjectInformation> dataMasterProjectInformation = objMasterProjectInformationRepository.GetAllData();
            return dataMasterProjectInformation;
        }

        public bool AddNewMasterProjectInformation(MasterProjectInformation objMasterProjectInformation)
        {
            bool isAdded = objMasterProjectInformationRepository.AddNewMasterProjectInformation(objMasterProjectInformation);
            return isAdded;
        }

        public bool DeleteMasterProjectInformationById(int id)
        {
            bool isDeleted = objMasterProjectInformationRepository.DeleteMasterProjectInformationById(id);
            return isDeleted;
        }
    }
}