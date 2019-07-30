(function () {
    $(function () {

        var _orderItemService = abp.services.app.orderItem;
        var _$modal = $('#OrderItemCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate({
        });

        $('#RefreshButton').click(function () {
            refreshOrderItemList();
        });

        $('.delete-orderItem').click(function () {
            var orderItemId = $(this).attr("data-orderItem-id");
            var orderItemName = $(this).attr('data-orderItem-name');

            deleteOrderItem(orderItemId, orderItemName);
        });

        $('.refresh-product').click(function (e) {
            var orderItemId = $(this).attr("data-orderItem-id");

            _orderItemService.updateProductDetails(orderItemId).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new orderItem!
            });

        });

        $('.edit-orderItem').click(function (e) {
            var orderItemId = $(this).attr("data-orderItem-id");

            e.preventDefault();

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'OrderItem/Edit?orderItemId=' + orderItemId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    console.log("success")
                    $('#OrderItemEditModal div.modal-content').html(content);
                },
                error: function (e) { console.log("Failure") }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var orderItem = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            console.log(orderItem);


            abp.ui.setBusy(_$modal);
            _orderItemService.create(orderItem).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new orderItem!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshOrderItemList() {
            location.reload(true); //reload page to see new orderItem!
        }

        function deleteOrderItem(orderItemId, orderItemName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'UltimateInvocing'), orderItemName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _orderItemService.delete(orderItemId).done(function () {
                            refreshOrderItemList();
                        });
                    }
                }
            );
        }
    });
})();