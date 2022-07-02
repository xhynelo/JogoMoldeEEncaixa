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
    bool podeMover;
    bool podeSelecionar;

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
            podeMover = Camera.main.GetComponent<MoveVertices>().podeMover;
            podeSelecionar = Camera.main.GetComponent<SelecionaVertices>().podeSelecionar;
            Camera.main.GetComponent<MoveVertices>().podeMover = false;
            Camera.main.GetComponent<SelecionaVertices>().podeSelecionar = false;
        }else{
            imagemAF.sprite = abre;
            fechado = true;
            Camera.main.GetComponent<MoveVertices>().podeMover = podeMover;
            Camera.main.GetComponent<SelecionaVertices>().podeSelecionar = podeSelecionar;

        }
        // EventSystem.current.SetSelectedGameObject(null);
    }
}
