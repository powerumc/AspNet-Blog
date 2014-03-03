function g(controlId)
{
	return document.getElementById(controlId);
}

function setContent(id)
{
	document.getElementById("iframeContent").src="/common/snap/templates/snapContent.aspx?snapID="+id;
}

function getContent(id)
{
	return "/common/snap/templates/snapContent.aspx?snapID="+id;
}

function openTagSelector()
{
	window.open('/common/popup/tagSelector.aspx', '','width=300, height=200, scrollbars=yes, resizable=no');
}

function openCommentReply(articleNo, group, step, order)
{
	window.open('/common/popup/commentreply.aspx?articleNo='+articleNo
		+'&group='+group
		+'&step='+step
		+'&order='+order,'','width=500, height=300, scrollbars=no, resizable=no');
}

function openRemoveComment(articleNo, commentNo)
{
	window.open('/common/popup/checkCommentPassword.aspx?articleNo='+articleNo+'&commentNo='
		+commentNo, '','width=400, height=200, scrollbars=no, resizable=no');
}

function opemModifyComment(articleNo, commentNo)
{
	window.open('/common/popup/commentModify.aspx?articleNo='+articleNo+'&commentNo='
		+commentNo, '','width=500, height=300, scrollbars=no, resizable=no');
}

function goComment(goNo)
{
	iframeContent.goComment(goNo);
}

function copyBlock(obj)
{
	window.clipboardData.setData("Text", obj.innerText);
	
	alert('클립보드에 복사되었습니다');
}

function checkEnter( obj )
{
	if( event.keyCode == 13 )
		doPostBack( obj, '' );
}


// 툴팁 소스
var theObj="";

function toolTip(text,me) {    
  theObj=me;  
  theObj.onmousemove=updatePos;
  
  document.getElementById('toolTipBox').innerHTML=text;
  document.getElementById('toolTipBox').style.display="block";  
  window.onscroll=updatePos;
}

 

function updatePos() {

  var ev=arguments[0]?arguments[0]:event;
  
  var x=ev.clientX;

  var y=ev.clientY;

  diffX=24;

  diffY=0;

  document.getElementById('toolTipBox').style.top  = y-2+diffY+document.body.scrollTop+"px";

  document.getElementById('toolTipBox').style.left = x-2+diffX+document.body.scrollLeft+"px";

  theObj.onmouseout=hideMe;

}

function hideMe() {

  document.getElementById('toolTipBox').style.display="none";

}


function resizeFrame(iframeObj)
{
	var innerBody = iframeObj.contentWindow.document.body;
	oldEvent = innerBody.onclick;
	innerBody.onclick = function(){ resizeFrame(iframeObj, 1);oldEvent; };
	var innerHeight = innerBody.scrollHeight + (innerBody.offsetHeight - innerBody.clientHeight);
	iframeObj.style.height = innerHeight;
	var innerWidth = innerBody.scrollWidth + (innerBody.offsetWidth - innerBody.clientWidth);
	iframeObj.style.width = innerWidth;     
	if( !arguments[1] )
	this.scrollTo(1,1);
}