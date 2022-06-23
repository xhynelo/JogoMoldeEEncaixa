using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPontoTemporario : MonoBehaviour
{

    public Canvas canvas;

    public PontoTemporario pt;

    void OnMouseDown()
    {
        print("oie");
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
}
