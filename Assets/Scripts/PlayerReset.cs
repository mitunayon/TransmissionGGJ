using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerReset : MonoBehaviour {

    private Vector3 startPos;
    [SerializeField] KeyCode hotKey = KeyCode.R;
    public UnityEvent resetBtnPressed;
   

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        if (resetBtnPressed == null)
        {
            resetBtnPressed = new UnityEvent();
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(hotKey))
        {
            resetBtnPressed.Invoke();
        }
	}

    public void ResetPosition()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
