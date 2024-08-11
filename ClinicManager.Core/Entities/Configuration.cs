namespace ClinicManager.Core.Entities
{
    public static class Configuration
    {
        public static SmtpConfiguracao Smtp = new SmtpConfiguracao();
        public static SmsConfiguracao Sms = new SmsConfiguracao();
        public static GoogleConfiguracao Calendar = new GoogleConfiguracao();

        public class SmtpConfiguracao
        {
            public string Host { get; set; } = string.Empty;
            public int Port { get; set; }
            public string UserName { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }

        public class SmsConfiguracao
        {
            public string awsAccessKeyId { get; set; } = string.Empty;
            public string awsSecretAccessKey { get; set; } = string.Empty;


        }
        public class GoogleConfiguracao
        {
            public GoogleConfiguracaoWebConfig Web { get; set; } = new GoogleConfiguracaoWebConfig();   
        }

        public class GoogleConfiguracaoWebConfig
        {
            public string ClientId { get; set; } = string.Empty;
            public string ProjectId { get; set; } = string.Empty;
            public string AuthUri { get; set; } = string.Empty;
            public string TokenUri { get; set; } = string.Empty;
            public string AuthProviderX509CertUrl { get; set; } = string.Empty;
            public string ClientSecret { get; set; } = string.Empty;
            public List<string> RedirectUris { get; set; } = [];
            public List<string> JavascriptOrigins { get; set; } = [];
        }

    }
}
