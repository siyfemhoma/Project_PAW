using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class KillZoneController : MonoBehaviour
{
    #region Inspector
    [Header("Collider Option")]
    [SerializeField] private bool _useTagFilter = true;
    [SerializeField] private string _targetTag = "Respawn";

    [Header("Sound")]
    [SerializeField] private AudioSource _SE_Respawn;
    #endregion

    #region Variables
    private CharacterController _cc;
    private BoxCollider _triggerCollider;
    private Vector3 _checkPoint;
    private string _checkPointTag = "CheckPoint";
    #endregion

    private void Awake()
    {
        _triggerCollider = GetComponent<BoxCollider>();

        _cc = FindObjectOfType<CharacterController>();

        if ( _triggerCollider == null )
        {
            enabled = false;
            return;
        }

        _triggerCollider.isTrigger = true;
        _triggerCollider.enabled = true;
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

            if (other.CompareTag(_checkPointTag))
            {
                _checkPoint = other.transform.position;
                Debug.Log("Checkpoint set");
                return;
            }

            else if (!other.CompareTag(_targetTag))
            {
                return;
            }
        }

        _SE_Respawn.Play();

        if (_checkPoint != null)
        {
            _cc.enabled = false;
            this.transform.position = _checkPoint;
            _cc.enabled = true;
        }
        else
        {
            Debug.LogWarning("Check Point is Missing.");
            this.transform.position = Vector3.one;
        }
    }
}
