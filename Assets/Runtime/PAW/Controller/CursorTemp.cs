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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_cursorLockMode == CursorLockMode.Locked)
            {
                _cursorLockMode = CursorLockMode.None;
                Cursor.lockState = _cursorLockMode;
            }
            else if (_cursorLockMode == CursorLockMode.None)
            {
                _cursorLockMode = CursorLockMode.Locked;
                Cursor.lockState = _cursorLockMode;
            }
        }
    }
}
