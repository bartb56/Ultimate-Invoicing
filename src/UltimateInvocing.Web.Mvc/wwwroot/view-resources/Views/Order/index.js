(function () {
    $(function () {

        var _orderService = abp.services.app.order;
        var _$modal = $('#OrderCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate({
        });

        $('#RefreshButton').click(function () {
            refreshOrderList();
        });

        $('.delete-order').click(function () {
            var orderId = $(this).attr("data-order-id");
            var orderName = $(this).attr('data-order-name');

            deleteOrder(orderId, orderName);
        });

        $('.edit-order').click(function (e) {
            var orderId = $(this).attr("data-order-id");

            e.preventDefault();

            $.ajax({
                url: abp.appPath + "Orders/EditOrderModal/" + orderId,
                type: "POST",
                success: function (content) {
                    console.log("success")
                    $('#OrderEditModal div.modal-content').html(content);
                },
                error: function (e) { console.log("Failure") }
            });
        });

        $('.update-customer').click(function (e) {
            var orderId = $(this).attr("data-order-id");

            e.preventDefault();

            $.ajax({
                url: abp.appPath + "Order/UpdateCustomerDetails?orderId=" + orderId,
                type: "POST",
                success: function () {
                    location.reload(true);
                }
            });

        });

        $('.update-company').click(function (e) {
            var orderId = $(this).attr("data-order-id");

            e.preventDefault();

            $.ajax({
                url: abp.appPath + "Order/UpdateCompanyDetails?orderId=" + orderId,
                type: "POST",
                success: function () {
                    location.reload(true);
                }
            })

        });

        _$form.find("#CustomerId").on('change', function (e) {
            var customerId = $(this).val();
            var select = _$form.find('#AddressId');
            select.empty();
            select.selectpicker("refresh");

            $.ajax({
                url: abp.appPath + 'Order/UpdateAddresses?customerId=' + customerId,
                type: 'POST',
                dataType: "json",
                success: function (content) {
                    console.log(content);
                    var provinces = content.result;
                    console.log(provinces);
                    var i = 0;
                    $.each(provinces, function () {
                        select.append("<option value='" + provinces[i].id + "'>" + provinces[i].streetAddress + " " + provinces[i].houseNumber + " " + provinces[i].postalCode + " " + "</option>")
                        i++;
                    });
                    select.selectpicker("refresh");
                },
                done: function (data) {
                    console.log(data);
                },
                error: function (jqXHR, exception) {
                    var msg = '';
                    if (jqXHR.status === 0) {
                        msg = 'Not connect.\n Verify Network.';
                    } else if (jqXHR.status == 404) {
                        msg = 'Requested page not found. [404]';
                    } else if (jqXHR.status == 500) {
                        msg = 'Internal Server Error [500].';
                    } else if (exception === 'parsererror') {
                        msg = 'Requested JSON parse failed.';
                    } else if (exception === 'timeout') {
                        msg = 'Time out error.';
                    } else if (exception === 'abort') {
                        msg = 'Ajax request aborted.';
                    } else {
                        msg = 'Uncaught Error.\n' + jqXHR.responseText;
                    }
                    alert(msg);
                }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            console.log(_$form);
            var order = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            console.log(order);


            abp.ui.setBusy(_$modal);
            _orderService.create(order).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new order!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshOrderList() {
            location.reload(true); //reload page to see new order!
        }

        function deleteOrder(orderId, orderName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'UltimateInvocing'), orderName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _orderService.delete(orderId).done(function () {
                            refreshOrderList();
                        });
                    }
                }
            );
        }
    });
})();