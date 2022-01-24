using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TesteKryptusMVVM.ViewModels
{
    class DashboardViewModel : INotifyPropertyChanged
    {
        private string _ipv4;
        private string _ipv6;
        private string _mac;
        private string _mtu;
        private string _dataAtualizacao;

        public string Ipv4
        {
            get => _ipv4;
            set
            {
                if(value != _ipv4)
                {
                    _ipv4 = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Ipv6
        {
            get => _ipv6;
            set
            {
                if (value != _ipv6)
                {
                    _ipv6 = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Mac
        {
            get => _mac;
            set
            {
                if (value != _mac)
                {
                    _mac = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Mtu
        {
            get => _mtu;
            set
            {
                if (value != _mtu)
                {
                    _mtu = value;
                    OnPropertyChanged();
                }
            }
        }

        public string DataAtualizacao
        {
            get => _dataAtualizacao;
            set
            {
                if (value != _dataAtualizacao)
                {
                    _dataAtualizacao = value;
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
