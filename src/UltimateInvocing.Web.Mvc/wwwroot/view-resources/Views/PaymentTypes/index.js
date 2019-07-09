(function () {
    $(function () {
        var _paymentTypeService = abp.services.app.paymentType;
        var _$modal = $('#PaymentTypeCreateModal');
        var _$form = _$modal.find('form');
        _$form.validate({
        });

        $('#RefreshButton').click(function () {
            refreshProductList();
        });

        $('.delete-paymentType').click(function () {
            var paymentTypeId = $(this).attr("data-paymentType-id");
            var paymentTypeName = $(this).attr('data-paymentType-name');

            deleteProduct(paymentTypeId, paymentTypeName);
        });

        $('.edit-paymentType').click(function (e) {
            var paymentTypeId = $(this).attr("data-paymentType-id");

            e.preventDefault();

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'PaymentType/EditPaymentTypeModal?paymentTypeId=' + paymentTypeId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    console.log("success")
                    $('#PaymentTypeEditModal div.modal-content').html(content);
                },
                error: function (e) { console.log("Failure") }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();
            if (!_$form.valid()) {
                return;
            }

            var paymentType = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            console.log(paymentType);


            abp.ui.setBusy(_$modal);
            _paymentTypeService.create(paymentType).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new paymentType!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshProductList() {
            location.reload(true); //reload page to see new paymentType!
        }

        function deleteProduct(paymentTypeId, paymentTypeName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'UltimateInvocing'), paymentTypeName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _paymentTypeService.delete(paymentTypeId).done(function () {
                            refreshProductList();
                        });
                    }
                }
            );
        }
    });
})();