using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoMoverVertice : MonoBehaviour
{
    public GameObject canvas;
    public GameObject cameraPrincipal;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void aperta(){

    }

    public void ativaMoveVertices()
    {
        cameraPrincipal.GetComponent<MoveVertices>().podeMover = true;
        cameraPrincipal.GetComponent<SelecionaVertices>().podeSelecionar = false;
        canvas.GetComponent<CriaPontosAdicionais>().deletaPontosTemporarios();
    }
}
