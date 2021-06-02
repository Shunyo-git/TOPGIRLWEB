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
		  response.write "錯誤。沒有選擇參數！"
		  end if%> <b>回覆留言[你選擇回覆編號為<font color="#FF0000"><%=id%></font>的這筆留言]</b> <br> <form method="POST" action="gb_re.asp?action=post&id=<%=id%>">
              <textarea rows="9" name="re" cols="60"></textarea>
              <br>
              <input type="submit" value="確認" name="B1">
              &nbsp;&nbsp;&nbsp;&nbsp; 
              <input type="reset" value="取消" name="B2">
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
          <td>注意！只能回覆一次，若重覆回應的話；最後的回覆會取代先前的回覆！</td>
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