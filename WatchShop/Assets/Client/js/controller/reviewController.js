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

        $(document).on('input', '#rating', function () {
            $('#slider_value').html($(this).val());
        });


        $('#btnSendReview').off('click').on('click', function () {
            var idProduct = $('#hidProductID').val();
            var rating = $('#slider_value').val();
            var comment = $('#txtComment').val();
            console.log(idProduct);

            $.ajax({
                url: '/Account/Rating',
                type: 'GET',
                data: {
                    idProduct: idProduct,
                    comment: comment,
                    rating:rating
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