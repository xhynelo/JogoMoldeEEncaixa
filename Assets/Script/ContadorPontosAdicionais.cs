using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorPontosAdicionais : MonoBehaviour
{
    public Text quantidade;
    public int qtdPontos;
    // Start is called before the first frame update
    void Start()
    {
        qtdPontos = InfoFases.jogos[InfoFases.jogoAtual].pontosAdionaveis;
        quantidade.text = qtdPontos.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void decrementaQuantidade()
    {
        qtdPontos--;
        quantidade.text = qtdPontos.ToString();
    }

}
