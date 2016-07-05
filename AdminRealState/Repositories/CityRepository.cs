using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class CityRepository
    {
        public List<City> GetAllData()
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                List<tblCity> datatblCity = new List<tblCity>();
                datatblCity = db.tblCities.ToList();
                List<City> dataCity = new List<City>();

                for (var i = 0; i < datatblCity.Count; i++)
                {
                    dataCity.Add(new City() { Id = datatblCity[i].Id, Name = datatblCity[i].Name });
                }
                return dataCity;
            }
        }
    }
}