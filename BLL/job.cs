using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
   
   public  class job
    {

       private DAL.job _DAL = new DAL.job();

       public int Insert_Job(MODEL.Criteria.job criteria)
            {
                return _DAL.Insert_Job(criteria);
            }


       public int Insert_JobDetail(MODEL.Criteria.jobDetail criteria)
       {
           return _DAL.Insert_JobDetail(criteria);
       }


       public DataTable getData_ReportJob(string job_id)
       {
           return _DAL.getData_ReportJob(job_id);
       }

       public DataTable getData_ReportJobTimestamp(string job_id)
       {
           return _DAL.getData_ReportJobTimestamp(job_id);
       }

        public int Update_stamp1(string job_id)
       {

           return _DAL.Update_stamp1(job_id);
       }


        public int Update_stamp2(string time_,string job_id)
        {

            return _DAL.Update_stamp2(time_, job_id);
        }

        public int Update_stamp3( string job_id)
        {

            return _DAL.Update_stamp3(job_id);
        }

        public int Update_stamp4(string job_id)
        {

            return _DAL.Update_stamp4(job_id);
        }

        public int Delete_Job(string job_id)
        {

            return _DAL.Delete_Job(job_id);
        }

       public int GetStatus_Barcode(string barcode)
        {
           return  _DAL.GetStatus_Barcode(barcode);
        }

    }

}
