<%@ codepage="950" %>
<!--#include file="gb_top.asp"-->
<%order=request("order")
if order="" then
order="id"
end if 

dim rs
dim sql
msg_per_page = msgperpage '定義每頁顯示記錄筆數
set rs = server.createobject("adodb.recordset")
%>
<%sql = "select * from gb order by "&order&" desc"%>
<%rs.cursorlocation = 3 '使用客戶端游標，可以使效率提高

rs.pagesize = msg_per_page '定義分頁記錄集每頁顯示記錄數
rs.open sql,conn,0,1 

if err.number<>0 then '錯誤處理
response.write "數據庫操作失敗：" & err.description
err.clear
else
if not (rs.eof and rs.bof) then '檢測記錄集是否為空
totalrec = RS.RecordCount 'totalrec：總記錄條數
if rs.recordcount mod msg_per_page = 0 then '計算總頁數,recordcount:數據的總記錄數
n = rs.recordcount\msg_per_page 'n:總頁數
else 
n = rs.recordcount\msg_per_page+1 
end if 

currentpage = request("page") 'currentpage:目前頁
If currentpage <> "" then
currentpage = cint(currentpage)
if currentpage < 1 then 
currentpage = 1
end if 
if err.number <> 0 then 
err.clear
currentpage = 1
end if
else
currentpage = 1
End if 
if currentpage*msg_per_page > totalrec and not((currentpage-1)*msg_per_page < totalrec)then 
currentPage=1
end if
rs.absolutepage = currentpage 'absolutepage：設置指針指向某頁開頭
rowcount = rs.pagesize 'pagesize：設置每一頁的數據記錄數

dim i
dim k
%>
<table width="1003" border="0" align="center" cellpadding="0" cellspacing="0">
            
              <tr>
                <td align="center" valign="top" class="gbookbg">
<table width="660" border="0" align="center" cellpadding="0" cellspacing="0"  >
  <tr> 
    <td width="1" background="images/dot2.gif"><img src="images/dot2.gif" width="1" height="3"></td>
    <td><table width="100%" border="0" align="center" cellpadding="0" cellspacing="2" class="white11">
        <%do while not rs.eof and rowcount>0%>
        <tr>
                        <td colspan="2" height="2" background="/img/gbook/line1.gif"></td>
                      </tr>
        <tr> 
          <td colspan="2" valign="top" class="jnfont"><table width="100%" border="0" cellspacing="0" cellpadding="1">
              <tr> 
                <td width="43%" align="left" nowrap class="white11"><img src="/img/gbook/sd.gif" width="19" height="7" /><font size=1><%=String(3-Len(rs("id")),"0") & rs("id")%></font>&nbsp;&nbsp;<span style="color: #FFFFFF"><%=rs("name")%></span></td>
                <td width="57%" align="right"> 
                  <%if session("admin")="" then%>
                  <%else%>
                  <%if session("flag")=1 then%>
                  <a href="gb_re.asp?id=<%=rs("id")%>"><img src="images/res.gif" width="36" height="11" border="0"></a> 
                  <a href="quit.asp"><img src="images/logout.gif" width="40" height="11" border="0"></a> 
                  <%else%>
                  <a href="gb_del.asp?id=<%=rs("id")%>"><img src="images/del.gif" border="0"></a> 
                  <a href="gb_re.asp?id=<%=rs("id")%>"><img src="images/res.gif" border="0"></a> 
                  <a href="quit.asp"><img src="images/logout.gif" width="40" height="11" border="0"></a> 
                  <% 
end if 
end if 
%>
                </td>
              </tr>
            </table></td>
        </tr>
        <tr> 
          <td width="70" align="left" valign="top" class="jnfont"> <img src="images/01.gif" width="70" height="70" border="0"></td>
          <td width="590"> 
            <%if rs("adminread")=false or session("admin")<>"" then%>
            <img border="0" src="images/icon/<%=rs("icon")%>.gif"> 
            <%content=rs("content")%>
            <%=UBBcode(content)%> <br> <br> 
            <%
			else
			response.write "這是我跟TOP girl的悄悄話。"
			end if%>
          </td>
        </tr>
        <tr align="right"> 
          <td colspan="2" valign="top"> 
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr> 
                <td width="90%"><span class="jnfont"> 
                  <a href="mailto:<%=rs("email")%>"><img border="0" src="images/gb_mail.gif" alt="發送E-mail給:<%=rs("name")%>"></a> </span><span class="style1" style="font-size: 10">IP:<%=rs("ip")%></span> </td>
                <td class="gray11" width="10%" align="right" nowrap>[<%=rs("time")%>]</td>
              </tr>
            </table>
            <%if rs("re")<>"" then%>
            <table width="100%" border="0">
              <tr> 
                <td height="12"> <table width="100%" border="0" cellspacing="0" cellpadding="0">
                   <tr>
                        <td  height="3" background="/img/gbook/line1.gif"></td>
                      </tr>
                  </table></td>
              </tr>
              <tr> 
                <td valign="top"> <img src="images/pen.gif" width="16" height="9"> 
                  <%re=rs("re")%>
                  <%response.write UBBCode(re)%>
                </td>
              </tr>
            </table>
            <%else%>
            <%end if%>
          </td>
        </tr>
		  <tr>
                        <td  colspan="2" height="2" background="/img/gbook/line1.gif"></td>
                      </tr>
        <%
rowcount=rowcount-1
rs.movenext   
loop
end if
end if     
rs.close
conn.close
set rs=nothing
set coon=nothing
%>
      </table>
      <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr> 
          <td colspan="2" valign="top"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            
              <tr> 
                <td align="center">
<form><%if listpagetype=0 then%>
                    <%call listPages()%>
                    <%else%>
                    <%call listpages1()%>
                    <%end if%>
                    &nbsp;移至第 
                    <Select  name="go" onChange="window.location=form.go.options[form.go.selectedIndex].value" size="1" class=smallselsect style='BACKGROUND-COLOR:#eeeeee;font-family: Arial; font-size: 8pt;'>
                    <%for i=1 to n      
   response.write "<option value="&filename&"?pl="&pl&"&se="&se&"&page="& i       
   if currentpage=i then       
     response.write " selected"      
   end if      
   response.write ">"& i &"</option>"      
next      
  response.write "</select>頁"   
%>
                  </select>
                  </form>
                </td>
              </tr>
            </table></td>
          <td>　</td>
        </tr>
        <tr> 
          <td colspan="2" valign="top"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
              <tr> 
                <td align="center"><form name="form1" method="post" action="gb_search.asp">
                    </form></td>
              </tr>
            </table></td>
          <td>　</td>
        </tr>
    </table>    </td>
    <td width="1" align="right" background="images/dot2.gif"><img src="images/dot2.gif" width="1" height="3"></td>
  </tr>
</table></td>
  </tr>
</table>
<!--#include file="copyright.asp"-->
