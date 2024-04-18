using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActiveValues : MonoBehaviour
{

    [SerializeField] float temperature;
    [SerializeField] string contents;
    [SerializeField] float boilingPoint;
    [SerializeField] float roomTemp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Heater"))
		{
		}

	}
}
