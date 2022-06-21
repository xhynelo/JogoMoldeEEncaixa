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

    public override int GetHashCode()
    {
        return posicao.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if(obj == null || !(obj is PontoTemporario)) return false;
        return posicao.Equals(((PontoTemporario)obj).posicao);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
