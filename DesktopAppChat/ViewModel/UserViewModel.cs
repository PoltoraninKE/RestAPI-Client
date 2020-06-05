using DesktopAppChat.Additionals;
using DesktopAppChat.Data;
using DesktopAppChat.Views;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using System;
using System.IO;
using System.Net;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DesktopAppChat.ViewModel
{
    class UserViewModel : ViewModelBase
    {
        
        private string login;
        private SecureString password;
        public SecureString Password
        {
            get => password;
            set 
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }


        private ICommand logIn;
        private ICommand signIn;

        public ICommand SignIn
        {
            get
            {
                if (signIn == null)
                {
                    signIn = new DelegateCommand(() => { SignWindow(); });
                }
                return signIn;
            }
        }

        public ICommand LogIn
        {
            get
            {
                if (logIn == null)
                {
                    logIn = new DelegateCommand(() => { LogInRequest(); });
                }
                return logIn;
            }
        }

        private void LogInRequest()
        {
            //Creating request with header 'Basic Authorization' and such data as Login + Password
            WebRequest httpWebRequest = WebRequest.Create("http://127.0.0.1:60737/token");
            httpWebRequest.Method = "POST";
            var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(login + ":" + DataConverter.UnsecureString(Password)));
            httpWebRequest.Headers.Add("Authorization", "Basic " + encoded);
            //Here should be response from this request
            try
            {
                WebResponse response = httpWebRequest.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var dataFromStream = reader.ReadToEnd();
                    var a_t = JObject.Parse(dataFromStream)["access_token"].ToString();
                    //UserDataSingletone uds = UserDataSingletone.GetInstance(login, a_t); if i’ll figure out how to do it, but for now static :)
                    UserDataStatic.Access_Token = a_t;
                    UserDataStatic.Login = login;
                }
                //MessageBox.Show("Welcome to SlothMessanger", "Messanger");
                var window = new ChatWindow();
                window.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void SignWindow()
        {
            SignInWindow window = new SignInWindow();
            window.Show();
        }

    }
}
