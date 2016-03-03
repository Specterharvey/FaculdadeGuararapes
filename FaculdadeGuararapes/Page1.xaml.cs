using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using FaculdadeGuararapes.Models;
using FaculdadeGuararapes.Controllers;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FaculdadeGuararapes
{
    public partial class Page1 : PhoneApplicationPage
    {
        private AlunoController aluno;

        public Page1()
        {
            InitializeComponent();
            aluno = new AlunoController();
            
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            BaseAlunoAutentic aut = new BaseAlunoAutentic()
            {
                nome = Nome.Text,
                senha = Senha.Text
            };
            var message = await aluno.Autenticar(aut);
            //var message = await aluno.Autenticar(Nome.Text,Senha.Text);
            //if (message != null)
            //{
            //    var read = await ConvertJson(message);
            //}
            //MessageBox.Show(message.);
            string a = await message.Content.ReadAsStringAsync();
            MessageBox.Show(a);

            //var g = await message.Content.ReadAsAsync<List<BaseAlunoList>>();

            
        }
        //private async Task<BaseAlunoAutentic> ConvertJson(HttpResponseMessage response)
        //{
        //    string read = await response.Content.ReadAsStringAsync();
        //    var client = JsonConvert.DeserializeObject<BaseAlunoAutentic>(read);
        //    return client;
        //}
    }
}