(function ($) {

    var _roleService = abp.services.app.company;
    var _$modal = $('#CompanyEditModal');
    var _$form = $('form[name=CompanyEditForm]');

    function save() {

        if (!_$form.valid()) {
            return;
        }
        _$form.submit();
        var role = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

        abp.ui.setBusy(_$form);
        _roleService.update(role).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page to see edited role!
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    }
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