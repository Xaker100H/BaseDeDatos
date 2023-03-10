using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Protagonista : Personajes
{

    [SerializeField] private GameObject botonVolver;
    [SerializeField] private Button botonCuracion;
    [SerializeField] private Button botonDaño;
    [SerializeField] private Button botonMonchitos;
    [SerializeField] private Botones botonController;

    [SerializeField] private float coolDownCuracion;
    [SerializeField] private float coolDownDaño;
    [SerializeField] private float coolDownMonchitos;

    private float tiempoCuracion;
    private float tiempoDaño;
    private float tiempoMonchitos;


    public static float DañoOcasionadoTorre;
    public static float DañoOcasionadoGuardia;
    
    private float DañoTorre;
    public static float DañoEnemigo;
    [SerializeField] private float MultiplicadorDaño;



    protected override void Start()
    {
        base.Start();
        botonCuracion.onClick.AddListener(Curacion);
        botonDaño.onClick.AddListener(Daño);
        botonMonchitos.onClick.AddListener(Monchitos);
        DañoTorre = DañoOcasionadoTorre;
        DañoEnemigo = DañoOcasionadoGuardia;
    }

    //el protect override sirve para sobreescribir una función para hacer el update y más cosas como el movimiento
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

        if (tiempoDaño >= 0)
        {
            tiempoDaño -= Time.deltaTime;
        }
        else
        {
            DañoOcasionadoGuardia = DañoEnemigo;
            DañoOcasionadoTorre = DañoTorre;

            botonDaño.interactable = true;
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

    public void Daño()
    {

        DañoOcasionadoTorre = DañoTorre * MultiplicadorDaño;
        DañoOcasionadoGuardia    = DañoEnemigo * MultiplicadorDaño;

        tiempoDaño = coolDownDaño;
        botonDaño.interactable = false;
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
            enemigoComun.RecibirDaño(DañoOcasionadoGuardia);
        }

        var torre = other.GetComponent<Torre>();

        if (torre != null)
        {
            torre.RecibirDaño(DañoOcasionadoTorre);
        }

    }


}
