﻿using Common.Application.Services.Abstraction;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace UserManagement.Web.Code
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(ISystemSettingsService systemSettingsService)
        {
            SystemSettingsService = systemSettingsService;
        }

        public ISystemSettingsService SystemSettingsService { get; }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {

                using (SmtpClient smtp = new SmtpClient(SystemSettingsService.SmtpSystemSettings.SmtpServer, SystemSettingsService.SmtpSystemSettings.SmtpPort))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential(SystemSettingsService.SmtpSystemSettings.SmtpUserName, SystemSettingsService.SmtpSystemSettings.SmtpPassword);
                    var mail = new MailMessage(new MailAddress("christmas@ja-software.dk", "Christmas_Application AutoAdmin"), new MailAddress(email, email))
                    {
                        Body = htmlMessage,
                        IsBodyHtml = true,
                        Subject = subject
                    };
                    smtp.Send(mail);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
