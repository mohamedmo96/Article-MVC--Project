using Article.core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Date.SqlServer
{
    public class dbContext : DbContext
    {

        public DbSet<Product> products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =MO-MOHSTAFA\\SQLEXPRESS; Initial Catalog =ArticalDb ; Integrated Security = True; Encrypt = False; ");
        }

    }
}
