using QRCODE.PROJECT.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using Spire.Barcode;
using System.Drawing;

namespace QRCODE.PROJECT
{
    public partial class Upload : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["NAME"] == null)
            {
                Response.Redirect("Authorize.aspx");
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            UploadMain();

        }


        private bool genBarcode(string job_id)
        {

            var setting = new BarcodeSettings()
            {
             Data = job_id,
            Type = BarCodeType.Code128,
            Unit = System.Drawing.GraphicsUnit.Millimeter,
            ShowTextOnBottom = true,
            TextFont  = new System.Drawing.Font("Arial",10)
            };

            var generator = new BarCodeGenerator(setting);
            System.Drawing.Image img ;
            img = generator.GenerateImage();
            img.Save(Server.MapPath("~/Barcode/" + job_id + ".jpeg"),System.Drawing.Imaging.ImageFormat.Jpeg);

            return true;
        }


        private string retDate(string strDate)
        {

            // RET M/dd/yyyy 1/27/2018
            string[] arrD;
            arrD = strDate.Split('/');


            if (arrD[1].Length == 1)
            {
                arrD[1] = "0" + arrD[1];
            }

            if(arrD[0].Length == 1)
            {
                arrD[0] = "0" + arrD[0];
            }


            return arrD[2] + "-" + arrD[0] + "-" + arrD[1];
        }

        private bool ReadExcel(string job_id)
        {

            FileInfo excel = new FileInfo(Server.MapPath("~/EXCEL/" + job_id + ".xlsx"));

            using (var package = new ExcelPackage(excel))
            {
                var workbook = package.Workbook;
                //*** Sheet 1
                var worksheet = workbook.Worksheets["Sheet1"];

                //*** Result

                MODEL.Criteria.job job = new MODEL.Criteria.job();


                job.job_name = worksheet.Cells["A3"].Text;

                string tmpD;
                tmpD = worksheet.Cells["B1"].Text;
                // RET M/dd/yyyy 1/27/2018

                job.job_date = retDate(tmpD);
                job.job_id = job_id;
                job.place_type = worksheet.Cells["K5"].Text.Trim();


                //  jobDetail


                List<MODEL.Criteria.jobDetail> lstJobDetail = new List<MODEL.Criteria.jobDetail>();

                int i = 5;

                do
                {

                    MODEL.jobDetail jobDetail = new MODEL.jobDetail();

                    jobDetail.place_get_job = worksheet.Cells[i, 1].Text;
                    jobDetail.container_type = worksheet.Cells[i, 2].Text;
                    jobDetail.container_dim = worksheet.Cells[i, 3].Text;
                    jobDetail.cust_dest = worksheet.Cells[i, 4].Text;
                    jobDetail.code_name = worksheet.Cells[i, 5].Text;
                    jobDetail.appointed_time = worksheet.Cells[i, 6].Text;
                    jobDetail.doc_no = worksheet.Cells[i, 7].Text;
                    jobDetail.place_send_job = worksheet.Cells[i, 8].Text;
                    jobDetail.send_company = worksheet.Cells[i, 9].Text;
                    jobDetail.remark = worksheet.Cells[i, 10].Text;
                    jobDetail.place_type = worksheet.Cells[i, 11].Text;
                    lstJobDetail.Add(jobDetail);
                    i++;
                } while (worksheet.Cells[i, 1].Text != "");




                job.createby = Session["NAME"].ToString();
                InsertJob(job, lstJobDetail);
            }

            return true;
        }



        private bool InsertJob(MODEL.Criteria.job job, List<MODEL.Criteria.jobDetail> lstJobDetail)
        {

            BLL.job _BLL = new BLL.job();
            int ret;

            ret = _BLL.Insert_Job(job);

            if(ret == 1)
            {
                int k ;
                k = lstJobDetail.Count();

                for (int i = 0; i < k; i++)
                {
                    MODEL.Criteria.jobDetail jdt = new MODEL.Criteria.jobDetail();
                    jdt = (MODEL.Criteria.jobDetail)lstJobDetail[i];
                    jdt.job_id = job.job_id;
                    jdt.job_name = job.job_name;
                    
                   
                    _BLL.Insert_JobDetail(jdt);
                }
            }
           

            return true;
        }

        private bool UploadMain()
        {
            if (FileUpload1.HasFile)
            {
                string folderPath = Server.MapPath("~/EXCEL/");
                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(folderPath);
                }

                FileUpload fu = FileUpload1;
                String fileExtension = System.IO.Path.GetExtension(fu.FileName).ToLower();
                String[] allowedExtensions = { ".xlsx" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        try
                        {
                            string job_id;
                            ClsModule mdl = new ClsModule();
                            job_id = mdl.getRuningNoDoc();

                           
                            //Doc.doc_name = fu.FileName;
                            //Doc.create_by = Session["NAME"].ToString();
                            //Doc.secure_prepare = Session["EMAIL"].ToString();
                            //Doc.attach_file_name = Doc.doc_id + ".zip";
                            //Doc.content = Content.Text;


                            string s_newfilename = job_id + fileExtension;
                            fu.PostedFile.SaveAs(folderPath + s_newfilename);


                            ClsModule obj = new ClsModule();


                                MODEL.Log L = new MODEL.Log();
                                Helper.Utility Log = new Helper.Utility();

                                L.ip = obj.GetIPAddress();
                                L.page = obj.getPageName();
                                L.content = "Upload success.";
                                L.create_by = "";// Session["EMAIL"].ToString();

                                Log.WriteLog(L);


                                ReadExcel(job_id);

                                genBarcode(job_id);

                                Response.Redirect("DataJob.aspx");

                            //    lblMessage.Text = Path.GetFileName(FileUpload1.FileName) + " has been uploaded.";
                            //imagepath = ImageSavedPath + s_newfilename;
                            return true;
                        }
                        catch (Exception ex)
                        {
                            Response.Write("File could not be uploaded." + ex.Message);
                            return false;
                        }

                    }
                    else
                    {
                        Response.Write("Please upload xlsx file only.");
                        return false;
                    }

                }
                return true;
            }
            else
            {

                Response.Write("<script>alert('โปรดเลือกไฟล์ก่อน');</script>");
                return false;
            }

        }
    }
}