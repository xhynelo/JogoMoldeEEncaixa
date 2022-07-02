using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class InfoFases
{
    public static int jogoAtual = 0;

    public static SaveData salvos = new SaveData();

    public static List<Jogo> jogos = new List<Jogo>{
        new Jogo(desenho1(), 4, 45, 3, 6, 8),
        new Jogo(estrela(), 3, 330, 4, 7, 10),
        new Jogo(coqueiro(), 6, 0, 5, 10, 15),
        new Jogo(carro(),4, 45, 4, 7, 10),
        new Jogo(quebraCabeca(), 6, 0, 6, 10, 13)
    };

    static List<Vector3> desenho1()
    // desenha uma casa
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
    // desenha um retangulo
    {
        List<Vector3> pontos = new List<Vector3>();
        pontos.Add(new Vector3(-6f, -3.8f, 0.0f));
        pontos.Add(new Vector3(-6f, 4.2f, 0.0f));
        pontos.Add(new Vector3(6f, 4.2f, 0.0f));
        pontos.Add(new Vector3(6f, -3.8f, 0.0f));
        return pontos;
    }

    static List<Vector3> coqueiro()
    // desenha um coqueiro
    {
        float deslocamento = 0.8f;
        List<Vector3> pontos = new List<Vector3>();
        pontos.Add(new Vector3(deslocamento + -1.6660815108156704f, -0.763092484723682f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -0.6537782364143109f, 1.6130045382514504f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -2.5377858260347512f, 1.4302281992422496f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -1.862917745743099f, 2.5690682289798983f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -0.892794159096423f, 2.8221440475802386f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -2.326889695189095f, 3.9750439732361156f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -0.6959579241689943f, 4.045343452827255f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -0.17574639105008677f, 3.5813715033812583f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 1.0474507062691685f, 4.2f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 2.1300534602616668f, 2.8502638394166953f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 1.3708260044606473f, 3.215816517435097f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 0.8084370915148167f, 2.9486808029165283f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 2.158173252098122f, 2.44253147364361f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 2.5377858260347512f, 0.6147634676960796f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 1.4130056922153302f, 1.6130045382514504f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 1.497365067724697f, 0.34762775317751193f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 1.188049665451446f, -0.7209127969689981f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 0.04920963571379687f, 1.6973639137608174f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -0.7240777160054507f, -0.8615117561512757f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -0.6678381323325393f, -3.799999999999999f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -1.834797953906644f, -3.7718802081635436f, 0.0f));

        return pontos;
    }

    static List<Vector3> estrela()
    // desenha uma estrela
    {
        float deslocamento = 0;
        List<Vector3> pontos = new List<Vector3>();
        pontos.Add(new Vector3(deslocamento + -0.014258916458324859f, 3.0592345887107415f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 0.838375548373169f, 1.1490443947730544f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 3.0000000000000004f, 0.8992325755625885f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 1.501462843509959f, -0.49677441571244524f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 1.8771732397866947f, -2.6349748290258876f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 0.018082573509707545f, -1.6741945751837986f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -1.8310310894530906f, -2.659234588710741f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -1.4814744014526458f, -0.44895155155888683f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -3.0f, 0.85998148433475f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -0.8445606811857622f, 1.1352861164738657f, 0.0f));
        return pontos;
    }

    static List<Vector3> carro()
    // desenha um carro
    {
        float deslocamento = 0;
        List<Vector3> pontos = new List<Vector3>();
        pontos.Add(new Vector3(deslocamento + -3.403096657008432f, -2.414993142431634f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -4.485687534221623f, -2.414993142431634f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -5.171838288798644f, -1.3476493353177748f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -5.999999999999998f, -1.0884377335916533f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -5.999999999999998f, 0.9090213597260175f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -4.780178971871404f, 0.9090213597260175f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -2.127064894180731f, 2.8149931424316343f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 1.0444723869621848f, 2.8149931424316343f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 3.392630392618032f, 1.335958882571562f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 6.000000000000001f, 0.48208383688047407f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 6.000000000000001f, -1.4392067361601335f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 4.853951384275257f, -1.5993091222298903f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 4.331713968290148f, -2.3311309968745997f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 3.2414979260219363f, -2.3311309968745997f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 2.448614420738885f, -1.6221096371485824f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -2.640707291924042f, -1.6221096371485824f, 0.0f));
        return pontos;
    }

    static List<Vector3> quebraCabeca()
    // desenha uma peca de quebra cabeca
    {
        float deslocamento = 1;
        List<Vector3> pontos = new List<Vector3>();
        pontos.Add(new Vector3(deslocamento + -5.3083366424517076f, 4.172709817570251f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -2.080915652519213f, 4.2f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -2.378082268575834f, 2.8890004905281352f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -1.1484543692041769f, 1.7937305832613109f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 0.13361425801779903f, 2.893969306953821f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -0.23296068767372916f, 4.2f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 2.680264418023406f, 4.2f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 2.680264418023406f, 0.9371899745392536f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 4.078708743080051f, 1.5025624255448362f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 5.3083366424517076f, 0.33137371236364443f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 4.312465487841911f, -0.9741748616009913f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 2.680264418023406f, -0.5836079512274888f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 2.680264418023406f, -3.8f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -0.30288103524794996f, -3.8f, 0.0f));
        pontos.Add(new Vector3(deslocamento + 0.16309266310060552f, -2.657779542640909f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -1.1829015907126668f, -1.6264352619653817f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -2.5294078624652543f, -2.599340356450444f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -2.179800518558314f, -3.7999999999999985f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -5.308336642451706f, -3.7727098175702496f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -5.308336642451706f, -0.7731312045969476f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -3.898364439046039f, -1.157699656630304f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -2.9484235360071005f, 0.2002896451846503f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -4.014730793487654f, 1.4299175445563073f, 0.0f));
        pontos.Add(new Vector3(deslocamento + -5.281046460021957f, 0.9076910139917327f, 0.0f));
        return pontos;
    }

}

public class Jogo
{
    public List<Vector3> desenho;
    public int lados;
    public float rotacao;
    public float raio;
    public int pontosAdionaveis;
    public int estrela1;
    public int estrela2;
    public int estrela3;

    public Jogo(List<Vector3> desenho, int lados, float rotacao, int estrela3 = 2, int estrela2 = 4, int estrela1 = 6, float raio = 1)
    {
        this.desenho = desenho;
        this.lados = lados;
        this.rotacao = rotacao;
        this.raio = raio;
        this.estrela1 = estrela1;
        this.estrela2 = estrela2;
        this.estrela3 = estrela3;
        pontosAdionaveis = desenho.Count - lados; 
    }

    public Jogo(List<Vector3> desenho, int lados, int angulo, int estrela3 = 2, int estrela2 = 4, int estrela1 = 6, float raio = 1)
    {
        this.desenho = desenho;
        this.lados = lados;
        this.rotacao = Mathf.PI * angulo/180;
        this.raio = raio;
        this.estrela1 = estrela1;
        this.estrela2 = estrela2;
        this.estrela3 = estrela3;
        pontosAdionaveis = desenho.Count - lados;
    }


}

[Serializable]
public class SaveData
{
    public int[] intArray = new int[5]{0,0,0,0,0};
}

public class SaveLoad
{
    public static void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter(); 
        FileStream file = File.Create(Application.persistentDataPath 
                    + "/MySaveData.dat"); 

        bf.Serialize(file, InfoFases.salvos);
        file.Close();
        Debug.Log("Game data saved!");
    }

    public static void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath 
                    + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = 
                    File.Open(Application.persistentDataPath 
                    + "/MySaveData.dat", FileMode.Open);
            InfoFases.salvos = (SaveData)bf.Deserialize(file);
            file.Close();

            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }

    public static void ResetData()
    {
        if (File.Exists(Application.persistentDataPath 
                    + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath 
                            + "/MySaveData.dat");
            // intToSave = 0;
            InfoFases.salvos = new SaveData();
            // boolToSave = false;
            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }
}
