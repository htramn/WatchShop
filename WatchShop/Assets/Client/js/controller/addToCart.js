$(document).ready(function () {
    $("#btnAddToCart").click(function (event) {
        event.preventDefault();
        var productid = $(this).attr("data-productid");
        var quantity = $("#txtquantity").val();
        $.ajax({
            type: "GET",
            url: "/Cart/AddItem",
            data: {
                productId: productid,
                quantity: quantity
            },
        });
    });

});