using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class MejorarTorre : MonoBehaviour
{
    [Header("PHP variables")]
    public string userToSearch;

    [Header("Connection variables")]
    public string ip = "37.135.112.226";

    public int puerto = 3306;

    private bool connectionInProcess = false;

    [Header("User Read")]
    public List<TorreNvl> TorreNvl_list = new List<TorreNvl>();

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
        if (Mejorar.dineroAhora >= Mejorar.dineronecesitado)
        {
            Read();
        }
    }

    public void Read()
    {

        //Read data from ddbb
        string url = "http://" + ip+ "/towerInvasion/" + consulta + "?_idUser=" + GuardarMensaje.inputUser + "&_DineroNecesitado=" + Mejorar.dineronecesitado; //change  URL
        Debug.Log("http://" + "localhost" + ":" + puerto + "/towerInvasion/" + consulta + "?_idUser=" + "Hugo" + "&_DineroNecesitado=" + Mejorar.dineronecesitado);
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
        /* TorreNvl[] torres = JsonConvert.DeserializeObject<TorreNvl[]>(JsonStringHP);
        TorreNvl_list = new List<TorreNvl>(torres);
      */

        Debug.Log("JsonStringHP=" + JsonStringHP);
        
        connectionInProcess = false;

    }
    public void Comparacion()
    {
        if (Mejorar.dineroAhora >= Mejorar.dineronecesitado)
        {
            Read();
        }
        else
        {
            Debug.Log("NEcesitas MAs oro");

        }
    } 
}
