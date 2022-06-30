using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CriaImagem : MonoBehaviour
{
    public GameObject colisor;
    public GameObject paiColisor;
    public GameObject imagem;
    List<Vector3> pontos = new List<Vector3>();
    LineRenderer LR;
    RectTransform RectT;

    // Start is called before the first frame update
    void Start()
    {
        LR = imagem.GetComponent<LineRenderer>();
        adicionaPonto();
        criaColisores();
        RectT = imagem.GetComponent<RectTransform>();
        desenhaImagem();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void adicionaPonto()
    {
        pontos = InfoFases.jogos[InfoFases.jogoAtual].desenho;
        LR.positionCount = pontos.Count;
    }

    public void desenhaImagem()
    {
        LR.startWidth = Mathf.Max(0.135f * RectT.rect.width/Screen.width, 0.055f);
        for(int i = 0; i < pontos.Count; i++)
        {
            Vector3 ponto = pontos[i];
            float x = ponto.x * RectT.rect.width/Screen.width;
            float y = ponto.y * RectT.rect.height/Screen.height;
           
            LR.SetPosition(i, new Vector3(x, y, 0.0f) + RectT.position);
        }
    }

    void criaColisores()
    {
        foreach(Vector3 p in pontos)
        {
            GameObject colisorGO = GameObject.Instantiate(colisor);
            colisorGO.transform.parent = paiColisor.transform;
            colisorGO.transform.position = p;
            paiColisor.GetComponent<ScriptAcerto>().colisores.Add(colisorGO.GetComponent<Rigidbody>());
            // colisorGO.AddComponent<ChegaColisaoAcerto>();
        }
    }

}
