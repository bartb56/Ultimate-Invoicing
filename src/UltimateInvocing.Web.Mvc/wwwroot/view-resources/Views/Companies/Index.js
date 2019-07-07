(function () {
    $(function () {

        var _companyService = abp.services.app.company;
        var _$modal = $('#CompanyCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate({
        });

        $('#RefreshButton').click(function () {
            refreshCompanyList();
        });

        $('.delete-company').click(function () {
            var companyId = $(this).attr("data-company-id");
            var companyName = $(this).attr('data-company-name');

            deleteCompany(companyId, companyName);
        });

        $('.edit-company').click(function (e) {
            var companyId = $(this).attr("data-company-id");

            e.preventDefault();

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Company/EditCompanyModel?id=' + companyId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    console.log("success")
                    $('#CompanyEditModal div.modal-content').html(content);
                },
                error: function (e) { console.log("Failure") }
            });
        });

        $("#extendedToggle").on("click", function () {
            $("#logoExtended").css("display", "none");
            $("#logoExtended img").remove();
        });

        $(".table-responsive .logo").on("click", function () {
            var clone = $(this).clone();
            clone.id = "extendedImg"; 
            $("#logoExtended").append(clone);
            $("#logoExtended").css("display", "block")
        });

        _$form.find('#CountryId').on("change", function (e) {
            var countryId = $(this).val();
            var select = _$form.find('#ProvinceId');
            select.empty();
            select.selectpicker("refresh");

            $.ajax({
                url: 'Address/UpdateProvinceList?countryId=' + countryId,
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

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }
            _$form.submit();
            //var company = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            //company.permissions = [];
            //var _$permissionCheckboxes = $("input[name='permission']:checked");
            //if (_$permissionCheckboxes) {
            //    for (var permissionIndex = 0; permissionIndex < _$permissionCheckboxes.length; permissionIndex++) {
            //        var _$permissionCheckbox = $(_$permissionCheckboxes[permissionIndex]);
            //        company.permissions.push(_$permissionCheckbox.val());
            //    }
            //}

            //abp.ui.setBusy(_$modal);
            //_companyService.create(company).done(function () {
            //    _$modal.modal('hide');
            //    location.reload(true); //reload page to see new company!
            //}).always(function () {
            //    abp.ui.clearBusy(_$modal);
            //});
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshCompanyList() {
            location.reload(true); //reload page to see new company!
        }

        function deleteCompany(companyId, companyName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'UltimateInvocing'), companyName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _companyService.delete(companyId).done(function () {
                            refreshCompanyList();
                        });
                    }
                }
            );
        }
    });
})();