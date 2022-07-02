using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstrelasPorJogo : MonoBehaviour
{

    public List<GameObject> botoes;

    // Start is called before the first frame update
    void Start()
    {
        estrelas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void estrelas()
    {
        int i = 0;
        foreach (int qtdEstrelas in InfoFases.salvos.intArray)
        {
            botoes[i].SendMessage("pintaEstrela", qtdEstrelas);
            i++;
        }
    }
}
