using TrainingManagement.Models;
using TrainingManagement.Context;
using Microsoft.EntityFrameworkCore;

namespace TrainingManagement.Repository
{
    public class TrainingRepository : InterfaceUser
    {

        TrainingDbContext _db;
        public TrainingRepository(TrainingDbContext db)
        {
            _db = db;
        }

        public List<User> GetUsers()
        {
            return _db.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _db.Users.FirstOrDefault(x => x.UserId == id);
        }


        public User Create(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return user;
        }
        public int Edit(int id, User user)
        {
            User obj = GetUserById(id);
            if (obj != null)
            {
                foreach (User temp in _db.Users)
                {
                    if (temp.UserId == id)
                    {
                        temp.Address = user.Address;
                        temp.ContactNo = user.ContactNo;
                        temp.UserName = user.UserName;
                        //temp.LastName = user.LastName;
                        temp.Email = user.Email;
                        temp.UserRole = user.UserRole;
                        temp.Password = user.Password;
                        temp.ManagerId = user.ManagerId;
                    }
                }
                _db.SaveChanges();
                return 0;
            }
            else

          
                return 1;
        }
        public int Delete(int id)
        {
            User obj = GetUserById(id);
            if (obj != null)
            {
                _db.Users.Remove(obj);
                _db.SaveChanges();
            }
            return 1;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return _db.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
        }
    }
}