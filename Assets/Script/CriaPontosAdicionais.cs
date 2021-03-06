using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CriaPontosAdicionais : MonoBehaviour
{
    public GameObject objetoInicial;
    public GameObject novoPontoPrefab;
    public GameObject prefabVertice;
    public Canvas cv;
    public GameObject cameraPrincipal;
    public Button botaoAdiciona;
    public GameObject qtdPontos;
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

    public void ativaCriaVertices()
    {
        cameraPrincipal.GetComponent<MoveVertices>().podeMover = false;
        cameraPrincipal.GetComponent<SelecionaVertices>().podeSelecionar = false;
    }

    public void CriaPossiveisPontos()
    {
        if(qtdPontos.GetComponent<ContadorPontosAdicionais>().qtdPontos > 0)
        {
            pegaTodasBolinhas();
            TiraMediaPontos();
            instanciaPossivelPonto();
        }
    }

    void pegaTodasBolinhas()
    {
        pontos.Clear();
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
        dictPontoTemp.Clear();
        Mesh ms = objetoInicial.GetComponent<MeshFilter>().mesh;
        int[] msT = ms.triangles;
        for(int i = 0; i < msT.Length; i+=3)
        {
            if(pontos.ContainsKey(ms.vertices[msT[i]]) && pontos.ContainsKey(ms.vertices[msT[i+1]])) adicionaAresta(ms.vertices[msT[i]], ms.vertices[msT[i+1]]);
            if(pontos.ContainsKey(ms.vertices[msT[i+1]]) && pontos.ContainsKey(ms.vertices[msT[i+2]])) adicionaAresta(ms.vertices[msT[i+1]], ms.vertices[msT[i+2]]);;
            if(pontos.ContainsKey(ms.vertices[msT[i+2]]) && pontos.ContainsKey(ms.vertices[msT[i]])) adicionaAresta(ms.vertices[msT[i+2]], ms.vertices[msT[i]]);;
            // adicionaAresta(ms.vertices[msT[i]], ms.vertices[msT[i+1]]);
            // adicionaAresta(ms.vertices[msT[i+1]], ms.vertices[msT[i+2]]);
            // adicionaAresta(ms.vertices[msT[i+2]], ms.vertices[msT[i]]);
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
                verticesClicaveis.GetComponent<ScriptPontoTemporario>().canvas = cv;
                verticesClicaveis.GetComponent<ScriptPontoTemporario>().pt = kvp.Key;
                verticesClicaveis.GetComponent<ScriptPontoTemporario>().qtdPontos = qtdPontos;
                kvp.Key.go = verticesClicaveis;
            }
        }
    }

    void deletaPontosTemporariosNaoEscolhidos(PontoTemporario pt)
    {
        foreach(KeyValuePair<PontoTemporario, int> kvp in dictPontoTemp)
        {
                Destroy(kvp.Key.go);
        }
        objetoInicial.SendMessage("insataciaNovoPontoClicavel", pt);
        botaoAdiciona.interactable = true;
        // print("EntreiAqui " + pt.posicao);
        // print(pontos.Count);
    }

    public void deletaPontosTemporarios()
    {
        // print("vou deletar");
        foreach(KeyValuePair<PontoTemporario, int> kvp in dictPontoTemp)
        {
            // print(kvp.Value);
            Destroy(kvp.Key.go);
        }
    }

}
