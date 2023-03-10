using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Protagonista : Personajes
{

    [SerializeField] private GameObject botonVolver;
    [SerializeField] private Button botonCuracion;
    [SerializeField] private Button botonDa�o;
    [SerializeField] private Button botonMonchitos;
    [SerializeField] private Botones botonController;

    [SerializeField] private float coolDownCuracion;
    [SerializeField] private float coolDownDa�o;
    [SerializeField] private float coolDownMonchitos;

    private float tiempoCuracion;
    private float tiempoDa�o;
    private float tiempoMonchitos;


    public static float Da�oOcasionadoTorre;
    public static float Da�oOcasionadoGuardia;
    
    private float Da�oTorre;
    public static float Da�oEnemigo;
    [SerializeField] private float MultiplicadorDa�o;



    protected override void Start()
    {
        base.Start();
        botonCuracion.onClick.AddListener(Curacion);
        botonDa�o.onClick.AddListener(Da�o);
        botonMonchitos.onClick.AddListener(Monchitos);
        Da�oTorre = Da�oOcasionadoTorre;
        Da�oEnemigo = Da�oOcasionadoGuardia;
    }

    //el protect override sirve para sobreescribir una funci�n para hacer el update y m�s cosas como el movimiento
    //del personaje (es para no duplicar lo que ya tiene el padre)
    //base. el justamente lo que hace update del padre

    //Basicamente sirve para tener ordenado el codigo
    protected override void Update()
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
           
                botonController.FinDeJuego = true;

                Destroy(gameObject);

            }

        }
        base.Update();
        MovimientoPersonajes();

        if(health <= 0)
        {

            if (botonController.FinDeJuego == false)
            {
                botonController.FinDeJuego = true;
                BotonVolver();
            }
        }

        if (tiempoCuracion >= 0)
        {
            tiempoCuracion -= Time.deltaTime;
        }
        else
        {
            botonCuracion.interactable = true;
        }

        if (tiempoDa�o >= 0)
        {
            tiempoDa�o -= Time.deltaTime;
        }
        else
        {
            Da�oOcasionadoGuardia = Da�oEnemigo;
            Da�oOcasionadoTorre = Da�oTorre;

            botonDa�o.interactable = true;
        }

        if (tiempoMonchitos >= 0)
        {
            tiempoMonchitos -= Time.deltaTime;
        }
        else
        {
            botonMonchitos.interactable = true;
        }
       
    }

    public void Curacion()
    {
        if (health <= maxhealth)
        {
            health = health + maxhealth * 25 / 100;
        }
        tiempoCuracion = coolDownCuracion;
        botonCuracion.interactable = false;

    }

    public void Da�o()
    {

        Da�oOcasionadoTorre = Da�oTorre * MultiplicadorDa�o;
        Da�oOcasionadoGuardia    = Da�oEnemigo * MultiplicadorDa�o;

        tiempoDa�o = coolDownDa�o;
        botonDa�o.interactable = false;
    }

    public void Monchitos()
    {


        tiempoMonchitos = coolDownMonchitos;
        botonMonchitos.interactable = false;
    }

    public void BotonVolver()
    {

        botonVolver.SetActive(true);

    }

    private void OnTriggerStay(Collider other)
    {
        var enemigoComun = other.GetComponent<Enemigos>();

        if (enemigoComun != null)
        {
            enemigoComun.RecibirDa�o(Da�oOcasionadoGuardia);
        }

        var torre = other.GetComponent<Torre>();

        if (torre != null)
        {
            torre.RecibirDa�o(Da�oOcasionadoTorre);
        }

    }


}
