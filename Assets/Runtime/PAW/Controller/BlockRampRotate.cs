using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRampRotate : MonoBehaviour
{
    private enum ERotateDir
    {
        DOWN,
        UP,
        LEFT,
        RIGHT
    };

    [Header("Speed")]
    [SerializeField] private float _rotateSpeed = 100.0f;

    [Header("Rotate Direction")]
    [SerializeField] private ERotateDir _rotateDirection = ERotateDir.DOWN;

    void Update()
    {
        switch (_rotateDirection)
        {
            case ERotateDir.DOWN:
                this.transform.Rotate(Vector3.right, -(_rotateSpeed * Time.deltaTime), Space.Self);
                break;
            case ERotateDir.UP:
                this.transform.Rotate(Vector3.right, _rotateSpeed * Time.deltaTime, Space.Self);
                break;
            case ERotateDir.LEFT:
                this.transform.Rotate(Vector3.up, -(_rotateSpeed * Time.deltaTime), Space.Self);
                break;
            case ERotateDir.RIGHT:
                this.transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime, Space.Self);
                break;
        }
    }
}
