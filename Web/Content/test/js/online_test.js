

$('.slimscroll').slimScroll({
    railVisible: true,
    railOpacity:0,
    alwaysVisible: true,
    position:'right',
    distance:'0px'
});

//  Initialize Plugins 
$(function () {
  $('[title]').tooltip();
})




$(document).on('click','#start_test_btn_instructions',function(){
  $('#prj_timer').startPrjCounter({
    'minutes':$('#test_duration').text()
  },function(){
    // alert("Timer Ends !!");
    $('#prj_timer').find('countdown').text("Test Ended !");
    $('#finish_test_btn').click();

  });
  // toggleFullScreen(document);
  $('.test_instructions_fade').addClass('hidden');
});


$(document).on('click','.question_option .q_tbl_optn_col_3',function(){
  // $(this).find('.option_input').prop('checked','checked');
  $(this).closest('.question_option').find(':checkbox').prop('checked', function (i, value) {
      return !value;
  });
  $(this).closest('.question_option').find(':radio').prop('checked', function (i, value) {
      return !value;
  });
});

$(document).on('click','.question_option .q_tbl_optn_col_2',function(){
  // $(this).find('.option_input').prop('checked','checked');
  $(this).closest('.question_option').find(':checkbox').prop('checked', function (i, value) {
      return !value;
  });
  $(this).closest('.question_option').find(':radio').prop('checked', function (i, value) {
      return !value;
  });
});

// var sections_object = $.parseJSON($('#sections_json').text());
// console.log(sections_object);
var seconds_elapsed_timer = 0;

// timer code - should be uncommented
var universal_timer = setInterval(function(){
  var cur_time = parseFloat($('.active_question').attr('data-time-spent'));
  $('.active_question').attr('data-time-spent',cur_time+0.1);
},100);

function bring_question_in_view(question_id) {
  //question_id = "HI_" + question_id;
  console.log(">>>>>>>>>>>>>>>>. "+question_id);
  var end_of_test_reached = false;
  if(!question_id ){
    alert("End of Test Reached !!");
    end_of_test_reached= true;
    return;
  }
  // Hide the current active question in the central pane
  // show the new question in central pane
  var current_question = $('#test_questions_wrapper').find('#'+question_id);

  var prev_active_question = $('#test_questions_wrapper').find('.active_question');
  console.log(current_question);
  console.log(prev_active_question);
  if (current_question[0] == prev_active_question[0]){
    return;
  }
  if (prev_active_question.find(":checked").length > 0){
    change_question_state(prev_active_question.attr('id'),'answered');
  }
  else{
    change_question_state(prev_active_question.attr('id'),'skipped');
  }
  
  
  var c_section = current_question.closest('.section_wrapper');
  var new_section_id = c_section.attr('data-section-id');
  var is_c_section_active = c_section.hasClass('active');
  if (!is_c_section_active){
    $('#test_questions_wrapper').find('.active_section').removeClass('active_section').addClass('hidden');
    c_section.addClass('active_section').removeClass('hidden');
    $('#test_sections_wrapper').find('.active_section').removeClass('btn-info').addClass('btn-default');
    $('#test_sections_wrapper').find('.'+new_section_id).removeClass('btn-default').addClass('btn-info active_section');
  }
  // prev_active_question.removeClass('active_question').fadeOut(1,function(){
  //   prev_active_question.addClass('hidden');
  //   current_question.addClass('active_question').css('display','none').removeClass('hidden').fadeIn(1,function(){
  //   });
  // });
  prev_active_question.removeClass('active_question').addClass('hidden');
  current_question.addClass('active_question').removeClass('hidden');
  

  // Left Pane 
  $('#test_left_snippets_wrapper').find('.test_q_list_item.active').removeClass('active');
  $('#test_left_snippets_wrapper').find('.'+question_id).addClass('active');
  var active_left_item =  $('.test_q_list_item.active');
  var active_item_offset = active_left_item.offset().top + active_left_item.height()+16;
  var wrapper_height = active_left_item.closest('.test_q_list').height();
  console.log(active_item_offset);
  console.log(wrapper_height);
  if(active_item_offset > wrapper_height || active_item_offset < 0 ){
    $('.test_q_list').scrollTo(active_item_offset-200+$('.test_q_list').scrollTop(),1000);
  }
  // we have to scoll to the correct question.

  // Right Pane 
  var right_q_btn = $('#test_right_snippets_wrapper').find('.section_q_btn_wrapper').find('.'+question_id);
  console.log(right_q_btn);
  // check if the section is visible.
  var r_section = right_q_btn.closest('.section_q_btn_wrapper');
  var is_r_section_active = r_section.hasClass('active');
  // console.log(r_section);
  // console.log(is_r_section_active);
  if (!is_r_section_active){
    // if the correct section is not visible, make it visible and hide the previous one.
    $('#test_right_snippets_wrapper').find('.section_q_btn_wrapper.active').removeClass('active').addClass('hidden');
    r_section.addClass('active').removeClass('hidden');
  }
  $('#test_right_snippets_wrapper').find('.section_q_btn_wrapper').find('.test_icons.active').removeClass('active');
  $('#test_right_snippets_wrapper').find('.section_q_btn_wrapper').find('.'+question_id).addClass('active');
}



function bring_section_in_view(section_id){
  console.log(section_id);
  if(!section_id){
    alert("Last Section's Last Question Reached !")
    return;
  }
  // Hide the current active section in the central pane
  // show the new section in the central pane.
  var current_section = $('#test_questions_wrapper').find('.active_section');
  var current_section_id = current_section.attr('data-section-id');
  current_section.removeClass('active_section').addClass('hidden');
  var $next_section = $('#test_questions_wrapper').find('.'+section_id+"_center");
  $next_section.addClass('active_section').removeClass('hidden');
  bring_question_in_view($next_section.find('.question_basic:first-child').attr('id'));

  // Highlight the next section in Right Pane
}

function bring_next_question_in_view(question_id){
  var cur_q = $('#test_questions_wrapper').find('#'+question_id);
  console.log(cur_q);
  if(cur_q.next().length > 0){
    // If there are next question, it means
    // that the question can be 1 to n-1 th question
    // of the current section.
    // simply bring the next question to view.
    var next_question_id = cur_q.next().attr('id');
    bring_question_in_view(next_question_id);
  }
  else{
    // If there are no more necxt sibings, it can mean 2 things.
    // 1. This is the last question of the current section.
    //   Sol'n : Bring the next section in view and make the 
    //           1st question as active question.
    // 2. This is the last question of the last section.
    // Code for the 1st case.
    var $next_section = cur_q.closest('.section_wrapper').next('.section_wrapper');
    if ($next_section){
      bring_question_in_view($next_section.find('.question_basic:first-child').attr('id'));
    }
    else{
      alert("You have Reached the last Question of the Test.");
    }
    // bring_section_in_view($next_section.attr('data-section-id'));
    
  }
  // console.log(cur_q.prev().length);
}

function change_question_state(question_id,state){
  // state can be:
  // 1. marked
  // 2. answered
  // 3. skipped
  // 4. marked_answered
  var current_question = $('#'+question_id);
  current_question.removeClass('unseen');
  if (state == "answered"){
    current_question.removeClass('skipped').removeClass('marked').addClass('answered');
    $('#test_left_snippets_wrapper').find('.'+question_id).find('.icon').addClass('answered').removeClass('skipped unseen');
    $('#test_right_snippets_wrapper').find('.'+question_id).addClass('answered').removeClass('skipped unseen');
    if (current_question.attr('data-current-state') == "marked"){
      current_question.attr('data-current-state','marked_answered');  
    }
    else if (current_question.attr('data-current-state') == "marked_answered"){
      // current_question.attr('data-current-state','answered');
    }
    else{
      current_question.attr('data-current-state','answered');
    }
  }
  else if (state == "skipped"){
    // current_question.removeClass('answered');
    if ( ! current_question.hasClass('marked')){
      current_question.attr('data-current-state','skipped').addClass('skipped').removeClass('answered');
      $('#test_left_snippets_wrapper').find('.'+question_id).find('.icon').addClass('skipped').removeClass('answered unseen');
      $('#test_right_snippets_wrapper').find('.'+question_id).addClass('skipped').removeClass('answered unseen');
    }
    else if (current_question.hasClass('marked') && current_question.hasClass('answered')){
      current_question.attr('data-current-state','marked').removeClass('answered');
      $('#test_left_snippets_wrapper').find('.'+question_id).find('.icon').removeClass('answered');
      $('#test_right_snippets_wrapper').find('.'+question_id).removeClass('answered');
    }
  }

  // current_question.attr('data-current-state','unanswered').addClass('unanswered');
  // var question_id = current_question.attr('id');
  // // left part
  // $('#test_left_snippets_wrapper').find('.'+question_id).find('.icon').addClass('marked').removeClass('unseen');
  // // right part
  // $('#test_right_snippets_wrapper').find('.'+question_id).addClass('marked');
  

}

$(document).on('click','.test_q_list_item',function(){
  bring_question_in_view($(this).attr('data-question-id'));
});

$(document).on('click','#test_right_snippets_wrapper .test_icons',function(){
  bring_question_in_view($(this).attr('data-question-id'));
});

$(document).on('click','.top_section_btns',function(){

  bring_section_in_view($(this).attr('data-section-id'));
});

$(document).on('click','#save_and_next_btn',function(){
  var current_question_id = $('#test_questions_wrapper').find('.question_basic.active_question').attr('id');
  bring_next_question_in_view(current_question_id);
});

$(document).on('click','#mark_for_review_btn',function(){

  var current_question = $('#test_questions_wrapper').find('.question_basic.active_question');
  if (current_question.attr('data-current-state') == "answered"){
    current_question.attr('data-current-state','marked_answered');  
  }
  else{
    current_question.attr('data-current-state','marked');
  }
  
  // central part
  var question_id = current_question.attr('id');
  current_question.addClass('marked').removeClass('skipped');
  // left part
  $('#test_left_snippets_wrapper').find('.'+question_id).find('.icon').addClass('marked').removeClass('unseen skipped');
  // right part
  $('#test_right_snippets_wrapper').find('.'+question_id).addClass('marked').removeClass('unseen skipped');
});

$(document).on('click','#clear_response_btn',function(){
  var current_question = $('#test_questions_wrapper').find('.question_basic.active_question');
  current_question.find(':checked').prop("checked","");
});

$(document).on('click','.show_summary_button',function(){
  $('.summary_table .summary_row').remove();
  var total_marked_count = 0;
  $('#test_questions_wrapper .section_wrapper').each(function(){
    var section_name = $(this).attr('data-section-name');
    
    var summary_template = $('.summary_table').find('.summary_row_template').clone().removeClass('summary_row_template hidden').addClass('summary_row');
    var answered_count = 0 ;
    var skipped_count = 0 ;
    var marked_count = 0;
    var unseen_count = 0;
    $(this).find('.question_basic').each(function(){
      if ($(this).attr('id') != "dummy"){
        if ($(this).attr('data-current-state') == "answered"){
          answered_count += 1
        }
        else if ( $(this).attr('data-current-state') == "skipped"){
          skipped_count += 1;
        }
        else if ( $(this).attr('data-current-state') == "marked"){
          marked_count += 1
        }
        else if ( $(this).attr('data-current-state') == "unseen"){
          unseen_count += 1;
        }
      }
    });
    total_marked_count += marked_count;
    summary_template.find('.answered_count').text(answered_count).end().find('.skipped_count').text(skipped_count).end().find('.marked_count').text(marked_count).end().find('.unseen_count').text(unseen_count).end().find('.section_name').text(section_name);
    console.log(summary_template);
    $('.summary_table').append(summary_template);
  });
  if(total_marked_count == 0){
    $('.summary_warning').addClass('hidden');
  }
  else{
    $('.summary_warning').removeClass('hidden');
    $('.warning_marked_count').text(total_marked_count);
  }
  $('#before_submit_summary_modal').modal('show');
});



function submit_test(malpractice){
  console.log("Malpractice "+malpractice);
  clearInterval(universal_timer);
  var current_btn = $('#finish_test_btn');
  var questions = [];
  var total_time_spent = $.trim($('#prj_timer').find('.total_seconds').text());
  var test_id = window.location.pathname.split("/")[2];
  var attempt_id = $.trim($('#attempt_id').text());
  var sections = [];
 
  $('#test_questions_wrapper .section_wrapper').each(function(){
    var section_id = encodeURIComponent($(this).attr('data-section-id'));
    var section={};
    section.section_id = section_id;
    section.time_spent=0;
    $(this).find('.question_basic').each(function(){

      if ($(this).attr('id')!="dummy"){
        var question = {};
        question.section_id = section_id;
        question.question_id = $(this).attr('id');
        question.topic_id =  encodeURIComponent($(this).attr('data-topic'));
        question.status = $(this).attr('data-current-state');
        question.option_ids = [];
        $(this).find('.option_input:checked').each(function(){
          console.log($(this));
          question.option_ids.push($(this).attr('data-option-id'));
        });
        question.time_spent = $(this).attr('data-time-spent');
        questions.push(question);
        section.time_spent += parseFloat($(this).attr('data-time-spent'));
      }
      
    });
    sections.push(section);
  });
  // console.log(questions);
  console.log(JSON.stringify(questions));
  console.log(total_time_spent);
  console.log(test_id);

  var csrf = $('#csrf_form').find('input[name="csrfmiddlewaretoken"]').val();
  var dataString = "csrfmiddlewaretoken="+csrf;
  dataString += "&questions="+JSON.stringify(questions);
  dataString += "&total_time_spent="+total_time_spent;
  dataString += "&test_id="+test_id;
  dataString += "&attempt_id="+attempt_id;
  dataString += "&sections="+JSON.stringify(sections);

  var form_url = current_btn.attr('data-submit-test-url');
  console.log(dataString);
  // console.log(total_time_spent);
  // console.log(sections);
  $.ajax({
        url : form_url,
        data : dataString,
        type : 'post',
        beforeSend: function(){
          $('.page_form_loader').removeClass('hidden');
          current_btn.button('loading');
        },
        complete: function(){
        },
        success: function(return_data){
            console.log( return_data);
            var resp_obj = $.parseJSON(return_data);                
            if (resp_obj.hasOwnProperty("success")){
                if (resp_obj.hasOwnProperty("redirect_url")){
                window.location = resp_obj.redirect_url ;
              }
            }
            else if (resp_obj.hasOwnProperty("errors")){
               $('.page_form_loader').addClass('hidden');
               current_btn.button('reset');
               alert("We are Sorry, your test could not be submitted! Please Try again..");

            }
        },
        error: function(xhr,status,errorThrown){
            console.log('Error in Ajax Request');
            console.log(errorThrown);
            console.log(status);
            $('.page_form_loader').addClass('hidden');
            current_btn.button('reset');
            alert("We are Sorry, your test could not be submitted! Please Try again..");
           
        }
    });
};

$(document).on('click','#finish_test_btn',function(event){
  console.log("CLicked Submit test");
  submit_test(false);
});

// var test_details_json = $.parseJSON($('#test_details_json').text());
// console.log(test_details_json);

// var test_section_height = $('.test_sections_list').height() +20;//add padding
// console.log(test_section_height);
// var parent_height = $('.test_sections_list').parent('div').height();
// console.log(parent_height);
// var final_height = parent_height - test_section_height - 52;
// console.log(final_height);
// $('.test_center_wrapper').css({'height': final_height});
// 
// 

$(document).on('click','.show_more_paragraph .btn',function(){
  var current_paragraph = $(this).closest('.paragraph_text');
  current_paragraph.css({'overflow':'visible','height':'auto'});
  $(this).closest('.show_more_paragraph').remove();
});





$(document).on('click','.hide_target',function(event){
    event.preventDefault();
    $($(this).attr("data-target")).addClass("hidden");
});

//  Start the test Timer 
function start_test_timer(){
  $('#prj_timer').startPrjCounter({
    'minutes':$('#test_duration').text()
  },function(){
    // alert("Timer Ends !!");
    $('#prj_timer').find('countdown').text("Test Ended !");
    $('#finish_test_btn').click();
  });
}
