using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _distanceBetweenStep;
    [SerializeField] private float _speed;

    private Animator _animator;
    private Player _player;
    private Vector3 targetPosition;

    public UnityAction<Boolean> Moving;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
        
        targetPosition = _player.transform.position;
    }

    private void Update()
    {
        MovePlayer();
    }

    public void OnLeftPointerClick()
    {
        targetPosition = _player.transform.position - _distanceBetweenStep;

        ChangeDirection(-90f);
    }

    public void OnRightPointerClick()
    {
        targetPosition = _player.transform.position + _distanceBetweenStep;

        ChangeDirection(90);
    }

    private void MovePlayer()
    {
        if (_player.transform.position.x != targetPosition.x)
        {
            _animator.SetBool("isWalk", true);

            _player.transform.position =
                Vector3.MoveTowards(_player.transform.position,
                    targetPosition,
                    _speed * Time.deltaTime);
            Moving?.Invoke(true);
        }
        else
        {
            _animator.SetBool("isWalk", false);

            ChangeDirection(180);
            Moving?.Invoke(false);
        }
    }

    private void ChangeDirection(float direction)
    {
        _player.transform.rotation =
            Quaternion.Euler(0, direction, 0);
    }
}