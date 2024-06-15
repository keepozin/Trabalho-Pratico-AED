using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string caminhoEntrada = "C:\\Users\\jpcam\\OneDrive\\Área de Trabalho\\TrabPrat\\Trabalho-Pratico-AED\\ConsoleApp1\\entrada.txt";
            string caminhoSaida = "C:\\Users\\jpcam\\OneDrive\\Área de Trabalho\\TrabPrat\\Trabalho-Pratico-AED\\ConsoleApp1\\saida.txt";
            ProcessoSeletivo processo = new ProcessoSeletivo();

            using (StreamReader reader = new StreamReader(caminhoEntrada))
            {
                string linha = reader.ReadLine();
                var primeiraLinha = linha.Split(';');
                int numeroCursos = int.Parse(primeiraLinha[0]);
                int numeroCandidatos = int.Parse(primeiraLinha[1]);

                for (int i = 0; i < numeroCursos; i++)
                {
                    linha = reader.ReadLine();
                    var dadosCurso = linha.Split(';');
                    int codigoCurso = int.Parse(dadosCurso[0]);
                    string nomeCurso = dadosCurso[1];
                    int vagasCurso = int.Parse(dadosCurso[2]);
                    processo.AdicionarCurso(codigoCurso, nomeCurso, vagasCurso);
                }

                for (int i = 0; i < numeroCandidatos; i++)
                {
                    linha = reader.ReadLine();
                    var dadosCandidato = linha.Split(';');
                    string nomeCandidato = dadosCandidato[0];
                    double notaRedacao = double.Parse(dadosCandidato[1]);
                    double notaMatematica = double.Parse(dadosCandidato[2]);
                    double notaLinguagens = double.Parse(dadosCandidato[3]);
                    int primeiraOpcao = int.Parse(dadosCandidato[4]);
                    int segundaOpcao = int.Parse(dadosCandidato[5]);

                    Candidato candidato = new Candidato(nomeCandidato, notaRedacao, notaMatematica, notaLinguagens, primeiraOpcao, segundaOpcao);
                    processo.AdicionarCandidato(candidato);
                }
            }

            processo.ProcessarSelecao();
            processo.GerarRelatorio(caminhoSaida);

            Console.WriteLine("Processo seletivo concluído. Verifique o arquivo de saída para os resultados.");
            Console.ReadLine();
        }
    }
}