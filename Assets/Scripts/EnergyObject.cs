using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyObject : MonoBehaviour {
	public bool isVisible = true; 
	Animator anim;


	void Awake()
	{
		anim = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {

		if (!isVisible)
		{
			//GetComponent<Renderer>().enabled = false;
			anim.SetBool("isMaterialized", false);
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
		//GetComponent<Renderer>().enabled = isVisible;
		anim.SetBool("isMaterialized", isVisible);
		gameObject.GetComponent<Collider>().isTrigger = !isVisible;

	}
}
