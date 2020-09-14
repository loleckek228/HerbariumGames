using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;

    private void Update()
    {
        Following();
    }

    private void Following()
    {
        if (_levelGenerator.GetPlayer() != null)
        {
            Vector3 targetPosition = _levelGenerator.GetPlayer().transform.position + _offset;

            transform.position =
                Vector3.MoveTowards(transform.position,
                    targetPosition,
                    _speed * Time.deltaTime);
        }
    }
}