using ClinicManager.Core.Entities;
using System.Net;
using System.Net.Mail;
using System.Xml.Linq;

namespace ClinicManager.Core.Services.Email
{
    public class EmailService : IEmailService
    {
        public bool Send(string toName, string toEmail, string subject, string bodyMail, string date, string fromName = "", string fromEmail = "", string bodyNotification = "")
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
            <p><strong>Data da consulta:</strong> {date}</p>
            <p><strong>Descrição da consulta:</strong></p>
            <p>{bodyMail}</p>
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

            if (!string.IsNullOrEmpty(bodyNotification))
            {
                body = this.bodyNotification(toName, date, fromName, fromEmail);

            }

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

        public string bodyNotification(string toName, string hoursRemaining, string fromName, string fromEmail)
        {
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
        <p>Sua consulta está agendada para amanhã.</p>
        <p>Faltam <strong>{hoursRemaining}</strong> horas para a sua consulta.</p>
        <p>Veja no seu e-mail para mais detalhes e não deixe de comparecer.</p>
        <p>Atenciosamente,<br>
        <strong>{fromName}</strong><br>
        {fromEmail}</p>
        <div class='footer'>
            <p>Esta é uma mensagem automática, por favor, não responda este e-mail.</p>
        </div>
    </div>
</body>
</html>";

            return body;

        }

    }
}
