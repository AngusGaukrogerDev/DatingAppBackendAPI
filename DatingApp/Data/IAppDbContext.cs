using DatingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace DatingApp.Data
{
    public interface IAppDbContext
    {
        DbSet<StandardApplicationUser> StandardApplicationUser { get; set; }
        int SaveChanges();
    }
}