<%
Response.write request.servervariables("remote_addr")
response.write "<BR>"
Response.write Request.ServerVariables("HTTP_X_FORWARDED_FOR") 
%>