<%
dim startime,endtime
startime=timer()
Set conn=Server.CreateObject("ADODB.Connection")
conn.Open "driver={Microsoft Access Driver (*.mdb)};dbq="& Server.MapPath("db/book.mdb")
%>