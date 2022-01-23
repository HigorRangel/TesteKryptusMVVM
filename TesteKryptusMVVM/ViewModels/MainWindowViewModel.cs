using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace TesteKryptusMVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Bitmap _logoImage;
        private string _path;
        private string _user;
        private string _password;

        public Bitmap LogoImage
        {
            get => _logoImage;
            set
            {
                if (value != _logoImage)
                {
                    _logoImage = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Path
        {
            get => _path;
            set
            {
                if (value != _path)
                {
                    _path = value;
                    OnPropertyChanged();
                }
            }
        }

        public string User
        {
            get => _user;
            set
            {
                if (value != _user)
                {
                    _user = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
