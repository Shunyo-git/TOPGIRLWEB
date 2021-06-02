<%@ codepage="950" %>
<!--#include file="gb_top.asp"-->
<!--#include file="chksetting.asp"-->
<!--#include file="inc/chkinput.asp"-->
<%
dim errmsg,errflag
errmsg="錯誤訊息：<p>"
'設定灌水限制
if cint(posttime)<>0 then
	if not isnull(session("posttime")) or cint(posttime)>0 then
		if DateDiff("s",session("posttime"),Now())<cint(posttime) then
		errmsg=errmsg&"<li>留言板防灌水功能已經打開，版主限制"&posttime&"秒內不能重複留言。</li>"
		errflag=true
		end if
	end if
end if

if request("name")="" or request("email")="" or request("content")="" or request("icon")=""  or request("where")="" then
errmsg=errmsg&"<li>沒有填寫完整：姓名、信箱、內容等是必須的。</li>"
errflag=true
end if

'使用隱藏暱稱
if usesplitwords=1 then
check_name=request("name")
splitwords1=split(splitwords1,",")
	for i = 0 to ubound(splitwords1)
		if instr(check_name,splitwords1(i))>0 then
           errmsg=errmsg&"<li>您使用了管理員限制的名稱，請更換你的使用者名稱。</li>"
           errflag=true
			exit for
		end if
	next
end if
'使用限制文字
check_content=request("content")
if usebadwords=1 then
badwords1=split(badwords1,",")
	for i = 0 to ubound(badwords1)
		if instr(check_content,badwords1(i))>0 then
           check_content=replace(check_content,badwords1(i),"***")
		end if
	next
end if




if IsValidEmail(trim(request("email")))=false then
       errmsg=errmsg&"<li>信箱格式填寫錯誤：請確認你的信箱地址。</li>" 
	   errflag=true
end if

if len(request("content"))>maxtext then
		errmsg=errmsg&"<li>內容填寫錯誤：字數不能超過"&maxtext&"。</li>"
		errflag=true
end if
%>
<table width="1003" border="0" align="center" cellpadding="0" cellspacing="0">
	<tr>
	<td align="center" valign="top" class="gbookbg">
<table width="660" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr> 
    <td width="1" background="images/dot2.gif"><img src="images/dot2.gif" width="1" height="3"></td>
    <td><table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="100"><%=errmsg%></td>
        </tr>
      </table></td>
    <td width="1" align="right" background="images/dot2.gif"><img src="images/dot2.gif" width="1" height="3"></td>
  </tr>
</table>
	</td>
	</tr>
</table>
<!--#include file="copyright.asp"-->
<%
if errflag<>true then
Set rs=Server.CreateObject("ADODB.Recordset")
sql="SELECT * FROM gb"
rs.Open sql,conn,1,3
rs.Addnew
rs("name")=Server.Htmlencode(Request("name"))
rs("email")=Server.Htmlencode(Request("email"))
rs("adminread")=Server.Htmlencode(Request("adminread"))
rs("content")=Server.Htmlencode(check_content)
rs("icon")=Server.Htmlencode(Request("icon"))
rs("where")=Server.Htmlencode(Request("where"))
rs("ip")=request.servervariables("remote_addr")
rs("time")=now()
rs.Update
rs.Close
Set rs=Nothing
      if cint(posttime)<>0 then
         session("posttime")=now()
	  end if
Response.Redirect"index.asp?提示=增加新留言成功"
end if
%>
