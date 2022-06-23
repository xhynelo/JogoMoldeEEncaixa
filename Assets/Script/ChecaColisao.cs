using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecaColisao : MonoBehaviour
{
    public GameObject erro;
    public GameObject acerto;
    public GameObject objetoInicial;

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
        int colisoes = 0;
        foreach(Transform child in objetoInicial.transform){
                
            }
        filhos = objetoInicial.transform.childCount;
        colisoes = erro.GetComponent<ChecaColisaoErro>().colisoes;
        if(colisoes == filhos)
        {
            print("todosColidiram");
        }else{
            print("apenas " + colisoes + " colidiram");
        }
    }
}
