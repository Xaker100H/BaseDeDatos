using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aliados : Personajes1
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
