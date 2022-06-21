using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontosClicaveis
{
    public List<int> vertices = new List<int>();
    public int indice;
    public List<PontosClicaveis> vizinhos = new List<PontosClicaveis>();
    public Vector3 pos;
    public Vector3 movimento;
    public Vector3 posAnterior;
    public Vector2 uv;
    public List<Face> faces = new List<Face>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
