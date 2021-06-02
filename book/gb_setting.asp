<%@ codepage="950" %>
<!--#include file="chklogin.asp"-->
<!--#include file="gb_top.asp"-->
<%if request("action")="delall" then%>
<script language="javascript">
if (confirm("±z?Tcw-n§R°￡cO|3¯d‥￥°O?y,?DAI?Tcw§R°￡,cIaIAI‥uRoae|^"))
  location.href="gb_setting.asp?action=delall_post";
else
  location.href="gb_setting.asp";
</script>
<%end if
if request("action")="delall_post" then
Dim StrSQL
StrSQL="delete from gb"
conn.Execute StrSQL
response.write "?w﹐g|‥￥\§R°￡￥t3!?o?y"
response.write "<a href=index.asp>-YAsAy?1‥S|3|U°Eae|^!A?DAI?i3o﹐I</a>"
Response.Redirect("index.asp")
end if
%>
<table width="520" border="0" align="center" cellpadding="0" cellspacing="0" >
  <tr>
    <td ><table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
          <td><form method="post" action="gb_setting.asp?action=post1">
              <b>留言版基本設定</b><br>
              <br>
              留言版名稱
              <input name="bookname" type="text" value="<%=bookname%>" size="16">
              <br>
              <br>
              網站名稱
              <input name="sitename" type="text" value="<%=sitename%>" size="16">
              <br>
              <br>
              網站地址
              <input name="url" type="text" value="<%=url%>" size="16">
              <br>
              <br>
              信箱地址
              <input name="email" type="text" value="<%=email%>" size="16">
              <br>
              <br>
              <br>
              <br>
              &nbsp;   
              <input type="submit" name="Submit3" value="確認">
              <input type="reset" name="Submit22" value="取消">  
              <p></p>
            </form></td>
        </tr>
    </table></td>
  </tr>
  <tr> 
    <td ><table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="100"><form method="post" action="gb_setting.asp?action=post2">
              <b>留言版使用設定</b><br>
              <br>
 重複留言的時間

<input name="posttime" type="text" value="<%=posttime%>" size="11">
秒（0為不限制） <br>
              <br>
 分頁顯示的類型

<input name="listpagetype" type="text" value="<%=listpagetype%>" size="11">
（1、2） <br>
              <br>
 是否開放留言板

<input name="opengb" type="text" value="<%=opengb%>" size="11">
（0關閉，1開放） <br>
              <br>
 是否限制留言數

<input name="usemaxdata" type="text" value="<%=usemaxdata%>" size="11">
（0為不限制，1為限制）<br>
              <br>
 最大允許留言數

<input name="maxdata" type="text" value="<%=maxdata%>" size="11">
(若上項為0則不起作用)<br>
              <br>
 最大留言字元數

<input name="maxtext" type="text" value="<%=maxtext%>" size="11">
              <br>
              <br>
 每頁顯示記錄數

<input name="msgperpage" type="text" value="<%=msgperpage%>" size="11">
              <br>
              <br>
 是否顯示編輯器

<input name="ubbedit" type="text" value="<%=ubbedit%>" size="11">
（0關閉，1開放）
              <br>
              <br>
 是否使用限制名稱

<input name="usesplitwords" type="text" value="<%=usesplitwords%>" size="11">
（0關閉，1開放）<br>
              <br>
 是否使用限制文字

<input name="usebadwords" type="text" value="<%=usebadwords%>" size="11">
（0關閉，1開放）<br>
              <br>
 限制的名稱

<textarea name="splitwords" cols="20" rows="2"><%=splitwords1%></textarea>
 (以,分開)<br>  
              <br>
 限制的文字

<textarea name="badwords" cols="20" rows="2"><%=badwords1%></textarea>
              <br>
              <br>
              &nbsp;   
              <input type="submit" name="Submit" value="確認">
              <input type="reset" name="Submit2" value="取消">  
            </form>
			<br>
            <input name="button10" type="button" id="button10" onClick="location.href='gb_setting.asp?action=delall'" value="刪除全部留言">
("注意"將會刪除所有留言！) <br>  
		  </td>
        </tr>
    </table></td>
  </tr>
  <tr> 
    <td bgcolor="#FEF7F5">&nbsp;</td>
  </tr>
</table>
<!--#include file="copyright.asp"-->
<%
action=request("action")
if action="post1" then
sql="update setting set bookname='"&request("bookname")&"',sitename='"&request("sitename")&"',url='"&request("url")&"',email='"&request("email")&"'"
conn.Execute(sql)
response.redirect "gb_setting.asp"
end if

if action="post2" then
gbset=request("posttime")&","&request("listpagetype")&","&request("opengb")&","&request("usesplitwords")&","&request("usebadwords")&","&request("usemaxdata")&","&request("msgperpage")&","&request("ubbedit")

sql="update setting set gbset='"&gbset&"',maxdata="&request("maxdata")&",maxtext="&request("maxtext")&",splitwords='"&request("splitwords")&"',badwords='"&request("badwords")&"'"
conn.Execute(sql)
response.redirect "gb_setting.asp"
end if
%>