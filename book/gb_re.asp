<%@ codepage="950" %>
<%if session("admin")="" then
response.redirect "index.asp"
end if%>
<!--#include file="gb_top.asp"-->
<%if request("action")="post" then
id=request("id")
Set rs=Server.CreateObject("ADODB.Recordset")
sql="select id,re from gb where id="& id
rs.open sql,conn,3,3
rs("re")=Server.Htmlencode(Request("re"))
rs.update
rs.close
set rs=nothing
Response.Redirect"index.asp"
end if
%><table width="1003" border="0" align="center" cellpadding="0" cellspacing="0">
	<tr>
	<td align="center" valign="top" class="gbookbg">


<table width="660" border="0" align="center" cellpadding="0" cellspacing="0" >
  <tr> 
    <td ><table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="100"> <%
		  id=request("id")
		  if id="" then
		  response.write "���~�C�S����ܰѼơI"
		  end if%> <b>�^�Яd��[�A��ܦ^�нs����<font color="#FF0000"><%=id%></font>���o���d��]</b> <br> <form method="POST" action="gb_re.asp?action=post&id=<%=id%>">
              <textarea rows="9" name="re" cols="60"></textarea>
              <br>
              <input type="submit" value="�T�{" name="B1">
              &nbsp;&nbsp;&nbsp;&nbsp; 
              <input type="reset" value="����" name="B2">
            </form></td>
        </tr>
    </table></td>
  </tr>
  <tr> 
    <td >&nbsp;</td>
  </tr>
  <tr> 
    <td ><table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
          <td>�`�N�I�u��^�Ф@���A�Y���Ц^�����ܡF�̫᪺�^�з|���N���e���^�СI</td>
        </tr>
        <tr>
          <td>&nbsp;</td>
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