var review = {
    init: function () {
        review.registerEvents();
    },


    registerEvents: function () {
        $('.btnReview').off('click').on('click', function (e) {
            e.preventDefault();
            $('#reviewModal').modal('show');
            $('#hidProductID').val($(this).data('id'));
        });


        $('#btnSendReview').off('click').on('click', function () {
            var idProduct = $('#hidProductID').val();
            var comment = $('#txtComment').val();
            console.log(idProduct);

            $.ajax({
                url: '/Account/Rating',
                type: 'GET',
                data: {
                    idProduct: idProduct,
                    comment: comment
                },
                success: function (res) {
                    $('#reviewModal').modal('hide');
                    alert("Cảm ơn quý khách đã mua hàng, và gửi nhận xét cho chúng tôi!");
                    location.reload();
                }

            });
        });
    },
}
review.init();