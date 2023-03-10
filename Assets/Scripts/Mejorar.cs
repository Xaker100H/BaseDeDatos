using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mejorar : MonoBehaviour
{
    public static float dineroAhora;
    public static float dineronecesitado;

    public static int nivelTorre;
    public static int nivelGuardia;
    public static int nivelProta;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(nivelTorre);
        Debug.Log(nivelGuardia);
        Debug.Log(nivelProta);
      

    }
    public static void mejoraTorre()
    {
      

                switch (nivelTorre)
                {
                    case 1:
                        dineronecesitado = 400f;
                Debug.Log(dineronecesitado);
                break;
                    case 2:
                        dineronecesitado = 700;
                Debug.Log(dineronecesitado);
                break;
                    case 3:
                        dineronecesitado = 1400;
                Debug.Log(dineronecesitado);
                break;
                    case 4:
                        dineronecesitado = 2900;
                Debug.Log(dineronecesitado);
                break;
                    case 5:
                        dineronecesitado = 6500;
                Debug.Log(dineronecesitado);
                break;
                }
              
        
    }
    public static void mejoraGuardia()
    {
        
           
                switch (nivelGuardia)
        {
            case 1:
                dineronecesitado = 200f;
                Debug.Log(dineronecesitado);
                break;
            case 2:
                dineronecesitado = 500;
                Debug.Log(dineronecesitado);
                break;
            case 3:
                dineronecesitado = 1600;
                Debug.Log(dineronecesitado);
                break;
            case 4:
                dineronecesitado = 3000;
                Debug.Log(dineronecesitado);
                break;
            case 5:
                dineronecesitado = 5000;
                Debug.Log(dineronecesitado);
                break;
        }


    }
    public static void mejoraProta()
    {
        
          
                switch (nivelProta)
        {
            case 1:
                dineronecesitado = 200f;
                Debug.Log(dineronecesitado);
                break;
            case 2:
                dineronecesitado = 500;
                Debug.Log(dineronecesitado);
                break;
            case 3:
                dineronecesitado = 1600;
                Debug.Log(dineronecesitado);
                break;
            case 4:
                dineronecesitado = 3000;
                Debug.Log(dineronecesitado);
                break;
            case 5:
                dineronecesitado = 5000;
                Debug.Log(dineronecesitado);
                break;
        }


    }
}
