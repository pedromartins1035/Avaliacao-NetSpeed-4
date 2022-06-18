using System;
using System.Linq;

namespace Pergunta4
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateO = new DateTime();
            var dateN = new DateTime();
            decimal valBoleto = 0;
            decimal valBoletoR = 0;
            decimal juros = 0.03m;
            decimal multa = 2;

            Console.Write("Informe a data original de vencimento: ");
            dateO = DateTime.Parse(Console.ReadLine());

            Console.Write("Informe a data de pagamento: ");
            dateN = DateTime.Parse(Console.ReadLine());

            Console.Write("Informe o valor do boleto: ");
            valBoleto = decimal.Parse(Console.ReadLine());

            int numDias = dateN.Day - dateO.Day;

            if (Feriado(dateO) == true || FinalSemana(dateO) == true)
            {
                if(numDias == 1)
                {
                    valBoletoR = valBoleto;
                    Console.Write($"O valor do boleto recalculado é: {valBoletoR}");
                }
                    
                else if(numDias == 3 && dateN.DayOfWeek == DayOfWeek.Monday)
                {
                    valBoletoR = valBoleto;
                    Console.Write($"O valor do boleto recalculado é: {valBoletoR}");
                }
                else if (numDias == 3)
                {
                    juros = juros * numDias;
                    valBoletoR = valBoleto + multa + juros;
                    Console.Write($"O valor do boleto recalculado é: {valBoletoR}");
                }
                else if(numDias <= 2)
                {
                    valBoletoR = valBoleto;
                    Console.Write($"O valor do boleto recalculado é: {valBoletoR}");
                }
                else if(numDias == 4)
                {
                    juros = juros * numDias;
                    valBoletoR = valBoleto + multa + juros;
                    Console.Write($"O valor do boleto recalculado é: {valBoletoR}");
                }

            }
            else if(Feriado(dateO) == false && FinalSemana(dateO) == false)
            {
                if(numDias <= 0)
                {
                    valBoletoR = valBoleto;
                    Console.Write($"O valor do boleto recalculado é: {valBoletoR}");
                }
                else if(numDias >= 1)
                {
                    juros = juros * numDias;
                    valBoletoR = valBoleto + multa + juros;
                    Console.Write($"O valor do boleto recalculado é: {valBoletoR}");
                }
            }
        }

        static bool Feriado(DateTime data)
        {
            var feriados = LeitorCSV.ObterFeriados();
            return feriados.Any(x => x.Data == data);
        }

        static bool FinalSemana(DateTime data)
        {
            return data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday;
        }

    }
}
