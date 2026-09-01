using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstaclePropeller : MonoBehaviour
{
    #region Inspector
    [Header("Input Obstacles")]
    [SerializeField] private GameObject _obstaclePrefab;

    [Header("RotateSpeed")]
    [SerializeField] private float _rotateSpeed = 100.0f;

    [Header("Set Position")]
    [SerializeField] private float _x;
    [SerializeField] private float _y;
    [SerializeField] private float _z;

    [Header("Ohter Setting")]
    [SerializeField] private bool _reverseRotate = false;
    #endregion

    #region Variables
    private Vector3 _spawnPosition;
    #endregion

    private void Awake()
    {
        if (_obstaclePrefab == null)
        {
            Debug.LogWarning("Prefab missing. Check Inspector.");
            enabled = false;
            return;
        }
        _spawnPosition = new Vector3(_x, _y, _z);
    }

    void Start()
    {
        this.transform.position = _spawnPosition;
        Instantiate(_obstaclePrefab, _spawnPosition, Quaternion.identity, this.transform);
    }

    
    void Update()
    {
        if (_obstaclePrefab != null)
        {
            if (_reverseRotate == true)
            {
                this.transform.Rotate(Vector3.up, -(_rotateSpeed *  Time.deltaTime));
            }
            else
            {
                this.transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
            }
        }
    }
}
