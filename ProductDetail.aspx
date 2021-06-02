<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" %>

<%@ Register Src="Template/inc_Category_Left.ascx" TagName="inc_Category_Left" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td background="/img/product/frame_head.gif"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="186" height="58" background="/img/product/frame_head.gif"><img src="/img/product/title.gif" width="186" height="58" /></td>
                <td width="380"><img src="/img/product/product_name.gif" width="380" height="58" id="imgCategoryTitle" runat="server" /></td>
                <td valign="bottom"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="342">&nbsp;</td>
                    <td><a href="javascript:window.history.go(-1);" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image7','','img/product/back_1.gif',1)"><img src="/img/product/back.gif" alt="回上頁" name="Image7" width="58" height="22" border="0" id="Image7" /></a></td>
                  </tr>
                </table></td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td background="/img/product/bg_content.gif"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="185" valign="top" class="productlightbg_menu">
                    <uc1:inc_Category_Left ID="Inc_Category_Left1" runat="server" />
                </td>
                <td width="1"><img src="/img/product/midline.gif" width="1" height="429" /></td>
                <td valign="top" class="productlightbg_content"><table width="700" border="0" align="center" cellpadding="0" cellspacing="0">
                  <tr>
                    <td height="35">&nbsp;</td>
                  </tr>
                  <tr>
                    <td><table width="572" height="355" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                          <td align="center" valign="middle" background="/img/product/product_frame.gif"><img src="/img/product/main_product_b.jpg"  id="imgProduct" runat="server" width="558" height="341" /></td>
                        </tr>
                    </table></td>
                  </tr>
                </table></td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td height="10" background="/img/product/frame_de.gif"></td>
          </tr>
        </table>
</asp:Content>

