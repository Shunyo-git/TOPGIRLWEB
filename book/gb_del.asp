<%@ codepage="950" %>
<!--#include file="chklogin.asp"-->
<!--#include file="inc/gb_conn.asp"-->
<%
id=request("id")
Dim StrSQL
StrSQL="delete from gb where id="& id
conn.Execute StrSQL
response.write "�w�g���\�R���Ӭ���"
response.write "<a href=index.asp>�Y�s�����S���۰ʪ�^�A���I��o��</a>"
Response.Redirect("index.asp")
%>
