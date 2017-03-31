(function ($) {
  $.fn.startPrjCounter = function (options, callback) {
    var settings = $.extend({},options);

    var container = $(this);
    var init_minutes = settings.minutes;
    var stop_timer = false;
    // var template = '<ul class="countdown"><li>\
    //   <span class="hours">__hour__</span>\
    //   </li>\
    //   <li class="seperator">:</li>\
    //   <li> \
    //     <span class="minutes">__minute__</span>\
    //   </li>\
    //   <li class="seperator">:</li>\
    //   <li> \
    //     <span class="seconds">__second__</span>\
    //   </li>\
    // </ul>';
    if (init_minutes<=0){
      alert("Error ! Intial Minute Can not be less than 1 Minute")
      return;
    }
    var total_seconds = 0;
    var seconds = 0;
    var minutes = init_minutes%60;
    var hours = Math.floor(init_minutes/60);
    function set_timer(){
      if (hours == 0 && minutes==0 && seconds ==0){
        stop_timer = true;
        if (callback && typeof callback === 'function') callback();
      }
      var str_hours = hours;
      var str_minutes = minutes;
      var str_seconds = seconds;

      if (hours<10){
        str_hours = '0'+hours;
      }
      if (minutes<10){
        str_minutes = '0'+minutes;
      }
      if (seconds<10){
        str_seconds = '0'+seconds;
      }
      container.find('.hours').text(str_hours);
      container.find('.minutes').text(str_minutes);
      container.find('.seconds').text(str_seconds);
      container.find('.total_seconds').text(total_seconds);
    }
    function countdown () {
      if (!stop_timer){
        total_seconds += 1;
        if (seconds == 0 ){
          if (minutes >= 0){
            seconds = 59;
          
            if (minutes == 0 ){
              if (hours > 0){
                minutes = 59; 
                hours -=1; 
              }
            }
            else{
              minutes -= 1;
            }
          }
        }
        else{
          seconds -=1;
        }
        set_timer();
      }
    };
    set_timer();
    var interval = setInterval(countdown, 1000);
  };
})(jQuery);