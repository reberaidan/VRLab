using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PressB : MonoBehaviour
{
    public InputActionReference pressButton;
    [SerializeField] GameObject GraphyInterface;

    private bool isDebug = false;

    // Start is called before the first frame update
    void Start()
    {
        GraphyInterface.SetActive(false);
    }

    public void OnEnable()
    {
        pressButton.action.performed += enableDebug;
        pressButton.action.Enable();
    }

    public void OnDisable()
    {
        pressButton.action.performed -= enableDebug;
        pressButton.action.Disable();
    }

    public void enableDebug(InputAction.CallbackContext obj)
    {
        isDebug = !isDebug;
        print("debug on");
        GraphyInterface.gameObject.SetActive(isDebug);
    }
}
