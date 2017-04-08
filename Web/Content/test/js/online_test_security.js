
//  ######## Security Features #################
// 1. Submit Test on alt press
// 2. Submit Test on clicking outside the window
// 3. 


// Disable Key Press 
$(document).keydown(function(event) { 
  event.preventDefault();
  event.stopPropagation();
  console.log("Pressed !"+event.keyCode);
  if (event.altKey || event.keyCode=="18"|| event.keyCode=="91"){
    console.log("Alt key Pressed, Your test will end now ! !");
    submit_test(true);
    
  }
  return false;
});



function addEvent(obj, evt, fn) {
    if (obj.addEventListener) {
        obj.addEventListener(evt, fn, false);
    }
    else if (obj.attachEvent) {
        obj.attachEvent("on" + evt, fn);
    }
}


addEvent(window,"load",function(e) {
    addEvent(document, "mouseout", function(e) {
        e = e ? e : window.event;
        var from = e.relatedTarget || e.toElement;
        if (!from || from.nodeName == "HTML") {
            // stop your drag event here
            // for now we can just use an alert
            console.log("left window");
            $('#mouse_out_warning').removeClass('hidden');
            // alert("You should not leave the current window.");
        }
    });
    addEvent(document, "mouseover", function(e) {
      $('#mouse_out_warning').addClass('hidden');
    });
});



Visibility.change(function (e, state) {
  console.log(state);
  if (state == "hidden"){
    // $('#finish_test_btn').click();
    submit_test(true);
    console.log("End Test ");
  }
});




$(document).on('fscreenchange', function(e, state, elem) {
    // if we currently in fullscreen mode
    if ($.fullscreen.isFullScreen()) {
      
    } else {
      submit_test(true);
    }
    
});

function isChrome() {
    var isChromium = window.chrome,
      winNav = window.navigator,
      vendorName = winNav.vendor,
      isOpera = winNav.userAgent.indexOf("OPR") > -1,
      isIEedge = winNav.userAgent.indexOf("Edge") > -1,
      isIOSChrome = winNav.userAgent.match("CriOS");

    if (isIOSChrome) {
        return true;
    } else if (isChromium !== null && isChromium !== undefined && vendorName === "Google Inc." && isOpera == false && isIEedge == false) {
        return true;
    } else {
        return false;
    }
}

// ################ END OF SECURTY FEATURES #########################
