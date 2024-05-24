using System;
using System.Collections.Generic;

public class Network
{
    private List<int>[] ListaDeControle;

    public Network(int n)
    {
        if (n <= 0)
            throw new ArgumentException("O número de elementos deve ser um inteiro positivo.");

        ListaDeControle = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            ListaDeControle[i] = new List<int>();
        }
    }

    public void connect(int x, int y)
    {
        ValidarInteiroNalista(x);
        ValidarInteiroNalista(y);

        if (!ListaDeControle[x].Contains(y))
        {
            ListaDeControle[x].Add(y);
        }

        if (!ListaDeControle[y].Contains(x))
        {
            ListaDeControle[y].Add(x);
        }
    }

    public bool query(int x, int y)
    {
        ValidarInteiroNalista(x);
        ValidarInteiroNalista(y);

        bool[] visitado = new bool[ListaDeControle.Length];
        return EstaConectado(x, y, visitado);
    }

    private bool EstaConectado(int x, int y, bool[] visitado)
    {
        if (x == y) return true;

        visitado[x] = true;

        foreach (int vizinho in ListaDeControle[x])
        {
            if (!visitado[vizinho] && EstaConectado(vizinho, y, visitado))
            {
                return true;
            }
        }

        return false;
    }

    private void ValidarInteiroNalista(int x)
    {
        if (x < 0 || x >= ListaDeControle.Length)
            throw new ArgumentException($"Número inválido: {x}. O Número deve estar entre 0 e {ListaDeControle.Length - 1}.");
    }
}
