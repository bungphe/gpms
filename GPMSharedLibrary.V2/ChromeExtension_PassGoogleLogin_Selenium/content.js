'use strict';

//Đổi user-agent
chrome.webRequest.onBeforeSendHeaders.addListener(
    function (details) {
        if(details.url.includes('https://accounts.google.com/ServiceLogin') || details.url.includes('https://accounts.google.com/signin')) {

            for (var i = 0; i < details.requestHeaders.length; ++i) {
                if (details.requestHeaders[i].name === 'User-Agent'){
                    details.requestHeaders[i].value = 'default_user_agent';
                    console.log('changed user-agent')
                    break;
                }
            }
        }
        return { requestHeaders: details.requestHeaders };
    },
    { urls: ['<all_urls>'] },
    ['blocking', 'requestHeaders']
);