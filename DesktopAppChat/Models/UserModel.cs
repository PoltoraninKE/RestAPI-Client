using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DesktopAppChat.Models
{
    public class UserModel : INotifyPropertyChanged
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Access_Token { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public UserModel() { }

    }
}
