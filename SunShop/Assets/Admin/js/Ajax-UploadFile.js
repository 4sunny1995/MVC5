
$(document).ready(function () {
    
    //Event handler when click btnUpload
    $("#btnUpload").click(function () {
        $("#fileUpload").trigger("click");
    });
    //Event handler when change fileUpload
    $("#fileUpload").change(function () {
        //check trình Formdata on IE
        if (window.FormData !== undefined) {
            //getData
            var fileUpload = $("#fileUpload").get(0);
            var files = fileUpload.files;
            //khởi tạo form data
            var formData = new FormData();
            //set data in formdata
            formData.append("file", files[0]);
            $.ajax({
                type: "POST",
                url: "/Admin/Product/ProcessUpload",
                contentType: false, //no header
                processData: false,// no processing
                data:formData,
                success: function (fileName) {
                    
                    $('#pictureUpload').attr("src", "~/Assets/Client/img/Upload/"+fileName);
                    $("#picture").val(fileName);
                    $("#fileUpload").file.fileName = fileName;
                },
                error: function (err) {
                    alert("Có lỗi trong khi upload " + err.statusText);
                }
            });
            
        }
    });
});