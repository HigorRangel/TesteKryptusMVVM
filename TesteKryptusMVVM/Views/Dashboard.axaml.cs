using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using TesteKryptusMVVM.ViewModels;

namespace TesteKryptusMVVM.Views
{
    public partial class Dashboard : Window
    {
        DashboardViewModel context;
        public Dashboard()
        {
            InitializeComponent();

            this.AttachDevTools();

            this.DataContext = new DashboardViewModel() { Ipv4 = "-", Ipv6 = "-", Mac = "-", Mtu = "-" };
            context = this.DataContext as DashboardViewModel;
            Thread mensagem = new Thread(new ThreadStart(getDataThread));
            mensagem.Start();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private string executeWindowsCmd(string comando)
        {

            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "ipconfig.exe";
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            p.WaitForExit();

            string output = p.StandardOutput.ReadToEnd();

            Encoding iso = Encoding.GetEncoding("us-ascii");
            Encoding utf8 = Encoding.UTF8;
            byte[] utfBytes = utf8.GetBytes(output);
            byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
            output = iso.GetString(isoBytes);


            return output;
        }


        public void getDataThread()
        {
            while (true)
            {
                getData();
                Thread.Sleep(TimeSpan.FromSeconds(30));

            }

        }

        public void getData()
        {
            context.DataAtualizacao = "Atualizado em " + DateTime.Now.ToString("G");

            string textCmd = executeWindowsCmd("");
            textCmd = Regex.Replace(textCmd, @"\. ", "");
            char[] delims = new[] { '\r', '\n' };

            List<string> listInfo = textCmd.Split(delims, StringSplitOptions.RemoveEmptyEntries).OfType<string>().ToList();
            Dictionary<string, string> dictInfo = new Dictionary<string, string>();

            for (int i = 0; i < listInfo.Count(); i++)
            {
                try
                {
                    string[] splitData = Regex.Split(listInfo[i], @" : ");
                    //Regex para retirar caracteres dentro de parênteses
                    dictInfo.Add(splitData[0].Trim(), Regex.Replace(splitData[1], @"\(([^()]+)\)", "").Trim());
                }
                catch (Exception e)
                {
                }
            }

            //context.Mac = dictInfo["Endere?o F?sico"];
            context.Ipv4 = dictInfo["Endere?o IPv4"];
            context.Ipv6 = dictInfo["Endere?o IPv6"];
        }

        public void OnStarWarsPressed(object sender, PointerPressedEventArgs args)
        {
            this.Hide();
            StarWars starWars = new StarWars();
            starWars.Show();

        }

        public void OnRefreshPressed(object sender, PointerPressedEventArgs args)
        {
            getData();
        }
    }
}
