<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to TOP GIRL</title>
    <link href="/css/topgirl.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/script/topgirl.js"></script>

    <style type="text/css">
<!--
#Layer3 {
	position:absolute;
	width:551px;
	height:23px;
	z-index:1;
}
-->
</style>

    <script type="text/javascript" language="JavaScript1.1"> 
<!-- 

var maxLoops = 3;  //圖片總數

var img1 = new Image(); 
img1.src = "/images/index/1.jpg"; 

var img2 = new Image(); 
img2.src = "/images/index/2.jpg";

var img3 = new Image(); 
img3.src = "/images/index/3.jpg";
 
  

var bInterval = 15;  //圖片完全開啟之後，停留的時間，2=2秒
var count = 1; 
function init() { 
    document.getElementById("MainImage").filters.blendTrans.apply(); 
    document.getElementById("MainImage").background = eval("img"+count+".src");
    document.getElementById("MainImage").filters.blendTrans.play(); 
    if (count < maxLoops) { 
        count++; 
    } 
    else { 
        count = 1; 
    } 
    setTimeout("init()", bInterval*500+2000); 
} 
//--> 
    </script>

</head>
<body onload="MM_preloadImages('/img/index/more_1.gif');init();">
    <form id="form1" runat="server">
        <div>
            <table width="1003" height="596" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top" background="/img/share/bg.gif">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="346" valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <a href="/">
                                                    <img src="/img/share/logo.gif" width="346" height="69" border="0" /></a></td>
                                        </tr>
                                        <tr>
                                            <td height="504" valign="top" class="indexleftbg">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="30">
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td width="130">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td bgcolor="#454545">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <img src="/img/index/sub_event.gif" width="101" height="14" /></td>
                                                                                <td>
                                                                                    <a href="Promotion.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('more','','/img/index/more_1.gif',1)">
                                                                                        <img src="/img/index/more.gif" name="more" width="42" height="14" border="0" id="more" /></a></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DataList ID="DataListArea1" runat="server" ShowFooter="False" ShowHeader="False"
                                                                            Width="100%">
                                                                            <ItemTemplate>
                                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="gray11">
                                                                                    <tr>
                                                                                        <td height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="11" valign="top">
                                                                                            ‧</td>
                                                                                        <td>
                                                                                            <a href='Promotion.aspx?EventID=<%# TopGirl.Web.WebUtility.ToBase64String(Convert.ToString(DataBinder.Eval(Container.DataItem,"ID")))%>'>
                                                                                                <%# TopGirl.Web.WebUtility.SubstringText(DataBinder.Eval(Container.DataItem,"Title").ToString(),13)%>
                                                                                            </a>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:DataList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td bgcolor="#454545">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <img src="/img/index/sub_product.gif" width="101" height="14" /></td>
                                                                                <td>
                                                                                    <a href="ProductList.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('more1','','/img/index/more_1.gif',1)">
                                                                                        <img src="/img/index/more.gif" name="more1" width="42" height="14" border="0" id="more1" /></a></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="8">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="gray11">
                                                                        <asp:DataList ID="DataListCategory" runat="server" ShowFooter="False" ShowHeader="False"
                                                                            Width="100%">
                                                                            <ItemTemplate>
                                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="gray11">
                                                                                    <tr>
                                                                                        <td width="11" valign="top">
                                                                                            ‧</td>
                                                                                        <td>
                                                                                            <a href='/ProductList.aspx?CategoryID=<%# TopGirl.Web.WebUtility.ToBase64String(Convert.ToString(DataBinder.Eval(Container.DataItem,"ID")))%>'>
                                                                                                <%# DataBinder.Eval(Container.DataItem,"Name")%>
                                                                                            </a>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:DataList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td bgcolor="#454545">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <img src="/img/index/sub_news.gif" width="101" height="14" /></td>
                                                                                <td>
                                                                                    <a href="Promotion.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('more2','','/img/index/more_1.gif',1)">
                                                                                        <img src="/img/index/more.gif" name="more2" width="42" height="14" border="0" id="more2" /></a></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DataList ID="DataListArea2" runat="server" ShowFooter="False" ShowHeader="False"
                                                                            Width="100%">
                                                                            <ItemTemplate>
                                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="gray11">
                                                                                    <tr>
                                                                                        <td height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="11" valign="top">
                                                                                            ‧</td>
                                                                                        <td>
                                                                                            <a href='Promotion.aspx?EventID=<%# TopGirl.Web.WebUtility.ToBase64String(Convert.ToString(DataBinder.Eval(Container.DataItem,"ID")))%>'>
                                                                                                <%# TopGirl.Web.WebUtility.SubstringText(DataBinder.Eval(Container.DataItem,"Title").ToString(),13)%>
                                                                                            </a>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:DataList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td bgcolor="#454545">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <img src="/img/index/sub_hire.gif" width="101" height="14" /></td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="8" class="gray11">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="gray11">
                                                                            <tr>
                                                                                <td width="11" valign="top">
                                                                                    ‧</td>
                                                                                <td>
                                                                                    <a href="Job.aspx">門市專員</a></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="gray11">
                                                                            <tr>
                                                                                <td width="11" valign="top">
                                                                                    ‧</td>
                                                                                <td>
                                                                                    <a href="Job.aspx">工讀生</a></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="gray11">
                                                                            <tr>
                                                                                <td width="11" valign="top">
                                                                                </td>
                                                                                <td>
                                                                                    <a href="Job.aspx"></a>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img src="/img/share/by.gif" width="165" height="23" /></td>
                                        </tr>
                                    </table>
                                </td>
                                <td valign="top" background="/images/index/1.jpg" id="MainImage" style="filter: blendTrans(duration=2)">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="83" height="14">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div id="Layer3">

                                                    <script type="text/javascript">
AC_FL_RunContent( 'codebase','http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0','width','634','height','23','src','menu_index','quality','high','pluginspage','http://www.macromedia.com/go/getflashplayer','wmode','transparent','movie','menu_index' ); //end AC code
                                                    </script>

                                                    <noscript>
                                                        <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                                            width="634" height="23">
                                                            <param name="movie" value="menu_index.swf" />
                                                            <param name="quality" value="high" />
                                                            <param name="wmode" value="transparent" />
                                                            <embed src="menu_index.swf" width="634" height="23" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                                                                type="application/x-shockwave-flash" wmode="transparent"></embed>
                                                        </object>
                                                    </noscript>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="199" valign="bottom">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="30">
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:DataList ID="MiniSiteList" runat="server" BorderWidth="0px" CellPadding="0"
                                                    RepeatColumns="1" RepeatLayout="Flow" ShowFooter="False" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <table border="0" cellspacing="0" cellpadding="1">
                                                            <tr>
                                                                <td onmouseover="this.style.backgroundColor='#aaaaaa';" onmouseout="this.style.backgroundColor='';">
                                                                    <a href='<%# Eval("URL")%>'>
                                                                        <img src='/images/miniSite/minisite_<%# Eval("ID")%>.gif' width="88" height="55"
                                                                            border="0" /></a></td>
                                                            </tr>
                                                        </table>
                                                    
                                                    </ItemTemplate>
                                                </asp:DataList>
                                                    <br />&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
