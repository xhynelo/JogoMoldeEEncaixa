using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoSelecionaVertice : MonoBehaviour
{
    public GameObject cameraPrincipal;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ativaSelecionaVertice()
    {
        // print("atum");
        cameraPrincipal.GetComponent<MoveVertices>().podeMover = false;
        cameraPrincipal.GetComponent<SelecionaVertices>().podeSelecionar = true;
        canvas.GetComponent<CriaPontosAdicionais>().deletaPontosTemporarios();
    }

    public void botaoCheca()
    {
        canvas.GetComponent<CriaPontosAdicionais>().deletaPontosTemporarios();
        cameraPrincipal.GetComponent<Pontuacao>().mostraEstrelas();
    }
}
