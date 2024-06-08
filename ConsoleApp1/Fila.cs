using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Fila
    {
        private Candidato[] array;
        private int primeiro;
        private int ultimo;
        private int tamanho;
        private int contador;

        public Fila(int tamanho)
        {
            this.tamanho = tamanho;
            array = new Candidato[tamanho + 1];
            primeiro = ultimo = 0;
            contador = 0;
        }

        public void Inserir(Candidato x)
        {
            if (((ultimo + 1) % array.Length) == primeiro)
            {
                return;
            }
            array[ultimo] = x;
            ultimo = (ultimo + 1) % array.Length;
            contador++;
        }

        public Candidato Remover()
        {
            if (primeiro == ultimo)
            {
                throw new Exception("Erro: A fila está vazia");
            }
            Candidato resp = array[primeiro];
            primeiro = (primeiro + 1) % array.Length;
            contador--;
            return resp;
        }

        public void Mostrar()
        {
            int i = primeiro;
            Console.WriteLine("Fila: ");
            while (i != ultimo)
            {
                Console.WriteLine(array[i].Nome);
                i = (i + 1) % array.Length;
            }
            Console.WriteLine();
        }

        public bool Pesquisar(string nome)
        {
            bool achou = false;
            for (int i = primeiro; i != ultimo && !achou; i = ((i + 1) % array.Length))
            {
                if (array[i].Nome == nome)
                {
                    achou = true;
                }
            }
            return achou;
        }

        public int Contagem()
        {
            return contador;
        }
    }
}