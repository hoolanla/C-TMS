<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="stamp2.aspx.cs" Inherits="QRCODE.PROJECT.Stamp2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"  >

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

    table{
    width:100%;
}
</style>
  
   






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





             <asp:UpdatePanel runat="server">

                  <ContentTemplate>

              




                <table style="width:100%" border="0"><tr><td>
        <div class="rounded_corners" style="width:100%" >



<asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" CssClass="Grid"
    DataKeyNames="job_id" OnRowDataBound="OnRowDataBound"    HeaderStyle-ForeColor="BLACK" RowStyle-BackColor="#00cc00" AlternatingRowStyle-BackColor="White"
        RowStyle-ForeColor="#3A3A3A"  AllowPaging="True"
         OnPageIndexChanged="grid_PageIndexChanged" OnPageIndexChanging="grid_PageIndexChanging" OnSelectedIndexChanged="grid_SelectedIndexChanged" OnRowCommand="grid_RowCommand">
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
        <asp:BoundField ItemStyle-Width="150px" DataField="job_id" HeaderText="JOB ID" >

<ItemStyle Width="150px"></ItemStyle>

        </asp:BoundField>
        <asp:BoundField ItemStyle-Width="1000px" DataField="job_name" HeaderText="JOB NAME" >
<ItemStyle Width="600px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="create_by" HeaderText="CREATE BY" />
        <asp:BoundField DataField="create_date" HeaderText="CREATE DATE" />
        <asp:TemplateField HeaderText="PRINT">
                <ItemTemplate>
                       <asp:imagebutton ID="print_barcode" runat="server" CommandName="print_barcode"   CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" ></asp:imagebutton>
                </ItemTemplate>
              <ControlStyle Height="20px" Width="20px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
        <asp:TemplateField HeaderText="START">
                <ItemTemplate>
                       <asp:imagebutton ID="timestamp1" runat="server" CommandName="timestamp1"   CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" ></asp:imagebutton>
                </ItemTemplate>
               <ControlStyle Height="20px" Width="20px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OFFICE APPROVE">
                <ItemTemplate>
                       <asp:imagebutton ID="timestamp2" runat="server" CommandName="timestamp2"   CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" ></asp:imagebutton>
                </ItemTemplate>
               <ControlStyle Height="20px" Width="20px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IN COME">
                <ItemTemplate>
                       <asp:imagebutton ID="timestamp3" runat="server" CommandName="timestamp3"   CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" ></asp:imagebutton>
                </ItemTemplate>
               <ControlStyle Height="20px" Width="20px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="END">
                <ItemTemplate>
                       <asp:imagebutton ID="timestamp4" runat="server" CommandName="timestamp4"   CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" ></asp:imagebutton>
                </ItemTemplate>
               <ControlStyle Height="20px" Width="20px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>
    </Columns>

<HeaderStyle ForeColor="Black"></HeaderStyle>

<RowStyle BackColor="#ffcc99" ForeColor="#3A3A3A"></RowStyle>
</asp:GridView>
                      </ContentTemplate>

                  <Triggers>
              <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />

          </Triggers>

               

</asp:UpdatePanel>

                      <asp:Timer ID="Timer1" runat="server" Interval="10000" OnTick="Timer1_Tick">
                      </asp:Timer>

          
   




</asp:Content>
