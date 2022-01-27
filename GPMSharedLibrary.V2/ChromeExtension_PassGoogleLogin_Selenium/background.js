// Copyright 2018 The Chromium Authors. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

'use strict';

//Khi có connect
// chrome.extension.onConnect.addListener(function (port) {
	////Khi có kết nối thì mới lắng nghe
    // port.onMessage.addListener(function (message) {
		// console.log(`Background have message: ${message}`);
    // });
// });

chrome.tabs.onRemoved.addListener(function(tab)
{
	// console.log(`Tab close ${tab}`);
});

chrome.tabs.onCreated.addListener(function(tab){
    // console.log(`Tab created event caught. Open tabs: ${tab.id}`);
});