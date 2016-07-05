using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminRealState.Repositories
{
    public class UserRepository
    {
        public User GetUserByUserId(int id)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                User objUser = new User();
                try { 
                    tblUser objtblUser = new tblUser();
                    objtblUser = db.tblUsers.FirstOrDefault(data => data.Id == id);
                    objUser.Id = objtblUser.Id;
                    objUser.FirstName = objtblUser.FirstName;
                    objUser.LastName = objtblUser.LastName;
                    objUser.EmailId = objtblUser.EmailId;
                    //objUser.ProfilePicture = objtblUser.ProfilePicture;
                    objUser.Contact = objtblUser.Contact;
                    objUser.Password = objtblUser.Password;
                    objUser.City = objtblUser.City;
                    objUser.LevelId = objtblUser.LevelId;
                    return objUser;
                }
                catch(Exception ex)
                {
                    objUser = null;
                    return objUser;
                }

            }
        }
        public bool DeleteUserByUserId(int id)
        {
            using (dbRealEstateEntities db = new dbRealEstateEntities())
            {
                try
                {
                    tblUser objtblUser = new tblUser();

                    objtblUser = db.tblUsers.FirstOrDefault(data => data.Id == id);
                    objtblUser.IsDeleted = 1;
                    db.tblUsers.Attach(objtblUser);
                    db.ObjectStateManager.ChangeObjectState(objtblUser, EntityState.Modified);
                    db.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
    }
}