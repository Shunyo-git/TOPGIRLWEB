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
<%=currentpage%>/<%=n%>�� �ثe�b:<%=totalrec%>�d��</font> 
<%end sub%>


<%
sub listPages1() 
if n <= 1 then exit sub 
%>
<%if currentpage = 1 then%>����         
<%else%>
<a href="<%=request.ServerVariables("script_name")%>?page=1&order=<%=request("order")%>&keytype=<%=request("keytype")%>&keyword=<%=request("keyword")%>">����</a>         
<a href="<%=request.ServerVariables("script_name")%>?page=<%=currentpage-1%>&order=<%=request("order")%>&keytype=<%=request("keytype")%>&keyword=<%=request("keyword")%>">         
�W�@��</a>
<%end if%>         
<%if currentpage = n then%>          
�U�@��         
<%else%> 
<a href="<%=request.ServerVariables("script_name")%>?page=<%=currentpage+1%>&order=<%=request("order")%>&keytype=<%=request("keytype")%>&keyword=<%=request("keyword")%>">�U�@��</a>         
 <a href="<%=request.ServerVariables("script_name")%>?page=<%=n%>&order=<%=request("order")%>&keytype=<%=request("keytype")%>&keyword=<%=request("keyword")%>">�̫᭶</a>         
<%end if%>         
  �ثe�b:<%=currentpage%>/<%=n%>��  �C��<%=msg_per_page%>��   �`�@:<%=totalrec%>��         
<%end sub%>