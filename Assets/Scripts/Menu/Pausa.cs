using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{

    [SerializeField] private GameObject Boton1;
    [SerializeField] private GameObject Boton2;
    [SerializeField] private GameObject Boton3;

    [SerializeField] public bool PausaActiva = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && PausaActiva == true)
        {
            Renaudar();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && PausaActiva == false)
        {
            Pause();
        }
    }



    public void Pause()
    {
        Time.timeScale = 0f;
        Boton1.SetActive(false);
        Boton2.SetActive(false);
        Boton3.SetActive(false);

        PausaActiva = true;
    }

    public void Renaudar()
    {
        Time.timeScale = 1f;
        Boton1.SetActive(true);
        Boton2.SetActive(true);
        Boton3.SetActive(true);

        PausaActiva = false;
    }
}
