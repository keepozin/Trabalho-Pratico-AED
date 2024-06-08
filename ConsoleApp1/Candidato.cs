using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Candidato
    {
        private string nome;
        private double notaRedacao;
        private double notaMatematica;
        private double notaLinguagens;
        private int primeiraOpcao;
        private int segundaOpcao;

        public Candidato(string nome, double notaRedacao, double notaMatematica, double notaLinguagens, int primeiraOpcao, int segundaOpcao)
        {
            this.nome = nome;
            this.notaRedacao = notaRedacao;
            this.notaMatematica = notaMatematica;
            this.notaLinguagens = notaLinguagens;
            this.primeiraOpcao = primeiraOpcao;
            this.segundaOpcao = segundaOpcao;
        }

        public double Media()
        {

            return (notaRedacao + notaMatematica + notaLinguagens) / 3;
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public double NotaRedacao
        {
            get { return notaRedacao; }
            set { notaRedacao = value; }
        }

        public double NotaMatematica
        {
            get { return notaMatematica; }
            set { notaMatematica = value; }
        }

        public double NotaLinguagens
        {
            get { return notaLinguagens; }
            set { notaLinguagens = value; }
        }

        public int PrimeiraOpcao
        {
            get { return primeiraOpcao; }
            set { primeiraOpcao = value; }
        }

        public int SegundaOpcao
        {
            get { return segundaOpcao; }
            set { segundaOpcao = value; }
        }
    }
}