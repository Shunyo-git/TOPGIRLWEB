<%
sub listPages() 
if n <= 1 then exit sub 
for i=0 to n\msg_per_page-1 
for j=1 to msg_per_page 
%>
<a href="<%=request.ServerVariables("script_name")%>?page=<%=i*msg_per_page+j %>&order=<%=request("order")%>&keytype=<%=request("keytype")%>&keyword=<%=request("keyword")%>">[<% =i*msg_per_page+j %>]</a> 
<% 
next 
next
EndPage = n mod msg_per_page 
for j=1 to EndPage 
%>
<a href="<%=request.ServerVariables("script_name")%>?page=<% =i*msg_per_page+j %>&order=<%=request("order")%>&keytype=<%=request("keytype")%>&keyword=<%=request("keyword")%>">[<% =i*msg_per_page+j %>]</a> 
<%next%>
<%=currentpage%>/<%=n%>頁 目前在:<%=totalrec%>留言</font> 
<%end sub%>


<%
sub listPages1() 
if n <= 1 then exit sub 
%>
<%if currentpage = 1 then%>首頁         
<%else%>
<a href="<%=request.ServerVariables("script_name")%>?page=1&order=<%=request("order")%>&keytype=<%=request("keytype")%>&keyword=<%=request("keyword")%>">首頁</a>         
<a href="<%=request.ServerVariables("script_name")%>?page=<%=currentpage-1%>&order=<%=request("order")%>&keytype=<%=request("keytype")%>&keyword=<%=request("keyword")%>">         
上一頁</a>
<%end if%>         
<%if currentpage = n then%>          
下一頁         
<%else%> 
<a href="<%=request.ServerVariables("script_name")%>?page=<%=currentpage+1%>&order=<%=request("order")%>&keytype=<%=request("keytype")%>&keyword=<%=request("keyword")%>">下一頁</a>         
 <a href="<%=request.ServerVariables("script_name")%>?page=<%=n%>&order=<%=request("order")%>&keytype=<%=request("keytype")%>&keyword=<%=request("keyword")%>">最後頁</a>         
<%end if%>         
  目前在:<%=currentpage%>/<%=n%>頁  每頁<%=msg_per_page%>筆   總共:<%=totalrec%>筆         
<%end sub%>