<%@ codepage="950" %>
<%if session("admin")="" then
response.redirect "gb_login.asp"
end if%>
<!--#include file="gb_top.asp"-->
<!--#include file="inc/MD5.asp"-->
<%
dim username
username=session("admin")
if request("action")="post" then
     Set rs=Server.CreateObject("ADODB.Recordset")
	 sql="select password from admin where username='"&username&"'"
	 rs.open sql,conn,3,3
	 if request("password")=rs("password") then
	     '不修改
	 else
	     rs("password")=MD5(Server.Htmlencode(Request("password")))
	 end if
	 rs.update
	 rs.close
	 set rs=nothing
	 Response.Redirect"index.asp"
end if
sql="select username,password from admin where username='"&username&"'"
set rs=conn.execute(sql)
if rs.eof or rs.bof then
response.redirect "index.asp"
end if
username1=rs("username")
password=rs("password")
rs.close
set rs=nothing
%>
<table width="1003" border="0" align="center" cellpadding="0" cellspacing="0">
	<tr>
	<td align="center" valign="top" class="gbookbg">


<table width="660" border="0" align="center" cellpadding="0" cellspacing="0"  >
  <tr> 
    <td ><table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
          <td height="100"><form method="post" action="?action=post">
    <p align="center"><b>修改個人資料</b></p>
              <p align="center">用戶名稱 
                <input name="Username" type="text" disabled value="<%=username1%>" size="11">
                <br>
                <br>
                用戶密碼 
                <input name="Password" type="password" value="<%=password%>" size="11">
                <br>
                <br>
                &nbsp;
                <input type="submit" name="Submit" value="確認">
                <input type="reset" name="Submit2" value="取消">
              </p>
            </form>
</td>
        </tr>
    </table></td>
  </tr>
  <tr> 
    <td >&nbsp;</td>
  </tr>
</table>
	</td>
	</tr>
</table>
<!--#include file="copyright.asp"-->