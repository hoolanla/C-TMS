<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rpt_Job.aspx.cs" Inherits="QRCODE.PROJECT.Report.rpt_Job" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <CR:CrystalReportViewer ID="crVw" runat="server" AutoDataBind="True" ToolPanelView="None"  Height="50px" ReportSourceID="CrystalReportSource1"  ToolPanelWidth="200px" Width="350px" />
        
    
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="Report\Job.rpt">
            </Report>
        </CR:CrystalReportSource>
        
    
    </div>
    </form>
</body>
</html>
