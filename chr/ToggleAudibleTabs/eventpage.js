
//////////////////
//// Internal ////
//// helpers. ////
//////////////////

// Executes the given callback on the selected tabs. Propagates extra arguments to the callback.
function getTabs (queryInfo, callback) {
  
  var otherArguments = Array.prototype.slice.call(arguments, 2);

  // chrome.tabs.query is asynchronous. Hence, use callback.
  chrome.tabs.query(queryInfo, function(tabs) {
    otherArguments.unshift(tabs);
    callback.apply(null, otherArguments);
  });
}

///////////////////
//// Extension ////
///// methods. ////
///////////////////

// Kills the given tabs.
function killGivenTabs (tabs) {
	var tabIds = tabs.map(function(obj){
		return obj.id;
	});
	chrome.tabs.remove(tabIds);
}

// Kills the muted tabs.
function killMutedTabs () {
	getTabs({muted: true}, killGivenTabs);
	chrome.browserAction.setIcon({path: "soundOn.png"})
}

// Unmutes given tabs.
function unmuteGivenTabs (tabs) {
	for (var i = tabs.length - 1; i >= 0; i--) {
		chrome.tabs.update(tabs[i].id, {muted: false});
	}
}

// Unmutes all tabs which are muted.
function unmuteAllTabs () {
	getTabs({muted: true}, unmuteGivenTabs);
	chrome.browserAction.setIcon({path: "soundOn.png"})
}

// Mutes given tabs.
function muteGivenTabs (tabs) {
	for (var i = tabs.length - 1; i >= 0; i--) {
		chrome.tabs.update(tabs[i].id, {muted: true});
	}
	chrome.browserAction.setIcon({path: "soundOff.png"})
}

// Gets called with a list of the audible tabs.
// If the list is not empty, executes first callback.
// If the list is empty, executes the second callback.
function processAudibleTabs (tabs, callbackNotEmpty, callbackEmpty) {
	if (tabs.length) {
		callbackNotEmpty(tabs);
	} else {
		callbackEmpty(tabs);
	}
}

// The entry point to the execution.
function main () {
	getTabs({audible: true, muted: false}, processAudibleTabs, muteGivenTabs, unmuteAllTabs);
}

// Invoke the main method whenever the extension button is clicked.
chrome.browserAction.onClicked.addListener(main);

// The command (keyboard shortcut) need not be registered when using the well-known
// command identifier "_execute_browser_action".

// Register the callback for the non-default keyboard shortcut command.
chrome.commands.onCommand.addListener(function(){
	getTabs({audible: true, muted: false}, processAudibleTabs, muteGivenTabs, killMutedTabs);
});
