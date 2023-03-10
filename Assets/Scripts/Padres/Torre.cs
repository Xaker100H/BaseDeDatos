using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torre : MonoBehaviour
{
    [SerializeField] protected Transform Disparador;


    [SerializeField] protected GameObject balaPrefab;
    [SerializeField] protected GameObject botonVolver;

    [SerializeField] protected float countToShoot;
    [SerializeField] protected float initCountToShoot;

    [SerializeField] protected bool inContact;

    [SerializeField]
    public static  float health;
    [SerializeField] public static float maxhealth;
    //[SerializeField] protected float dañoRecibido;

    [SerializeField] protected GameObject healthBarUI;
    [SerializeField] protected Slider slider;


    public virtual void Start()
    {
        initCountToShoot = countToShoot;
        health = maxhealth;
        slider.value = CalculateHealth();
    }

    public virtual void Update()
    {
       

    }

    protected virtual float CalculateHealth()
    {
        return health / maxhealth;
    }
    

    public void RecibirDaño(float dañoAplicado)
    {
        health = health - dañoAplicado;
    }

    

    
    
}
