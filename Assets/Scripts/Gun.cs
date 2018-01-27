using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	Camera playerCam;
	bool isLoaded;

	void Awake() {
		playerCam = GetComponent<Camera>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject raycastedObj = RaycastObject();
		if (raycastedObj == null)
			return;
		
		EnergyObject raycastedEnergyObj = raycastedObj.GetComponent<EnergyObject>();
		if (raycastedEnergyObj == null)
			return;

		if (!isLoaded && raycastedEnergyObj.isVisible)
		{
			Absorb();
			raycastedEnergyObj.SwitchState(raycastedObj);
		}

		else if (isLoaded && !raycastedEnergyObj.isVisible)
		{
			Shoot();
			raycastedEnergyObj.SwitchState(raycastedObj);
		}
	}

	GameObject RaycastObject()
	{
		RaycastHit hit;
		float dist;

		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		Debug.DrawRay(transform.position, forward, Color.green);

		if(Physics.Raycast(transform.position, forward, out hit))
		{
			if (Input.GetMouseButtonDown(0))
			{
				print(hit.transform.gameObject.name);
				return hit.transform.gameObject;
			}
		}

		return null;
	}

	void Absorb()
	{
		isLoaded = true;
	}

	void Shoot()
	{
		isLoaded = false;
	}
}
