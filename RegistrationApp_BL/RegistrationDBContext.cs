using Microsoft.EntityFrameworkCore;
using RegistrationApp_DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationApp_BL
{
    public class RegistrationDBContext : DbContext
    {
        public RegistrationDBContext(DbContextOptions<RegistrationDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<RegistrationModel> tblUserRegistration { get; set; }
        public DbSet<CityModel> tblCity { get; set; }
        public DbSet<StateModel> tblState { get; set; }
        public DbSet<SP_RegistrationInsertUpdateModel> SP_RegistrationInsertUpdate { get; set; }
    }
}
