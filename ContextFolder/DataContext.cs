using Microsoft.EntityFrameworkCore;
using PhoneBook_ASP.NET_Core_App.Models.Classes;

namespace PhoneBook_ASP.NET_Core_App.ContextFolder
{
    public class DataContext : DbContext
    {
        public DbSet<Notes> Note { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-V784SJL;
                  DataBase=PhoneNumbersStore;
                  Trusted_Connection=True;"
                );
        }
    }
}
