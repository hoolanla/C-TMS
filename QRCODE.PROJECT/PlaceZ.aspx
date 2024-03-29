﻿<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="False" CodeBehind="PlaceZ.aspx.cs" Inherits="QRCODE.PROJECT.PlaceZ" %>

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

        td {
    vertical-align:middle;
    text-align:left;
    font-size:small;
     font-weight: bold;

    table{
    width:100%;
}
}
          .auto-style4 {
              width: 40%;
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



         <table style="width:100%" border="0">
            <tr>
              <td class="auto-style4"><asp:Label ID="lblContent" Text="|| Station Security ||" runat="server" ForeColor="#006600"></asp:Label></td><td style="width:15%"></td>  <td style="width:15%"><br /><br /></td> 
           <td style="width:15%"></td><td style="width:15%"></td>
                 </tr>
            <tr>
                <td class="auto-style4"></td><td style="width:15%"></td><td style="width:15%"></td><td style="width:15%"></td><td style="width:15%"></td>
            </tr>

            <tr>
                <td class="auto-style4">         <%--  <div class="col-md-4 gap-text">--%>

                       Barcode &nbsp;         <asp:TextBox runat="server" ID="txtBarcode" CssClass="form-control" OnTextChanged="txtBarcode_TextChanged" AutoPostBack="True" MaxLength="10" Width="344px" />
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="RED" runat="server" ControlToValidate="txtBarcode" ErrorMessage="ใส่รหัสบาร์โค้ด"></asp:RequiredFieldValidator>
                               <br />
                     <asp:RegularExpressionValidator ID="Exp" ForeColor="RED" runat ="server" ControlToValidate="txtBarcode"  ErrorMessage="ใส่เลขบาร์โค้ดไม่ถูกต้อง" ValidationExpression="^[\s\S]{10,10}$" Width="38%"></asp:RegularExpressionValidator>

                           <%-- </div> --%>

            </td>
         <td style="width:15%"></td><td style="width:15%"></td>
                <td style="width:15%"></td>
                <td style="width:15%">

</td>
                   </tr>

        </table>



      <asp:UpdatePanel runat="server">
                         <ContentTemplate>


                
     



      <table style="width:100%" border="0"><tr><td>
        <div class="rounded_corners" style="width:100%" >


<asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" CssClass="Grid"
    DataKeyNames="job_id" OnRowDataBound="OnRowDataBound"    HeaderStyle-ForeColor="BLACK" RowStyle-BackColor="#00cc00" AlternatingRowStyle-BackColor="White"
        RowStyle-ForeColor="#3A3A3A"
          OnSelectedIndexChanged="grid_SelectedIndexChanged" OnRowCommand="grid_RowCommand">
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
        <asp:BoundField ItemStyle-Width="150px" DataField="job_id" HeaderText="รหัสงาน" >

<ItemStyle Width="150px"></ItemStyle>

        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="1000px" DataField="job_name" HeaderText="ชื่องาน" >
<ItemStyle Width="600px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="job_date" HeaderText="ประจำวันที่" />
        <asp:BoundField DataField="place_type" HeaderText="ที่รับงาน" />
        <asp:BoundField DataField="create_by" HeaderText="ผู้ประสานงาน" />
        <asp:BoundField DataField="create_date" HeaderText="CREATE DATE" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
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
        </asp:TemplateField>
    </Columns>

<HeaderStyle ForeColor="Black"></HeaderStyle>

<RowStyle BackColor="#ffcc99" ForeColor="#3A3A3A"></RowStyle>
</asp:GridView>



            </div>
            </td></tr></table>

          <asp:Label ID="lblresult" runat="server" Font-Bold="True" ForeColor="#006600"/>
            <asp:Timer ID="Timer1" runat="server" Interval="20000" OnTick="Timer1_Tick1" />
</ContentTemplate>
          </asp:UpdatePanel>
 





         
    

</asp:Content>
