(function () {
    $(function () {
        var _addressService = abp.services.app.address;
        var _provinceService = abp.services.app.province;
        var _$modal = $('#AddressCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate({
        });

        $('#RefreshButton').click(function () {
            refreshAddressList();
        });

        $('.delete-address').click(function () {
            var addressId = $(this).attr("data-address-id");
            var addressName = $(this).attr('data-address-name');

            deleteAddress(addressId, addressName);
        });

        $('.edit-address').click(function (e) {
            var addressId = $(this).attr("data-address-id");

            e.preventDefault();

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Address/EditAddressModal?addressId=' + addressId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    console.log("success")
                    $('#AddressEditModal div.modal-content').html(content);
                },
                error: function (e) { console.log("Failure") }
            });
        });

        _$form.find('#CountryId').on("change", function (e) {
            var countryId = $(this).val();
            var select = _$form.find('#ProvinceId');
            select.empty();
            select.selectpicker("refresh");

            $.ajax({
                url: abp.appPath + 'Address/UpdateProvinceList?countryId=' + countryId,
                type: 'POST',
                success: function (content) {
                    //console.log(content);
                    var provinces = content.result;
                    console.log(provinces);
                    var i = 0;
                    $.each(provinces, function () {
                        select.append("<option value='" + provinces[i].id + "'>" + provinces[i].name + "</option>")
                        i++;
                    });
                    select.selectpicker("refresh");
                }
            });
        })

        _$form.find("#Taxable").click(function (e) {

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

            var address = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            address.permissions = [];
            var _$permissionCheckboxes = $("input[name='permission']:checked");
            if (_$permissionCheckboxes) {
                for (var permissionIndex = 0; permissionIndex < _$permissionCheckboxes.length; permissionIndex++) {
                    var _$permissionCheckbox = $(_$permissionCheckboxes[permissionIndex]);
                    address.permissions.push(_$permissionCheckbox.val());
                }
            }

            abp.ui.setBusy(_$modal);
            _addressService.create(address).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new address!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshAddressList() {
            location.reload(true); //reload page to see new address!
        }

        function deleteAddress(addressId, addressName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'UltimateInvocing'), addressName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _addressService.delete(addressId).done(function () {
                            refreshAddressList();
                        });
                    }
                }
            );
        }
    });
})();