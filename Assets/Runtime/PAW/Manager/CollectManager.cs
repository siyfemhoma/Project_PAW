using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    #region Inspector
    [Header("Item to collect (prefab)")]
    [SerializeField] private GameObject _collectItem;

    [Header("Collider Option")]
    [SerializeField] private bool _useTagFilter = true;
    [SerializeField] private string _targetTag = "Item";

    [Header("Sound")]
    [SerializeField] private AudioSource _SE_PickUp;
    #endregion

    #region Variables
    private BoxCollider _itemCollider;

    protected int _collectCount = 0;
    #endregion

    private void Awake()
    {
        _itemCollider = GetComponent<BoxCollider>();

        if (_itemCollider == null )
        {
            Debug.LogWarning("BC Missing");
            enabled = false;
            return;
        }

        _itemCollider.isTrigger = true;
        _itemCollider.enabled = true;
    }

    void Start()
    {
        if (_collectItem == null)
        {
            Debug.LogWarning("Collect Item Prefab is empty. Check Inspector.");
            return;
        }
        // Total : 25

        // sect A
        GenerateItem(new Vector3(51, 6, 2.5f));

        //// sect B1
        GenerateItem(new Vector3(9.5f, 5.75f, 12));

        //// sect B2
        //GenerateItem(new Vector3(0, 0, 0));
        //GenerateItem(new Vector3(0, 0, 0));
        //GenerateItem(new Vector3(0, 0, 0));

        //// sect C1
        //GenerateItem(new Vector3(0, 0, 0));
        //GenerateItem(new Vector3(0, 0, 0));
        //GenerateItem(new Vector3(0, 0, 0));

        //// sect C2
        //GenerateItem(new Vector3(0, 0, 0));
        //GenerateItem(new Vector3(0, 0, 0));

        //// sect M
        //GenerateItem(new Vector3(0, 0, 0));
        //GenerateItem(new Vector3(0, 0, 0));
        //GenerateItem(new Vector3(0, 0, 0));
        //GenerateItem(new Vector3(0, 0, 0));
        //GenerateItem(new Vector3(0, 0, 0));
        //GenerateItem(new Vector3(0, 0, 0));
        //GenerateItem(new Vector3(0, 0, 0));

        //// D1
        //GenerateItem(new Vector3(0, 0, 0));
        
        //// D2
        //GenerateItem(new Vector3(0, 0, 0));

        //// E
        //GenerateItem(new Vector3(0, 0, 0));
        //GenerateItem(new Vector3(0, 0, 0));

        //// F1
        //GenerateItem(new Vector3(0, 0, 0));
        //GenerateItem(new Vector3(0, 0, 0));

        //// F2
        //GenerateItem(new Vector3(0, 0, 0));
        //GenerateItem(new Vector3(0, 0, 0));
    }

    private void GenerateItem(Vector3 spawnPosition)
    {
        if (_collectItem == null)
        {
            Debug.LogWarning("Input Collect Item Prefab in Inspector.");
            return;
        }

        GameObject item = Instantiate(_collectItem, spawnPosition, Quaternion.identity);
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

        _SE_PickUp.Play();

        Destroy(other.gameObject);
        _collectCount++;
    }
}
