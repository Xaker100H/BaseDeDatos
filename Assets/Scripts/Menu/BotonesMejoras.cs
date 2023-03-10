using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonesMejoras : MonoBehaviour
{

    [SerializeField] public GameObject Barracones;
    [SerializeField] public GameObject torre;
    [SerializeField] public GameObject Personaje;

    //Activar el boton para mejorar barracones
    public void activarBarracones()
    {
        Barracones.SetActive(true);
       // StartCoroutine(RutinaTemporizadorBarracones());
    }

    //Activar el boton para mejorar torre
    public void activarTorre()
    {
        torre.SetActive(true);
      //  StartCoroutine(RutinaTemporizadorTorre());
    }

    //Activar el boton para mejorar personaje
    public void activarPersonaje()
    {
        Personaje.SetActive(true);
      //  StartCoroutine(RutinaTemporizadorPersonaje());
    }


    //corrutinas para esperar 10 segundos y que desaparezca el cartel de mejora de cada uno
    IEnumerator RutinaTemporizadorPersonaje()
    {
        yield return new WaitForSeconds(10);
        Personaje.SetActive(false);
    }

    IEnumerator RutinaTemporizadorBarracones()
    {
        yield return new WaitForSeconds(10);
        Barracones.SetActive(false);
    }

    IEnumerator RutinaTemporizadorTorre()
    {
        yield return new WaitForSeconds(10);
        torre.SetActive(false);
    }

}
