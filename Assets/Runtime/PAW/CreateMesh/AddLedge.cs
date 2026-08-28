using DiasGames.ClimbingSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLedge : MonoBehaviour
{
    #region Inspector
    [Header("Input Ledge Prefab")]
    [SerializeField] private GameObject _ledgePrefab;

    [Header("Set Position / Rotation Y")]
    [SerializeField] private float _x;
    [SerializeField] private float _y;
    [SerializeField] private float _z;
    [SerializeField] private float _rotateY;
    #endregion

    #region Variables
    
    #endregion


    void Start()
    {
        if (_ledgePrefab == null)
        {
            Debug.LogWarning("Input Ledge Prefab in Inspector.");
            return;
        }

        Vector3 spawnPos = new Vector3(_x, _y, _z);
        Quaternion rotate = Quaternion.Euler(0, _rotateY, 0);

        Instantiate(_ledgePrefab, spawnPos, rotate);


    }
}
