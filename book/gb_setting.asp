<%@ codepage="950" %>
<!--#include file="chklogin.asp"-->
<!--#include file="gb_top.asp"-->
<%if request("action")="delall" then%>
<script language="javascript">
if (confirm("��z?Tcw-n��R�X�GcO|3��d�L�D�XO?y,?DAI?Tcw��R�X�G,cIaIAI�LuRoae|^"))
  location.href="gb_setting.asp?action=delall_post";
else
  location.href="gb_setting.asp";
</script>
<%end if
if request("action")="delall_post" then
Dim StrSQL
StrSQL="delete from gb"
conn.Execute StrSQL
response.write "?w�Mg|�L�D\��R�X�G�Dt3!?o?y"
response.write "<a href=index.asp>-YAsAy?1�LS|3|U�XEae|^!A?DAI?i3o�MI</a>"
Response.Redirect("index.asp")
end if
%>
<table width="520" border="0" align="center" cellpadding="0" cellspacing="0" >
  <tr>
    <td ><table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
          <td><form method="post" action="gb_setting.asp?action=post1">
              <b>�d�����򥻳]�w</b><br>
              <br>
              �d�����W��
              <input name="bookname" type="text" value="<%=bookname%>" size="16">
              <br>
              <br>
              �����W��
              <input name="sitename" type="text" value="<%=sitename%>" size="16">
              <br>
              <br>
              �����a�}
              <input name="url" type="text" value="<%=url%>" size="16">
              <br>
              <br>
              �H�c�a�}
              <input name="email" type="text" value="<%=email%>" size="16">
              <br>
              <br>
              <br>
              <br>
              &nbsp;   
              <input type="submit" name="Submit3" value="�T�{">
              <input type="reset" name="Submit22" value="����">  
              <p></p>
            </form></td>
        </tr>
    </table></td>
  </tr>
  <tr> 
    <td ><table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="100"><form method="post" action="gb_setting.asp?action=post2">
              <b>�d�����ϥγ]�w</b><br>
              <br>
 ���Ưd�����ɶ�

<input name="posttime" type="text" value="<%=posttime%>" size="11">
��]0��������^ <br>
              <br>
 ������ܪ�����

<input name="listpagetype" type="text" value="<%=listpagetype%>" size="11">
�]1�B2�^ <br>
              <br>
 �O�_�}��d���O

<input name="opengb" type="text" value="<%=opengb%>" size="11">
�]0�����A1�}��^ <br>
              <br>
 �O�_����d����

<input name="usemaxdata" type="text" value="<%=usemaxdata%>" size="11">
�]0��������A1������^<br>
              <br>
 �̤j���\�d����

<input name="maxdata" type="text" value="<%=maxdata%>" size="11">
(�Y�W����0�h���_�@��)<br>
              <br>
 �̤j�d���r����

<input name="maxtext" type="text" value="<%=maxtext%>" size="11">
              <br>
              <br>
 �C����ܰO����

<input name="msgperpage" type="text" value="<%=msgperpage%>" size="11">
              <br>
              <br>
 �O�_��ܽs�边

<input name="ubbedit" type="text" value="<%=ubbedit%>" size="11">
�]0�����A1�}��^
              <br>
              <br>
 �O�_�ϥέ���W��

<input name="usesplitwords" type="text" value="<%=usesplitwords%>" size="11">
�]0�����A1�}��^<br>
              <br>
 �O�_�ϥέ����r

<input name="usebadwords" type="text" value="<%=usebadwords%>" size="11">
�]0�����A1�}��^<br>
              <br>
 ����W��

<textarea name="splitwords" cols="20" rows="2"><%=splitwords1%></textarea>
 (�H,���})<br>  
              <br>
 �����r

<textarea name="badwords" cols="20" rows="2"><%=badwords1%></textarea>
              <br>
              <br>
              &nbsp;   
              <input type="submit" name="Submit" value="�T�{">
              <input type="reset" name="Submit2" value="����">  
            </form>
			<br>
            <input name="button10" type="button" id="button10" onClick="location.href='gb_setting.asp?action=delall'" value="�R�������d��">
("�`�N"�N�|�R���Ҧ��d���I) <br>  
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