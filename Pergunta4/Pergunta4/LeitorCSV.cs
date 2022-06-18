using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Pergunta4
{
    public static class LeitorCSV
    {
        public static IEnumerable<Feriado> ObterFeriados()
        {
            //Crio a lista com os feriados e leio todas as linhas

            var feriados = new List<Feriado>();
            var linhas = File.ReadAllLines("./feriados_nacionais.csv");

            //Faço um foreach percorrendo as linhas e separando as datas da descrição por virgula e no fim retorno os feriados

            foreach(var linha in linhas)
            {
                var dados = linha.Split(",");
                feriados.Add(new Feriado(DateTime.ParseExact(dados[0], "dd/MM/yyyy", CultureInfo.InvariantCulture), dados[1]));
            }

            return feriados;
        }
    }
}
