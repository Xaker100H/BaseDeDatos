using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    public static string resultado;
    public bool FinDeJuego;
    //defines funcion pública que despues elegiras mediante una funcion on clic desde el editor
    public void Opciones()
    {
        SceneManager.LoadScene("MenuOpciones");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuUsuario");
    }

    public void Registrarse()
    {
        SceneManager.LoadScene("MenuRegistro");
    }

    public void SelectorJuego()
    {
        
        SceneManager.LoadScene("MenuNuevaPartida");
    }
    public void Game()
    {
        SceneManager.LoadScene("MainBase");
    }
    public void BuscarPartida()
    {
        SceneManager.LoadScene("Juego");
    }

    public void Salir()
    {
        Application.Quit();
    }

}
