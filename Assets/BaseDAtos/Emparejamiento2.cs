using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class Emparejamiento2 : MonoBehaviour
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
    static public int id;
    public List<Guardia> Guardia_list { get; private set; }

    private void Start()
    {
    }

    private void Update()
    {

        if (connectionInProcess)
        {
            Debug.Log("Connecting");
        }

    }

    public void Read()
    {

        //Read data from ddbb
        string url = "http://" + ip + "/towerInvasion/" + consulta + "?_idUser=" +id;
            //+  "&_DineroNecesitado=" + GuardarMensaje.inputContra; //change  URL
        Debug.Log("http://" + "localhost" + ":" + puerto + "/towerInvasion/" + consulta + "?_idUser="+ idRival);
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
        
        Guardia[] guardia = JsonConvert.DeserializeObject<Guardia[]>(JsonStringHP);
      Guardia_list = new List<Guardia>(guardia);
        Debug.Log(Guardia_list[0].vida);
        Debug.Log(Guardia_list[0].ataque);
        Guardia_list = new List<Guardia>(guardia);
        Personajes1.maxhealth = Guardia_list[0].vida;
        Mejorar.nivelGuardia = Guardia_list[0].nivel;

       Personajes.danioRecibido = Guardia_list[0].ataque;
        Debug.Log("JsonStringHP=" + JsonStringHP);
       
        connectionInProcess = false;

    }
    public void Rival() 
    {
        idRival = Random.Range(1, 4);
        
        //Random.Range(1, numeroJugadores);
    }

}
