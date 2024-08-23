using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSinhViennhom5
{
    internal class Database
    {

        //private string sql = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        private string sql = "Data Source=DESKTOP-CQPPRKT;Initial Catalog=QlSinhVien;Integrated Security=True";
        public Database()
        {
          
        }


        public string ConnectionString
        {
            get { return sql; }
        }
    }
}
