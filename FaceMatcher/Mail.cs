using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace FaceMatcher
{
    public class Mail
    {
        private string _adresseSource;
        private string _motdepasseSource;
        private string _adresseDestinataire;
        

        public Mail(string source, string motdepasse, string destinataire)
        {
            _adresseSource = source;
            _adresseDestinataire = destinataire;
            _motdepasseSource = motdepasse;
        }

        public void Envoyer(string objet, string corps, string chemin_attachement="")
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_adresseSource);
            mail.To.Add(_adresseDestinataire);
            mail.Subject = objet;
            mail.Body = corps;

            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(_adresseSource, _motdepasseSource);
            SmtpServer.EnableSsl = true;

            if (chemin_attachement.Length > 0)
                mail.Attachments.Add(new Attachment(chemin_attachement));

            SmtpServer.Send(mail);

        }

       

    }
}
