using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdicionaVerticesClicaveis : MonoBehaviour
{
    public GameObject prefabVertice;
    public GameObject essaMalha;
    Dictionary<Vector3, PontosClicaveis> dictPontos = new Dictionary<Vector3, PontosClicaveis>();

    // Start is called before the first frame update
    void Start()
    {
        CriaClassPontos();
        adicionaVizinhos();
        instanciaPontosClicaveis();
    }

    void CriaClassPontos()
    //
    {
        Mesh ms = this.GetComponent<MeshFilter>().mesh;
        Vector3[] msV3 = ms.vertices;
        for(int numeroVertice = 0; numeroVertice < msV3.Length; numeroVertice++)
        {
            PontosClicaveis ponto;
            if(!dictPontos.TryGetValue(msV3[numeroVertice], out ponto))
            {
                ponto = new PontosClicaveis();
                ponto.pos = msV3[numeroVertice];
                dictPontos[msV3[numeroVertice]] = ponto;
            }
            ponto.vertices.Add(numeroVertice);
        }
    }

    void adicionaAresta(Vector3 p, Vector3 pv)
    //Conta quantidade aresta com dicionario
    {
        if(dictPontos[p].vizinhos.Contains(dictPontos[pv])) return;
        dictPontos[p].vizinhos.Add(dictPontos[pv]);
        dictPontos[pv].vizinhos.Add(dictPontos[p]);
    }

    void adicionaVizinhos()
    //
    {
        Mesh ms = this.GetComponent<MeshFilter>().mesh;
        Vector3[] msV3 = ms.vertices;
        int[] msT = ms.triangles;
        for(int i = 0; i < msT.Length; i+=3)
        {
            adicionaAresta(ms.vertices[msT[i]], ms.vertices[msT[i+1]]);
            adicionaAresta(ms.vertices[msT[i+1]], ms.vertices[msT[i+2]]);
            adicionaAresta(ms.vertices[msT[i+2]], ms.vertices[msT[i]]);
        }
        
        

    }


    void instanciaPontosClicaveis()
    //
    {
        int i = 0;
        foreach(KeyValuePair<Vector3, PontosClicaveis> kvp in dictPontos)
        {
            PontosClicaveis ponto = kvp.Value;
            if(ponto.pos.z < 0)
            {
                GameObject verticesClicaveis = GameObject.Instantiate(prefabVertice);
                verticesClicaveis.transform.parent = gameObject.transform;
                verticesClicaveis.name = "vertice_" + i;
                verticesClicaveis.transform.position = ponto.pos;
                verticesClicaveis.GetComponent<ScrpitVerticesPrefab>().malhaPrincipal = essaMalha;
                verticesClicaveis.GetComponent<ScrpitVerticesPrefab>().numeroVertice = i;
                verticesClicaveis.GetComponent<ScrpitVerticesPrefab>().ponto = ponto;
                i++;
            }
            
        }
    }

    void printaPosPontos()
    //
    {
        foreach(KeyValuePair<Vector3, PontosClicaveis> kvp in dictPontos)
        {
            PontosClicaveis pc = kvp.Value;
            foreach(PontosClicaveis p in pc.vizinhos){
                print("pontos: " + pc.vertices + " vizinhos: " + p.vertices);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
