using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Criteria
{
    public class jobDetail
    {
       public string job_id { get; set; }
       public string job_name { get; set; }

       public string place_get_job { get; set; }
       public string container_type { get; set; }
       public string container_dim { get; set; }
       public string cust_dest { get; set; }
       public string code_name { get; set; }
       public string appointed_time { get; set; }
       public string doc_no { get; set; }
       public string place_send_job { get; set; }
       public string send_company { get; set; }
       public string remark { get; set; }
       public string place_type { get; set; }
     

       //public string place_get_job2 { get; set; }
       //public string container_type2 { get; set; }
       //public string container_dim2 { get; set; }
       //public string cust_dest2 { get; set; }
       //public string code_name2 { get; set; }
       //public string appointed_time2 { get; set; }
       //public string doc_no2 { get; set; }
       //public string place_send_job2 { get; set; }
       //public string send_company2 { get; set; }
       //public string remark2 { get; set; }

    
    }

    public class job
    {
        public string job_id { get; set; }
        public string job_name { get; set; }
        public string job_date { get; set; }
        public string createdate { get; set; }
        public string createby { get; set; }
        public string place_type { get; set; }
        public string date_start { get; set; }
        public string date_end { get; set; }
 

   
    }
}
