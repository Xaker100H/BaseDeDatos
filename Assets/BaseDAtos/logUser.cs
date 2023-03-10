using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class logUser : MonoBehaviour
{
    [Header("PHP variables")]
    public string userToSearch;

    [Header("Connection variables")]
    public string ip = "37.135.112.226";

    public int puerto = 3306;

    private bool connectionInProcess = false;

    [Header("User Read")]
    public List<Base> userList = new List<Base>();

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

    }

    public void Read()
    {

        //Read data from ddbb
        string url = "http://" +ip +"/towerInvasion/" + consulta + "?_User=" + GuardarMensaje.inputUser + "&_Contra=" + GuardarMensaje.inputContra; //change  URL
        Debug.Log("http://" + ip +"/towerInvasion/" + consulta + "?_User=" + GuardarMensaje.inputUser + "&_Contra=" + GuardarMensaje.inputContra);
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
        //User[] userAux = JsonConvert.DeserializeObject<User[]>(JsonStringHP);
        //userList = new List<User>(userAux);
        Debug.Log("JsonStringHP=" + JsonStringHP);
        comprobar(JsonStringHP);
        connectionInProcess = false;
      
    }
    public void comprobar(string zizi)
    {
        if (zizi == "0")
        {
            GuardarMensaje.inputContra = "";
            GuardarMensaje.inputUser = "";
        }
        if (zizi == "1")
        {
            SceneManager.LoadScene("MenuNuevaPartida");
        }
        else
        {
            Debug.Log("error");
        }
        Debug.Log("Ziziz="+zizi);
    }
}


