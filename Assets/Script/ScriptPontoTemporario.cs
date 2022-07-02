using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPontoTemporario : MonoBehaviour
{

    public Canvas canvas;

    public PontoTemporario pt;

    public bool ehVertices = false;
    public GameObject qtdPontos;

    void OnMouseDown()
    {
        print("oie");
        qtdPontos.GetComponent<ContadorPontosAdicionais>().decrementaQuantidade();
        canvas.SendMessage("deletaPontosTemporariosNaoEscolhidos", pt);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveVertice()
    {
        
    }
    
    void ativaVertice()
    {
        
    }
}
