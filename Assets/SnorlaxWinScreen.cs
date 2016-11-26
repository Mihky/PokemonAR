using UnityEngine;
using System.Collections;

public class SnorlaxWinScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Make Snorlax's Win Screen is initially hidden 
		gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;
	}
}
