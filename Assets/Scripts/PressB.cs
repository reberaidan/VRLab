using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PressB : MonoBehaviour
{
    public InputActionReference pressButton;
    public GameObject GraphyOverlay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnEnable()
    {
        pressButton.action.performed += OpenPerf;
        pressButton.action.Enable();
    }

    public void OnDisable()
    {
        pressButton.action.performed -= OpenPerf;
        pressButton.action.Disable();
    }

    public void OpenPerf(InputAction.CallbackContext obj)
    {
        GraphyOverlay.SetActive(true);
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
