using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Log
    {

        public void WriteLog(MODEL.Log log)
        {
            Class.clsDB db = new Class.clsDB();
            string sql = "Insert into log(create_by,content,ip_address,page) Values(";
            sql += "'" + log.create_by + "','" + log.content + "','" + log.ip + "','" + log.page + "')";
            db.ExecuteNonQuery(sql);
            db.Close();
            
        }

    }
}
