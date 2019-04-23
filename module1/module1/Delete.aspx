<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="module1.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
     <h2 style="margin-left: 278px;font-family:Helvetica Neue,Helvetica,Arial,sans-serif;line-height: 1.42857143;color: #333;font-weight: 200;">
    delete and notify candidate
</h2>
<div style="float: left;margin-left: 56px; width: 1000px; height: 238px;border: 2px solid #ddd; border-radius: 3px;">
    <div style="width: 1000px;background: #f5f5f5;height: 48px;margin-top: 0px;">
        <img src="~/images/profile.PNG" style="margin-top: 13px; height: 21px; margin-left: 11px; width: 21px;" />
        <h4 style="margin-top: -29px; padding-left: 40px; padding-top: 4px; font-size: 18px;">
            delete and notify
        </h4>
    </div>
     <div class="ex1">
          <asp:GridView ID="GRD_User" runat="server" AutoGenerateColumns="false" Width="100%"
                            OnRowCommand="GRD_Province_RowCommand" DataKeyNames="U_ID" ClientIDMode="Static"
                            CssClass="table table-striped table-bordered table-hover with-check GRD_paging">
                            <AlternatingRowStyle CssClass="grid2" />
                            <Columns>
                                <%--<asp:BoundField HeaderText="UID" DataField="U_ID" ItemStyle-Width="15%" ItemStyle-CssClass="alignLeft"/>--%>
                         
                                <asp:BoundField HeaderText="User Name" DataField="user_Name" ItemStyle-Width="15%" ItemStyle-CssClass="alignLeft"/>
                                
                                <asp:BoundField HeaderText="Last Use" DataField="Last_Used" ItemStyle-Width="15%" ItemStyle-CssClass="alignLeft"/>
                              
                                  <asp:BoundField HeaderText="DataSize" DataField="data_size" ItemStyle-Width="15%" ItemStyle-CssClass="alignLeft"/>

                               <asp:TemplateField HeaderText="Notify" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                       
                                        <asp:ImageButton ID="btnEmail" runat="server" CommandName="Email" ImageUrl="~/image/email.png"
                                            Width="18px" Height="18px" Style="float: left; margin-left: 5px; margin-right: 5px; cursor:pointer;" 
                                            OnClientClick="return confirm('Are you sure to want to send email.');" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Delete" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="remove" runat="server" CommandName="remove" ImageUrl="~/image/delete-icon.png"
                                            Width="18px" Height="18px" Style="float: left; margin-left: 5px; margin-right: 5px; cursor:pointer;" 
                                            OnClientClick="return confirm('Are you sure to want to delete.');" />
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
            <input type="hidden" id="txtDoctorID"/>
            <div style="float: left; margin-left: 30px; margin-top: 16px;">
               
            </div>
            
           

        </div>
  


</div>

    
    
     <div style=" width:100%">
    
                       
                   
    </div>
</asp:Content>

