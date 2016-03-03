using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using FaculdadeGuararapes.Controllers;
using FaculdadeGuararapes.Models;
using Newtonsoft.Json;
using System.Windows.Media;
using System.Windows.Threading;

namespace FaculdadeGuararapes
{
    public partial class Postagens : PhoneApplicationPage
    {
        private string nome;
        private string senha;
        private AlunoController alunoController;
        private PushController pushController;
        private DispatcherTimer dispatcherTimer;

        public Postagens()
        {
            InitializeComponent();
            Loaded += Postagens_Loaded;
            alunoController = new AlunoController();
            pushController = new PushController();

            

        }

        

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var user = (BaseAlunoAutentic)NavigationService.GetNavigationData();
            nome = user.nome;
            senha = user.senha;
        }
        private async void Postagens_Loaded(object sender, RoutedEventArgs e)
        {
            BaseAlunoAutentic aut = new BaseAlunoAutentic()
            {
                nome = nome,
                senha = senha
            };
            var message = await alunoController.Listar(aut);
            if (message != null)
            {
                var read = await message.Content.ReadAsStringAsync();
                var client = JsonConvert.DeserializeObject<IEnumerable<BaseAlunoList>>(read);

                string curso = string.Join(",", client.Select(i => i.Curso));
                string periodo = string.Join(",", client.Select(i => i.Periodo));
                string turno = string.Join(",", client.Select(i => i.Turno));
                string semestre = string.Join(",", client.Select(i => i.Semestre));

                Enviar(curso, periodo, turno, semestre);
            }
            else
            {
                MessageBox.Show("Erro ao acessar os dados!");
            }
        }
        public async void Enviar(string curso, string periodo,string turno,string semestre)
        {
            BasePropPush push = new BasePropPush()
            {
                curso = curso,
                periodo = periodo,
                turno = turno,
                semestre = semestre
            };
            var message = await pushController.ListarPush(push);
            if (message != null)
            {
                var read = await message.Content.ReadAsStringAsync();
                var client = JsonConvert.DeserializeObject<IEnumerable<BasePushList>>(read);
                LstServerData.ItemsSource = client;
            }

        }

        private void StackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            

        }

        
    }
}