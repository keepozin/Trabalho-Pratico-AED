using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Curso
    {
        public int codigo;
        public string nome;
        public int vagas;
        public List<Candidato> selecionados;
        public Fila filaEspera;

        public Curso(int codigo, string nome, int vagas)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.vagas = vagas;
            selecionados = new List<Candidato>();
            filaEspera = new Fila(10);
        }

        public void AdicionarSelecionado(Candidato candidato)
        {
            if (selecionados.Count < vagas)
            {
                selecionados.Add(candidato);
            }
        }

        public void AdicionarFilaEspera(Candidato candidato)
        {
            filaEspera.Inserir(candidato);
        }

        public double GetNotaDeCorte()
        {
            if (selecionados.Count > 0)
            {
                double menorMedia = selecionados[0].Media();
                foreach (var candidato in selecionados)
                {
                    if (candidato.Media() < menorMedia)
                    {
                        menorMedia = candidato.Media();
                    }
                }
                return menorMedia;
            }
            else
            {
                return 0;
            }
        }
    }
}