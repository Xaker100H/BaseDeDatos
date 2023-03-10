using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class DineroAhora: MonoBehaviour
{
    public static string textValue = "0";
    public TextMeshProUGUI textelement;
    // public GameObject botonVolver;
    [Header("PHP variables")]
    public string userToSearch;

    [Header("Connection variables")]
    public string ip = "37.135.112.226";

    public int puerto = 3306;

    private bool connectionInProcess = false;

    [Header("User Read")]
    public List<Dinero> dineroLista = new List<Dinero>();

    public string consulta;

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
        string url = "http://" + ip+ "/towerInvasion/" + consulta +  "?_idUser=" + GuardarMensaje.inputUser; //change  URL
        Debug.Log("http://" + "localhost" + ":" + puerto + "/towerInvasion/" + consulta + "&_idUser=" + GuardarMensaje.inputUser);
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

        //userList.Clear();
        string JsonStringHP = www.downloadHandler.text;
        Dinero[] userAux = JsonConvert.DeserializeObject<Dinero[]>(JsonStringHP);
       dineroLista = new List<Dinero>(userAux);
        Debug.Log("JsonStringHP=" + JsonStringHP);
      textValue= dineroLista[0].dinero.ToString();
        Mejorar.dineroAhora = dineroLista[0].dinero;
        
        connectionInProcess = false;
      
    }
  
}


