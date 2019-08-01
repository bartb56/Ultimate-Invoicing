(function ($) {

    var _roleService = abp.services.app.order;
    var _$modal = $('#OrderEditModal');
    var _$form = $('form[name=OrderEditForm]');
    var _$checkbox = true;

    function save() {

        if (!_$form.valid()) {
            return;
        }

        var role = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

        abp.ui.setBusy(_$form);
        _roleService.update(role).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page to see edited role!
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    }

    _$form.find("#CustomerId").on('change', function (e) {
        var customerId = $(this).val();
        var select = _$form.find('#AddressId');
        select.empty();
        select.selectpicker("refresh");

        $.ajax({
            url: abp.appPath + 'Orders/UpdateAddresses/' + customerId,
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

    //Handle save button click
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    //Handle enter key
    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    $.AdminBSB.input.activate(_$form);

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);