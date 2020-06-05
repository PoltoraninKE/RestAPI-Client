using DesktopAppChat.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace DesktopAppChat.ViewModel
{
    class SignInViewModel : ViewModelBase
    {

        private string login;
        private string password;

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

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private ICommand signIn;

        public ICommand SignIn
        {
            get
            {
                if (signIn == null)
                {
                    signIn = new DelegateCommand(() => { SignInRequest(); });
                }
                return signIn;
            }
        }

        private void SignInRequest()
        {
            string data = "{ \"login\" : \"" + login
                         +"\", \"password\" : \"" + password 
                         +"\" }";
            byte[] dataByte = Encoding.GetEncoding("ISO-8859-1").GetBytes(data);
            try
            {
                WebRequest httpWebRequest = WebRequest.Create("http://127.0.0.1:60737/sign_in");
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.ContentLength = dataByte.Length;
                using (Stream stream = httpWebRequest.GetRequestStream())
                {
                    stream.Write(dataByte, 0, dataByte.Length);
                }
                WebResponse response = httpWebRequest.GetResponse();
                response.Close();
                MessageBox.Show("You have been registered");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
