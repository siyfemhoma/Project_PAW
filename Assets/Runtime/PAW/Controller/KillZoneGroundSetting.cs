using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KillZoneGroundSetting : MonoBehaviour
{
    private Rigidbody _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        if (_rb == null)
        {
            enabled = false;
            return;
        }

        _rb.useGravity = false;
        _rb.isKinematic = true;
        _rb.constraints = RigidbodyConstraints.FreezeAll;
    }

}
