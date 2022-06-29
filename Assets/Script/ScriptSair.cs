using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptSair : MonoBehaviour
{
    public GameObject panelSair;
    public bool PSair = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aparecePanelSair();
    }

    void aparecePanelSair()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            PSair = !PSair;    
            panelSair.SetActive(PSair);
        }
    }

    public void DesativaPanelSair()
    {
        panelSair.SetActive(false);
        PSair = false;
    }

    public void sairFase()
    {
        SceneManager.LoadScene("EscolherMapa");
    }
}
