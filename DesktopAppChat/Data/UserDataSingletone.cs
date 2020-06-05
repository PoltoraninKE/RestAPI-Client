using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopAppChat.Data
{
    //In progress
    public class UserDataSingletone
    {
        private UserDataSingletone() { }

        private static UserDataSingletone _instance;

        private static readonly object _lock = new object();

        public static UserDataSingletone GetInstance(string login, string access_token)
        {
            if (_instance == null)
            {
               
                lock (_lock)
                {
                    
                    if (_instance == null)
                    {
                        _instance = new UserDataSingletone();
                        _instance.Login = login;
                        _instance.Access_Token = access_token;
                    }
                }
            }
            return _instance;
        }

        public string Login { get; set; }
        public string Access_Token { get; set; }
    }
}