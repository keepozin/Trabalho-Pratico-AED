using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    public class ProcessoSeletivo
    {
        private List<Candidato> candidatos;
        private Dictionary<int, Curso> cursos;
        public ProcessoSeletivo()
        {
            candidatos = new List<Candidato>();
            cursos = new Dictionary<int, Curso>();
        }

        public void AdicionarCandidato(Candidato candidato)
        {
            candidatos.Add(candidato);
        }

        public void AdicionarCurso(int codigo, string nome, int vagas)
        {
            cursos[codigo] = new Curso(codigo, nome, vagas);
        }

        public void ProcessarSelecao()
        {
            Ordenacao.Quicksort(candidatos, 0, candidatos.Count - 1);

            foreach (var candidato in candidatos)
            {
                int primeiraOpcao = candidato.PrimeiraOpcao;
                int segundaOpcao = candidato.SegundaOpcao;

                if (cursos.ContainsKey(primeiraOpcao))
                {
                    Curso cursoPrimeiraOpcao = cursos[primeiraOpcao];

                    if (cursoPrimeiraOpcao.Selecionados.Count < cursoPrimeiraOpcao.Vagas)
                    {
                        cursoPrimeiraOpcao.AdicionarSelecionado(candidato);
                    }
                    else if (cursos.ContainsKey(segundaOpcao))
                    {
                        Curso cursoSegundaOpcao = cursos[segundaOpcao];

                        if (cursoSegundaOpcao.Selecionados.Count < cursoSegundaOpcao.Vagas)
                        {
                            cursoSegundaOpcao.AdicionarSelecionado(candidato);
                            cursoSegundaOpcao.AdicionarFilaEspera(candidato);
                        }
                        else
                        {
                            cursoPrimeiraOpcao.AdicionarFilaEspera(candidato);
                            cursoSegundaOpcao.AdicionarFilaEspera(candidato);
                        }
                    }
                    else
                    {
                        cursoPrimeiraOpcao.AdicionarFilaEspera(candidato);
                    }
                }
            }
        }

        public void GerarRelatorio(string caminhoArquivo)
        {
            using (StreamWriter writer = new StreamWriter(caminhoArquivo))
            {
                foreach (var curso in cursos.Values)
                {
                    writer.WriteLine($"{curso.NomeCurso} {curso.NotaCorte():F2}");
                    writer.WriteLine("Selecionados");

                    Ordenacao.Quicksort(curso.Selecionados, 0, curso.Selecionados.Count - 1);

                    foreach (var candidato in curso.Selecionados)
                    {
                        writer.WriteLine($"{candidato.Nome} {candidato.Media():F2} {candidato.NotaRedacao} {candidato.NotaMatematica} {candidato.NotaLinguagens}");
                    }

                    writer.WriteLine("Fila de Espera");

                    List<Candidato> candidatosFila = curso.FilaEspera.ObterLista();

                    foreach (var candidato in candidatosFila)
                    {
                        writer.WriteLine($"{candidato.Nome} {candidato.Media():F2} {candidato.NotaRedacao} {candidato.NotaMatematica} {candidato.NotaLinguagens}");
                    }

                    writer.WriteLine();
                }
            }
        }
    }
}