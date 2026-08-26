using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTemp : MonoBehaviour
{
    [SerializeField] private CursorLockMode _cursorLockMode = CursorLockMode.Locked;
    [SerializeField] private bool _visibleCursor = false;

    private void Awake()
    {
        Cursor.lockState = _cursorLockMode;
        Cursor.visible = _visibleCursor;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
