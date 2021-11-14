using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TransitorImagens.Models
{
    public class GoogleSheet
    {
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };

        private static readonly string NomeAplicacao = System.Configuration.ConfigurationSettings.AppSettings["NomeAplicacao"].ToString();

        private static readonly string SpreadsheetId = System.Configuration.ConfigurationSettings.AppSettings["SpreadsheetId"].ToString();

        private static readonly string TituloPlanilha = System.Configuration.ConfigurationSettings.AppSettings["TituloPlanilha"].ToString();

        private static readonly string TempoTransicao = System.Configuration.ConfigurationSettings.AppSettings["TempoTransicao"].ToString();

        private static SheetsService Service;

        /// <summary>
        /// Metodo responsável por chamar os métodos das credenciais e da leitura de entidades da planilha
        /// <!--Criação: Pedro Lucas dos Santos Constantino-->
        /// <!--Data: 13/10/2021-->
        /// </summary>
        /// <returns>Retorna o link das imagens em formato de List<string></returns>
        public static List<string> Sheets()
        {
            try
            {
                Credenciais();
                return LerEntidades();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo responsável pelas credenciais
        /// <!--Criação: Pedro Lucas dos Santos Constantino-->
        /// <!--Data: 13/10/2021-->
        /// </summary>
        public static void Credenciais()
        {
            try
            {
                GoogleCredential credencial;

                using (var stream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Client_secrets.json", FileMode.Open, FileAccess.Read))
                {
                    credencial = GoogleCredential.FromStream(stream)
                        .CreateScoped(Scopes);
                }

                Service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
                {
                    HttpClientInitializer = credencial,
                    ApplicationName = NomeAplicacao,
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo responsável por retornar as entidades da planilha
        /// <!--Criação: Pedro Lucas dos Santos Constantino-->
        /// <!--Data: 13/10/2021-->
        /// </summary>
        /// <returns>Retorna o link das imagens em formato de List<string></returns>
        public static List<string> LerEntidades()
        {
            try
            {
                var alcance = $"{TituloPlanilha}!A2:N";
                var requisicao = Service.Spreadsheets.Values.Get(SpreadsheetId, alcance);

                var resposta = requisicao.Execute();
                var valor = resposta.Values;

                List<string> lista = new List<string>();
                if (valor != null && valor.Count > 0)
                {
                    foreach (var item in valor)
                    {
                        lista.Add(item[2].ToString());
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo responsável por retornar o tempo que as imagens serão passadas
        /// <!--Criação: Pedro Lucas dos Santos Constantino-->
        /// <!--Data: 25/10/2021-->
        /// </summary>
        /// <returns>Retorna um double o tempo em milissegundos<string></returns>
        public static double BuscaTempo()
        {
            return double.Parse(TempoTransicao) * 1000;
        }
    }
}