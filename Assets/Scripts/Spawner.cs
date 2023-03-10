using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemigos;
    [SerializeField] int numeroDeItems;
    public float spawnTime;
    public float spawnDelay;


    void Start()
    {
        //Al comenzar invocamos repetidamente la función de SpawnObject con un delay aplicado 
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        //Creamos un bucle for que instancie objetos repetitivamente y sume la variable numero de items, cuando alcanze un numero de invocaciones especificas debe cancelar la invocación
        for (int i = 0; i <= numeroDeItems; i++)
        {
            Instantiate(enemigos, new Vector3(10.41f, -3.56f, 0), transform.rotation);
            numeroDeItems++;

            if (numeroDeItems == 5)
                CancelInvoke();

            break;
        }
        return;
    }
}
