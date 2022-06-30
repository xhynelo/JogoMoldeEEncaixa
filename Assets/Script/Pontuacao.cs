using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuacao : MonoBehaviour
{
    public int aberturas = 0;
    public GameObject panelVitoria;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void calculaEstrelas()
    {
        if(aberturas <= InfoFases.jogos[InfoFases.jogoAtual].estrela3)
        {
            print("3 estrela");
        }else if(aberturas <= InfoFases.jogos[InfoFases.jogoAtual].estrela2)
        {
            print("2 estrelas");
        }else if(aberturas <= InfoFases.jogos[InfoFases.jogoAtual].estrela1)
        {
            print("1 estrelas");
        }else{
            print("0 estrelas");
        }
    }

    // 2 4 6
    //3 2 1 0 
}
