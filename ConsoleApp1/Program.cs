using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string caminhoEntrada = "entrada.txt";
            string caminhoSaida = "saida.txt";

            ProcessoSeletivo processo = new ProcessoSeletivo();
            
            using (StreamReader reader = new StreamReader(caminhoEntrada))
            {
                string linha = reader.ReadLine();
                var primeiroLinha = linha.Split(' ');

                int numeroCursos = int.Parse(primeiroLinha[0]);
                int numeroCandidatos = int.Parse(primeiroLinha[1]);

                for (int i = 0; i < numeroCursos; i++)
                {
                    linha = reader.ReadLine();
                    var dados = linha.Split(';');
                    int codigo = int.Parse(dados[0]);
                    string nome = dados[1];
                    int vagas = int.Parse(dados[2]);

                    processo.AdicionarCurso(codigo, nome, vagas);
                }

                for (int i = 0; i < numeroCandidatos; i++)
                {
                    linha = reader.ReadLine();
                    var dados = linha.Split(';');

                    string nome = dados[0];
                    double notaRedacao = double.Parse(dados[1]);
                    double notaMatematica = double.Parse(dados[2]);
                    double notaLinguagens = double.Parse(dados[3]);
                    int primeiraOpcao = int.Parse(dados[4]);
                    int segundaOpcao = int.Parse(dados[5]);

                    Candidato candidato = new Candidato(nome, notaRedacao, notaMatematica, notaLinguagens, primeiraOpcao, segundaOpcao);
                    processo.AdicionarCandidato(candidato);
                }
            }

            processo.ProcessarSelecao();

            processo.GerarRelatorio(caminhoSaida);
        }
    }
}