(function () {
    $(function () {

        var _productService = abp.services.app.product;
        var _$modal = $('#ProductCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate({
        });

        $('#RefreshButton').click(function () {
            refreshProductList();
        });

        $('.delete-product').click(function () {
            var productId = $(this).attr("data-product-id");
            var productName = $(this).attr('data-product-name');

            deleteProduct(productId, productName);
        });

        $('.edit-product').click(function (e) {
            var productId = $(this).attr("data-product-id");

            e.preventDefault();

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Product/EditProductModal?productId=' + productId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    console.log("success")
                    $('#ProductEditModal div.modal-content').html(content);
                },
                error: function (e) { console.log("Failure") }
            });
        });

        _$form.find("#IsAvailable").click(function (e) {

            if ($(this).val() == "True") {
                $(this).val("False");
            }
            else {
                $(this).val("True")
            }

        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var product = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            console.log(product);


            abp.ui.setBusy(_$modal);
            _productService.create(product).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new product!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshProductList() {
            location.reload(true); //reload page to see new product!
        }

        function deleteProduct(productId, productName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'UltimateInvocing'), productName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _productService.delete(productId).done(function () {
                            refreshProductList();
                        });
                    }
                }
            );
        }
    });
})();