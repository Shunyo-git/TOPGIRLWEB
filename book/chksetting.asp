<%
'計算總筆數
'on error resume next
'設置關閉開放
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
if (confirm("留言板記錄已超過設定的最大留言數，請按確定進入管理中心設置或者點取消返回主界面"))
  location.href="gb_setting.asp";
else
  location.href="index.asp";
</script>
		 
<%end if
end if%>
