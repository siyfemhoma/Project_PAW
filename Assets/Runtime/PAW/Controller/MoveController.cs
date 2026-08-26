using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveController : MonoBehaviour
{
    #region Inspector
    //[Header("Camera for Rotation")]
    //[SerializeField] private Transform _camera;

    [Header("Move Speed Setting")]
    [SerializeField] private float _moveSpeed = 5.0f;

    [Header("Jump Setting")]
    [SerializeField] private float _jumpImpulse = 6.0f;
    [SerializeField] private float _groundCheckDis = 0.6f;
    [SerializeField] private LayerMask _groundMask = ~0;
    #endregion

    #region Variables
    private Rigidbody _rb;
    #endregion

    void Start()
    {
        TryGetComponent(out _rb);

        //if (_camera == null)
        //{
        //    Debug.LogWarning("There's no Camera. Check the Inspector.");
        //    return;
        //}

        if (_rb == null)
        {
            Debug.LogWarning("There's no RigidBody. Check the Script.");
            return;
        }
    }

    
    void Update()
    {
        InputMove();
        InputJump();
    }

    private void InputMove()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        moveX *= _moveSpeed * Time.deltaTime;
        moveZ *= _moveSpeed * Time.deltaTime;

        transform.Translate(Vector3.right * moveX, Space.Self);
        transform.Translate(Vector3.forward * moveZ, Space.Self);
    }

    private void InputJump()
    {
        if (_rb == null)
        {
            return;
        }

        if (!Input.GetKeyDown(KeyCode.Space))
        {
            return;
        }

        if (!IsGrounded())
        {
            return;
        }

        _rb.AddForce(Vector3.up * _jumpImpulse, ForceMode.Impulse);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast((transform.position + Vector3.up * 0.1f), Vector3.down, _groundCheckDis, _groundMask);
    }
}
