﻿using UnityEngine;
using System.Collections;

public class ActionHUD : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Make Action HUD is initially hidden 
		gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
