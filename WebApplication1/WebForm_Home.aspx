<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm_Home.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
        <asp:objectdatasource runat="server" ID="DataSource" SelectMethod="SearchSppliers" TypeName="ClassLibrary1.SupplierDB">
            <SelectParameters>
                <asp:Parameter Name="search" Type="String" />
            </SelectParameters>
        </asp:objectdatasource>
        <asp:ListView ID="ListView1" runat="server" DataSourceID="DataSource" GroupItemCount="3">
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>Aucune donnée n&#39;a été retournée.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <EmptyItemTemplate>
                <td runat="server" />
            </EmptyItemTemplate>
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td runat="server" style="background-color: #FFFBD6; padding: 10px">
                    <asp:Label ID="CompanyNameLabel" runat="server" Text='<%# Eval("CompanyName") %>' />
                    <br />
                    <asp:Label ID="ContactNameLabel" runat="server" Text='<%# Eval("ContactName") %>' />
                    <br />
                    <asp:Label ID="ContactTitleLabel" runat="server" Text='<%# Eval("ContactTitle") %>' />
                    <br />
                    <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>' />
                    <br />
                    <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />
                    <br />
                    <asp:Label ID="PostalCodeLabel" runat="server" Text='<%# Eval("PostalCode") %>' />
                    <br />
                    <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                    <br />
                    <asp:Label ID="PhoneLabel" runat="server" Text='<%# Eval("Phone") %>' />
                    <br /></td>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="groupPlaceholderContainer" runat="server" border="0" style="border-spacing: 20px">
                                <tr id="groupPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="">
                            <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>

