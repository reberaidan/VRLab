using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PressX : MonoBehaviour
{
    public InputActionReference pressButton;
    public GameObject EquipmentCabinet;

    private List<XRGrabInteractable> interactables = new List<XRGrabInteractable>();

    private bool isEquipmentCabinetActive = false;

    // Start is called before the first frame update
    void Start()
    {
        interactables.Add(GameObject.Find("Beakers").GetComponent<XRGrabInteractable>());
        interactables.Add(GameObject.Find("Erlenmeyer_flasks").GetComponent<XRGrabInteractable>());
        interactables.Add(GameObject.Find("Graduated_Cylinders").GetComponent<XRGrabInteractable>());
    }

    public void OnEnable()
    {
        pressButton.action.performed += ToggleEquipmentCabinet;
        pressButton.action.Enable();
    }

    public void OnDisable()
    {
        pressButton.action.performed -= ToggleEquipmentCabinet;
        pressButton.action.Disable();
    }

    public void ToggleEquipmentCabinet(InputAction.CallbackContext obj)
    {
        isEquipmentCabinetActive = !isEquipmentCabinetActive;
        EquipmentCabinet.SetActive(isEquipmentCabinetActive);

        if (isEquipmentCabinetActive)
        {
            // Enable all interactables when the cabinet is open
            EnableAllInteractables();
        }
        else
        {
            // Disable interactables when the cabinet is closed
            DisableNonInteractables();
        }
    }

    private void EnableAllInteractables()
    {
        foreach (var interactable in interactables)
        {
            interactable.enabled = true;
        }
    }

    private void DisableNonInteractables()
    {
        // Disable all interactables that are not in the list
        foreach (var interactable in interactables)
        {
            if (!interactable.isSelected)
            {
                interactable.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
