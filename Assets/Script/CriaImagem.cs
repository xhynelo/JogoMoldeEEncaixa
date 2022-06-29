using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CriaImagem : MonoBehaviour
{
    public GameObject colisor;
    public RawImage imagem;
    // public Canvas imagemCanvas;
    
    List<Vector3> pontos = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
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
        imagem.texture = t2D;
        pontos.Add(new Vector3(0.5f, 0.5f, 0.0f));
        pontos.Add(new Vector3(0.0f, 0.5f, 0.0f));
        pontos.Add(new Vector3(0.5f, 0.0f, 0.0f));
        Texture texturaImagem = imagem.texture;
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
                    novaTextura.SetPixel((int)(p.x * texturaImagem.width/10) +i, (int)(p.y * texturaImagem.height/10) + j, Color.black);
                    print("x: " + (int)p.x * texturaImagem.width/10 +i + " y: " + (int)p.y * texturaImagem.height/10 + j);
                }
            }

        }
        novaTextura.Apply();
        RenderTexture.active = atualRT;
        RT.Release();
        // Destroy(RT);
        // Destroy(texturaImagem);
        imagem.texture = novaTextura;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
