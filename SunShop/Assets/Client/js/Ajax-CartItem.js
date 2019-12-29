$(document).ready(function () {
    $(".btnAddItem").on("click", function () {
        var btn = $(this);
        var id = btn.data("id");
        $.ajax({
            url: "/CartItem/AddItem",
            data: { productID: id, quantity: 1 },
            type: "POST",
            dataType: "Json",
            success: function (data) {
                alert("Thêm thành công");
                $('"#' + id + '"').css("display", "block");

                
            },
            error: function (err) {
                alert("Có lỗi xảy ra " + err.statusText);
            }
        });
    });
})