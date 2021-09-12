// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#from-modal .modal-body").html(res);
            $("#from-modal .modal-title").html(title);
            $("#from-modal").modal('show');
        }
    })
}

jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $("#view-all").html(res.html);
                    $("#from-modal .modal-body").html('');
                    $("#from-modal .modal-title").html('');
                    $("#from-modal").modal('hide');
                }
                else {
                    $("#from-modal .modal-body").html(res.html);
                }
            },
            error: function (err) {
                console.log(err);
            }
        })
    } catch (e) {
        console.log(e);
    }

    return false;
}

