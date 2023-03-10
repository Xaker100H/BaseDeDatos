using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Base
{
    public int id, nivelTorre, nivelGuardia, nivelProta, dinero;
    public string usuario, contrasenia;

    public Base(int id, string usuario, string contrasenia, int nivelTorre, int nivelGuardia,int nivelProta,int dinero)
    {
        this.id = id;
        this.nivelTorre = nivelTorre;
        this.nivelGuardia = nivelGuardia;
        this.nivelProta = nivelProta;
        this.usuario = usuario;
        this.contrasenia = contrasenia;
        this.dinero = dinero;
    }
}