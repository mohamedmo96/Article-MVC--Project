using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Date
{
    public interface IDataHelper<Table>
    {
        //Read 
        List<Table> GetAll();   
        Table GetById(int id);  
        int Add(Table table);
        int Update( int id , Table table);
        int Delete(int id);

    }
}
