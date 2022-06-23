using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtualizaMalha : MonoBehaviour
{
    public Vector3[] listaVertices;
    // Start is called before the first frame update
    void Start()
    {
        listaVertices = GetComponent<MeshFilter>().mesh.vertices;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void atualizaVertice(PontosClicaveis ob)
    {
        // foreach(int p in ob.vertices)
        // {
        //     listaVertices[p] += ob.movimento;
        // }
        listaVertices[ob.indice] += ob.movimento;
        for(int i = 0; i < listaVertices.Length; i++)
        {
            if(listaVertices[i].x == ob.posAnterior.x && listaVertices[i].y == ob.posAnterior.y && listaVertices[i].z > 0)
            {
                listaVertices[i].x += ob.movimento.x;
                listaVertices[i].y += ob.movimento.y;
            }
        }
    }

    // public void atualizaVertice2(List<dynamic> ob){
    //     // listaVertices[int.Parse(ob[0].x.ToString())] += ob[1];
    //     foreach(int p in ob[0].vertices)
    //     {
    //         listaVertices[p] += ob[1];
    //     }
    //     for(int i = 0; i < listaVertices.Length; i++){
    //         if(listaVertices[i].x == ob[2].x && listaVertices[i].y == ob[2].y && listaVertices[i].z > 0){
    //             listaVertices[i].x += ob[1].x;
    //             listaVertices[i].y += ob[1].y;
    //         }
    //     }
    //     // print("pos: " + int.Parse(ob[0].x.ToString()) + " valor: " + ob[1]);
    // }

    public void atualizaMalha()
    {
        GetComponent<MeshFilter>().mesh.vertices = listaVertices;
        listaVertices = GetComponent<MeshFilter>().mesh.vertices;
    }

    public void atualizaListaVertices()
    {
        listaVertices = GetComponent<MeshFilter>().mesh.vertices;
    }
}
