<%@ codepage="950" %>
<!--#include file=inc/gb_conn.asp-->
<!--#include file=inc/MD5.asp-->
<%

 
	dim sql
	dim rs
	dim username
	dim password
	username=replace(trim(request("username")),"'","")
	password=MD5(replace(trim(Request("password")),"'",""))

	set rs=server.createobject("adodb.recordset")
	sql="select * from admin where password='"&password&"' and username='"&username&"'"
'	response.write ""&sql&""
'	response.end
	rs.open sql,conn,1,1
 	if not(rs.bof and rs.eof) then
 		if password=rs("password") then
			session("admin")=rs("username")
			session("flag")=rs("flag")
                        Response.Redirect "index.asp"
 		else
                Response.Redirect "gb_login.asp"
 		end if
	else	
                Response.Redirect "gb_login.asp"
	end if
        rs.close
	conn.close
	set rs=nothing
	set conn=nothing

%>

