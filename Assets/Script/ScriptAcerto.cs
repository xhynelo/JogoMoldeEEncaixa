using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAcerto : MonoBehaviour
{
    public List<Rigidbody> colisores = new List<Rigidbody>();
    int quantidadeColisores;
    // Start is called before the first frame update
    void Start()
    {
        quantidadeColisores = colisores.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CalculaColisores(out int quantidade)
    {
        quantidade = 0;
        foreach(Rigidbody c in colisores)
        {
            int cColisao = c.GetComponent<ChegaColisaoAcerto>().colisoes;
            if(cColisao >= 1)
            {
                print(c.name);
                quantidade++;
            }
        }
        return quantidade == quantidadeColisores;
    }
}
