using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PressX : MonoBehaviour
{
    public InputActionReference pressButton;
    public GameObject EquipmentCabinet;
    [SerializeField] Animator cabinetAnimation;

    private List<GameObject> interactables = new List<GameObject>();

    private bool isEquipmentCabinetActive = false;


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
        //this is the only necessary part to the cabinet function - Aidan
        isEquipmentCabinetActive = !isEquipmentCabinetActive;
        cabinetAnimation.SetBool("Open", isEquipmentCabinetActive);

    }
}
