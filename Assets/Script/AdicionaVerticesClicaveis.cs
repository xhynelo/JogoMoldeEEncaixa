using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdicionaVerticesClicaveis : MonoBehaviour
{
    public GameObject prefabVertice;
    public GameObject essaMalha;
    public Dictionary<Vector3, PontosClicaveis> dictPontos = new Dictionary<Vector3, PontosClicaveis>();
    List<Face> triangulos = new List<Face>();
    public GameObject infoFases;

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
                ponto = new PontosClicaveis(msV3[numeroVertice]);
                // ponto.pos = msV3[numeroVertice];
                // ponto.uv = ms.uv[numeroVertice];
                dictPontos[msV3[numeroVertice]] = ponto;
            }
            // ponto.vertices.Add(numeroVertice);
        }
    }

    // void adicionaAresta(Vector3 p, Vector3 pv)
    // //Conta quantidade aresta com dicionario
    // {
    //     if(dictPontos[p].vizinhos.Contains(dictPontos[pv])) return;
    //     dictPontos[p].vizinhos.Add(dictPontos[pv]);
    //     dictPontos[pv].vizinhos.Add(dictPontos[p]);
    // }

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
                dictPontos[ms.vertices[msT[i+2]]]));
            // adicionaAresta(ms.vertices[msT[i]], ms.vertices[msT[i+1]]);
            // adicionaAresta(ms.vertices[msT[i+1]], ms.vertices[msT[i+2]]);
            // adicionaAresta(ms.vertices[msT[i+2]], ms.vertices[msT[i]]);
        }
    }


    void instanciaPontosClicaveis()
    //
    {
        int i = 0;
        foreach(KeyValuePair<Vector3, PontosClicaveis> kvp in dictPontos)
        {
            PontosClicaveis ponto = kvp.Value;
            // if(ponto.pos.z < 0)
            // {
                GameObject verticesClicaveis = GameObject.Instantiate(prefabVertice);
                verticesClicaveis.transform.parent = gameObject.transform;
                verticesClicaveis.name = "vertice_" + i;
                verticesClicaveis.transform.position = ponto.pos;
                verticesClicaveis.GetComponent<ScrpitVerticesPrefab>().malhaPrincipal = essaMalha;
                verticesClicaveis.GetComponent<ScrpitVerticesPrefab>().numeroVertice = i;
                verticesClicaveis.GetComponent<ScrpitVerticesPrefab>().ponto = ponto;
                i++;
            // }
        }
    }

    public void recriarMalha()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        Vector3[] newNormals = new Vector3[dictPontos.Count];
        Vector3[] newVertices = new Vector3[dictPontos.Count];
        // print(dictPontos.Count);
        Vector2[] newUV = new Vector2[dictPontos.Count];
        int[] newTriangles = new int[triangulos.Count * 3];
        // print(triangulos.Count * 3);
        Dictionary<PontosClicaveis, int> dictIndiceV = new Dictionary<PontosClicaveis, int>();


        int i = 0;
        foreach(KeyValuePair<Vector3, PontosClicaveis> kvp in dictPontos)
        {
            newVertices[i] = kvp.Value.pos;
            newUV[i] = new Vector2(0.0f, 0.0f);
            newNormals[i] = new Vector3(0.0f, 0.0f, -1.0f);
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
        // foreach(Face f in triangulos)
        // {
        //     newTriangles[i+2] = dictIndiceV[f.vertices[0]];
        //     newTriangles[i+1] = dictIndiceV[f.vertices[1]];
        //     newTriangles[i] = dictIndiceV[f.vertices[2]];
        //     i += 3;
        // }

        // for(int ijk = 0; ijk < newTriangles.Length; ijk+=3)
        // {
        //     print("v1: " +  newTriangles[ijk] + " v2: " +  newTriangles[ijk+1] + " v3: " +  newTriangles[ijk+2]);
        // }

        // Mesh mesh = new Mesh();
        mesh.Clear();

       // Do some calculations...
        mesh.triangles = new int[0];
        
        mesh.vertices = newVertices;
        // print(mesh.vertices.Length);
        mesh.uv = newUV;
        mesh.triangles = newTriangles;
        
        // mesh.RecalculateNormals();
        mesh.normals = newNormals;
        // foreach(var n in mesh.normals)
        // {
        //     print(n);
        // }
        // print(mesh.normals.Length);
        // GetComponent<MeshFilter>().mesh = mesh;
        SendMessage("atualizaListaVertices");
    }

    void printaPosPontos()
    //
    {
        Mesh ms = this.GetComponent<MeshFilter>().mesh;
        // print(ms.vertices.Length);
        // foreach(Vector3 v in ms.vertices){
        //     print(v);
        // }
        // foreach(KeyValuePair<Vector3, PontosClicaveis> kvp in dictPontos)
        // {
        //     PontosClicaveis pc = kvp.Value;
        //     foreach(PontosClicaveis p in pc.vizinhos){
        //         print("pontos: " + pc.vertices + " vizinhos: " + p.vertices);
        //     }
        // }
    }

    void insataciaNovoPontoClicavel(PontoTemporario pt)
    {
        GameObject verticesClicaveis = GameObject.Instantiate(prefabVertice);
        verticesClicaveis.transform.parent = gameObject.transform;
        verticesClicaveis.name = "vertice_" + dictPontos.Count;
        verticesClicaveis.transform.position = pt.posicao;
        verticesClicaveis.GetComponent<ScrpitVerticesPrefab>().malhaPrincipal = essaMalha;
        // print(pontos.Count);
        // verticesClicaveis.GetComponent<ScrpitVerticesPrefab>().numeroVertice = objetoInicial.GetComponent<MeshFilter>().mesh.vertices.Length;


        verticesClicaveis.GetComponent<ScrpitVerticesPrefab>().ponto = criarPontoClicavel(pt);
        // i++;
    }

    public PontosClicaveis criarPontoClicavel(PontoTemporario pt)
    {
        PontosClicaveis ponto = new PontosClicaveis(pt.posicao);
        List<Face> removidas = new List<Face>();
        List<List<PontosClicaveis>> novasFaces = new List<List<PontosClicaveis>>();
        foreach(Face f in pt.v1.faces)
        {
            PontosClicaveis v3;
            PontosClicaveis v2;
            PontosClicaveis v1;
            if(f.contemAresta(pt.v1, pt.v2, out v1, out v2, out v3))
            {
                removidas.Add(f);
                novasFaces.Add(new List<PontosClicaveis>(){v3, v1, ponto});
                novasFaces.Add(new List<PontosClicaveis>(){v3, ponto, v2});
            }
        }
        foreach(Face f in removidas)
        {
            triangulos.Remove(f);
            foreach(PontosClicaveis pc in f.vertices)
            {
                pc.faces.Remove(f);
            }
        }
        foreach(List<PontosClicaveis> lPC in novasFaces)
        {
            triangulos.Add(new Face(lPC[0],lPC[1],lPC[2]));
        }
        dictPontos[pt.posicao] = ponto;
        recriarMalha();
        // Cria ponto
        // Percorre face
        //   apaga face
        //   cria 2 faces
        //     v1 v2 ponto
        //     v2 ponto v3
        return ponto;
    }

    // Update is called once per frame
    void Update()
    {
        // infoFases = GameObject.Find("infoFases");
    }
}

public class Face
{
    // public int indice;
    public PontosClicaveis[] vertices;

    public Face(PontosClicaveis v1, PontosClicaveis v2, PontosClicaveis v3)
    {
        vertices = new PontosClicaveis[3]{v1, v2, v3};
        // indice = i;
        v1.faces.Add(this);
        v2.faces.Add(this);
        v3.faces.Add(this);
    }

    public bool contemAresta(PontosClicaveis v1, PontosClicaveis v2, out PontosClicaveis ov1, out PontosClicaveis ov2, out PontosClicaveis ov3)
    {
        int quantidades = 0;
        ov1 = null;
        ov2 = null;
        ov3 = null;
        foreach(PontosClicaveis pc in vertices)
        {
            if(pc.pos == v1.pos || pc.pos == v2.pos)
            {
                quantidades++;
                if(ov1 == null) ov1 = pc;
                else ov2 = pc;
            } else {
                ov3 = pc;
            }
        }
        if(ov1 == vertices[0] && ov2 == vertices[2])
        {
            ov1 = vertices[2];
            ov2 = vertices[0];
        }  
        return quantidades == 2;
    }

    
}
