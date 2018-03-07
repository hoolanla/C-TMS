<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataJob.aspx.cs" Inherits="QRCODE.PROJECT.DataJob" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


      <style id=";">
body {
    background-color: linen;
}

h1 {
    color: maroon;
    margin-left: 40px;


} 

.hiddencol { display: none; }

.pagination {
            font-size: 80%;
        }

.pagination a {
    text-decoration: none;
    border: solid 1px #AAE;
    color: #15B;
}

.pagination a, .pagination span {
    display: block;
    float: left;
    padding: 0.3em 0.5em;
    margin-right: 5px;
    margin-bottom: 5px;
}

.pagination .current {
    background: #26B;
    color: #fff;
    border: solid 1px #AAE;
}

.pagination .current.prev, .pagination .current.next{
    color:#999;
    border-color:#999;
    background:#fff;
}

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
     
       
    }
    .rounded_corners table table td
    {
        border-style: none;
    }

    td {
    vertical-align:auto;
    text-align:left;
    font-size:small;
    font-weight:bold;
}

    .gvItemCenter { text-align: left; }
.gvHeaderCenter {  text-align: center; }
    table{
    width:100%;
}
          .auto-style2 {
              width: 4%;
          }
          .auto-style3 {
              width: 623px;
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

    <div>
<Form id="Frm1" name="frm1">


        <table style="width:100%" border="0">
            <tr>
              <td style="width:40%"><asp:Label ID="lblContent" Text="|| MANAGE JOB ||" runat="server" ForeColor="#006600"></asp:Label></td><td></td>  <td><br /><br /></td> 
           <td class="auto-style2"></td><td style="width:20%"></td>
                 </tr>
            <tr>
                <td style="width:40%"></td><td style="width:15%"></td><td style="width:15%"></td><td style="width:15%"></td><td style="width:15%"></td>
            </tr>

            <tr>
                <td style="width:40%">   JOB ID : JOB NAME &nbsp; <asp:TextBox ID="txtJob" placeholder="Find.."  runat="server"   CssClass="form-control" ></asp:TextBox><asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/search.png" Width="20px" Height="20px" OnClick="btnSearch_Click" Visible="True"/></td>
         <td style="width:20%"></td><td style="width:20%"></td>
                <td style="width:15%"></td>
                <td style="width:50%">

                     Report <asp:ImageButton  ID="btnReportAll" runat="server" ImageUrl="~/images/report.png" Width="20px" Height="20px" OnClick="btnReportAll_Click" /></td>
                   </tr>


        </table>




      <table style="width:100%" border="0"><tr><td>
      <%--  <div  style="width:80%" >--%>

     

<%--             <asp:UpdatePanel runat="server" ID="UpdatePanel1" >

                  <ContentTemplate>--%>

              

<%--<asp:TextBox ID="txtDate" runat="server" ReadOnly="true"></asp:TextBox>
<asp:ImageButton ID="imgPopup" ImageUrl="images/calendar.png" ImageAlign="Bottom"
    runat="server" />
<ajaxToolkit:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDate"
    Format="dd/MM/yyyy">
</ajaxToolkit:CalendarExtender> &nbsp To &nbsp <asp:TextBox ID="txtDateEnd" runat="server" ReadOnly="true"></asp:TextBox>
<asp:ImageButton ID="imgPopup2" ImageUrl="images/calendar.png" ImageAlign="Bottom"
    runat="server" />
<ajaxToolkit:CalendarExtender ID="Calendar2" PopupButtonID="imgPopup2" runat="server" TargetControlID="txtDateEnd"
    Format="dd/MM/yyyy">
</ajaxToolkit:CalendarExtender>--%>

                   
                   
                  
<asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="job_id" OnRowDataBound="OnRowDataBound"    HeaderStyle-ForeColor="BLACK" RowStyle-BackColor="#00cc00" AlternatingRowStyle-BackColor="White"
        RowStyle-ForeColor="#3A3A3A"  AllowPaging="True"
         OnPageIndexChanged="grid_PageIndexChanged" OnPageIndexChanging="grid_PageIndexChanging" OnSelectedIndexChanged="grid_SelectedIndexChanged" OnRowCommand="grid_RowCommand" OnRowDeleting="grid_RowDeleting">
 <PagerSettings FirstPageText="First" LastPageText="Last" 
    Mode="NumericFirstLast" PageButtonCount="3" position="Bottom" />
  <PagerStyle CssClass="pagination" HorizontalAlign="Left" 
 VerticalAlign="Middle"/>
<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <img alt = "" style="cursor: pointer" src="images/plus.png" width="20" height="20" />
                <asp:Panel ID="pnlOrders" runat="server" Style="display: none" Width="50px" >
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
        <asp:BoundField ItemStyle-Width="100px" DataField="job_id" HeaderText="รหัสงาน" >



<ItemStyle Width="100px"></ItemStyle>



        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="500px" DataField="job_name" HeaderText="ชื่องาน" >
        <HeaderStyle Wrap="False" />

<ItemStyle Width="500px"></ItemStyle>

        </asp:BoundField>
        <asp:BoundField DataField="job_date" HeaderText="ประจำวันที่" ItemStyle-Width="100" >
<ItemStyle Width="100px"></ItemStyle>
        </asp:BoundField>
        <asp:TemplateField HeaderText="พิมพ์">
                <ItemTemplate>
                       <asp:imagebutton ID="print_barcode" runat="server" CommandName="print_barcode"   CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" ></asp:imagebutton>
                </ItemTemplate>
              <ControlStyle Height="20px" Width="20px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
        <asp:TemplateField HeaderText="เวลาติดต่อ"  ItemStyle-Width="100" >
                <ItemTemplate>
                       <asp:imagebutton ID="timestamp1" runat="server" CommandName="timestamp1"   CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" ></asp:imagebutton>
             <br />
                        <asp:Label ID="lblStamp1" runat="server" Text='<%# Eval("timestamp1") %>'></asp:Label>
                       </ItemTemplate>
               <ControlStyle Height="20px" Width="20px" />
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="gvItemCenter" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ยืนยันเวลาเข้า"  ItemStyle-Width="100" >
                <ItemTemplate>
                       <asp:imagebutton ID="timestamp2" runat="server" CommandName="timestamp2"   CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" ></asp:imagebutton>
            <br />
                        <asp:Label ID="lblStamp2" runat="server" Text='<%# Eval("timestamp2") %>'></asp:Label>
                        </ItemTemplate>
               <ControlStyle Height="20px" Width="20px" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="เวลาเข้า"  ItemStyle-Width="100" >
                <ItemTemplate>
                       <asp:imagebutton ID="timestamp3" runat="server" CommandName="timestamp3"   CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" ></asp:imagebutton>
                <br />
                       <asp:Label ID="lblStamp3" runat="server" Text='<%# Eval("timestamp3") %>'></asp:Label>
                     </ItemTemplate>
               <ControlStyle Height="20px" Width="20px" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="เวลาออก"  ItemStyle-Width="100" >
                <ItemTemplate>
                       <asp:imagebutton ID="timestamp4" runat="server" CommandName="timestamp4"   CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" ></asp:imagebutton>
                 <br />
                     <asp:Label ID="lblStamp4" runat="server" Text='<%# Eval("timestamp4") %>'></asp:Label>
                      </ItemTemplate>
               <ControlStyle Height="20px" Width="20px" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
        </asp:TemplateField>
       
        <asp:TemplateField HeaderText="รายงาน"  ItemStyle-Width="50" >
                  <ItemTemplate>
                       <asp:imagebutton ID="REPORT" runat="server" CommandName="REPORT"   CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" ></asp:imagebutton>
                </ItemTemplate>
               <ControlStyle Height="20px" Width="20px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>
       
        <asp:TemplateField HeaderText="ลบ"  ItemStyle-Width="50" >
                <ItemTemplate>
                       <asp:imagebutton ID="DELETE" runat="server" CommandName="DELETE" OnClientClick="return confirm('Are you sure you want to delete this event?');"  CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" ImageUrl="~/images/DeleteHS.png" ></asp:imagebutton>
                </ItemTemplate>
               <ControlStyle Height="20px" Width="20px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"  />

        </asp:TemplateField>
       
    </Columns>

<HeaderStyle ForeColor="Black"></HeaderStyle>

<RowStyle BackColor="#ffcc99" ForeColor="#3A3A3A"></RowStyle>
</asp:GridView>
                <%--   </ContentTemplate>--%>

      <%--            <Triggers>
              <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />

          </Triggers>--%>

               

<%--</asp:UpdatePanel>--%>

                   

            <%--</div>--%>

      
      
      </td></tr></table>
   

    </Form>

        </div>
</asp:Content>
