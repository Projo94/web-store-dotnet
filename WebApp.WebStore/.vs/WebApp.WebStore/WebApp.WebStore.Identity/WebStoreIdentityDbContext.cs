

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.WebStore.Identity.Models;

namespace WebApp.WebStore.Identity
{
    public class WebStoreIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public WebStoreIdentityDbContext(DbContextOptions<WebStoreIdentityDbContext> options) : base(options)
        {
        }
    }
}
