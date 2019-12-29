$(window).ready(function () {
    $("#btnsearchID").click(function () {
        var key = $("#searchID").val();
        $.ajax({
            type: "POST",
            datatype: "JSON",
            data: key,
            url: "/Admin/User/findByID",
            success: function (data) {
                $("#resultID").html("<div style='background-color:red'></div>");
            },
            error: function (err) {
                alert("Có lỗi xảy ra " + err.statusText);
            }
        });
    })
})