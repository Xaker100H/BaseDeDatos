using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuardarMensaje : MonoBehaviour
{
    public static string inputUser;
    public static string inputContra;
    public void leerUser(string s)
    {
        inputUser = s;
        Debug.Log(inputUser);
    }
    public void leerContra(string c)
    {
        inputContra = c;
        Debug.Log(inputContra);
    }
}
