using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCPROJECT.Models;

namespace MVCPROJECT.Data
{
    public class MVCPROJECT_DBContext : DbContext
    {
        public MVCPROJECT_DBContext (DbContextOptions<MVCPROJECT_DBContext> options)
            : base(options)
        {
        }

        public DbSet<MVCPROJECT.Models.AdminModel>? AdminModel { get; set; }

        public DbSet<MVCPROJECT.Models.UserModels>? UserModels { get; set; }
    }
}
