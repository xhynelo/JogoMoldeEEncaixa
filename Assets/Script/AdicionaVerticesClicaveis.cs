using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdicionaVerticesClicaveis : MonoBehaviour
{
    public GameObject prefabVertice;
    public GameObject essaMalha;
    public List<PontosClicaveis> pontos = new List<PontosClicaveis>();
    // Dictionary<Vector3, List<int>> vertices = new Dictionary<Vector3, List<int>>();
    // Dictionary<int, PontosClicaveis> verticeDoPonto = new Dictionary<int, PontosClicaveis>();
    // Start is called before the first frame update
    void Start()
    {
        CriaClassPontos();
        adicionaVizinhos();
        // printaPosPontos();
        adciovaPontosClicaveis();
        // // // Mesh ms = this.GetComponent<MeshFilter>().mesh;
        // // // Vector3[] msV3 = ms.vertices;
        // int numeroVertice = 0;
        // // // for(int numeroVertice = 0; numeroVertice < msV3.Length; numeroVertice++){
        // // //     if(msV3[numeroVertice].z < 0){
        // // //         GameObject verticesClicaveis = GameObject.Instantiate(prefabVertice);
        // // //         verticesClicaveis.transform.parent = gameObject.transform;
        // // //         verticesClicaveis.name = "vertice_" + numeroVertice;
        // // //         verticesClicaveis.transform.position = msV3[numeroVertice];
        // // //         verticesClicaveis.GetComponent<ScrpitVerticesPrefab>().malhaPrincipal = essaMalha;
        // // //         verticesClicaveis.GetComponent<ScrpitVerticesPrefab>().numeroVertice = numeroVertice;
        // // //     }
        // // // }
        // foreach(Vector3 v in msV3){
        //     if(v.z < 0){
        //         GameObject verticesClicaveis = GameObject.Instantiate(prefabVertice);
        //         verticesClicaveis.transform.parent = gameObject.transform;
        //         verticesClicaveis.name = "vertice_" + numeroVertice;
        //         verticesClicaveis.transform.position = v;
        //         verticesClicaveis.GetComponent<ScrpitVerticesPrefab>().malhaPrincipal = essaMalha;
        //         verticesClicaveis.GetComponent<ScrpitVerticesPrefab>().numeroVertice = msV3.in;
        //         numeroVertice++;
        //     }
        // }
        

    }

    void CriaClassPontos()
    //
    {
        List<Vector3> posPontos = new List<Vector3>();
        Mesh ms = this.GetComponent<MeshFilter>().mesh;
        Vector3[] msV3 = ms.vertices;
        // int numeroVertice = 0;
        for(int numeroVertice = 0; numeroVertice < msV3.Length; numeroVertice++)
        {
            if(posPontos.Contains(msV3[numeroVertice]))
            {
                pontos[posPontos.IndexOf(msV3[numeroVertice])].vertices.Add(numeroVertice);
            }else{
                PontosClicaveis ponto = new PontosClicaveis();
                ponto.vertices.Add(numeroVertice);
                ponto.pos = msV3[numeroVertice];
                posPontos.Add(msV3[numeroVertice]);
                pontos.Add(ponto);
            }
        }
    }

    void adicionaVizinhos()
    //
    {
        Mesh ms = this.GetComponent<MeshFilter>().mesh;
        Vector3[] msV3 = ms.vertices;
        int[] msT = ms.triangles;
        foreach(PontosClicaveis ponto in pontos)
        {
            List<int> verticiesVizinhos;
            verticiesVizinhos = procuraTriangulos(ponto, msT);
            procuraVizinhos(ponto, verticiesVizinhos);
        }
        

    }

    List<int> procuraTriangulos(PontosClicaveis ponto, int[] triangulos)
    //
    {
        List<int> vizinhos = new List<int>();
        foreach(int v in triangulos)
        {
            foreach(int p in ponto.vertices)
            {
                if(v == p){
                    if((v % 3) == 0 ){
                        int aux1 = v+1;
                        int aux2 = v+2;
                        vizinhos.Add(aux1);
                        vizinhos.Add(aux2);
                    }
                    if((v % 3) == 1 ){
                        int aux1 = v-1;
                        int aux2 = v+1;
                        vizinhos.Add(aux1);
                        vizinhos.Add(aux2);
                    }
                    if((v % 3) == 2 ){
                        int aux1 = v-1;
                        int aux2 = v-2;
                        vizinhos.Add(aux1);
                        vizinhos.Add(aux2);
                    }
                }
            }
        }
        return vizinhos;
    }

    void procuraVizinhos(PontosClicaveis ponto, List<int> vizinhos)
    //
    {
        List<PontosClicaveis> pc = new List<PontosClicaveis>();
        foreach(int v in vizinhos)
        {
            foreach(PontosClicaveis p in pontos)
            {
                if(!pc.Contains(p))
                {
                    foreach(int i in p.vertices)
                    {
                        if(v == i) pc.Add(p);
                    }
                }
            }
        }
        foreach(PontosClicaveis v in pc)
        {
            ponto.vizinhos.Add(v);
        }
    }

    void adciovaPontosClicaveis()
    //
    {
        for(int i = 0; i < pontos.Count; i++)
        {
            PontosClicaveis ponto = pontos[i];
            if(ponto.pos.z < 0)
            {
                GameObject verticesClicaveis = GameObject.Instantiate(prefabVertice);
                verticesClicaveis.transform.parent = gameObject.transform;
                verticesClicaveis.name = "vertice_" + i;
                verticesClicaveis.transform.position = ponto.pos;
                verticesClicaveis.GetComponent<ScrpitVerticesPrefab>().malhaPrincipal = essaMalha;
                verticesClicaveis.GetComponent<ScrpitVerticesPrefab>().numeroVertice = i;
                verticesClicaveis.GetComponent<ScrpitVerticesPrefab>().ponto = ponto;
            }
        }
        // foreach(PontosClicaveis ponto in pontos)
        // {
        //     if(ponto.pos.z < 0)
        //     {
        //         GameObject verticesClicaveis = GameObject.Instantiate(prefabVertice);
        //         verticesClicaveis.transform.parent = gameObject.transform;
        //         verticesClicaveis.name = "vertice_" + pontos.IndexOf(ponto);
        //         verticesClicaveis.transform.position = ponto.pos;
        //         verticesClicaveis.GetComponent<ScrpitVerticesPrefab>().malhaPrincipal = essaMalha;
        //         verticesClicaveis.GetComponent<ScrpitVerticesPrefab>().numeroVertice = pontos.IndexOf(ponto);
        //         verticesClicaveis.GetComponent<ScrpitVerticesPrefab>().ponto = ponto;
        //     }
        // }
    }

    void printaPosPontos()
    //
    {
        foreach(PontosClicaveis pc in pontos)
        {
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
