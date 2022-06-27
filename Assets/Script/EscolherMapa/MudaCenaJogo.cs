using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudaCenaJogo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mudaCenaJogo1()
    {
        SceneManager.LoadScene("Jogo");
    }

    public void voltaCena()
    {
        if(SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByBuildIndex(2)))
        {
            print("TRUE");
        }
        else{
            print(SceneManager.GetActiveScene().buildIndex);
        }
        
        SceneManager.LoadScene("Menu");
        
    }
}
