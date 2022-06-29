using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CriaImagem : MonoBehaviour
{
    public GameObject colisor;
    public RawImage imagemRI;
    public GameObject imagem;
    public bool mudouImagem = false;
    // public Canvas imagemCanvas;
    
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
        // if(mudouImagem)
        //     desenhaImagem();
    }

    void adicionaPonto()
    {
        pontos.Add(new Vector3(2.0f, 2.0f, 0.0f));
        pontos.Add(new Vector3(0.0f, 2.0f, 0.0f));
        pontos.Add(new Vector3(2.0f, 0.0f, 0.0f));
        LR.positionCount = pontos.Count;
    }

    public void desenhaImagem()
    {
        for(int i = 0; i < pontos.Count; i++)
        {
            Vector3 ponto = pontos[i];
            float x = ponto.x * RectT.rect.width/Screen.width;
            float y = ponto.y * RectT.rect.height/Screen.height;
           
            LR.SetPosition(i, new Vector3(x, y, 0.0f) + RectT.position);
        }
    }

    public void mudaMudouImagem()
    {
        mudouImagem = !mudouImagem;
    }


    void criaColisores()
    {
        foreach(Vector3 p in pontos)
        {
            GameObject verticesClicaveis = GameObject.Instantiate(colisor);
            // verticesClicaveis.transform.parent = ;
            verticesClicaveis.transform.position = p;
        }
    }

    void coisas()
    {
        Texture2D t2D = new Texture2D(Screen.width, Screen.height, TextureFormat.RGBA32, false);
        for(int i = 0; i < t2D.width; i++)
        {
            for(int j = 0; j < t2D.height; j++)
            {
                t2D.SetPixel(i, j, Color.white);
            }
        }
        t2D.Apply();
        imagemRI.texture = t2D;
        
        Texture texturaImagem = imagemRI.texture;
        Texture2D novaTextura = new Texture2D(texturaImagem.width, texturaImagem.height, TextureFormat.RGBA32, false);
        RenderTexture atualRT = RenderTexture.active;
        RenderTexture RT = new RenderTexture(texturaImagem.width, texturaImagem.height, 32);
        Graphics.Blit(texturaImagem, RT);
        RenderTexture.active = RT;
        novaTextura.ReadPixels(new Rect(0.0f, 0.0f, texturaImagem.width, texturaImagem.height), 0, 0);
        print("w: " + texturaImagem.width + " h: " + texturaImagem.height);

        foreach(Vector3 p in pontos)
        {
            GameObject verticesClicaveis = GameObject.Instantiate(colisor);
            // verticesClicaveis.transform.parent = ;
            verticesClicaveis.transform.position = p;
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    novaTextura.SetPixel((int)(p.x * texturaImagem.width) +i, (int)(p.y * texturaImagem.height) + j, Color.black);
                    print("x: " + (int)p.x * texturaImagem.width/10 +i + " y: " + (int)p.y * texturaImagem.height/10 + j);
                }
            }

        }
        novaTextura.Apply();
        RenderTexture.active = atualRT;
        RT.Release();
        // Destroy(RT);
        // Destroy(texturaImagem);
        imagemRI.texture = novaTextura;
    }
}
