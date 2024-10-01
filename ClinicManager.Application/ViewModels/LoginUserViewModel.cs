namespace ClinicManager.Application.ViewModels
{
    public class LoginUserViewModel
    {
        public LoginUserViewModel(string userName, string token)
        {
            UserName = userName;
            Token = token;
        }

        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
