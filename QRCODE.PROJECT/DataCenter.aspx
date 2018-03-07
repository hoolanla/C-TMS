<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataCenter.aspx.cs" Inherits="QRCODE.PROJECT.DataCenter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="GridView1" runat="server">
                    <Columns>
                        <asp:TemplateField></asp:TemplateField>
                        <asp:BoundField DataField="job_id" HeaderText="รหัสงาน" />
                        <asp:BoundField DataField="job_name" HeaderText="ชื่องาน" />
                        <asp:BoundField DataField="job_date" HeaderText="ประจำวันที่" />
                        <asp:BoundField DataField="create_by" HeaderText="ผู้ประสานงาน" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>



</asp:Content>
