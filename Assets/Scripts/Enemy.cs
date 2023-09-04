using System;
using System.Collections;
using System.Collections.Generic;
using HurricaneVR.Framework.Components;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected HVRDestructible destructible;

    protected void Awake()
    {
        destructible = GetComponent<HVRDestructible>();
    }
}
