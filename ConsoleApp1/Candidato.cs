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
            double media = (notaRedacao + notaMatematica + notaLinguagens) / 3.0;
            return media;
        }

        public string Nome
        {
            get { return nome; }
        }

        public double NotaRedacao
        {
            get { return notaRedacao; }
        }

        public double NotaMatematica
        {
            get { return notaMatematica; }
        }

        public double NotaLinguagens
        {
            get { return notaLinguagens; }
        }

        public int PrimeiraOpcao
        {
            get { return primeiraOpcao; }
        }

        public int SegundaOpcao
        {
            get { return segundaOpcao; }
        }
    }
}