<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rpt_job_report.aspx.cs" Inherits="QRCODE.PROJECT.Report.rpt_job_report" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
            <CR:CrystalReportViewer ID="crVw" runat="server" AutoDataBind="true" ReportSourceID="CrystalReportSource1" />

        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="Report\job_report.rpt">
            </Report>
        </CR:CrystalReportSource>
    
    
    </div>
    </form>
</body>
</html>
