using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoFases
{
    public static int jogoAtual = 0;

    public static List<Jogo> jogos = new List<Jogo>{
        new Jogo(desenho1(), 0),
        new Jogo(desenho2(), 0)
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
    public int modelo;

    public Jogo(List<Vector3> desenho, int modelo)
    {
        this.desenho = desenho;
        this.modelo = modelo;
    }


}
