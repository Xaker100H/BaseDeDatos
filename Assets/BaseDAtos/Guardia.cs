using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Guardia
{
    public int nivel, vida, ataque;


    public Guardia(int nivel, int vida, int ataque)
    {
        this.nivel= nivel;
        this.vida = vida;
        this.ataque = ataque;


    }
}
