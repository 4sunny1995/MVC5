$(document).ready(function () {
    $("#Upload-file").change(function () {
        var formData = new FormData();
        var totalFiles = document.getElementById("Upload-file").files.length;
        var code = $("#code").val();
        for (var i = 0; i < totalFiles; i++) {
            var file = document.getElementById("Upload-file").files[i];
            formData.append("Upload-file", file);
        }
        $.ajax({
            type:"POST",
            URL:'/Admin/Product/Upload',
            data: formData,
            datatype: 'json',
            contentType: false,
            processData:false
        }).done(function () {
            alert("success");
        }.fail(function (xhr, status, errorThrown) {
            alert("fail");
        }
        ))
    })
})