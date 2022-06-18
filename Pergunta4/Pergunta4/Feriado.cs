using System;
using System.Collections.Generic;
using System.Text;

namespace Pergunta4
{
    public class Feriado
    {
        //Crio o modelo para facilitar a leitura do arquivo de feriados

        public Feriado(DateTime data, string descricao)
        {
            Data = data;
            Descricao = descricao;
        }

        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public string DataFormatada => Data.ToString("dd/MM/yyyy");
    }
}
