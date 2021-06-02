<%
if request("skinid")<>"" then
Response.Cookies("ceocio").Expires=Date+1
response.Cookies("ceocio")("skinid")=request("skinid")
end if
%>
<!--#include file="inc/gb_conn.asp"-->
<!--#include file="inc/const.asp"-->
<!--#include file="inc/ubbcode.asp"-->
<!--#include file="inc/listpages.asp"-->
<!--#include file="inc/formsubmit.asp"-->

<html>
<head>

<meta http-equiv="Content-Type" content="text/html; charset=big5">
<title><%=bookname%></title>
<script src="alt.js"></script>
<!--樣式定義開始-->
<style type="text/css">
td {WORD-BREAK: break-all}
BODY {

	background-color: #050505;
	scrollbar-face-color: #050505;
	scrollbar-highlight-color: #050505;
	scrollbar-shadow-color: #050505;
	scrollbar-3dlight-color: #050505;
	scrollbar-arrow-color: #ffffff;
	scrollbar-track-color: #050505;
	scrollbar-darkshdow-color: #050505;
	scrollbar-base-color: #050505;

		
}
A {COLOR: #FFFFFF; TEXT-DECORATION: none }
A:visited {COLOR: #FFFFFF; TEXT-DECORATION: none}
A:active {COLOR: #ffffff; TEXT-DECORATION: none}
A:hover {
	COLOR: #666666;
	background-color:#FFFFFF;
}
td {FONT-SIZE: 9pt;  FONT-FAMILY: "Arial"; color:#FFFFFF;letter-spacing : 1pt ;line-height :14pt}
textarea{border:0px #FFFFFF ;FONT-SIZE: 8pt; COLOR: #000000; FONT-FAMILY: "Arial"}
input{  border:solid 0 #000000; background-image:url('images/dot.gif'); background-repeat:repeat-x; background-position:bottom; height:18px;FONT-SIZE: 8pt; COLOR: #000000; FONT-FAMILY: "Arial"; }
select{border:0px; height:14px;FONT-SIZE: 8pt; COLOR: #000000; FONT-FAMILY: "Arial"}
.jnfont {FONT-SIZE: 10.5pt; FILTER: dropshadow(color=#000000,offx=1,offy=1); FONT-FAMILY: "Arial"}
.jnfont1 {FONT-SIZE: 9pt; FILTER: dropshadow(color=#000000,offx=1,offy=1)}
.style1 {font-size: 10pt}
.gbookbg{
	background-image: url(/img/share/bg.gif);
}
</style>
<!--樣式定義結束-->
<SCRIPT language=JavaScript1.2>
/*
Gradual-Highlight Image Script- 
?Dynamic Drive (www.dynamicdrive.com)
For full source code, installation instructions,
100's more DHTML scripts, and Terms Of
Use, visit dynamicdrive.com
*/

function high(which2){
theobject=which2
highlighting=setInterval("highlightit(theobject)",35)
}
function low(which2){
clearInterval(highlighting)
which2.filters.alpha.opacity=35
}
function highlightit(cur2){
if (cur2.filters.alpha.opacity<100)
cur2.filters.alpha.opacity+=5
else if (window.highlighting)
clearInterval(highlighting)
}
</SCRIPT>
<script src="Scripts/AC_RunActiveContent.js" type="text/javascript"></script>
 <link href="/css/topgirl.css" rel="stylesheet" type="text/css" />
</head>
<%if bgpic<>"" then%>
<body bgcolor="#FFFFFF" leftmargin="0" topmargin="0"><NOSCRIPT><IFRAME SRC=gb_top.asp></IFRAME></NOSCRIPT>
<%else%>
<body bgcolor="#FFFFFF" leftmargin="0" topmargin="0">
<%end if%><table width="1003" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td width="346"><a href="/"><img src="/img/share/logo.gif" width="346" height="69" border="0" /></a></td>
            <td width="657" align="left" background="/img/share/headright_bg.gif"><script type="text/javascript">
AC_FL_RunContent( 'codebase','http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0','width','634','height','23','src','/menu_index','quality','high','pluginspage','http://www.macromedia.com/go/getflashplayer','wmode','transparent','movie','/menu_index' ); //end AC code
</script><noscript><object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" width="634" height="23">
              <param name="movie" value="/menu_index.swf" />
              <param name="quality" value="high" />
              <param name="wmode" value="transparent" />
              <embed src="/menu_index.swf" width="634" height="23" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" wmode="transparent"></embed>
            </object>
</noscript></td>
  </tr>
          <tr>
            <td colspan="2"><img src="/img/gbook/title.gif" width="1003" height="62" /></td>
  </tr>
          <tr>
            <td colspan="2" class="gbookbg"><table width="660" border="0" align="center" cellpadding="0" cellspacing="0">
              <tr>
                <td width="1" background="images/dot2.gif"><img src="images/dot2.gif" width="1" height="3"></td>
                <td><table width="90%" border="0" align="right" cellpadding="0" cellspacing="0">
                    <tr>
                      <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td width="50%">&nbsp;</td>
                            <td width="50%" align="right"><%if opengb=0 then%>
                                <input name="button1" onClick="location.href='gb_write.asp'" type="button" value="留言板暫時關閉" disabled>
                                <%else%>
                                <img src="images/icon.gif" width="11" height="11" border="0" align="absmiddle"> <a href="gb_write.asp">留言</a>
                                <%end if%>
                                <%if session("admin")<>"" then
					      if session("flag")=2 then%>
                                <input name="button2" onClick="location.href='gb_setting.asp'" type="button" value="使用設定">
                                <%end if%>
                                <input name="button5" onClick="location.href='gb_usermodify.asp'" type="button" value="修改密碼">
                                <input name="button6" onClick="location.href='quit.asp'" type="button" value="登出">
                                <%else%>
                              &nbsp;&nbsp;<img src="images/icon.gif" width="11" height="11" border="0" align="absmiddle"> <a href="gb_login.asp">管理</a>
                              <%end if%>
                            </td>
                          </tr>
                      </table></td>
                    </tr>
                </table></td>
                <td width="1" align="right" background="images/dot2.gif"><img src="images/dot2.gif" width="1" height="3"></td>
              </tr>
            </table></td>
          </tr>
        </table>
