var order = {
    init: function () {
        order.registerEvents();
    },


    registerEvents: function () {
        $('.btnCancelOrder').off('click').on('click', function (e) {
            e.preventDefault();
            $('#ReasonCancel').modal('show');
            $('#hidOrderID').val($(this).data('id'));
        });


        $('#btnConfirmCancelOrder').off('click').on('click', function () {
            var id = $('#hidOrderID').val();
            var reasonCacel = $('#txtReason').val();
            console.log(id);
           
            $.ajax({
                url: '/Account/CancelOrder',
                type: 'GET',
                data: {
                    id: id,
                    reasonCacel: reasonCacel
                },
                success: function (res) {
                    $('#ReasonCancel').modal('hide');
                    alert("Hủy đơn hàng thành công!");                  
                    location.reload();
                }
                
            });
        });
    },
}
order.init();
