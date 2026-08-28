using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class KillZoneController : MonoBehaviour
{
    #region Inspector
    [Header("Check Point")]
    [SerializeField] private Transform _checkPoint;

    [Header("Collider Option")]
    [SerializeField] private bool _useTagFilter = true;
    [SerializeField] private string _targetTag = "Player";

    [Header("Sound")]
    [SerializeField] private AudioSource _SE_Respawn;
    #endregion

    #region Variables
    private BoxCollider _triggerCollider;
    private Rigidbody _rd;
    #endregion

    private void Awake()
    {
        _triggerCollider = GetComponent<BoxCollider>();

        if ( _triggerCollider == null )
        {
            enabled = false;
            return;
        }

        _rd = GetComponent<Rigidbody>();

        if (_rd == null)
        {
            enabled = false;
            return;
        }

        _triggerCollider.isTrigger = true;
        _triggerCollider.enabled = true;
        
        _rd.useGravity = false;
        _rd.isKinematic = true;
        _rd.constraints = RigidbodyConstraints.FreezeAll;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other == null)
        {
            return;
        }

        if (_useTagFilter)
        {
            if (string.IsNullOrEmpty(_targetTag))
            {
                Debug.LogWarning("Target tag is empty.");
                return;
            }

            if (!other.CompareTag(_targetTag))
            {
                return;
            }
        }

        _SE_Respawn.Play();

        other.transform.position = _checkPoint.position;
    }
}
