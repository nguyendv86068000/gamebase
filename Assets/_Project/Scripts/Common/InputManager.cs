using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool _isMouseDown = false;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isMouseDown = true;
            EventManager.MouseButtonDown?.Invoke();
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isMouseDown = false;
            EventManager.MouseButtonUp?.Invoke();
        }
        if (_isMouseDown)
        {
            EventManager.MouseButtonDownUpdate?.Invoke(Input.mousePosition);
        }
    }
}
