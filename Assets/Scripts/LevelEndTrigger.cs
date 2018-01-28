using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTrigger : MonoBehaviour {

    [SerializeField] string nextLevel;
	[SerializeField] GameObject particleGameObject;
	[SerializeField] GameObject endCamera;
	Animator particleAnim;

	// Use this for initialization
	void Start () {
		if (particleGameObject != null)
		{
			particleAnim = particleGameObject.GetComponent<Animator>();
		}
		else print("error: please assign the particle gameObject in the inspector");

		if (endCamera != null)
			endCamera.SetActive(false);
			

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
			StartCoroutine(FinishState(5, other.gameObject));
        }
    }

	IEnumerator FinishState(float waitTime, GameObject player)
	{
		Destroy(player);
		endCamera.SetActive(true);
		particleAnim.SetBool("isLevelFinished", true);
		yield return new WaitForSeconds(waitTime);
		SceneManager.LoadScene(nextLevel);
	}
}
