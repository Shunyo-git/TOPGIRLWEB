<%@ codepage="950" %>
<!--#include file="gb_top.asp"-->
<!--#include file="chksetting.asp"-->
<%'�]�m�������
	if not isnull(session("posttime")) or cint(posttime)>0 then
		if DateDiff("s",session("posttime"),Now())<cint(posttime) then%>
<script language="javascript">
if (confirm("�d���O�w�]�w������\��A�Ы��T�w�i�J�޲z���߳]�w�Ϊ��I������^����"))
  location.href="gb_setting.asp";
else
  location.href="index.asp";
</script>
<%		end if
	end if
%>
<script language=javascript>
<!--
function newin(width,height,url,name) {
msgWindow=window.open(url,name,'statusbar=no,scrollbars=yes,status=no,resizable=no,width='+width+',height='+height)
}
// -->
</script>
<script src="inc/ubbcode.js"></script>
<script language="JavaScript1.2">
function confirm_reset(){
	if (confirm("�o�˷|�M�����������e�A�A�T�w�n�M����?")){
		return true;
	}
	return false;
}
</script>
<table width="1003" border="0" align="center" cellpadding="0" cellspacing="0">
            
              <tr>
                <td align="center" valign="top" class="gbookbg">
<table width="660" border="0" align="center" cellpadding="0" cellspacing="0" background="/img/share/bg.gif" >
  <tr>
    <td>&nbsp;</td>
  </tr>
  <td ><tr> 
    <td ><td><table width="90%" border="0" align="center" cellpadding="0" cellspacing="0"  >
        <tr>
          <td width="74%">
            <table border="0" width="100%" cellpadding="5" cellspacing="0">
              <tr><form action="gb_post.asp" method="post" name="frmAnnounce" onSubmit=submitonce(this)>
          <td width="26%" >�z���m�W</td>
          <td width="74%" >
            <p>
            <input type="text" name="name" size="20"><font color="#FF0000">*</font></p>
    </td>
              </tr>
              <tr>
          <td width="26%" >�߱��ϥ�</td>
          <td width="74%" >
          <img border="0" src="images/icon/1.gif"><input name="icon" type="radio" value="1" checked>
            <img border="0" src="images/icon/2.gif"><input type="radio" value="2" name="icon"><img border="0" src="images/icon/3.gif"><input type="radio" value="3" name="icon"><img border="0" src="images/icon/4.gif"><input type="radio" value="4" name="icon"><img border="0" src="images/icon/5.gif"><input type="radio" value="5" name="icon"><img border="0" src="images/icon/6.gif"><input type="radio" value="6" name="icon">
<br><img border="0" src="images/icon/7.gif"><input type="radio" value="7" name="icon"><img border="0" src="images/icon/8.gif"><input type="radio" value="8" name="icon"><img border="0" src="images/icon/9.gif"><input type="radio" value="9" name="icon"><img border="0" src="images/icon/10.gif"><input type="radio" value="10" name="icon"><img border="0" src="images/icon/11.gif"><input type="radio" value="11" name="icon"><img border="0" src="images/icon/12.gif"><input type="radio" value="12" name="icon">
<br><img border="0" src="images/icon/13.gif"><input type="radio" value="13" name="icon"><img border="0" src="images/icon/14.gif"><input type="radio" value="14" name="icon"><img border="0" src="images/icon/15.gif"><input type="radio" value="15" name="icon"><img border="0" src="images/icon/16.gif"><input type="radio" value="16" name="icon"><img border="0" src="images/icon/17.gif"><input type="radio" value="17" name="icon"><img border="0" src="images/icon/18.gif"><input type="radio" value="18" name="icon">
              <tr>
          <td width="26%" >�Ӧۦa��</td>
          <td width="74%" >
          <select name="where">
              <option>�п�� </option>
              <option value="�����i�H�ܡH" selected>-�O�d-</option>
              <option value="�򶩥�">�򶩥�</option>
           <option value="�x�_��">�x�_��</option>
           <option value="�x�_��">�x�_��</option>
           <option value="��鿤">��鿤</option>
           <option value="�s�˿�">�s�˿�</option>
           <option value="�s�˥�">�s�˥�</option>
           <option value="�]�߿�">�]�߿�</option>
           <option value="�x����">�x����</option>
           <option value="�׭쥫">(�׭�)</option>
           <option value="�Z���m">(�Z��)</option>
           <option value="�����m">(����)</option>
           <option value="��l�m">(��l)</option>
           <option value="�j���m">(�j��)</option>
           <option value="�s���m">(�s��)</option>
           <option value="�۩��m">(�۩�)</option>
           <option value="�~�H�m">(�~�H)</option>
           <option value="�F����">(�F��)</option>
           <option value="�j����">(�j��)</option>
           <option value="�M����">(�M��)</option>
           <option value="�F����">(�F��)</option>
           <option value="�x����">�x����</option>
           <option value="�n�뿤">�n�뿤</option>
           <option value="���ƿ�">���ƿ�</option>
           <option value="���L��">���L��</option>
           <option value="�Ÿq��">�Ÿq��</option>
           <option value="�Ÿq��">�Ÿq��</option>
           <option value="�x�n��">�x�n��</option>
           <option value="�x�n��">�x�n��</option>
           <option value="������">������</option>
           <option value="������">������</option>
           <option value="�̪F��">�̪F��</option>
           <option value="�x�F��">�x�F��</option>
           <option value="�Ὤ��">�Ὤ��</option>
           <option value="�y����">�y����</option>
           <option value="�s����">�s����</option>
           <option value="������">������</option>
           <option value="���">���</option>
           <option value="����">����</option>
           <option value="����">����</option>
           <option value="�饻">�饻</option>
           <option value="�䥦">�䥦</option>
            </select><font color="#FF0000">*</font></td>
              </tr>
              <tr>
          <td width="26%" >E-Mail</td>
          <td width="74%" >
          <input type="text" name="email" size="20"><font color="#FF0000">*</font></td>
              </tr>
              <tr>
          <td width="26%" >������</td>
          <td width="74%" >
          <input type="radio" value="0" checked name="adminread">���}�d��<input type="radio" value="1" name="adminread">�ȵ����D</td>
              </tr>
              <tr>
          <td width="100%"  colspan="2">�d�����e</td>
              </tr>
              <tr>
          <td width="100%"  colspan="2">
            <p align="center">
            <%if ubbedit=1 then%>
            <!--#include file="inc/getubb.asp"-->       
            <br>
            <%end if%>
<textarea class="FormClass" cols="71" name="Content" rows="6" wrap="VIRTUAL" title="�i�H�ϥ�Ctrl+Enter�����e�X" class=FormClass onkeydown=ctlent()></textarea><font color="#FF0000">*</font></p>      
          </td>
              </tr>
              <tr>
          <td width="100%"  colspan="2">
          <p align="center"><input type=Submit value=" �T �{ " name=Submit>&nbsp;&nbsp;&nbsp;&nbsp;     
          <input type="reset" name="reset" value=" �� �� " onClick="return confirm_reset()"></form></td>
              </tr>
            </table>
    </td>
        </tr>
      </table></td>
  </tr>
 
</table>
</td>
  </tr>
 
</table>
<!--#include file="copyright.asp"-->