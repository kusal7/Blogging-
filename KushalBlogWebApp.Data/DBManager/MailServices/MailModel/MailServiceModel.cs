using Microsoft.AspNetCore.Http;

namespace DBManager.MailServices.MailModel
{
    /// <summary>
    /// The mail service model.
    /// </summary>
    public class MailServiceModel
    {
        /// <summary>
        /// Gets or sets the mail for.
        /// </summary>
        public string MailFor { get; set; }
        /// <summary>
        /// Gets or sets the recipient name.
        /// </summary>
        public string RecipientName { get; set; }
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the mail to.
        /// </summary>
        public string MailTo { get; set; }
        /// <summary>
        /// Gets or sets the mail cc.
        /// </summary>
        public string MailCc { get; set; }
        /// <summary>
        /// Gets or sets the mail bcc.
        /// </summary>
        public string MailBcc { get; set; }
        /// <summary>
        /// Gets or sets the mail subject.
        /// </summary>
        public string MailSubject { get; set; }
        /// <summary>
        /// Gets or sets the mail body.
        /// </summary>
        public string MailBody { get; set; }
        /// <summary>
        /// Gets or sets the mail attachement.
        /// </summary>
        public List<IFormFile> MailAttachement { get; set; }
    }

    /// <summary>
    /// The mail message settings model.
    /// </summary>
    public class MailMessageSettingsModel
    {
        /// <summary>
        /// Gets or sets the mail for.
        /// </summary>
        public string MailFor { get; set; }
        /// <summary>
        /// Gets or sets the mail to.
        /// </summary>
        public string MailTo { get; set; }
        /// <summary>
        /// Gets or sets the mail c c.
        /// </summary>
        public string MailCC { get; set; }
        /// <summary>
        /// Gets or sets the mail b c c.
        /// </summary>
        public string MailBCC { get; set; }
        /// <summary>
        /// Gets or sets the mail subject.
        /// </summary>
        public string MailSubject { get; set; }
        /// <summary>
        /// Gets or sets the mail body.
        /// </summary>
        public string MailBody { get; set; }
        /// <summary>
        /// Gets or sets the mail attachement.
        /// </summary>
        public List<IFormFile> MailAttachement { get; set; }
    }

    /// <summary>
    /// The mail request model.
    /// </summary>
    public class MailRequestModel
    {
        /// <summary>
        /// Gets or sets the mail for.
        /// </summary>
        public string MailFor { get; set; }
        /// <summary>
        /// Gets or sets the mail to.
        /// </summary>
        public string MailTo { get; set; }
        /// <summary>
        /// Gets or sets the mail subject.
        /// </summary>
        public string MailSubject { get; set; }
        /// <summary>
        /// Gets or sets the recipient name.
        /// </summary>
        public string RecipientName { get; set; }
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        public List<IFormFile> Attachments { get; set; }
    }

    /// <summary>
    /// The mail configuration.
    /// </summary>
    public class MailConfiguration
    {
        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// Gets or sets the mail from.
        /// </summary>
        public string MailFrom { get; set; }
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }
        //public string To { get; set; }
        //public string Cc { get; set; }
        //public string Bcc { get; set; }
    }
}
