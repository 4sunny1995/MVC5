$(window).ready(function () {
    $("#select1").click(function () {
        var temp = $(this).parent().find(".active");
        temp.removeClass("active");
        $(this).addClass("active");
        $("#Tieude").html("Thông tin cá nhân");
        $("#menu1").css("display", "block");
        $("#menu2").css("display", "none");
        $("#menu3").css("display", "none");
        $("#menu4").css("display", "none");
        $("#menu5").css("display", "none");
    });
    $("#select2").click(function () {
        var temp = $(this).parent().find(".active");
        temp.removeClass("active");
        $(this).addClass("active");
        $("#Tieude").html("Quản lý hình ảnh");
        $("#menu2").css("display", "block");
        $("#menu1").css("display", "none");
        $("#menu3").css("display", "none");
        $("#menu4").css("display", "none");
        $("#menu5").css("display", "none");
    });
    $("#select3").click(function () {
        var temp = $(this).parent().find(".active");
        temp.removeClass("active");
        $(this).addClass("active");
        $("#Tieude").html("Thay đổi mật khẩu")
        $("#menu3").css("display", "block");
        $("#menu2").css("display", "none");
        $("#menu1").css("display", "none");
        $("#menu4").css("display", "none");
        $("#menu5").css("display", "none");
    });
    $("#select4").click(function () {
        var temp = $(this).parent().find(".active");
        temp.removeClass("active");
        $(this).addClass("active");
        $("#Tieude").html("Lịch sử giao dịch");
        $("#menu4").css("display", "block");
        $("#menu2").css("display", "none");
        $("#menu3").css("display", "none");
        $("#menu1").css("display", "none");
        $("#menu5").css("display", "none");
    });
    $("#select5").click(function () {
        var temp = $(this).parent().find(".active");
        temp.removeClass("active");
        $(this).addClass("active");
        $("#Tieude").html("Báo cáo");
        $("#menu5").css("display", "block");
        $("#menu2").css("display", "none");
        $("#menu3").css("display", "none");
        $("#menu4").css("display", "none");
        $("#menu1").css("display", "none");
    });
})