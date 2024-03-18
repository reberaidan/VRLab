using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PressX : MonoBehaviour
{
    public InputActionReference pressButton;
    public GameObject EquipmentCabinet;

    private List<XRGrabInteractable> specialInteractables = new List<XRGrabInteractable>();

    private bool isEquipmentCabinetActive = false;

    // Start is called before the first frame update
    void Start()
    {
        specialInteractables.Add(GameObject.Find("Beaker").GetComponent<XRGrabInteractable>());
        specialInteractables.Add(GameObject.Find("Erlenmeyer_flask").GetComponent<XRGrabInteractable>());
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
            // Disable interactables that are not in the special list when the cabinet is closed
            DisableNonSpecialInteractables();
        }
    }

    private void EnableAllInteractables()
    {
        foreach (var interactable in specialInteractables)
        {
            interactable.enabled = true;
        }
    }

    private void DisableNonSpecialInteractables()
    {
        // Disable all interactables that are not in the special list
        foreach (var interactable in specialInteractables)
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
