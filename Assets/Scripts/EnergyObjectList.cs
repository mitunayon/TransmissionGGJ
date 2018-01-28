using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyObjectList : MonoBehaviour {

	GameObject[] energyGameObjects;
	public bool isVisible;
    [SerializeField] AudioSource audioSource;


    // Use this for initialization
    void Start () {
		int childrenCount = transform.childCount;
		energyGameObjects = new GameObject[childrenCount];
        audioSource = GetComponent<AudioSource>();
        UpdateSound();
    }

	// Update is called once per frame
	void Update () {

	}

    void UpdateSound()
    {
        if (isVisible)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }

	public void SwitchState(bool _isVisible)
	{
        
        _isVisible = !_isVisible;
		isVisible = _isVisible;
        //audioSource.enabled = isVisible;
        UpdateSound();
        

        for (int i = 0; i < energyGameObjects.Length; i++)
		{
			transform.GetChild(i).GetComponent<EnergyObject>().isVisible = isVisible;
			//transform.GetChild(i).GetComponent<Renderer>().enabled = isVisible;
			transform.GetChild(i).GetComponent<Animator>().SetBool("isMaterialized", isVisible);
			transform.GetChild(i).GetComponent<Collider>().isTrigger = !isVisible;
			print("Object " + i + " renderer is " + isVisible);
			print("Object " + i + " collider is " + !isVisible);
		}
	}

}
