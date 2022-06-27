using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarCenaMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByBuildIndex(2))) SceneManager.LoadScene("Menu");
        print(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
