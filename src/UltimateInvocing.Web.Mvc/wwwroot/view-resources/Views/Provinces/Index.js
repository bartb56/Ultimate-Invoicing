(function () {
    $(function () {

        var _provinceService = abp.services.app.province;
        var _$modal = $('#ProvinceCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate({
        });

        $('#RefreshButton').click(function () {
            refreshProvinceList();
        });

        $('.delete-province').click(function () {
            var provinceId = $(this).attr("data-province-id");
            var provinceName = $(this).attr('data-province-name');

            deleteProvince(provinceId, provinceName);
        });

        $('.edit-province').click(function (e) {
            var provinceId = $(this).attr("data-province-id");

            e.preventDefault();

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Province/EditProvinceModal?provinceId=' + provinceId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    console.log("success")
                    $('#ProvinceEditModal div.modal-content').html(content);
                },
                error: function (e) { console.log("Failure") }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var province = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            province.permissions = [];
            var _$permissionCheckboxes = $("input[name='permission']:checked");
            if (_$permissionCheckboxes) {
                for (var permissionIndex = 0; permissionIndex < _$permissionCheckboxes.length; permissionIndex++) {
                    var _$permissionCheckbox = $(_$permissionCheckboxes[permissionIndex]);
                    province.permissions.push(_$permissionCheckbox.val());
                }
            }

            abp.ui.setBusy(_$modal);
            _provinceService.create(province).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new province!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshProvinceList() {
            location.reload(true); //reload page to see new province!
        }

        function deleteProvince(provinceId, provinceName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'UltimateInvocing'), provinceName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _provinceService.delete(provinceId).done(function () {
                            refreshProvinceList();
                        });
                    }
                }
            );
        }
    });
})();