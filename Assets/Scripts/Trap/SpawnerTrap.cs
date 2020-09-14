using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

[RequireComponent(typeof(ActivationTrap))]
[RequireComponent(typeof(Rigidbody))]
public class SpawnerTrap : Trap
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _spawnerHeight;
    [SerializeField] private float _speed;

    private Rigidbody rigidbody;
    private Vector3 _spherePosition;

    protected override void Start()
    {
        _spherePosition =
            transform.position + new Vector3(0, _spawnerHeight, 0);

        transform.position = _spherePosition;

        gameObject.name = "SpawnerTrap";
        rigidbody = GetComponent<Rigidbody>();

        ActivationTrap();
    }

    public override void IsActive(bool isActive)
    {
        if (isActive)
        {
            StartCoroutine(SphereSpawner());
        }
        else
        {
            StopCoroutine(SphereSpawner());
        }
    }

    private IEnumerator SphereSpawner()
    {
        yield return new WaitForSeconds(_spawnDelay);

        transform.position = _spherePosition;
        rigidbody.velocity = new Vector3(0, _speed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.gameObject.SetActive(false);
            player.GetLosing().Losing?.Invoke();
        }
    }
}