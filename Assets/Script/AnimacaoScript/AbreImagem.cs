using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbreImagem : MonoBehaviour
{
    public GameObject panel;

    public Animator anim;
    public bool abre;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("abre", abre);
    }

    public void abreImagem(){
        abre = !abre;
    }
}
