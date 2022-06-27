using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChecaColisao : MonoBehaviour
{
    public GameObject erro;
    public GameObject acerto;
    public GameObject objetoInicial;
    public GameObject checkFalha;
    public GameObject checkAcerto;
    public Text textoFalha;
    public Text textoAcerto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VerificaAcerto()
    {
        
    }

    
    public void verificaColisoes()
    {
        int filhos = 0;
        // int colisoes = 0;
        foreach(Transform child in objetoInicial.transform){
                
            }
        filhos = objetoInicial.transform.childCount;
        int quantidade;
        bool FiguraCorreta = acerto.GetComponent<ScriptAcerto>().CalculaColisores(out quantidade);
        if(FiguraCorreta)
        {
            checkAcerto.SetActive(true);
            print("todosColidiram");
        }else{
            checkFalha.SetActive(true);
            print("apenas " + quantidade + " colidiram");
        }
    }
}
