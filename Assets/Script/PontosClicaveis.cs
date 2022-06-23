using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontosClicaveis
{
    public Vector3 pos;
    // public List<int> vertices = new List<int>();
    public int indice;
    public List<PontosClicaveis> vizinhos = new List<PontosClicaveis>();
    public Vector3 movimento;
    public Vector3 posAnterior;
    // public Vector2 uv;
    public List<Face> faces = new List<Face>();

    public PontosClicaveis(Vector3 posicao)
    {
        pos = posicao;
        movimento = Vector3.zero;
        posAnterior = posicao;
    }

    public override int GetHashCode()
    {
        return pos.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if(obj == null || !(obj is PontosClicaveis)) return false;
        return pos.Equals(((PontosClicaveis)obj).pos);
    }
}
