var product = {
    init: function () {
        product.setStatusEvent();
    },
    setStatusEvent: function () {
        $('.ajax-status-product').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/Product/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        btn.removeClass("text-danger");
                        btn.addClass("text-success");
                        btn.html("Còn hàng");
                    }
                    else {
                        btn.removeClass("text-success");
                        btn.addClass("text-danger");
                        btn.html("Hết hàng");

                    }

                }
            })
        })
    }

}
product.init()