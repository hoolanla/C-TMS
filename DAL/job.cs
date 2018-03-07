using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class job
    {


        public DataTable getData_ReportJob(string job_id)
        {
            DataTable dt = null;
            string sql = "Select * From vw_JobTrailer where job_id='" + job_id + "' and show_=1";
            Class.clsDB db = new Class.clsDB();
            dt = db.ExecuteDataTable(sql);
            db.Close();
         
            return dt;
        }


        public DataTable getData_ReportJobTimestamp(string job_id)
        {
            DataTable dt = null;
            string sql = "Select job_id,job_name,job_date,time(timestamp1) as timestamp1,";
            sql += "time(timestamp2) as timestamp2,time(timestamp3) as timestamp3,time(timestamp4) as timestamp4";
            sql += " From job_trailer where job_id='" + job_id + "' and show_=1";
            Class.clsDB db = new Class.clsDB();
            dt = db.ExecuteDataTable(sql);
            db.Close();
       
            return dt;
        }



        public List<MODEL.jobDetail>getJobDetail(MODEL.Criteria.jobDetail criteria)
        {
            DataSet ds = new DataSet();
            String sql;
            sql = "Select * From job_detail where show_=1";
            Class.clsDB db = new Class.clsDB();
            ds = db.ExecuteDataSet(sql);
            db.Close();
       
      return ds.Tables[0].AsEnumerable().Select(s => new MODEL.jobDetail
            {
                job_id = s.Field<string>("job_id"),
                //place_get_job = s.Field<string>("place_get_job"),
                //container_type = s.Field<string>("container_type"),
                //container_dim = s.Field<string>("container_dim"),
            }).ToList();
  
        }


        public int Insert_Job(MODEL.Criteria.job criteria)
        {
            try
            {

                criteria.createdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Class.clsDB db = new Class.clsDB();
                string sql;
                sql = "Insert into job_trailer ( ";
                sql += "job_id,";
                sql += "job_name,";
                sql += "job_date,";
                sql += "place_type,";
                sql += "create_by ,";
                sql += "create_date) VALUES(";
                sql += "'" + criteria.job_id + "',";
                sql += "'" + criteria.job_name + "',";
                sql += "'" + criteria.job_date + "',";
                sql += "'" + criteria.place_type + "',";
                sql += "'" + criteria.createby + "',";
                sql += "'" + criteria.createdate + "')";

                int ret;
                ret = db.ExecuteNonQuery(sql);
                db.Close();
 
                return ret;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Insert_JobDetail(MODEL.Criteria.jobDetail criteria)
        {
            try
            {
                Class.clsDB db = new Class.clsDB();
                string sql;
                sql = "Insert into job_trailer_detail ( ";
                sql += "job_id,";
                sql += "job_name,";
                sql += "place_get_job ,";
                sql += "container_type,";
                sql += "container_dim,";
                sql += "cust_dest,";
                sql += "code_name ,";
                sql += "appointed_time,";
                sql += "doc_no,";
                sql += "place_send_job,";
                sql += "send_company,";
                sql += "place_type,";
                sql += "remark) VALUES('";
                sql +=  criteria.job_id + "',";
                sql += "'" + criteria.job_name + "',";
                sql += "'" + criteria.place_get_job + "',";
                sql += "'" + criteria.container_type + "',";
                sql += "'" + criteria.container_dim + "',";
                sql += "'" + criteria.cust_dest + "',";
                sql += "'" + criteria.code_name + "',";
                sql += "'" + criteria.appointed_time + "',";
                sql += "'" + criteria.doc_no + "',";
                sql += "'" + criteria.place_send_job + "',";
                sql += "'" + criteria.send_company + "',";
                sql += "'" + criteria.place_type + "',";
                sql += "'" + criteria.remark + "')";

                int ret;
                ret = db.ExecuteNonQuery(sql);
                db.Close();
                return ret;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }



        public int Update_stamp1(string job_id)
        {
            try
            {
                Class.clsDB db = new Class.clsDB();
                string sql;
                string timestamp1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                sql = "Update job_trailer SET timestamp1='" + timestamp1 + "' Where job_id='" + job_id + "'";
                int ret;
                ret = db.ExecuteNonQuery(sql);
                db.Close();
                return ret;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public int Update_stamp2(string appointed_time,string job_id)
        {
            try
            {
                Class.clsDB db = new Class.clsDB();
                string sql;
                sql = "Update job_trailer SET timestamp2='" + appointed_time + "' Where job_id='" + job_id + "'";
                int ret;
                ret = db.ExecuteNonQuery(sql);
                db.Close();
                return ret;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public int Update_stamp3(string job_id)
        {
            try
            {
                Class.clsDB db = new Class.clsDB();
                string sql;
                string timestamp1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                sql = "Update job_trailer SET timestamp3='" + timestamp1 + "' Where job_id='" + job_id + "'";
                int ret;
                ret = db.ExecuteNonQuery(sql);
                db.Close();
                return ret;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Update_stamp4(string job_id)
        {
            try
            {
                Class.clsDB db = new Class.clsDB();
                string sql;
                string timestamp1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                sql = "Update job_trailer SET timestamp4='" + timestamp1 + "' Where job_id='" + job_id + "'";
                int ret;
                ret = db.ExecuteNonQuery(sql);
                db.Close();
                return ret;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Delete_Job(string job_id)
        {
            try
            {
                string nl = System.Environment.NewLine;
                Class.clsDB db = new Class.clsDB();
                string sql;
                sql = "Update job_trailer SET show_ = 0 Where job_id='" + job_id + "';" + nl;
                sql += "Update job_trailer_detail SET show_ = 0 Where job_id='" + job_id + "';";
                int ret;
                ret = db.ExecuteNonQuery(sql);
                db.Close();
                return ret;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public int GetStatus_Barcode(string barcode)
        {
            Class.clsDB db = new Class.clsDB();
            string sql = "Select * From job_trailer WHERE job_id ='" + barcode + "'";
            DataTable dt;
            dt = db.ExecuteDataTable(sql);
            db.Close();
            if (dt.Rows.Count > 0)
            {
                if(dt.Rows[0].IsNull("timestamp1"))
                {
                    return 1;
                }
                else if ((!dt.Rows[0].IsNull("timestamp1")) && (!dt.Rows[0].IsNull("timestamp2")) && (!dt.Rows[0].IsNull("timestamp3")))
                {
                    return 3;
                }
                     else if((!dt.Rows[0].IsNull("timestamp1")) && (!dt.Rows[0].IsNull("timestamp2")) )
                {
                    return 2;
                }


            }

            return 0;
        }


        }

    }

