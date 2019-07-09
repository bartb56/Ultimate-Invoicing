(function () {
    $(function () {

        var _countryService = abp.services.app.country;
        var _$modal = $('#CountryCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate({
        });

        $('#RefreshButton').click(function () {
            refreshCountryList();
        });

        $('.delete-country').click(function () {
            var countryId = $(this).attr("data-country-id");
            var countryName = $(this).attr('data-country-name');
            deleteCountry(countryId, countryName);
        });

        $('.edit-country').click(function (e) {
            var countryId = $(this).attr("data-country-id");

            e.preventDefault();

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Country/EditCountryModal?countryId=' + countryId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#CountryEditModal div.modal-content').html(content);
                },
                error: function (e) { console.log("Failure") }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var country = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            console.log(country);

            abp.ui.setBusy(_$modal);
            _countryService.create(country).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new country!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshCountryList() {
            location.reload(true); //reload page to see new country!
        }

        function deleteCountry(countryId, countryName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'UltimateInvocing'), countryName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _countryService.deleteCustom(countryId).done(function () {
                            refreshCountryList();
                        });
                    }
                }
            );
        }
    });
})();