using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationTrap : MonoBehaviour
{
    [SerializeField] private float minDelayTime;
    [SerializeField] private float maxDelayTime;

    private Trap trap;

    public void Activate(Trap trap)
    {
        this.trap = trap;

        StartCoroutine(ActiveTime());
    }

    private IEnumerator ActiveTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelayTime, maxDelayTime));
            trap.IsActive(true);

            yield return new WaitForSeconds(Random.Range(minDelayTime, maxDelayTime));
            trap.IsActive(false);
        }
    }
}