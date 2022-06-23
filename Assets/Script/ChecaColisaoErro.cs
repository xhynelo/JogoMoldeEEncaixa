using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecaColisaoErro : MonoBehaviour
{
    public int colisoes = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        colisoes++;
        // print("CCE " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        colisoes--;
        // print("saiu");
    }
}
