using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Curso
    {
        public int codigo;
        public string nomeCurso;
        public int vagas;
        public List<Candidato> selecionados; 
        public Fila filaEspera;
        public Curso(int codigo, string nomeCurso, int vagas)
        {
            this.codigo = codigo;
            this.nomeCurso = nomeCurso;
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

        public double NotaCorte()
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

        public void OrdenarFilaEspera()
        {
            List<Candidato> candidatosFila = FilaEspera.ObterLista();

            
            Ordenacao.Quicksort(candidatosFila, 0, candidatosFila.Count - 1);

            
            FilaEspera.Limpar();
            foreach (var candidato in candidatosFila.Take(10))
            {
                FilaEspera.Inserir(candidato);
            }
        }

        public int Codigo
        {
            get { return codigo; }
        }

        public string NomeCurso
        {
            get { return nomeCurso; }
        }

        public int Vagas
        {
            get { return vagas; }
        }

        public List<Candidato> Selecionados 
        {
            get { return selecionados; }
        }

        public Fila FilaEspera
        {
            get { return filaEspera; }
        }
    }
}