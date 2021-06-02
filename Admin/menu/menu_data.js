fixMozillaZIndex=true; //Fixes Z-Index problem  with Mozilla browsers but causes odd scrolling problem, toggle to see if it helps
_menuCloseDelay=100;
_menuOpenDelay=100;
_subOffsetTop=2;
_subOffsetLeft=-2;




with(menuStyle=new mm_style()){
bordercolor="#669933";
borderstyle="solid";
borderwidth=1;
fontfamily="Verdana, Tahoma, Arial";
fontsize="75%";
fontstyle="normal";
headerbgcolor="#ffffff";
headercolor="#000000";
offbgcolor="#F1F3F5";
offcolor="#515151";
onbgcolor="#94C64C";
oncolor="#ffffff";
outfilter="randomdissolve(duration=0.1)";
overfilter="Fade(duration=0.2);Alpha(opacity=90);Shadow(color=#777777', Direction=135, Strength=5)";
padding=5;
pagebgcolor="#94C64C";
pagecolor="black";
separatorcolor="#669933";
separatorsize=1;
subimage="/Admin/menu/arrow.gif";
subimagepadding=2;
}

with(milonic=new menuname("Main Menu")){
alwaysvisible=1;
followscroll=1;
//left=document.body.scrollLeft+(document.body.clientWidth )/4;
left=20;
orientation="horizontal";
style=menuStyle;
top=10;

aI("text=後台首頁;url=index.aspx;");
aI("showmenu=MainPage;text=首頁管理;");
aI("showmenu=Product;text=產品管理;url=ProductList.aspx;");
aI("showmenu=Event;text=活動訊息管理;url=EventList.aspx;");
aI("showmenu=Store;text=門市管理;url=StoreList.aspx;");
aI("showmenu=Download;text=下載區管理;");
aI("text=留言板管理;url=../book/gb_login.asp;");
aI("text=會員管理;url=MemberList.aspx;");
//aI("showmenu=Member;text=會員管理;url=MemberList.aspx;");
}

with(milonic=new menuname("MainPage")){
//overflow="scroll";
style=menuStyle;
aI("text=輪播圖片設定;url=HomePageImage.aspx;")
aI("text=MiniSite設定;url=MiniSiteList.aspx;")
}

with(milonic=new menuname("Product")){
style=menuStyle;
aI("text=新增商品;url=ProductModify.aspx;");
aI("text=新增分類;url=CategoryModify.aspx;");
aI("text=商品管理;url=ProductList.aspx;");
aI("text=分類管理;url=CategoryList.aspx;");
}
with(milonic=new menuname("Event")){
style=menuStyle;
aI("text=新增活動;url=EventModify.aspx;");
aI("text=活動訊息列表;url=EventList.aspx;");
}
 with(milonic=new menuname("Store")){
style=menuStyle;
aI("text=新增門市;url=StoreModify.aspx;");
aI("text=門市管理;url=StoreList.aspx;");
}
with(milonic=new menuname("Download")){
style=menuStyle;
aI("text=桌布管理;url=Desktop.aspx;");
aI("text=螢幕保護程式;url=Screen.aspx;");
}

with(milonic=new menuname("Member")){
//overflow="scroll";
style=menuStyle;
aI("text=會員列表;url=MemberList.aspx;")
aI("text=下載會員名單;url=MemberList.xls;")
aI("text=下載電子報訂閱名單;url=EpaperList.xls;")
}
 

drawMenus();

