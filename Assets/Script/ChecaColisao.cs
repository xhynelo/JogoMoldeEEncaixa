using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChecaColisao : MonoBehaviour
{
    public GameObject erro;
    public GameObject acerto;
    public GameObject objetoInicial;
    public GameObject checkFalha;
    public GameObject checkAcerto;
    public Text textoFalha;
    public Text textoAcerto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VerificaAcerto()
    {
        
    }

    
    public void verificaColisoes()
    {
        int filhos = 0;

        filhos = objetoInicial.transform.childCount;
        int quantidade;
        bool FiguraCorreta = acerto.GetComponent<ScriptAcerto>().CalculaColisores(out quantidade);
        bool normaisCertas = true;
        Mesh ms = objetoInicial.GetComponent<MeshFilter>().mesh;
        Mesh copyms = new Mesh();
        copyms.vertices = ms.vertices;
        copyms.normals = ms.normals;
        copyms.triangles = ms.triangles;
        // foreach(Vector3 v3 in copyms.normals)
        // {
        //     print("normais copyms antes: " + v3);
        // }
        Vector3 n = new Vector3(0.0f, 0.0f, 1.0f);
        // print(n);
        copyms.RecalculateNormals();
        for(int i = 0; i < ms.normals.Length; i++)
        {
            if(copyms.normals[i] != n)
            {
                normaisCertas = false;
                print("entrei aqui");
                print("normais erradas "+copyms.normals[i] + " n: " + n);
            }
        }
        if(FiguraCorreta && normaisCertas)
        {
            
            checkAcerto.SetActive(true);
                
            
            print("todosColidiram");
        }else{
            checkFalha.SetActive(true);
            if(!normaisCertas)
            {
                textoFalha.text = "Faces viradas para o lado errado";
            }else{
                textoFalha.text = quantidade.ToString() + " pontos estão na posição correta";
            }
            Camera.main.GetComponent<Pontuacao>().aberturas++;
            print("apenas " + quantidade + " colidiram");
        }
    }
}
; 