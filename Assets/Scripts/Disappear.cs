using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dissapear : MonoBehaviour
{	
	public GameObject PauseInstruction;
	public int frame = 0;	

    // Update is called once per frame
    void Update()
    {
		
        if (frame == 200) {
			PauseInstruction.SetActive(false);
		}
		
		frame += 1;
    }
}
