<%
'�p���`����
'on error resume next
'�]�m�����}��
if opengb=0 then
response.Redirect "index.asp"
end if%>
<%if usemaxdata=1 then
     dim gbtotal
     sql = "select id from gb"
     set rs = server.CreateObject ("adodb.recordset")
     rs.open sql,conn,1,1
     gbtotal=rs.recordcount
     rs.close
     set rs=nothing
     if cint(gbtotal)>=cint(maxdata) then%>
	 
<script language="javascript">
if (confirm("�d���O�O���w�W�L�]�w���̤j�d���ơA�Ы��T�w�i�J�޲z���߳]�m�Ϊ��I������^�D�ɭ�"))
  location.href="gb_setting.asp";
else
  location.href="index.asp";
</script>
		 
<%end if
end if%>
