<%
if session("admin")="" then
   response.redirect "gb_login.asp"
elseif session("flag")<>2 then
      response.redirect "gb_login.asp"
end if
%>

