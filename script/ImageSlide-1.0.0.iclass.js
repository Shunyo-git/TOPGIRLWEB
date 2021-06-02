/**
 * =========================================================================
 * 本程式可自由複製、修改、傳播，不得刪除以下資訊。如用於商業用途須經原作者同意方可使用。
 * =========================================================================
 * 程式名稱：ForceWindow(@iClass.JS)
 * 描　　述：網頁上的圖片幻燈片。
 * 版　　本：1.0.0
 * 創建時間：2005年4月23日
 * 修改時間：2005年4月23日
 * 作　　者：鐘鐘
 * 郵箱地址：zhong@iecn.net
 * 版權聲明：本程式屬於iClass.JS，版權歸作者所有。
 * 討論地址：http://www.iecn.net/forum/showthread.php?threadid=16975
 * 有關iClass計畫詳見：http://www.iecn.net/forum/showthread.php?threadid=14811
 * =========================================================================
 */


//構造ImageSlide類
function ImageSlide () {
	if((/MSIE\s*[5-9]/).test(navigator.appVersion)) {
		this.count = 0;
		this.timer = null;
		this.first = new Object();
		this.frms = new Array();

		this.imgs = new Array();
		this.width = 640;
		this.height = 480;
		this.boxId = "imageSlideBox";
		this.delay = 5;
		this.autoPlay = true;
		this.transform = 23;
		/**
		 * 播放切換效果說明
		 * --------------
		 *  0. 矩形縮小
		 *  1. 矩形擴大
		 *  2. 圓形縮小
		 *  3. 圓形擴大
		 *  4. 從下到上
		 *  5. 從上到下
		 *  6. 從左到右
		 *  7. 從右到左
		 *  8. 豎百葉窗
		 *  9. 橫百葉窗
		 * 10. 錯位橫百葉窗
		 * 11. 錯位豎百葉窗
		 * 12. 點擴散
		 * 13. 兩邊到中間
		 * 14. 中間到兩邊
		 * 15. 中間到上下
		 * 16. 上下到中間
		 * 17. 右下到左上
		 * 18. 右上到左下
		 * 19. 左上到右下
		 * 20. 左下到右上
		 * 21. 橫條
		 * 22. 豎條
		 * 23. 隨機
		 * --------------
		 */
	}
	else {
		alert("請使用IE5或IE5以上版本的流覽器使用本程式！");
	}
}

//加入一張或多張圖片（傳入一個或多個圖片路徑）
//pushImg(sPath1 [, sPath2 [, sPath3 [, ...]]])
ImageSlide.prototype.pushImgs = function () {
	for (var i = 0; i < arguments.length; i++)
		this.imgs.push(arguments[i]);
}

//設置圖片播放容器的長寬
ImageSlide.prototype.setSize = function (nWidth, nHeight) {
	this.width = nWidth;
	this.height = nHeight;
}

//設置圖片播放容器的ID
ImageSlide.prototype.setBoxId = function (sBoxId) {
	this.boxId = sBoxId;
}

//設置是否自動播放
ImageSlide.prototype.setAutoPlay = function (bAutoPlay) {
	this.autoPlay = bAutoPlay;
}

//設置自動播放的延時秒數
ImageSlide.prototype.setDelay = function (nSeconds) {
	this.delay = nSeconds;
}

//設置播放的切換效果（0-23的整數）
ImageSlide.prototype.setTransform = function (nTransform) {
	this.transform = nTransform;
}

//顯示
ImageSlide.prototype.display = function () {
	var boxStr = "<div style='width:" + this.width + "px;height:" + this.height + "px;' ";
	boxStr += "id='"  + this.boxId + "'><div ";
	if (this.autoPlay)
		boxStr += "onclick='window.imageSlide.play();window.imageSlide.timerPlay();'";
	else
		boxStr += "onclick='window.imageSlide.play();'";
	boxStr += "style='word-break:keep-all;width:100%;height:100%;background-color:#EEEEEE;'>";
	if (this.autoPlay)
		boxStr += "<br />　點擊此處開始進行自動播放……";
	else
		boxStr += "<br />　點擊此處開始播放，播放時單擊播放下一張……";
	boxStr += "</div>";
	var img;
	var transform = this.transform;
	for (var i = 0; i < this.imgs.length; i++) {
		if (this.transform >= 23)
			var transform = Math.floor(Math.random()*23);
		boxStr += "<img src='" + this.imgs[i] + "' style='display:none;width:";
		boxStr += this.width + ";height:" + this.height + "px;height:px;filter:";
		boxStr += "revealTrans(transition=" + transform + ",duration=1);'";
		if (!this.autoPlay)
			boxStr += "' onclick='window.imageSlide.play();' alt='點擊播放下一張'";
		boxStr += " />";
	}
	boxStr += "</div>";
	document.writeln(boxStr);
	var box = document.getElementById(this.boxId);
	this.first = box.childNodes[0];
	this.frms = box.getElementsByTagName("IMG");
}

//播放
ImageSlide.prototype.play = function () {
	if (window.imageSlide.imgs.length) {
		window.imageSlide.first.style.display = "none";
		if (window.imageSlide.count >= window.imageSlide.imgs.length) {
			alert("播放完畢！");
			window.imageSlide.frms[window.imageSlide.count-1].style.display = "none";
			window.imageSlide.first.style.display = "block";
			window.imageSlide.first.innerHTML = "<br />　點擊此處再次進行播放！";
			clearInterval(window.imageSlide.timer);
			window.imageSlide.count = 0;
		}
		else if (window.imageSlide.count == 0) {
			window.imageSlide.first.style.display = "none";
			window.imageSlide.frms[0].filters[0].apply();
			window.imageSlide.frms[0].style.display = "block";
			window.imageSlide.frms[0].filters[0].play();
		}
		else {
			window.imageSlide.frms[window.imageSlide.count-1].style.display = "none";
			window.imageSlide.frms[window.imageSlide.count].filters[0].apply();
			window.imageSlide.frms[window.imageSlide.count].style.display = "block";
			window.imageSlide.frms[window.imageSlide.count].filters[0].play();
		}
		window.imageSlide.count++;
	}
	else {
		alert("你沒有放入任何圖片，無法進行播放！");
	}
}

//連續播放
ImageSlide.prototype.timerPlay = function () {
	this.timer = setInterval(this.play, this.delay * 1000);
}

//實例化一個ImageSlide物件imageSlide並將其做為window物件的一個子物件
window.imageSlide = new ImageSlide();
