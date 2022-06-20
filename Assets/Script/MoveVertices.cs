using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertices : MonoBehaviour
{
    public Vector3 posMouseInicial;
    public Vector3 posMouseAtual;
    public Vector3 difPosMouse;
    public GameObject objetoInicial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Move"))
        {
            posMouseInicial = Input.mousePosition;
        }
        if(Input.GetButton("Move"))
        {
            posMouseAtual = Input.mousePosition;
            difPosMouse = posMouseAtual - posMouseInicial;
            foreach(Transform child in objetoInicial.transform)
            {
                child.SendMessage("moveVertice", difPosMouse * Time.deltaTime);
            }
            objetoInicial.SendMessage("atualizaMalha");
            posMouseInicial = posMouseAtual;

        }
    }
}
