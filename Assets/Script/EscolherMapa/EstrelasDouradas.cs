using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstrelasDouradas : MonoBehaviour
{
    public Sprite estrelaDourada;
    public Sprite estrelaVazia;
    public List<Image> estrelas;
    // Start is called before the first frame update
    void Start()
    {
        // for(int i = 0; i < estrelas.Count; i++)
        // {
        //     pintaEstrela(InfoFases.salvos.intArray[i]);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pintaEstrela(int i)
    {
        int j;
        for(j=0; j< i; j++)
        {
            estrelas[j].sprite = estrelaDourada;
        }
        for(int k = j; k < 3; k++)
        {
            estrelas[k].sprite = estrelaVazia;
        }
    }
}
