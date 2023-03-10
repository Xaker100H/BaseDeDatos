using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreAtaque : Torre
{
    public string tagEnemigo;
    private Transform target;

    public Botones botonController;

    public GameObject BotonAliado;
    public GameObject g;

    public override void Update()
    {
        slider.value = CalculateHealth();

        if (health < maxhealth)
        {
            healthBarUI.SetActive(transform);
        }

        if (health <= 0)
        {

            if (botonController.FinDeJuego == false)
            {
                botonVolver.SetActive(true);
                g.SetActive(true);
                botonController.FinDeJuego = true;
                
                Destroy(gameObject);

            }
        
        }

        if (health > maxhealth)
        {
            health = maxhealth;
        }

        if (botonController.FinDeJuego == false)
        {
            if (inContact == true)
            {
                BotonAliado.SetActive(false);
                if (countToShoot <= 0)
                {
                    //la posicion del cubo es la taget position
                    GameObject bala = Instantiate(balaPrefab, Disparador.position, transform.rotation);
                    bala.GetComponent<Bala>().SetDirection((target.position - bala.transform.position).normalized);
                    countToShoot = initCountToShoot;
                }
                else
                {
                    countToShoot -= Time.deltaTime;
                }
            }
        }

        
    }
    //protected virtual void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag(tagEnemigo))
    //    {
    //        RecibirDaño(dañoRecibido);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagEnemigo))
        {
            inContact = true;
            target = other.transform;
        }
    }

    
}
