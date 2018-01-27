using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCrosshair : MonoBehaviour {
	[SerializeField] Texture2D crosshairImage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		float width = 20;
		float height = width;
		GUI.DrawTexture(new Rect(Screen.width/2 - width / 2,Screen.height/2 - height / 2, width, height), crosshairImage);
	}
}
