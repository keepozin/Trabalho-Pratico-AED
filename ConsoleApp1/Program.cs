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
        /*    string caminhoEntrada = "entrada.txt";
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
                    string nomeCurso = dados[1];
                    int vagas = int.Parse(dados[2]);

                    processo.AdicionarCurso(codigo, nomeCurso, vagas);
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
*/
            ProcessoSeletivo processo = new ProcessoSeletivo();
            
            processo.candidatos.Add(new Candidato("João", 9, 8, 6));
            processo.candidatos.Add(new Candidato("Maria", 9, 8, 9));
            processo.candidatos.Add(new Candidato("Ana", 7, 7, 8));
            processo.candidatos.Add(new Candidato("Pedro", 9, 8, 7));
            
            Ordenacao.Quicksort(processo.candidatos, 0, processo.candidatos.Count - 1);

            foreach (var candidato in processo.candidatos)
            {
                Console.WriteLine(candidato.ToString());
            }
            Console.ReadLine();
        }
    }
}