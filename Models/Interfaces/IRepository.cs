using PhoneBook_ASP.NET_Core_App.Models.Classes;
using System.Collections.Generic;

namespace PhoneBook_ASP.NET_Core_App.Models.Interfaces
{
    public interface IRepository
    {
        Notes GetById(int id);
        List<Notes> GetAll();
    }
}
