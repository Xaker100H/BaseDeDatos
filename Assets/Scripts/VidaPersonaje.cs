using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPersonaje : MonoBehaviour
{
    public float health;
    public float maxhealth;
    public float dañoRecibido;

    public GameObject healthBarUI;
    public Slider slider;

    private void Start()
    {
        health = maxhealth;
        slider.value = CalculateHealth();
    }

    private void Update()
    {
        slider.value = CalculateHealth();

        if (health < maxhealth)
        {
            healthBarUI.SetActive(transform);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (health > maxhealth)
        {
            health = maxhealth;
        }
    }


    float CalculateHealth()
    {
        return health / maxhealth;
    }

    void OnCollisionStay(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Enemigo(Clone)")
        {
            health = health - dañoRecibido;
        }
    }
}
