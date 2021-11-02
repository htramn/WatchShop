$(document).ready(function () {
    $("#btnAddCoupon").click(function (event) {
        event.preventDefault();
        var code = $(".txtCoupon").val();
        $.ajax({
            type: "GET",
            url: "/Payment/AddCoupon",
            data: {
                code: code
            },
            success: function (res) {
                location.reload();
            }
        });
    });
});