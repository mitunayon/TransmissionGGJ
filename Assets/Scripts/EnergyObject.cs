using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyObject : MonoBehaviour {
	public bool isVisible;


	// Use this for initialization
	void Start () {
		isVisible = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SwitchState()
	{
		isVisible = !isVisible;
		GetComponent<Renderer>().enabled = isVisible;
	}
}
