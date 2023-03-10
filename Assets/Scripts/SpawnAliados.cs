using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAliados : MonoBehaviour
{
    [SerializeField] private GameObject Aliados;
    [SerializeField] int numeroDeItems;
    public float spawnTime;

    //public Vector3 Spawn;
    //public GameObject Spawner;

    public void Spawnear()
    {
        Invoke("SpawnObject", spawnTime);
    }

    public void SpawnObject()
    {
        Instantiate(Aliados, transform.position, transform.rotation);
        return;
    }
}
