using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyObject : MonoBehaviour {
	public bool isVisible = true; 
	Animator anim;
    [SerializeField] AudioSource audioSource;


	void Awake()
	{
		anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
	}

	// Use this for initialization
	void Start () {

		if (!isVisible)
		{
			//GetComponent<Renderer>().enabled = false;
			anim.SetBool("isMaterialized", false);
			GetComponent<Collider>().isTrigger = true;
            audioSource.enabled = false;
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
        audioSource.enabled = isVisible;
        //GetComponent<Renderer>().enabled = isVisible;
        anim.SetBool("isMaterialized", isVisible);
		gameObject.GetComponent<Collider>().isTrigger = !isVisible;

	}
}
