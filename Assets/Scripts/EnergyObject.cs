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
		
	bool ParentEnergy()
	{
		Transform parent = transform.parent;

		if (parent == null)
			return false;
			
		EnergyObjectList energyObjectList = parent.GetComponent<EnergyObjectList>();
		if (energyObjectList == null)
			return false;


		energyObjectList.SwitchState(isVisible);
		return true;
	}



	public void SwitchState()
	{
		if (ParentEnergy())
			return;

		isVisible = !isVisible;
		GetComponent<Renderer>().enabled = isVisible;

		gameObject.GetComponent<Collider>().isTrigger = !isVisible;
		print("regular switch state");
	}
}
