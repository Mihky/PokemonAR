using UnityEngine;
using System.Collections;

public class MewtwoWinScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Make Mewtwo's Win Screen is initially hidden 
		gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;
	}
}
