using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoFases
{
    public static int jogoAtual = 0;

    public static List<Jogo> jogos = new List<Jogo>{
        new Jogo(desenho1(), 4, 45),
        new Jogo(desenho2(), 3, 330)
    };
    static List<Vector3> desenho1()
    {
        List<Vector3> pontos = new List<Vector3>();
        pontos.Add(new Vector3(-3.15f, -1.11f, 0.0f));
        pontos.Add(new Vector3(-3.15f, 0.61f, 0.0f));
        pontos.Add(new Vector3(0.0f, 2.01f, 0.0f));
        pontos.Add(new Vector3(3.15f, 0.61f, 0.0f));
        pontos.Add(new Vector3(3.15f, -1.11f, 0.0f));
        return pontos;
    }
    static List<Vector3> desenho2()
    {
        List<Vector3> pontos = new List<Vector3>();
        pontos.Add(new Vector3(-3.15f, -1.11f, 0.0f));
        pontos.Add(new Vector3(-3.15f, 0.61f, 0.0f));
        pontos.Add(new Vector3(3.15f, 0.61f, 0.0f));
        pontos.Add(new Vector3(3.15f, -1.11f, 0.0f));
        return pontos;
    }
}

public class Jogo
{
    public List<Vector3> desenho;
    public int lados;

    public float rotacao;
    public float raio;
    public int estrela1;
    public int estrela2;
    public int estrela3;

    public Jogo(List<Vector3> desenho, int lados, float rotacao, float raio = 1, int estrela1 = 6, int estrela2 = 4, int estrela3 = 2)
    {
        this.desenho = desenho;
        this.lados = lados;
        this.rotacao = rotacao;
        this.raio = raio;
        this.estrela1 = estrela1;
        this.estrela2 = estrela2;
        this.estrela3 = estrela3;
    }

    public Jogo(List<Vector3> desenho, int lados, int angulo, float raio = 1, int estrela1 = 6, int estrela2 = 4, int estrela3 = 2)
    {
        this.desenho = desenho;
        this.lados = lados;
        this.rotacao = Mathf.PI * angulo/180;
        this.raio = raio;
        this.estrela1 = estrela1;
        this.estrela2 = estrela2;
        this.estrela3 = estrela3;
    }


}
