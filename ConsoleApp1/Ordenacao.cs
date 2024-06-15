using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Ordenacao
    {
        public static void Quicksort(List<Candidato> candidatos, int esquerda, int direita)
        {
            if (esquerda < direita)
            {
                int indiceParticao = Particao(candidatos, esquerda, direita);
            }
        }

        private static int Particao(List<Candidato> candidatos, int esquerda, int direita)
        {
            Candidato pivo = candidatos[direita];
            int i = esquerda - 1;

            for (int j = esquerda; j < direita; j++)
            {
                if (CompararCandidatos(candidatos[j], pivo) <= 0)
                {
                    i++;
                    Trocar(candidatos, i, j);
                }
            }

            Trocar(candidatos, i + 1, direita);
            return i + 1;
        }

        private static void Trocar(List<Candidato> candidatos, int i, int j)
        {
            Candidato temp = candidatos[i];
            candidatos[i] = candidatos[j];
            candidatos[j] = temp;
        }

        public static int CompararCandidatos(Candidato candidatoA, Candidato candidatoB)
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
    }
}