using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyObject : MonoBehaviour {
	public bool isVisible = true;



	// Use this for initialization
	void Start () {
		if (!isVisible)
		{
			GetComponent<Renderer>().enabled = false;

			GetComponent<Collider>().isTrigger = true;
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SwitchState()
	{
		isVisible = !isVisible;
		GetComponent<Renderer>().enabled = isVisible;

		gameObject.GetComponent<Collider>().isTrigger = !isVisible;

	}
}
