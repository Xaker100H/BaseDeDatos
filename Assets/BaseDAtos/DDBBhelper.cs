using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class DDBBhelper : MonoBehaviour
{
   
    [Header("PHP variables")]
    public string userToSearch;

    [Header("Connection variables")]
    public string ip = "37.135.112.226";

    public int puerto= 3306;

    private bool connectionInProcess = false;

    [Header("User Read")]
    public List<Base> userList = new List<Base>();

    public string consulta;

    private void Start()
    {
        Read();
    }

    private void Update()
    {
        Debug.Log(GuardarMensaje.inputContra);
        Debug.Log(GuardarMensaje.inputUser);
        if (connectionInProcess)
        {
            Debug.Log("Connecting");
        }
        
    }

    public void Read()
    {
       
        //Read data from ddbb
        string url = "http://" + ip +"/towerInvasion/" + consulta+ "?_idUser=" + GuardarMensaje.inputUser+ "&_Contra=" + GuardarMensaje.inputContra; //change  URL
        Debug.Log("http://" + ip +"/towerInvasion/" + consulta + "?_idUser='" + GuardarMensaje.inputUser + "'&_Contra=" + GuardarMensaje.inputContra);
        connectionInProcess = true;
        WWWForm form = new WWWForm();
        form.AddField("_idUser", userToSearch.ToString());
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        StartCoroutine(WaitForRequest_Select(www));
    }


    private IEnumerator WaitForRequest_Select(UnityWebRequest www)
    {
        yield return www.SendWebRequest();

        // check for errors
        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("WWW Error: " + www.error);
            connectionInProcess = false;
            yield break;
        }

       
        userList.Clear();
        string JsonStringHP = www.downloadHandler.text;
        Base[] userAux = JsonConvert.DeserializeObject<Base[]>(JsonStringHP);
        userList = new List<Base>(userAux);

        connectionInProcess = false;
    }

}
