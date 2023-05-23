using Microsoft.AspNetCore.Mvc;
using static TrainingManagement.Repository.TrainingRepository;
using TrainingManagement.Models;
using static TrainingManagement.Models.User;

namespace TrainingManagement

{
    public interface InterfaceUser
    {
        List<User> GetUsers();

        User Create(User user);
        User GetUserById(int id);
        int Edit(int id, User user);
        int Delete(int id);
        User GetUserByUsernameAndPassword(string username, string password);


    }
}
