using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Fila
{
    private Candidato[] candidatos;
    private int primeiro;
    private int ultimo;
    private int tamanho;

    public Fila(int tamanhoMaximo)
    {
        candidatos = new Candidato[tamanhoMaximo];
        primeiro = 0;
        ultimo = -1;
        tamanho = tamanhoMaximo;
    }

    public void Inserir(Candidato candidato)
    {
        for (int i = primeiro; i <= ultimo; i++)
        {
            if (candidatos[i].Nome == candidato.Nome)
            {
                return; 
            }
        }

        if (ultimo < tamanho - 1)
        {
            int posicaoInsercao = ultimo + 1;

            while (posicaoInsercao > 0 && candidato.Media() > candidatos[posicaoInsercao - 1].Media())
            {
                candidatos[posicaoInsercao] = candidatos[posicaoInsercao - 1];
                posicaoInsercao--;
            }

            candidatos[posicaoInsercao] = candidato;
            ultimo++;
        }
        else if (candidato.Media() > candidatos[primeiro].Media())
        {
            for (int i = primeiro; i < ultimo; i++)
            {
                candidatos[i] = candidatos[i + 1];
            }

            candidatos[ultimo] = candidato;
        }
    }

    public int Tamanho
    {
        get { return tamanho; }
    }

    public int Primeiro
    {
        get { return primeiro; }
    }

    public int Ultimo
    {
        get { return ultimo; }
    }

    public List<Candidato> ObterLista()
    {
        List<Candidato> lista = new List<Candidato>();
        for (int i = primeiro; i <= ultimo; i++)
        {
            lista.Add(candidatos[i]);
        }
        return lista;
    }

    public void Limpar()
    {
        primeiro = 0;
        ultimo = -1;
    }
}
}