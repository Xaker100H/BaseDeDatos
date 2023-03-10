using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class RandomId : MonoBehaviour
{
    [Header("PHP variables")]
    public string userToSearch;

    [Header("Connection variables")]
    public string ip = "37.135.112.226";

    public int puerto = 3306;
    public static int idRival;
    private bool connectionInProcess = false;

    [Header("User Read")]
    public List<Base> userList = new List<Base>();

    public string consulta;
    static public int numeroJugadores;

    public List<Base> Base_list { get; private set; }

    private void Start()
    {
    }

    private void Update()
    {

        if (connectionInProcess)
        {
            Debug.Log("Connecting");
        }
        Read();
    }

    public void Read()
    {

        //Read data from ddbb
        string url = "http://" + ip + "/towerInvasion/" + consulta;
            //+  "&_DineroNecesitado=" + GuardarMensaje.inputContra; //change  URL
  
        connectionInProcess = true;
        WWWForm form = new WWWForm();
        form.AddField("_idUser", userToSearch.ToString());
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        StartCoroutine(WaitForRequest_Select(www));
    }


    public IEnumerator WaitForRequest_Select(UnityWebRequest www)
    {
        yield return www.SendWebRequest();

        // check for errors
        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("WWW Error: " + www.error);
            connectionInProcess = false;
            yield break;
        }

        
        string JsonStringHP = www.downloadHandler.text;

        Base[] Bas = JsonConvert.DeserializeObject<Base[]>(JsonStringHP);
        Base_list = new List<Base>(Bas);
        Emparejamiento.id = Base_list[0].id;
        Emparejamiento2.id = Base_list[0].id;
        Debug.Log(Emparejamiento.id);
        Debug.Log(Emparejamiento2.id);

        //  Personajes.health = Prota_list[0].vida;
        Debug.Log("JsonStringHP=" + JsonStringHP);
       
        connectionInProcess = false;

    }
    public void Rival() 
    {
        idRival = Random.Range(1, 4);
        
        //Random.Range(1, numeroJugadores);
    }

}
