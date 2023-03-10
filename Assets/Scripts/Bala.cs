using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad;
    private Vector3 direccion;

    public static float dañoAplicado;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direccion * velocidad * Time.deltaTime;
    }

    public void SetDirection(Vector3 dir)
    {
        direccion = dir;
    }

    private void OnTriggerEnter(Collider other)
    {
        Personajes character = other.gameObject.GetComponent<Personajes>();

        if (character != null)
        {
            character.RecibirDaño(dañoAplicado);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Personajes character = other.gameObject.GetComponent<Personajes>();

        Personajes.DestroyObject(character);
    }
}
