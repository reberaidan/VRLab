using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PressX : MonoBehaviour
{
    public InputActionReference pressButton;
    public GameObject EquipmentCabinet;

    private List<GameObject> interactables = new List<GameObject>();

    private bool isEquipmentCabinetActive = false;

    // Start is called before the first frame update
    void Start()
    {
        //These are never getting added to the list, they are returning nulls because the equipment cabinet is getting loaded in after the XRRig - Aidan
        /*interactables.Add(GameObject.Find("Beakers"));
        interactables.Add(GameObject.Find("Erlenmeyer_flasks"));
        interactables.Add(GameObject.Find("Graduated_Cylinders"));*/
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
        //this is the only necessary part to the cabinet function - Aidan
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

    //The two functions below were disabled because they will throw errors because the list is empty/has nulls. These cannot be activated or deactivated. - Aidan
    private void EnableAllInteractables()
    {
        //print(interactables);
       // foreach (var interactable in interactables)
       // {
       //     print(interactable.name);
       //     interactable.SetActive(true);
       // }
    }

    private void DisableNonInteractables()
    {
        // Disable all interactables that are not in the list
        /*foreach (var interactable in interactables)
        {

            interactable.SetActive(false);
            
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }
}
