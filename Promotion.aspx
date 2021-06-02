<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="Promotion.aspx.cs" Inherits="Promotion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<table width="921" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="73" colspan="2" valign="top"><img src="img//promotion/title.gif" width="311" height="73" /></td>
            <td rowspan="3" valign="top"  style="width: 7px;background-image: url(img/promotion/midline_bg.gif); background-repeat: repeat;"><img src="img/promotion/midline.gif" width="7" height="476" /></td>
            <td height="73" valign="bottom" background="img/promotion/type_bg.gif">
                            <table border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="132">&nbsp;                                        </td>
                                    <td>
                                        <a href="Promotion.aspx?TypeID=1" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('imgType1','','img/promotion/type1_bt_1.gif',1)">
                                            <img src="/img/promotion/type1_bt.gif" alt="促銷活動" name="imgType1" width="90" height="37"
                                                border="0" id="imgType1" runat="server" /></a></td>
                                    <td>
                                        <a href="Promotion.aspx?TypeID=2" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('imgType2','','img/promotion/type2_bt_1.gif',1)">
                                            <img src="/img/promotion/type2_bt.gif" alt="新聞稿" name="imgType2" width="62" height="37"
                                                border="0" id="imgType2" runat="server" /></a></td>
                                    <td>
                                        <a href="Promotion.aspx?TypeID=3" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('imgType3','','img/promotion/type3_bt_1.gif',0)">
                                            <img src="/img/promotion/type3_bt.gif" alt="新櫃登場" name="imgType3" width="79" height="37"
                                                border="0" id="imgType3" runat="server" /></a></td>
                                    <td>
                                        <a href="Promotion.aspx?TypeID=4" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('imgType4','','img/promotion/type4_bt_1.gif',1)">
                                            <img src="/img/promotion/type4_bt.gif" alt="展場活動" name="imgType4" width="78" height="37"
                                                border="0" id="imgType4" runat="server" /></a></td>
                                    <td>
                                        <a href="Promotion.aspx?TypeID=5" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('imgType5','','img/promotion/type5_bt_1.gif',1)">
                                            <img src="/img/promotion/type5_bt.gif" alt="記者會及服裝秀" name="imgType5" width="134"
                                                height="37" border="0" id="imgType5" runat="server" /></a></td>
                                </tr>
                            </table>                        </td>
        </tr>
        <tr>
          <td width="89" rowspan="2" valign="top" style="background-image: url(img/promotion/leftlightbg.gif); background-repeat: no-repeat;">&nbsp;</td>
          <td width="222" height="100%" valign="top" background="img/promotion/leftmenu_bg.gif">
		  <table border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="38">&nbsp;                                              </td>
                                                <td width="169">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td>
                                                                <img src="img/promotion/sub_type1.gif" width="169" height="32" id="imgSubType"
                                                                    runat="server" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                                                                    <tr>
                                                                        <td background="img/promotion/sub_point.gif">
                                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                                                                                <tr>
                                                                                    <td width="10">&nbsp;                                                                                  </td>
                                                                                    <td width="98">
                                                                                        活動</td>
                                                                                    <td width="50">
                                                                                        日期</td>
                                                                                </tr>
                                                                            </table>                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                                GridLines="None" Width="100%" ShowHeader="False">
                                                                                <Columns>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="white12">
                              
                              <tr>
                                <td><table width="100%" border="0" cellpadding="0" cellspacing="０" class="white12">
                                  <tr>
                                    <td width="1">&nbsp;</td>
                                    <td width="107"><a href='PromotionDetail.aspx?EventID=<%# TopGirl.Web.WebUtility.ToBase64String(Convert.ToString(DataBinder.Eval(Container.DataItem,"ID")))%>' target="showDetail">
                                                                                                            <%# TopGirl.Web.StringHelper.SubstringByte(DataBinder.Eval(Container.DataItem, "Title").ToString(), 14)%>
                                                                                                        </a></td>
                                    <td width="50" align="right"><%# TopGirl.Web.StringHelper.FormatDateTimeString(DataBinder.Eval(Container.DataItem,"ReleaseDate").ToString(),"yyyy/MM/dd")%></td>
                                  </tr>
                                </table></td>
                                </tr>
                              <tr>
                                <td height="5"><img src="img/promotion/point_line.gif" width="169" height="5" /></td>
                                </tr>
                            </table>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <PagerSettings Visible="False" />
                                                                                <RowStyle BorderStyle="None" />
                                                                            </asp:GridView>                                                                        </td>
                                                                    </tr>
                                                                </table>                                                            </td>
                                                        </tr>
                                                    </table>                                                </td>
                                            </tr>
            </table>		  </td>
          <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    
                    <tr>
                        <td height="383" valign="top" background="img/promotion/rightcontent_bg.gif">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="15">&nbsp;                                        </td>
                                    <td width="565" valign="top">
                                        <asp:Label ID="lblFrame" runat="server"  ></asp:Label>
                                        </td>
                                </tr>
                            </table>                        </td>
                    </tr>
                    
                </table></td>
        </tr>
        <tr>
          <td valign="bottom" background="img/promotion/leftmenu_bg.gif"><img src="img/promotion/leftde.gif" width="222" height="20" /></td>
          <td valign="top"><img src="img/promotion/rightde.gif" width="603" height="20" /></td>
        </tr>
    </table>
</asp:Content>
