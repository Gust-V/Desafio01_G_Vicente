using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class sGameController : MonoBehaviour
{
    public string saveFilePath { get => $"{Application.persistentDataPath}/save.json"; }
    public List<ObjectSaveDTO> ObjectSaveList = new List<ObjectSaveDTO>();
    public List<BlocoClass> objects = new List<BlocoClass>();

    public GameObject pfb;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerSaveToJson();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadPlayerSave();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            CreateObject();
        }
    }

    private void CreateObject() //Uso para criar 11 objetos aleatórios 
    {
        ObjectSaveDTO saveDTO = new ObjectSaveDTO();

        for(int i = 0; i < 11; i++)
        {
            var R = UnityEngine.Random.Range(0f, 1f);
            var G = UnityEngine.Random.Range(0f, 1f);
            var B = UnityEngine.Random.Range(0f, 1f);
            var colorr = new Color(R, G, B);
            Vector3 position = new Vector3(UnityEngine.Random.Range(-4.0f, 4.0f), UnityEngine.Random.Range(-2.0f, 2.0f), 0);
            Quaternion rotation = new Quaternion(UnityEngine.Random.Range(0f, 4.0f), UnityEngine.Random.Range(0f, 2.0f), 0, 0);
            Vector3 scale = new Vector3(UnityEngine.Random.Range(1f, 2f), UnityEngine.Random.Range(1f, 2f), UnityEngine.Random.Range(1f, 2f));

            //Esses objetos são do BlocoClass e são feitos em cima do construtor.
            //Em seguida eu adiciono esses objetos em uma lista do tipo BlocoClass
            
            BlocoClass go = new BlocoClass(ObjectType.WTypeOb(ObjectType.Aux.Cube), Collider.Collider, colorr, position, rotation, scale);
            objects.Add(go);
        }
    }

    private void PlayerSaveToJson()
    {
        //Leio a lista e adiciono as informações em uma lista do tipo ObjectSaveDTO, pegando as informações do construtor DTO da classe BlocoClass
        foreach (BlocoClass go in objects)
        {
            ObjectSaveList.Add(go.GetSaveData());
        }
 
        var saves = new ObjectSave()
        {
            Saves = ObjectSaveList.ToArray()
        };
        var json = JsonUtility.ToJson(saves, true);
        Debug.Log(json);

        //Escreve todo o texto, que no caso é a var json criada antes, que contém os dados do player. Ela salva na .persistentDataPath (original da unity)
        //string savepath = $"{Application.persistentDataPath}/save.json";
        Debug.Log(saveFilePath);
        File.WriteAllText(saveFilePath, json);
    }

    private void LoadPlayerSave() //Lê o arquivo de save, através do caminho 
    {
        var jsonText = File.ReadAllText(saveFilePath);
        Debug.Log(jsonText);

        var saveData = JsonUtility.FromJson<ObjectSave>(jsonText);    //Cria uma variavel que recebe um objeto jason do tipo PlayerSave com o arquivo lido
        ObjectSaveList = new List<ObjectSaveDTO>();//Cria uma nova lista DTO
        ObjectSaveList.AddRange(saveData.Saves);//Adiciona  as informações do arquivo lido para a nova lista.
                                                //como as informações estavam serializadas, ele adiciona esses "blocos" de informações separados.
                                                //ObjectSaveList[0] = Um bloco de informações DTO

        //Recrio todos os objetos da lista, usando o construtor do Bloco Class
        int aux = 0;
        foreach (var objct in ObjectSaveList)
        {
            BlocoClass go2 = new BlocoClass(ObjectSaveList[aux].obTypeString, ObjectSaveList[aux].clld, ObjectSaveList[aux].color, ObjectSaveList[aux].position, ObjectSaveList[aux].rotation, ObjectSaveList[aux].scale);
            objects.Add(go2);
            aux++;
        }
    }
}
