using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontoTemporario
{
    public Vector3 posicao;
    public PontosClicaveis v1;
    public PontosClicaveis v2;
    public int indice;
    public GameObject go;

    public PontoTemporario(PontosClicaveis v1, PontosClicaveis v2)
    {
        this.v1 = v1;
        this.v2 = v2;
        posicao = (v1.pos + v2.pos)/2;
    }

    public PontosClicaveis criarPontoClicavel()
    {
        PontosClicaveis ponto = new PontosClicaveis(posicao);
        // Cria ponto
        // Percorre face
        //   apaga face
        //   cria 2 faces
        //     v1 v2 ponto
        //     v2 ponto v3
        return ponto;
    }


    public override int GetHashCode()
    {
        return posicao.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if(obj == null || !(obj is PontoTemporario)) return false;
        return posicao.Equals(((PontoTemporario)obj).posicao);
    }

}
