using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personajes : MonoBehaviour
{
    [SerializeField] protected float Velocidad;

  
    public static float maxhealth;   
    public static float health;
    public static float danioRecibido;

    [SerializeField] protected GameObject healthBarUI;

    [SerializeField] protected Slider slider;
    [SerializeField] protected string tagEnemigo;

    protected virtual void Start()
    {  
        health = maxhealth;
      slider.value = CalculateHealth();

    }

    //el protect virtual void le da la capacidad a la clase padre de que los hijos hagan lo mismo y puedan agregar otras cosas 
    protected virtual void Update()
    {
       

    }


   public float CalculateHealth()
    {
        return health / maxhealth;
    }

   
    
    protected virtual void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagEnemigo))
        {
            RecibirDaño(danioRecibido);
        }
    }

    public void RecibirDaño(float dañoAplicado)
    {
        health = health - dañoAplicado;
    }

    public void MovimientoPersonajes()
    {
        transform.position += transform.forward * Velocidad * Time.deltaTime;
    }

   

}
