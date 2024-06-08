using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

        private int CompararCandidatos(Candidato candidatoA, Candidato candidatoB)
        {
            double mediaAlunoA = candidatoA.Media();
            double mediaAlunoB = candidatoB.Media();

            if (mediaAlunoA > mediaAlunoB)
            {
                return -1;
            }
            else if (mediaAlunoA < mediaAlunoB)
            {
                return 1;
            }
            else
            {
                double notaRedacaoA = candidatoA.NotaRedacao;
                double notaRedacaoB = candidatoB.NotaRedacao;

                if (notaRedacaoA > notaRedacaoB)
                {
                    return -1;
                }
                else if (notaRedacaoA < notaRedacaoB)
                {
                    return 1;
                }
                else
                {
                    double notaMatematicaA = candidatoA.NotaMatematica;
                    double notaMatematicaB = candidatoB.NotaMatematica;

                    if (notaMatematicaA > notaMatematicaB)
                    {
                        return -1;
                    }
                    else if (notaMatematicaA < notaMatematicaB)
                    {
                        return 1;
                    }
                    else
                    {
                        double notaLinguagensA = candidatoA.NotaLinguagens;
                        double notaLinguagensB = candidatoB.NotaLinguagens;

                        if (notaLinguagensA > notaLinguagensB)
                        {
                            return -1;
                        }
                        else if (notaLinguagensA < notaLinguagensB)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
        }
        public void ProcessarSelecao()
        {

        }
        public void GerarRelatorio(string caminhoArquivo)
        {
            
        }
    }
}