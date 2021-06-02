<%@ codepage="950" %>
<!--#include file="gb_top.asp"-->
<!--#include file="chksetting.asp"-->
<%'設置灌水限制
	if not isnull(session("posttime")) or cint(posttime)>0 then
		if DateDiff("s",session("posttime"),Now())<cint(posttime) then%>
<script language="javascript">
if (confirm("留言板已設定防灌水功能，請按確定進入管理中心設定或者點取消返回首頁"))
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
	if (confirm("這樣會清除全部的內容，你確定要清除嗎?")){
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
          <td width="26%" >您的姓名</td>
          <td width="74%" >
            <p>
            <input type="text" name="name" size="20"><font color="#FF0000">*</font></p>
    </td>
              </tr>
              <tr>
          <td width="26%" >心情圖示</td>
          <td width="74%" >
          <img border="0" src="images/icon/1.gif"><input name="icon" type="radio" value="1" checked>
            <img border="0" src="images/icon/2.gif"><input type="radio" value="2" name="icon"><img border="0" src="images/icon/3.gif"><input type="radio" value="3" name="icon"><img border="0" src="images/icon/4.gif"><input type="radio" value="4" name="icon"><img border="0" src="images/icon/5.gif"><input type="radio" value="5" name="icon"><img border="0" src="images/icon/6.gif"><input type="radio" value="6" name="icon">
<br><img border="0" src="images/icon/7.gif"><input type="radio" value="7" name="icon"><img border="0" src="images/icon/8.gif"><input type="radio" value="8" name="icon"><img border="0" src="images/icon/9.gif"><input type="radio" value="9" name="icon"><img border="0" src="images/icon/10.gif"><input type="radio" value="10" name="icon"><img border="0" src="images/icon/11.gif"><input type="radio" value="11" name="icon"><img border="0" src="images/icon/12.gif"><input type="radio" value="12" name="icon">
<br><img border="0" src="images/icon/13.gif"><input type="radio" value="13" name="icon"><img border="0" src="images/icon/14.gif"><input type="radio" value="14" name="icon"><img border="0" src="images/icon/15.gif"><input type="radio" value="15" name="icon"><img border="0" src="images/icon/16.gif"><input type="radio" value="16" name="icon"><img border="0" src="images/icon/17.gif"><input type="radio" value="17" name="icon"><img border="0" src="images/icon/18.gif"><input type="radio" value="18" name="icon">
              <tr>
          <td width="26%" >來自地區</td>
          <td width="74%" >
          <select name="where">
              <option>請選擇 </option>
              <option value="不說可以嗎？" selected>-保留-</option>
              <option value="基隆市">基隆市</option>
           <option value="台北市">台北市</option>
           <option value="台北縣">台北縣</option>
           <option value="桃園縣">桃園縣</option>
           <option value="新竹縣">新竹縣</option>
           <option value="新竹市">新竹市</option>
           <option value="苗栗縣">苗栗縣</option>
           <option value="台中縣">台中縣</option>
           <option value="豐原市">(豐原)</option>
           <option value="后里鄉">(后里)</option>
           <option value="神岡鄉">(神岡)</option>
           <option value="潭子鄉">(潭子)</option>
           <option value="大雅鄉">(大雅)</option>
           <option value="新社鄉">(新社)</option>
           <option value="石岡鄉">(石岡)</option>
           <option value="外埔鄉">(外埔)</option>
           <option value="東勢鎮">(東勢)</option>
           <option value="大甲鎮">(大甲)</option>
           <option value="清水鎮">(清水)</option>
           <option value="沙鹿鎮">(沙鹿)</option>
           <option value="台中市">台中市</option>
           <option value="南投縣">南投縣</option>
           <option value="彰化縣">彰化縣</option>
           <option value="雲林縣">雲林縣</option>
           <option value="嘉義市">嘉義市</option>
           <option value="嘉義縣">嘉義縣</option>
           <option value="台南縣">台南縣</option>
           <option value="台南市">台南市</option>
           <option value="高雄縣">高雄縣</option>
           <option value="高雄市">高雄市</option>
           <option value="屏東縣">屏東縣</option>
           <option value="台東縣">台東縣</option>
           <option value="花蓮縣">花蓮縣</option>
           <option value="宜蘭縣">宜蘭縣</option>
           <option value="連江縣">連江縣</option>
           <option value="金門縣">金門縣</option>
           <option value="澎湖縣">澎湖縣</option>
           <option value="中國">中國</option>
           <option value="美國">美國</option>
           <option value="日本">日本</option>
           <option value="其它">其它</option>
            </select><font color="#FF0000">*</font></td>
              </tr>
              <tr>
          <td width="26%" >E-Mail</td>
          <td width="74%" >
          <input type="text" name="email" size="20"><font color="#FF0000">*</font></td>
              </tr>
              <tr>
          <td width="26%" >悄悄話</td>
          <td width="74%" >
          <input type="radio" value="0" checked name="adminread">公開留言<input type="radio" value="1" name="adminread">僅給版主</td>
              </tr>
              <tr>
          <td width="100%"  colspan="2">留言內容</td>
              </tr>
              <tr>
          <td width="100%"  colspan="2">
            <p align="center">
            <%if ubbedit=1 then%>
            <!--#include file="inc/getubb.asp"-->       
            <br>
            <%end if%>
<textarea class="FormClass" cols="71" name="Content" rows="6" wrap="VIRTUAL" title="可以使用Ctrl+Enter直接送出" class=FormClass onkeydown=ctlent()></textarea><font color="#FF0000">*</font></p>      
          </td>
              </tr>
              <tr>
          <td width="100%"  colspan="2">
          <p align="center"><input type=Submit value=" 確 認 " name=Submit>&nbsp;&nbsp;&nbsp;&nbsp;     
          <input type="reset" name="reset" value=" 取 消 " onClick="return confirm_reset()"></form></td>
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