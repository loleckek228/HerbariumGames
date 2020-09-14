using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

[RequireComponent(typeof(ActivationTrap))]
public class Trap : MonoBehaviour
{
    private ActivationTrap activationTrap;

    protected virtual void Start()
    {
        gameObject.name = "Trap";

        ActivationTrap();
    }

    protected void ActivationTrap()
    {
        activationTrap = GetComponent<ActivationTrap>();
        activationTrap.Activate(this);
    }

    public virtual void IsActive(bool isActive)
    {
    }
}