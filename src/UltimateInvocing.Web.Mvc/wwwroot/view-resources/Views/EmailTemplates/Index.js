(function () {
    $(function () {

        var _emailTemplateService = abp.services.app.emailTemplate;
        var _$modal = $('#EmailTemplateCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate({
        });

        $('#RefreshButton').click(function () {
            refreshEmailTemplateList();
        });

        _$emailModal = $("#EmailSettingsEditModal");
        _$emailSettingsForm = $("form[name='emailSettingsForm']");

        $('#OpenSettings').click(function () {
            $("#DefaultFromAddress").val(abp.setting.get("Abp.Net.Mail.DefaultFromAddress"));
            $("#SmtpHost").val(abp.setting.get("Abp.Net.Mail.Smtp.Host"));
            $("#SmtpPort").val(abp.setting.get("Abp.Net.Mail.Smtp.Port"));
            $("#DefaultFromDisplayName").val(abp.setting.get("Abp.Net.Mail.DefaultFromDisplayName"));
            $("#UserName").val(abp.setting.get("Abp.Net.Mail.DefaultFromAddress"));
            $("#EnableSsl").val(abp.setting.get("Abp.Net.Mail.Smtp.EnableSsl"));
            var settingsForm = $("form[name='emailSettingsForm']");
            $.AdminBSB.input.activate(settingsForm);
        });

        $('.delete-emailTemplate').click(function () {
            var emailTemplateId = $(this).attr("data-emailTemplate-id");
            var emailTemplateName = $(this).attr('data-emailTemplate-name');
            deleteEmailTemplate(emailTemplateId, emailTemplateName);
        });

        $('.edit-emailTemplate').click(function (e) {
            var emailTemplateId = $(this).attr("data-emailTemplate-id");

            e.preventDefault();

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'EmailTemplate/EditEmailTemplateModal?emailTemplateId=' + emailTemplateId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#EmailTemplateEditModal div.modal-content').html(content);
                },
                error: function (e) { console.log("Failure") }
            });
        });

        _$emailSettingsForm.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            var data = _$emailSettingsForm.serializeFormToObject();
            abp.ui.setBusy(_$emailModal);
            abp.services.app.email.updateEmailSettings(data).done(function () {
                _$emailModal.modal('hide');
            }).always(function () {
                abp.ui.clearBusy(_$emailModal);
            });
        })
        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();


            $(".ql-tooltip").remove();
            $("#HtmlContent").val(quill.container.innerHTML);

            if (!_$form.valid()) {
                return;
            }


            var emailTemplate = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            console.log(emailTemplate);

            abp.ui.setBusy(_$modal);
            _emailTemplateService.create(emailTemplate).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new emailTemplate!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshEmailTemplateList() {
            location.reload(true); //reload page to see new emailTemplate!
        }

        function deleteEmailTemplate(emailTemplateId, emailTemplateName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'UltimateInvocing'), emailTemplateName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _emailTemplateService.delete(emailTemplateId).done(function () {
                            refreshEmailTemplateList();
                        });
                    }
                }
            );
        }
    });
})();