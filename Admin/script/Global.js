function chkConfirmDelete(){
	if(confirm("確定要刪除項目嗎？")){return true;}
	return false ;
}
function chkConfirmUploadImage(){
	if(confirm("確定要上傳嗎？ \n\n請注意:上傳後檔案將立即更新，原有舊檔將會被新檔覆蓋。")){return true;}
	return false ;
}

function getAttachment(ProjectID,DataID,Mode,AttachmentType){
		var theURL = "attachment.aspx?ProjectID=" + ProjectID + "&RecordID=" +  DataID + "&Mode=" + Mode  + "&AttachmentType=" + AttachmentType  + "&AttachmentFiles=" + document.getElementById("txtFilename").value ;
		var CWIN=window.open(theURL,"PM_attachment","toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=auto,resizable=1" ,true)
	}
	
function DeleteReply(topicID,replyID)	
{
	if(confirm("確定要刪除回覆嗎？")){
	document.location.href="ForumTopicDetail.aspx?TopicID=" + topicID + "&ProjectID=1&index=-1&projectIndex=6&DelReplyID=" + replyID ;
	}
}

var swidth=screen.width;
var sheight=screen.height;
function toShowFile(strApp) {
		var strWinType='d';
		var strLoc=strApp +'&tm=' + getStringDate();
		nWin(strLoc,strWinType)
		window.event.cancelBubble = true;
}

function nWin(f,sType) {
//	var usrWin;
	var nwidth=(swidth*5/7)+30;
	var nheight=(sheight*5/7)+30;
	if (sType && sType.indexOf("b")>=0) {
		nwidth=swidth*6/7;
		nheight=sheight*6/7;
		}
	if (sType && sType.indexOf("s")>=0) {
		nwidth=swidth*2/3;
		nheight=sheight*2/3;
		}
		
	var sLeft=(swidth-nwidth)/2;
	var sTop=(sheight-nheight)/2-50;
	var parm="toolbar=no,width=" + nwidth + ",height=" + nheight + ",top=" + sTop+",left=" + sLeft+ ",directories=no,status=no,scrollbars=yes,resizable=yes,menubar=no";
		
	if (sType && sType.indexOf("d")>=0) {
		parm="toolbar=no,width=" + nwidth + ",height=" + nheight + ",top=" + sTop+",left=" + sLeft+ ",directories=no,status=no,scrollbars=yes,resizable=yes,menubar=yes";

		}
		
	if (sType && sType.indexOf("i")>=0) {
		parm="toolbar=no,width=" + nwidth + ",height=" + nheight + ",top=" + sTop+",left=" + sLeft+ ",toolbar=no,directories=no,status=no,scrollbars=no,resizable=no,menubar=no,titlebar=no ";

		}

	
    	window.open(f,'',parm);
	//usrWin.focus();
}

function getStringDate() {
		var t=new Date();
		t=t.toLocaleString();
		return t;
}