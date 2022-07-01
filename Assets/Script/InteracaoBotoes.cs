using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteracaoBotoes : MonoBehaviour
{
    public List<Button> botoes;
    // Start is called before the first frame update
    void Start()
    {
        botoes[0].interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ativabotao(int indice)
    {
        for(int i = 0; i < botoes.Count; i++)
        {
            if(i == indice)
            {
                botoes[i].interactable = false;
            }else{
                botoes[i].interactable = true;
            }
        }
    }
}
