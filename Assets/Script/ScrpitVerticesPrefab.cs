using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrpitVerticesPrefab : MonoBehaviour
{
    public GameObject malhaPrincipal;
    public GameObject prefab;
    public int numeroVertice;
    public List<int> vizinhos; 
    public bool selecionado;
    public PontosClicaveis ponto;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        mudaCor();

    }

    void mudaCor()
    {
        if(selecionado)
        {
            GameObject cube = prefab;
            var cubeRenderer = cube.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.red);
        }else{
            GameObject cube = prefab;
            var cubeRenderer = cube.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.white);
        }
    }

    public void ativaVertice(Rect retangulo)
    {
        if(retangulo.Contains(Camera.main.WorldToScreenPoint(transform.position)))
        {
            selecionado = true;
        }else{
            selecionado = false;
        }
    }

    public void moveVertice(Vector3 movimento)
    {
        if(selecionado)
        {
            Vector3 posAnterior = transform.position;
            transform.position += movimento;
            ponto.pos = transform.position;
            ponto.movimento = movimento;
            ponto.posAnterior = posAnterior;
            transform.parent.SendMessage("atualizaVertice", ponto);
        } 
    }
}
