<%@ codepage="950" %>
<!--#include file="chklogin.asp"-->
<!--#include file="inc/gb_conn.asp"-->
<%
id=request("id")
Dim StrSQL
StrSQL="delete from gb where id="& id
conn.Execute StrSQL
response.write "已經成功刪除該紀錄"
response.write "<a href=index.asp>若瀏覽器沒有自動返回，請點選這裡</a>"
Response.Redirect("index.asp")
%>
