using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : Personajes1
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        MovimientoPersonajes();
    }

}
