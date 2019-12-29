var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $("#btnContinue").off('click').on('click', function () {
            window.location.href = "/HomeBasic/homePage";
        });
        $("btnAccept").off('click').on('click', function () {
            var UserName = $("input[name=txtUserName]").val();
            var txtPhone = $("input[name=txtPhone]").val();
            var txtAddress = $("input[name=txtAddress]").val();
            var userID = $("#getid").val();
            $.ajax({
                url: "/CartItem/Thanhtoan",
                type:"POST",
                data: {
                    userID: userID
                },
                success:function(){
                    alert("Thành công");
                },
                error: function () {
                    alert("Thất bại");
                }
            });

        })
        $("#btnUpdate").off("click").on('click', function () {
            var listproduct = $(".txtquantity");
            var cartList = [];
            $.each(listproduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        ID: $(item).data("id")
                    }
                });
            });
            $.ajax({
                url: "/CartItem/Update",
                data: { cartModel: JSON.stringify(cartList) },
                dataType: "json",
                type: "POST",
                success: function (res) {
                    if (res.status==true) {
                        window.location.href = "/CartItem/Index";
                    }
                    
                }
            })
        });
        $("#btnDeleteAll").off("click").on('click', function () {
            
            $.ajax({
                url: "/CartItem/DeleteAll",
                dataType: "json",
                type: "POST",
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/CartItem/Index";
                    }
                    else {

                    }
                }
            });
        });
    }
}
cart.init();