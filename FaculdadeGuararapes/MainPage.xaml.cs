using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using FaculdadeGuararapes.Resources;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using FaculdadeGuararapes.Models;
using FaculdadeGuararapes.Controllers;
using System.Text.RegularExpressions;
using System.Collections;

namespace FaculdadeGuararapes
{
    public partial class MainPage : PhoneApplicationPage
    {
        private AlunoController alunoController;
        private string a;
        private BaseAlunoAutentic aut;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            alunoController = new AlunoController();
            
        }
        private void Sair(object sender, EventArgs e)
        {
            MessageBoxButton buttons = MessageBoxButton.OKCancel;
            MessageBoxResult result = MessageBox.Show("Sair?", "FG", buttons);
            if (result == MessageBoxResult.OK)
            {
                Application.Current.Terminate();
            }
            else
            {
                InitializeComponent();
            }
        }
        private void sobre(object sender, EventArgs e)
        {
            MessageBox.Show("Aplicativo criado por bla bla bla");
        }  
        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            if (UserName.Text == "" || PassWord.Password == "")
            {
                MessageBox.Show("Preencha os Campos");
            }
            else
            {
                try
                {
                    aut = new BaseAlunoAutentic()
                    {
                        nome = UserName.Text,
                        senha = PassWord.Password
                    };
                    var message = await alunoController.Autenticar(aut);
                     a = await message.Content.ReadAsStringAsync();
                    MessageBox.Show(a);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //Uri uri = new Uri(string.Concat(a,"");
                    if (a == @"""Logado""")
                    {
                        NavigationService.Navigate(new Uri("/Postagens.xaml", UriKind.Relative),aut);
                    }
                }               
            }
        }
    }   
}