using Article.core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Date.SqlServer
{
    public class ProductEntity : IDataHelper<Product>
    {
        private dbContext db;
        private Product _table;
        public ProductEntity()
        {
            db = new dbContext();
        }
        public int Add(Product table)
        {
            if (db.Database.CanConnect())
            {
                db.products.Add(table);
                db.SaveChanges();   
                return 1;
            }
            else { return 0; }
        }

        public int Delete(int id)
        {

            if (db.Database.CanConnect())
            {
                
                db.products.Remove(db.products.Find(id));
                db.SaveChanges();
                return 1;
            }
            else { return 0; }
        }

        public List<Product> GetAll()
        {
            if (db.Database.CanConnect())
            {
                return db.products.ToList();

            }
            else { return null; }
        }

        public Product GetById(int id)
        {
            if (db.Database.CanConnect())
            {
                return db.products.FirstOrDefault(e => e.id == id);

            }
            else { return null; }
        }

        public int Update(int id, Product table)
        {
            db = new dbContext();
            if (db.Database.CanConnect())
            {
                db.products.Update(table);
                return 1;
            }
            else { return 0; }
        }
    }
}
