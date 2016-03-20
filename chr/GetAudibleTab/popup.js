
// Executes the given callback on the selected tabs. Propagates extra arguments to the callback.
function getTabs (queryInfo, callback) {
  
  var otherArguments = Array.prototype.slice.call(arguments, 2);

  // chrome.tabs.query is asynchronous. Hence, use callback.
  chrome.tabs.query(queryInfo, function(tabs) {
    otherArguments.unshift(tabs);
    callback.apply(null, otherArguments);
  });
}

// Uses the 'tabs' data and executes the given callback. Propagates extra arguments to the callback.
function processTabs(tabs, callback) {

  var tab = tabs[0];
  var url = tab.url;
  console.assert(typeof url == 'string', 'tab.url should be a string');

  var otherArguments = Array.prototype.slice.call(arguments, 2)
  otherArguments.unshift(url);
  callback.apply(null, otherArguments);
}

// Adds decorative text to the url string and executes provided callback.
function useUrl (url, callback) {
  callback('URL is: ' + url + '.');
}

// Updates the display text.
function setStatus(statusText) {
  document.getElementById('text').textContent = statusText;
}

// Entry point to the execution.
function main() {

  // https://developer.chrome.com/extensions/tabs#method-query.
  var queryInfo = {
    audible: true
  };

  // The following line can be used to visualize the overall execution flow. The arguments are callbacks.
  // Get the tabs -> process the tabs -> use the URL -> set status.
  getTabs(queryInfo, processTabs, useUrl, setStatus);
}

// Invoked when the popup is loaded.
document.addEventListener('DOMContentLoaded', main);
