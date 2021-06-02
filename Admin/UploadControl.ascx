<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UploadControl.ascx.cs" Inherits="UploadControl" %>

<asp:FileUpload ID="FilUpl" runat="server" Width="50%" /> 
 
<asp:CustomValidator ID="ErrorMsg" runat="server" ErrorMessage="*"  Text="" OnServerValidate="ErrorMsg_ServerValidate" Font-Size="Small"></asp:CustomValidator>
