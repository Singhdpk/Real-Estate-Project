using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminPanel.Models
{
    [Table("tblUser")]
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string ProfilePicture { get; set; }
        public Nullable<decimal> Contact { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public int LevelId { get; set; }
        public int IsDeleted { get; set; }

        UserRepository objUserRepository = new UserRepository();
        public User GetUserByUserId(int id)
        {
            User objUser = new User();
            objUser = objUserRepository.GetUserByUserId(id);
            return objUser;
        }
        public bool DeleteUserByUserId(int id)
        {
            bool isDeleted = objUserRepository.DeleteUserByUserId(id);
            return isDeleted;
        }
    }
}