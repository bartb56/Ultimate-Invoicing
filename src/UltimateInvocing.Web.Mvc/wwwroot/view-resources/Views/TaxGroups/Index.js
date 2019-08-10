(function () {
    $(function () {

        var _taxGroupService = abp.services.app.taxGroup;
        var _$modal = $('#TaxGroupCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate({
        });

        $('#RefreshButton').click(function () {
            refreshTaxGroupList();
        });

        $('.delete-taxGroup').click(function () {
            var taxGroupId = $(this).attr("data-taxGroup-id");
            var taxGroupName = $(this).attr('data-taxGroup-name');

            deleteTaxGroup(taxGroupId, taxGroupName);
        });

        $('.edit-taxGroup').click(function (e) {
            var taxGroupId = $(this).attr("data-taxGroup-id");

            e.preventDefault();

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'TaxGroup/EditTaxGroupModal?taxGroupId=' + taxGroupId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    console.log("success")
                    $('#TaxGroupEditModal div.modal-content').html(content);
                },
                error: function (e) { console.log("Failure") }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var taxGroup = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            taxGroup.permissions = [];
            var _$permissionCheckboxes = $("input[name='permission']:checked");
            if (_$permissionCheckboxes) {
                for (var permissionIndex = 0; permissionIndex < _$permissionCheckboxes.length; permissionIndex++) {
                    var _$permissionCheckbox = $(_$permissionCheckboxes[permissionIndex]);
                    taxGroup.permissions.push(_$permissionCheckbox.val());
                }
            }

            abp.ui.setBusy(_$modal);
            _taxGroupService.create(taxGroup).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new taxGroup!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshTaxGroupList() {
            location.reload(true); //reload page to see new taxGroup!
        }

        function deleteTaxGroup(taxGroupId, taxGroupName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'UltimateInvocing'), taxGroupName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _taxGroupService.delete(taxGroupId).done(function () {
                            refreshTaxGroupList();
                        });
                    }
                }
            );
        }
    });
})();