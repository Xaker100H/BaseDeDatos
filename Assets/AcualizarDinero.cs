using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AcualizarDinero : MonoBehaviour
{
    public static string textValue = "0";
    public static string textT = "0";
    public static string textG = "0";
    public static string textP = "0";
    public  TextMeshProUGUI textelement;
    public  TextMeshProUGUI texttorre;
    public  TextMeshProUGUI textguardia;
    public  TextMeshProUGUI textprota;
    // Update is called once per frame
    private void Start()
    {
        textValue = Mejorar.dineroAhora.ToString();
    }
    private void Update()
    {
        textValue = Mejorar.dineroAhora.ToString();
        textelement.text = textValue;
        texttorre.text = textT;
        textguardia.text = textG;
        textprota.text = textP;
        Debug.Log(textValue);
        

    }
    public static void  Dineros()
    {
       textValue = Mejorar.dineroAhora.ToString();
        textT = Mejorar.dineronecesitado.ToString();
       textP = Mejorar.dineronecesitado.ToString();
        textG = Mejorar.dineronecesitado.ToString();

    }
}
