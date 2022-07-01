using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class botaoAbreFechaImagem : MonoBehaviour
{
    public Sprite abre; 
    public Sprite fecha; 
    public Image imagemAF;
    public Button abreFecha;
    public Sprite botao;
    bool fechado =  true;

    // Start is called before the first frame update
    void Start()
    {
        imagemAF.sprite = abre;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mudaIcone()
    {
        if(fechado)
        {
            imagemAF.sprite = fecha;
            fechado = false;
        }else{
            imagemAF.sprite = abre;
            fechado = true;
        }
        // EventSystem.current.SetSelectedGameObject(null);
    }
}
