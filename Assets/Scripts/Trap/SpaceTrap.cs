using System;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(ActivationTrap))]
public class SpaceTrap : Trap
{
    private Floor floor;

    protected override void Start()
    {
        gameObject.name = "SpaceTrap";

        ActivationTrap();
    }

    public override void IsActive(bool isActive)
    {
        if (isActive)
        {
            floor.gameObject.SetActive(false);
        }
        else
        {
            floor.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Floor floor))
        {
            this.floor = floor;
        }
    }
}