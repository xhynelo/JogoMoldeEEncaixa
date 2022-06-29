using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoFases : MonoBehaviour
{
    public bool atum = true;
    public string stg = "vemPraPertin";

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        print(transform.gameObject.name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Move"))
        {
            print(transform.gameObject.name);
        }
    }
}
