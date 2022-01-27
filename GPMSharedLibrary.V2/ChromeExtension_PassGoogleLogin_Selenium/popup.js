

var btnConnect = document.getElementById('btnConnect');
btnConnect.onclick = function()
{
    var port = chrome.extension.connect({
        name: "Sample Communication"
    });
	port.postMessage({code:'ConnectServer', value:'DoIt'});
}

var btnConnect_FirstTab = document.getElementById('btnConnect_FirstTab');
btnConnect_FirstTab.onclick = function()
{
    var port = chrome.extension.connect({
        name: "Sample Communication"
    });
	port.postMessage({code:'ConnectServer', value:'Connect_FirstTab'});
}