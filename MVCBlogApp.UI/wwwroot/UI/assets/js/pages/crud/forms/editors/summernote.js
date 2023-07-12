"use strict";
// Class definition

var KTSummernoteDemo = function () {
    // Private functions
    var demos = function () {
        $('.summernote').summernote({
            height: 400,
            tabsize: 2,
            callbacks: {
                onImageUpload: function (files, editor, welEditable) {
                    console.log("files", files);
                    console.log("editor", editor);
                    console.log("welEditable", welEditable);
                    sendFile(files[0], editor, welEditable);
                }
            }
        });
    };

    function sendFile(file, editor, welEditable) {
        //console.log("sendFile File: ", file);
        var data = new FormData();
        data.append("file", file);
        $.ajax({
            data: data,
            type: "POST",
            url: "/Yonetim/Blog/PostUploadImage",
            cache: false,
            contentType: false,
            processData: false,
            success: function (url) {
                //console.log(url);
                var image = $('<img>').attr('src', url[0]);
                $('.summernote').summernote("insertNode", image[0]);
            }
        });
    }

    return {
        // public functions
        init: function() {
            demos();
        }
    };
}();

// Initialization
jQuery(document).ready(function() {
    KTSummernoteDemo.init();
});
