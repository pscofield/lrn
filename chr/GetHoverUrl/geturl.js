// This is the content script that gets run in the context of the webpage.

// Constants used in the script.
var HOVER_BOX_ELEMENT = 'hoverbox';

// Get the hoverbox object for given href element.
function getHoverBox (element)
{
    console.log("Enter getHoverBox.");
    // Check if the hover box already exists.
    var allChildren = element.children;
    if (allChildren)
    {
        console.log("allChildren.length = '" + allChildren.length + "'.");
        for (var i = 0 ; i < allChildren.length ; i++)
        {
            if (allChildren[i].id === HOVER_BOX_ELEMENT)
            {
                console.log("Returning allChildren[" + i + "].id = " + allChildren[i].id + ".");
                return allChildren[i];
            }
        }
    }
    
    console.log("Creating a new hoverBox element.");
    var hoverBox = document.createElement('div');
    hoverBox.id = HOVER_BOX_ELEMENT;
    hoverBox.className = HOVER_BOX_ELEMENT;
    hoverBox.innerHTML = element.href;
    element.appendChild(hoverBox);
    hoverBox.hidden = true;
}

// Handles the enter event over the given element.
function hoverStartHandler (element)
{
    console.log("Enter hoverStartHandler.");
    var targetUrl = element.currentTarget.href;
    console.log("Target URL = '" + targetUrl + "'.");
    getHoverBox(element.currentTarget).hidden = false;
}

// Handles the exit event over the given element.
function hoverEndHandler (element)
{
    console.log("Enter hoverEndHandler.");
    getHoverBox(element.currentTarget).hidden = true;
}


// Register the event for all links on the page.
function registerHoverEvents () {
    var allLinks = document.links;
    Array.from(allLinks).forEach(function (e) {

        $(e).hovercard({
            detailsHTML: e.href,
            width: 400
        });

        // Disabled over the usage of hovercard.
    	// e.onmouseenter = hoverStartHandler;
        // e.onmouseleave = hoverEndHandler;
    });
}

function main ()
{
    console.log("Enter main.");
    registerHoverEvents();
    console.log("Exit main.");
}

// Entry point into the script.
main();





