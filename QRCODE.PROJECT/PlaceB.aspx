<%@ Page Title="OFFICE APPROVE" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlaceB.aspx.cs" Inherits="QRCODE.PROJECT.PlaceB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   

    
      <style>
body {
    background-color: linen;
}

h1 {
    color: maroon;
    margin-left: 40px;


} 

.hiddencol { display: none; }



    .rounded_corners
    {
        border: 1px solid #A1DCF2;
        -webkit-border-radius: 8px;
        -moz-border-radius: 8px;
        border-radius: 8px;
        overflow: hidden;
    }
    .rounded_corners td, .rounded_corners th
    {
        border: 1px solid #A1DCF2;
        font-family: Arial;
        font-size: 10pt;
        text-align: center;
    }
    .rounded_corners table table td
    {
        border-style: none;
    }

    /*td {
    vertical-align:middle;
    text-align:left;
    font-size:small;
     font-weight: bold;
}*/
    table{
    width:100%;
}

    .Content
    {
        width:80px;
    }
</style>

    <script type="text/javascript" src="./Scripts/jquery.min.js"></script>
<script type="text/javascript">
    $("[src*=plus]").live("click", function () {    
        $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
        $(this).attr("src", "images/minus.png");
       
    });
    $("[src*=minus]").live("click", function () {
        $(this).attr("src", "images/plus.png");
        $(this).closest("tr").next().remove();
        
    });
</script>

         <script type="text/javascript">

             function PlaySound_Warning() {
                 //Wrapper to call sound function.

                 PlaySoundNow(this, 'Audio/Windows Exclamation.wav');
             }


             function PlaySoundNow(el, soundfile) {
                 if (el.mp3) {
                     if (el.mp3.paused) el.mp3.play();
                     else el.mp3.pause();
                 } else {
                     el.mp3 = new Audio(soundfile);
                     el.mp3.play();
                 }
             }

    </script>
    
<script type="text/javascript">
    function chkNumber(ele) {
    
        var vchar = String.fromCharCode(event.keyCode);
        alert(vchar);
        if ((vchar < '0' || vchar > '9') && (vchar != '.')) return false;
        ele.onKeyPress = vchar;
    }
</script>

    <script type="text/javascript">
        function keyintdot() {
            var key = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
            if ((key < 46 || key > 57 || key == 47) && (key != 13)) {
                event.returnValue = false;
            }
        }

</script> 

   <table border="0"><tr><td><br />
       <asp:Label ID="Label1" runat="server" Text="|| โลจิสติกส์ (เอฟจี) ||" Font-Bold="True" ForeColor="#003366"></asp:Label><br /><br />

       </td></tr></table>

      




      <table style="width:100%" border="0"><tr><td>
        <div class="rounded_corners" style="width:100%" >
                   <asp:UpdatePanel runat="server">
                         <ContentTemplate>
<asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" CssClass="Grid"
    DataKeyNames="job_id" OnRowDataBound="OnRowDataBound"    HeaderStyle-ForeColor="BLACK" RowStyle-BackColor="#00cc00" AlternatingRowStyle-BackColor="White"
        RowStyle-ForeColor="#3A3A3A"  AllowPaging="True"
         OnPageIndexChanged="grid_PageIndexChanged" OnPageIndexChanging="grid_PageIndexChanging" OnSelectedIndexChanged="grid_SelectedIndexChanged" OnRowCommand="grid_RowCommand" AllowSorting="True" EnableSortingAndPagingCallbacks="True" OnSorting="grid_Sorting">
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <img alt = "" style="cursor: pointer" src="images/plus.png" width="20" height="20" />
                <asp:Panel ID="pnlOrders" runat="server" Style="display: none" Width="900px" >
                       <div class="rounded_corners" style="width:100%" >
                    <asp:GridView ID="grid_nested" runat="server" AutoGenerateColumns="false" CssClass = "ChildGrid"    HeaderStyle-ForeColor="BLACK" RowStyle-BackColor="#6699ff" AlternatingRowStyle-BackColor="White"
        RowStyle-ForeColor="#3A3A3A"  >
                        <Columns>
                            <asp:BoundField ItemStyle-Width="150px" DataField="place_get_job" HeaderText="สถานที่รับงาน" HeaderStyle-Width="300px" />
                            <asp:BoundField ItemStyle-Width="100px" DataField="container_type" HeaderText="งาน/คอนเทรนเนอร์" HeaderStyle-Width="30px" />

                             <asp:BoundField ItemStyle-Width="150px" DataField="container_dim" HeaderText="ขนาดรถ" HeaderStyle-Width="30px"  />
                             <asp:BoundField ItemStyle-Width="100px" DataField="cust_dest" HeaderText="ปลายทางลูกค้า" HeaderStyle-Width="30px"  />
                             <asp:BoundField ItemStyle-Width="100px" DataField="code_name" HeaderText="ชื่อย่อ" HeaderStyle-Width="30px"  />
                             <asp:BoundField ItemStyle-Width="100px" DataField="appointed_time" HeaderText="เวลานัด" HeaderStyle-Width="30px"  />
                             <asp:BoundField ItemStyle-Width="100px" DataField="doc_no" HeaderText="DOC NO." HeaderStyle-Width="30px"  />

                             <asp:BoundField ItemStyle-Width="100px" DataField="place_send_job" HeaderText="รับงานไปที่" HeaderStyle-Width="30px"  />
                             <asp:BoundField ItemStyle-Width="100px" DataField="send_company" HeaderText="บริษัทรับงาน" HeaderStyle-Width="30px"  />
                             <asp:BoundField ItemStyle-Width="150px" DataField="remark" HeaderText="Remark" HeaderStyle-Width="300px"  />
                        </Columns>
                    </asp:GridView>
                           </div>
                </asp:Panel>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField ItemStyle-Width="150px" DataField="job_id" HeaderText="รหัสงาน" SortExpression="job_id" >

<ItemStyle Width="150px"></ItemStyle>

        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="1000px" DataField="job_name" HeaderText="ชื่องาน" >
<ItemStyle Width="600px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="job_date" HeaderText="ประจำวันที่" />
        <asp:BoundField DataField="create_by" HeaderText="ผู้ประสานงาน" />
<%--        <asp:BoundField DataField="create_date" HeaderText="CREATE DATE"/>--%>
        <asp:TemplateField HeaderText="เวลาติดต่อ">
                <ItemTemplate>
                       <asp:imagebutton ID="timestamp1" runat="server" CommandName="timestamp1"   CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" ></asp:imagebutton>
                   <asp:Label ID="lblStamp1" runat="server" Text='<%# Eval("timestamp1") %>'></asp:Label>
                      </ItemTemplate>
               <ControlStyle Height="20px" Width="20px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ยืนยันเวลาเข้า">
                <ItemTemplate>
                       <asp:imagebutton ID="timestamp2" runat="server" CommandName="timestamp2"   CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" ></asp:imagebutton>
                 <asp:Label ID="lblStamp2" runat="server" Text='<%# Eval("timestamp2") %>'></asp:Label>
                        </ItemTemplate>
              <ControlStyle Height="20px" Width="20px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
        <asp:TemplateField HeaderText="เวลาเข้า">
                <ItemTemplate>
                       <asp:imagebutton ID="timestamp3" runat="server" CommandName="timestamp3"   CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" ></asp:imagebutton>
                    <asp:Label ID="lblStamp3" runat="server" Text='<%# Eval("timestamp3") %>'></asp:Label>
                     </ItemTemplate>
               <ControlStyle Height="20px" Width="20px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="เวลาออก">
                <ItemTemplate>
                       <asp:imagebutton ID="timestamp4" runat="server" CommandName="timestamp4"   CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" ></asp:imagebutton>
                    <asp:Label ID="lblStamp4" runat="server" Text='<%# Eval("timestamp4") %>'></asp:Label>
                     </ItemTemplate>
               <ControlStyle Height="20px" Width="20px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="แจ้งเตือน">
                <ItemTemplate>
                       <asp:imagebutton ID="SOUND" runat="server" CommandName="SOUND"   CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" ></asp:imagebutton>
                </ItemTemplate>
               <ControlStyle Height="20px" Width="20px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>
    </Columns>

<HeaderStyle ForeColor="Black"></HeaderStyle>

<RowStyle BackColor="#ffcc99" ForeColor="#3A3A3A"></RowStyle>
</asp:GridView>
<br />
                  &nbsp; <asp:Label ID="lblresult" runat="server" Font-Bold="True" ForeColor="#006600"/>
                             <br />
                             <br />

            <asp:Timer ID="Timer1" runat="server" Interval="20000" OnTick="Timer1_Tick1" />
</ContentTemplate>

         

       </asp:UpdatePanel>



    
<asp:Button ID="btnShowPopup" runat="server" style="display:none" />
<asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
 BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>
<asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="150px" Width="300px" style="display:none">
<table width="100%" style="border:Solid 3px #D55500; width:100%; height:100%" cellpadding="0" cellspacing="0" border="2">
<tr style="background-color:#D55500">
<td colspan="2" style=" height:10%; color:White; font-weight:bold; font-size:larger" align="center">APPOINTED TIME</td>
</tr>

<tr>
<td align="right" style="width:50%">
<asp:Label ID="lbl1" CssClass="Content" Text="JOB ID" runat="server"></asp:Label>
</td>
<td style="width:40%">
<asp:Label ID="lbl_job_id" runat="server" ForeColor="#006600" Font-Bold="True" Font-Size="Medium"></asp:Label>
</td>
  
</tr>
<tr>
<td align="right" style="width:30%">
<asp:Label ID="lbl2" CssClass="Content" Text="เวลาเข้า" runat="server"></asp:Label>
</td>
<td style="width:40%">

<%--    <asp:RegularExpressionValidator runat="server" ID="regxTime" ControlToValidate="txtHH" ErrorMessage="โปรดใส่ Format HH:mm" 
        ValidationExpression="^([1-9]|1[0-2]|0[1-9]){1}(:[0-5][0-9][aApP][mM]){1}$"></asp:RegularExpressionValidator>--%>
    <%--  --%>
<%--    <cc1:TimeSelector ID="TimeSelector1" runat="server" Font-Bold="true" SelectedTimeFormat="Twelve" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" Height="50" Width="200px" AllowSecondEditing="False" >
</cc1:TimeSelector>--%>

    <asp:TextBox ID="txtHH" placeholder="HH:mm" runat="server" MaxLength="5" CssClass="Content"></asp:TextBox>


</td>

</tr>


<tr>
<td>
</td>
<td>
<asp:Button ID="btnUpdate"  runat="server" Text="Update" onclick="btnUpdate_Click"/>


    <asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click" /></td>

</table>
</asp:Panel>


            </div>
            </td></tr></table>


</asp:Content>
