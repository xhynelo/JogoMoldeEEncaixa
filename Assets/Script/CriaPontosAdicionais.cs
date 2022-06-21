using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriaPontosAdicionais : MonoBehaviour
{
    public GameObject objetoInicial;
    public GameObject novoPontoPrefab;
    // List<PontosClicaveis> pontos = new List<PontosClicaveis>();
    List<Vector3> medias = new List<Vector3>();
    Dictionary<PontoTemporario, int> dictPontoTemp = new Dictionary<PontoTemporario, int>();
    Dictionary<Vector3, PontosClicaveis> pontos = new Dictionary<Vector3, PontosClicaveis>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CriaPossiveisPontos()
    {
        pegaTodasBolinhas();
        TiraMediaPontos();
        instanciaPossivelPonto();
    }

    void pegaTodasBolinhas()
    {
        int i = 0;
        foreach(Transform child in objetoInicial.transform)
        {
            i++;
            PontosClicaveis ponto = child.GetComponent<ScrpitVerticesPrefab>().ponto;
            pontos[ponto.pos] = ponto;
        }
    }

    void adicionaAresta(Vector3 p, Vector3 pv)
    //Conta quantidade aresta com dicionario
    {
        PontoTemporario novoPonto = new PontoTemporario(pontos[p], pontos[pv]);
        int repeticao;
        if(!dictPontoTemp.TryGetValue(novoPonto, out repeticao))
        {
            repeticao = 0;
        } 
        dictPontoTemp[novoPonto] = repeticao + 1;
    }

    void TiraMediaPontos()
    // adciona medias
    {
        Mesh ms = objetoInicial.GetComponent<MeshFilter>().mesh;
        int[] msT = ms.triangles;
        for(int i = 0; i < msT.Length; i+=3)
        {
            if(!pontos.ContainsKey(ms.vertices[msT[i]])) continue;
            if(!pontos.ContainsKey(ms.vertices[msT[i+1]])) continue;
            if(!pontos.ContainsKey(ms.vertices[msT[i+2]])) continue;
            adicionaAresta(ms.vertices[msT[i]], ms.vertices[msT[i+1]]);
            adicionaAresta(ms.vertices[msT[i+1]], ms.vertices[msT[i+2]]);
            adicionaAresta(ms.vertices[msT[i+2]], ms.vertices[msT[i]]);
        }
    }

    void instanciaPossivelPonto()
    // instacia possiveis pontos
    {
        int i = 0;
        foreach(KeyValuePair<PontoTemporario, int> kvp in dictPontoTemp)
        {
            if(kvp.Value == 1)
            {
                GameObject verticesClicaveis = GameObject.Instantiate(novoPontoPrefab);
                verticesClicaveis.transform.parent = objetoInicial.transform;
                verticesClicaveis.name = "Sprit_" + i;
                i++;
                verticesClicaveis.transform.position = kvp.Key.posicao;
                kvp.Key.go = verticesClicaveis;
            }
        }
    }
}
