<%
'留言板基本變量設置
'WGB Ver3.0
dim gbset,posttime,splitwords1,badwords1,sitename,url,email,maxdata,skinid,version,opengb
dim baseurl,basesite,usesplitwords,usebadwords,usemaxdata,listpagetype,msgperpage,bookname
dim content,re,ubbedit,maxtext
sub getconst()
	sql = "select * from setting"
	set rs = server.CreateObject ("adodb.recordset")
	rs.open sql,conn,1,1
	if rs.eof and rs.bof then
	response.write "請指定正確的參數。"
	response.end
	else
	gbset=split(rs(0),",")
        posttime=gbset(0)
        listpagetype=gbset(1)
        opengb=gbset(2)
        usesplitwords=gbset(3)
        usebadwords=gbset(4)
        usemaxdata=gbset(5)
        msgperpage=gbset(6)
        '是否顯示編輯工具
        ubbedit=gbset(7)

    '限制留言使用姓名
    splitwords1=rs("splitwords")
    '過濾文字
    badwords1=rs("badwords")
    bookname=rs("bookname")
    sitename=rs("sitename")
    url=rs("url")
    email=rs("email")
    maxdata=rs("maxdata")
    maxtext=rs("maxtext")
    skinid=rs("skinid")
    version=rs("version")
    baseurl=rs("baseurl")
    basesite=rs("basesite")
    end if
	rs.close
	set rs=nothing
end sub
call getconst()
%>
<%
dim bg,lybg,writebg1,writebg2,bgpic
dim formcolor,formbg,formborder,formtext
dim jnfontcolor,namecolor,nameshadow,gbtextcolor,gbtextshadow
dim textcolor,maincolor,linkcolor,hovercolor
dim bar,barface,barhighlight,barshadow,bar3d,bararrow,bartrack,bardarkshadow
dim replycolor,recolor,copyrightbg
sub getskin()

     if request.cookies("ceocio")("skinid")<>"" then
        skinid=request.cookies("ceocio")("skinid")
     end if

	sql = "select * from skin where skinid="&skinid
	set rs = server.CreateObject ("adodb.recordset")
	rs.open sql,conn,1,1
	if rs.eof and rs.bof then
	response.write "請指定正確的參數。"
	response.end
	else

bg=rs("bg")
lybg=rs("lybg")
writebg1=rs("writebg1")
writebg2=rs("writebg2")

bgpic=rs("bgpic")
copyrightbg=rs("copyrightbg")
replycolor=rs("replycolor")
recolor=rs("recolor")

formcolor=split(rs("formcolor"),",")
formbg=formcolor(0)
formborder=formcolor(1)
formtext=formcolor(2)

jnfontcolor=split(rs("jnfontcolor"),",")
namecolor=jnfontcolor(0)
nameshadow=jnfontcolor(1)
gbtextcolor=jnfontcolor(2)
gbtextshadow=jnfontcolor(3)

textcolor=split(rs("textcolor"),",")
maincolor=textcolor(0)
linkcolor=textcolor(1)
hovercolor=textcolor(2)

bar=split(rs("bar"),",")
barface=bar(0)
barhignlight=bar(1)
barshadow=bar(2)
bar3d=bar(3)
bararrow=bar(4)
bartrack=bar(5)
bardarkshadow=bar(6)


end if
rs.close
set rs=nothing
end sub
call getskin()
%>
<%
'don't modify the code
if request("copyright")="liuwei" then
response.redirect "http://www.ceocio.net"
end if%>

