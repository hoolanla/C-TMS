using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
	





namespace QRCODE.PROJECT
{
    public partial class TestQR_GEN : System.Web.UI.Page
    {


        protected void getExcel()
     {

       //  FileInfo excel = new FileInfo(Server.MapPath(@"C:\_CODE\WEB_APP\QR_CODE\QRCODE.PROJECT\Xls\รูปแบบเอกสารสำหรับเข้ารับงาน R1.xls"));
FileInfo excel = new FileInfo("C://Book1.xlsx");

using (var package = new ExcelPackage(excel))

{
var workbook = package.Workbook;
//*** Sheet 1
var worksheet = workbook.Worksheets["Sheet1"];

             //*** Result

    MODEL.job job = new MODEL.job();
   

    job.job_name = worksheet.Cells["A3"].Text;
    job.job_date = worksheet.Cells["B1"].Text;


  //  jobDetail


    List<MODEL.jobDetail> lstJobDetail = new List<MODEL.jobDetail>();

    int i = 5;
    
    do{

        MODEL.jobDetail jobDetail = new MODEL.jobDetail();

    jobDetail.place_get_job = worksheet.Cells[i,1].Text;
    jobDetail.container_type = worksheet.Cells[i,2].Text;
    jobDetail.container_dim =worksheet.Cells[i,3].Text;
    jobDetail.cust_dest =worksheet.Cells[i,4].Text;
    jobDetail.code_name =worksheet.Cells[i,5].Text;
    jobDetail.appointed_time =worksheet.Cells[i,6].Text;
    jobDetail.doc_no = worksheet.Cells[i,7].Text;
    jobDetail.place_send_job =worksheet.Cells[i,8].Text;
    jobDetail.send_company =worksheet.Cells[i,9].Text;
    jobDetail.remark = worksheet.Cells[i,10].Text;
    lstJobDetail.Add(jobDetail);
    i++ ;
    } while (worksheet.Cells[i, 1].Text != "");

    //jobDetail.place_get_job2 = worksheet.Cells["A6"].Text;
    //jobDetail.container_type2 = worksheet.Cells["B6"].Text;
    //jobDetail.container_dim2 = worksheet.Cells["C6"].Text;
    //jobDetail.cust_dest2 = worksheet.Cells["D6"].Text;
    //jobDetail.code_name2 = worksheet.Cells["E6"].Text;
    //jobDetail.appointed_time2 = worksheet.Cells["F6"].Text;
    //jobDetail.doc_no2 = worksheet.Cells["G6"].Text;
    //jobDetail.place_send_job2 = worksheet.Cells["H6"].Text;
    //jobDetail.send_company2 = worksheet.Cells["I6"].Text;
    //jobDetail.remark2 = worksheet.Cells["J6"].Text;



    string tmp = worksheet.Cells["A7"].Text;

  //  genQR(job, jobDetail);

         }


     }

    //    private void genQR (MODEL.job job,MODEL.jobDetail jobDetail)
    //{


    //    StringBuilder strId = new StringBuilder();
    //    strId.Append( "ใบงานประจำวันที่#" + job.job_date + "#");
    //    strId.Append("ชื่องาน#" + job.job_name + "#");

    //   strId.Append("สถานที่รับงานในบริษัท#" + jobDetail.place_get_job + "|" + jobDetail.place_get_job2 + "#");
    //   strId.Append("งาน/คอนเทรนเนอร์#" + jobDetail.container_type + "|" + jobDetail.container_type2 + "#");
    //   strId.Append("ขนาดรถ#" + jobDetail.container_dim + "|" + jobDetail.container_type2 + "#");

    //   strId.Append("ปลายทางลูกค้า#" + jobDetail.cust_dest + "|" + jobDetail.cust_dest2 + "#");
    //   strId.Append("ชื่อย่อ#" + jobDetail.code_name + "|" + jobDetail.code_name2 + "#");
    //   strId.Append("เวลานัด#" + jobDetail.appointed_time + "|" + jobDetail.appointed_time2 + "#");
    //   strId.Append("DOC NO.#" + jobDetail.doc_no + "|" + jobDetail.doc_no2 + "#");
    //   strId.Append("รับงานไปที่#" + jobDetail.place_send_job + "|" + jobDetail.place_send_job2 + "#");
    //   strId.Append("บริษัทรับงาน#" + jobDetail.send_company + "|" + jobDetail.send_company2 + "#");
    //   strId.Append("Remark#" + jobDetail.remark + "|" + jobDetail.remark);


    //    ASCIIEncoding encoding = new ASCIIEncoding();
    //    string postData = strId.ToString();
    //    byte[] data = Encoding.UTF8.GetBytes(postData);
    //    var url = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "/QRcode.ashx";
    //    HttpWebRequest myRequest =
    //      (HttpWebRequest)WebRequest.Create(url);
    //    myRequest.Method = "POST";
    //    myRequest.ContentType = "text/html; charset=utf-8";
    //    myRequest.ContentLength = data.Length;
    //    Stream newStream = myRequest.GetRequestStream();
    //    newStream.Write(data, 0, data.Length);
    //    newStream.Close();

    //}
        protected void Page_Load(object sender, EventArgs e)
        {




            getExcel();






//            string strId;
//            strId = "ใบงานประจำวันที่4 January 2018"	;							
//strId += "ชื่องานนำตู้เปล่าเข้าโรงงาน และสลับตู้หนักลากออก คืนท่าเรือสถานที่รับงานในบริษัทงาน/คอนเทรนเนอร์ขนาดรถปลายทางลูกค้าชื่อย่อเวลานัดDOC NO.รับงานไปที่	บริษัทรับงานRemark";
//strId += "	ตู้เปล่า	ตู้ขนาด 20ฟุต	อินโดนีเซีย	FTAI	14:00น.	DOC 1	ท่าเรือ	ยูเซ็น	PDC.0112.17E, 0113.17E, 0114.17E";
//strId +=  "จุดโหลดสินค้าตู้คอนเทรนเนอร์	ตู้หนัก	ตู้ขนาด 40ฟุต	ญี่ปุ่น	TNJP(TBC)	14:00น.	DOC 1	ท่าเรือ	ยูเซ็น	PDC.0112.17E, 0113.17E, 0114.17E";
    
//            ASCIIEncoding encoding = new ASCIIEncoding();
//            string postData = strId;
//            byte[] data = Encoding.UTF8.GetBytes(postData);
//            var url = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "/QRcode.ashx";
//            HttpWebRequest myRequest =
//              (HttpWebRequest)WebRequest.Create(url);
//            myRequest.Method = "POST";
//            myRequest.ContentType = "text/html; charset=utf-8";  
//            myRequest.ContentLength = data.Length;
//            Stream newStream = myRequest.GetRequestStream();
//            newStream.Write(data, 0, data.Length);
//            newStream.Close();



        }
    }
}