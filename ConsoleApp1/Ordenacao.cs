using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Ordenacao
    {
        public static void Quicksort(List<Candidato> candidatos, int left, int right)
        {
            if (left < right)
            {
                int pivot = Particao(candidatos, left, right);
                Quicksort(candidatos, left, pivot - 1);
                Quicksort(candidatos, pivot + 1, right);
            }
        }
        private static int Particao(List<Candidato> candidatos, int left, int right)
        {
            Candidato pivot = candidatos[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (ProcessoSeletivo.CompararCandidatos(candidatos[j], pivot) < 0)
                {
                    i++;
                    Swap(candidatos, i, j);
                }
            }

            Swap(candidatos, i + 1, right);
            return i + 1;
        }

        private static void Swap(List<Candidato> candidatos, int i, int j)
        {
            Candidato temp = candidatos[i];
            candidatos[i] = candidatos[j];
            candidatos[j] = temp;
        }
    }
}
