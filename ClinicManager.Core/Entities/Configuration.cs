namespace ClinicManager.Core.Entities
{
    public static class Configuration
    {
        public static SmtpConfiguracao Smtp = new SmtpConfiguracao();
        public class SmtpConfiguracao
        {
            public string Host { get; set; } = string.Empty;
            public int Port { get; set; }   
            public string UserName { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }
    }
}
