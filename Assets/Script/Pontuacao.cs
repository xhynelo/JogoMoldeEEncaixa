using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour
{
    public int aberturas = 0;
    public GameObject panelVitoria;

    public Text placar;
    int estrelas;
    public Color cor3;
    public Color cor2; //F1E42D
    public Color cor1;
    public Color cor0; //D93636
    public Sprite estrela;
    public Sprite naoEstrela;
    public Image Estrela1;
    public Image Estrela2;
    public Image Estrela3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        calculaPlacar();
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

    public void calculaPlacar()
    {
        if(aberturas <= InfoFases.jogos[InfoFases.jogoAtual].estrela3)
        {
            placar.text = aberturas.ToString() + " / " + InfoFases.jogos[InfoFases.jogoAtual].estrela3.ToString();
            placar.color = cor3;
            estrelas = 3;
        }else if(aberturas <= InfoFases.jogos[InfoFases.jogoAtual].estrela2)
        {
            placar.text = aberturas.ToString() + " / " + InfoFases.jogos[InfoFases.jogoAtual].estrela2.ToString();
            placar.color = cor2;
            estrelas = 2;
        }else if(aberturas <= InfoFases.jogos[InfoFases.jogoAtual].estrela1)
        {
            placar.text = aberturas.ToString() + " / " + InfoFases.jogos[InfoFases.jogoAtual].estrela1.ToString();
            placar.color = cor1;
            estrelas = 1;
        }else{
            placar.text = aberturas.ToString() + " / ∞ ";
            placar.color = cor0;
            estrelas = 0;
        }
    }

    public void mostraEstrelas()
    {
        if(estrelas == 3)
        {
            Estrela1.sprite = estrela;
            Estrela2.sprite = estrela;
            Estrela3.sprite = estrela;

            
        }else if(estrelas == 2){
            Estrela1.sprite = estrela;
            Estrela2.sprite = estrela;
            Estrela3.sprite = naoEstrela;
        }else if(estrelas == 1){
            Estrela1.sprite = estrela;
            Estrela2.sprite = naoEstrela;
            Estrela3.sprite = naoEstrela;
        }else{
            Estrela1.sprite = naoEstrela;
            Estrela2.sprite = naoEstrela;
            Estrela3.sprite = naoEstrela;
        }
        if(InfoFases.salvos.intArray[InfoFases.jogoAtual] < estrelas)
        {
            InfoFases.salvos.intArray[InfoFases.jogoAtual] = estrelas;
        }
        SaveLoad.SaveGame();
    }

    // 2 4 6
    //3 2 1 0 
}
