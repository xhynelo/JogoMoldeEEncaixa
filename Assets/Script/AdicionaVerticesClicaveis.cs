using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdicionaVerticesClicaveis : MonoBehaviour
{
    public GameObject prefabVertice;
    public GameObject essaMalha;
    Dictionary<Vector3, PontosClicaveis> dictPontos = new Dictionary<Vector3, PontosClicaveis>();
    List<Face> triangulos = new List<Face>();
    

    // Start is called before the first frame update
    void Start()
    {
        CriaClassPontos();
        adicionaVizinhos();
        recriarMalha();
        // printaPosPontos();
        instanciaPontosClicaveis();
    }

    void CriaClassPontos()
    //
    {
        Mesh ms = this.GetComponent<MeshFilter>().mesh;
        Vector3[] msV3 = ms.vertices;
        // print("uv: " + ms.uv.Length + " vertices " + ms.vertices.Length + " triangulos " + ms.triangles.Length);
        for(int numeroVertice = 0; numeroVertice < msV3.Length; numeroVertice++)
        {
            PontosClicaveis ponto;
            if(!dictPontos.TryGetValue(msV3[numeroVertice], out ponto))
            {
                ponto = new PontosClicaveis();
                ponto.pos = msV3[numeroVertice];
                ponto.uv = ms.uv[numeroVertice];
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
            triangulos.Add(new Face(
                dictPontos[ms.vertices[msT[i]]],
                dictPontos[ms.vertices[msT[i+1]]],
                dictPontos[ms.vertices[msT[i+2]]], i));
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

    public void recriarMalha()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        
        
        Vector3[] newVertices = new Vector3[dictPontos.Count];
        Vector2[] newUV = new Vector2[dictPontos.Count];
        int[] newTriangles = new int[triangulos.Count * 3];
        Dictionary<PontosClicaveis, int> dictIndiceV = new Dictionary<PontosClicaveis, int>();


        int i = 0;
        foreach(KeyValuePair<Vector3, PontosClicaveis> kvp in dictPontos)
        {
            newVertices[i] = kvp.Key;
            newUV[i] = new Vector2(0.0f, 0.0f);
            dictIndiceV[kvp.Value] = i;
            kvp.Value.indice = i;
            i++;
        }

        i = 0;
        foreach(Face f in triangulos)
        {
            newTriangles[i] = dictIndiceV[f.vertices[0]];
            newTriangles[i+1] = dictIndiceV[f.vertices[1]];
            newTriangles[i+2] = dictIndiceV[f.vertices[2]];
            i += 3;
        }

        mesh.Clear();

       // Do some calculations...
        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = newTriangles;
        mesh.RecalculateNormals();
    }

    void printaPosPontos()
    //
    {
        Mesh ms = this.GetComponent<MeshFilter>().mesh;
        print(ms.vertices.Length);
        foreach(Vector3 v in ms.vertices){
            print(v);
        }
        // foreach(KeyValuePair<Vector3, PontosClicaveis> kvp in dictPontos)
        // {
        //     PontosClicaveis pc = kvp.Value;
        //     foreach(PontosClicaveis p in pc.vizinhos){
        //         print("pontos: " + pc.vertices + " vizinhos: " + p.vertices);
        //     }
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Face
{
    public int indice;
    public PontosClicaveis[] vertices;

    public Face(PontosClicaveis v1, PontosClicaveis v2, PontosClicaveis v3, int i)
    {
        vertices = new PontosClicaveis[3]{v1, v2, v3};
        indice = i;
        v1.faces.Add(this);
        v2.faces.Add(this);
        v3.faces.Add(this);
    }
}
