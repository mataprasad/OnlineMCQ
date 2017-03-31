function fnPerformAjax(url, data, successHandler) {
    $.ajax({
        url: url,
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        data: data,
        success: successHandler,
        error: function (a, b, c) { alert(a.responseText); }
    });
}