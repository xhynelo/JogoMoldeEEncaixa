using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoMoverVertice : MonoBehaviour
{
    public GameObject seta;
    public GameObject cameraPrincipal;
    // public Vector3 posMouseInicial;
    // public Vector3 posMouseAtual;
    // public Vector3 difPosMouse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetMouseButtonDown(0)){
        //     posMouseInicial = Input.mousePosition;
            
        // }
        // if(Input.GetMouseButton(0)){
        //     posMouseAtual = Input.mousePosition;
        //     difPosMouse = posMouseAtual - posMouseInicial;
        //     print(difPosMouse);// sendMessange();
        //     posMouseInicial = posMouseAtual;

        // }

    }

    public void aperta(){
        // Vector3 posicaoS = new Vector3(transform.position.x, transform.position.y - 3, transform.position.z);
        // Vector3 posicaoZ = new Vector3(transform.position.x + 1.2f, transform.position.y - 4.2f, transform.position.z);
        // GameObject s = Instantiate(seta, posicaoS, Quaternion.Euler(0, 0, 0));
        // s.name = "setaCima";
        // GameObject z = Instantiate(seta, posicaoZ, Quaternion.Euler(0, 0, -90));
        // z.name = "setaLado";
        // print(gameObject.GetComponent<RectTransform>().rect.height);
    }

    public void ativaMoveVertices()
    {
        cameraPrincipal.GetComponent<MoveVertices>().podeMover = true;
        cameraPrincipal.GetComponent<SelecionaVertices>().podeSelecionar = false;
    }
}
