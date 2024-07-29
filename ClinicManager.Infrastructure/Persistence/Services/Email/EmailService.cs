using ClinicManager.Core.Entities;
using System.Net;
using System.Net.Mail;

namespace ClinicManager.Core.Services.Email
{
    public class EmailService : IEmailService
    {
        public bool Send(string toName, string toEmail, string subject, string consultaDescricao, string fromName = "", string fromEmail = "")
        {
            var smtpClient = new SmtpClient(Configuration.Smtp.Host, Configuration.Smtp.Port)
            {
                Credentials = new NetworkCredential(Configuration.Smtp.UserName, Configuration.Smtp.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };

            var mail = new MailMessage
            {
                From = new MailAddress(fromEmail, fromName),
                Subject = subject,
                IsBodyHtml = true
            };
            mail.To.Add(new MailAddress(toEmail, toName));

            string body = $@"
    <!DOCTYPE html>
    <html lang='en'>
    <head>
        <meta charset='UTF-8'>
        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
        <title>Consulta Agendada</title>
        <style>
            body {{
                font-family: Arial, sans-serif;
                background-color: #f4f4f4;
                color: #333;
                line-height: 1.6;
            }}
            .container {{
                max-width: 600px;
                margin: 20px auto;
                padding: 20px;
                background-color: #fff;
                border: 1px solid #ddd;
                border-radius: 10px;
            }}
            h1 {{
                color: #4CAF50;
            }}
            p {{
                font-size: 1.2em;
            }}
            .footer {{
                margin-top: 20px;
                font-size: 0.9em;
                color: #777;
            }}
        </style>
    </head>
    <body>
        <div class='container'>
            <h1>Consulta Agendada</h1>
            <p>Olá <strong>{toName}</strong>,</p>
            <p>Sua consulta está agendada com sucesso.</p>
            <p><strong>Descrição da consulta:</strong></p>
            <p>{consultaDescricao}</p>
            <p>Se você tiver alguma dúvida, por favor, entre em contato conosco.</p>
            <p>Atenciosamente,<br>
            <strong>{fromName}</strong><br>
            {fromEmail}</p>
            <div class='footer'>
                <p>Esta é uma mensagem automática, por favor, não responda este email.</p>
            </div>
        </div>
    </body>
    </html>";

            mail.Body = body;

            try
            {
                smtpClient.Send(mail);
            }
            catch
            {
                return false;
            }

            return true;
        }

    }
}
