using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Snorlax : MonoBehaviour {
	private Component[] moveParticles;
	private Dictionary<string, ParticleSystem> moves = new Dictionary<string, ParticleSystem> ();
	private GameObject SurfMove;
	// Need to access panel
	private GameObject ActionHUD;

	// Script(s) that Snorlax can talk to:
	// 1. Mewtwo to let AI pick his move. Important function to access: AI()
	public Mewtwo mewtwoScript;

	// Use this for initialization
	void Start () {
		// This block is to get the 3 particle system moves into an easily accessible array
		moveParticles = GetComponentsInChildren<ParticleSystem>();
		foreach (ParticleSystem move in moveParticles) {
			switch (move.name) {
			case "Earthquake":
				moves.Add("Earthquake", move);
				break;
			case "Hyperbeam":
				moves.Add("Hyperbeam", move);
				break;
			case "Icebeam":
				moves.Add("Icebeam", move);
				break;
			default:
				break;
			}
		}
	  
		// One of Snorlax's moves, Surf, isn't a particle system
		// Pretty cringeworthy and djanky to store the move separately from the other moves, but I'm just starting
		SurfMove = GameObject.Find("Surf");
		// Hides Surf initially
		SurfMove.transform.localScale = new Vector3(0, 0, 0);

		// Access the Action HUD
		ActionHUD = GameObject.Find("ActionHUD");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Z)) {
			UseMove("Earthquake");
			UpdateActionHUD("Earthquake", true);
		} else if (Input.GetKeyDown (KeyCode.X)) {
			UseMove("Hyperbeam");
			UpdateActionHUD("Hyper Beam", true);
		} else if (Input.GetKeyDown (KeyCode.C)) {
			UseMove("Icebeam");
			UpdateActionHUD("Ice Beam", true);
		} else if (Input.GetKeyDown (KeyCode.V)) {
			UseMove("Surf");
			UpdateActionHUD("Surf", true);
		}
	}

	// Depending on input, uses one of Snorlax's four moves
	void SnorlaxUse(string moveName) {
		bool hit = true;
		switch (moveName) {
		case "Earthquake":
			UseMove("Earthquake");
			break;
		case "Hyperbeam":
			if (MoveHit (0.9f)) {
				UseMove("Hyperbeam");
			} else {
				hit = false;
			}
			break;
		case "Icebeam":
			UseMove("Icebeam");
			break;
		case "Surf":
			UseMove("Surf");
			break;
		default:
			break;
		}
		UpdateActionHUD(moveName, hit);
	}

	// Checks if moves hit/miss for moves that have < 100% hit rate
	private bool MoveHit(float threshold)
	{
		if (float.Parse(Random.value.ToString("F2")) <= threshold)
		{
			return true;
		}
		return false;
	}

	// Plays the move's particle system
	void UseMove(string moveName) {
		StartCoroutine(DoAndWait(moveName));
	}

	// Function "stalls" the program for x seconds before and after you need to complete something
	IEnumerator DoAndWait(string whatDo)
	{
		// Before waiting
		if (whatDo == "Earthquake") {
			moves ["Earthquake"].Play ();
		} else if (whatDo == "Hyperbeam") {
			moves ["Hyperbeam"].Play ();
		} else if (whatDo == "Icebeam") {
			moves ["Icebeam"].Play ();
		} else if (whatDo == "Surf") {
			SurfMove.transform.localScale = new Vector3 (200, 10, 200);
		} else if (whatDo == "UpdateHUD") {
			ActionHUD.GetComponent<CanvasRenderer>().SetColor (new Color (0f, 221f, 255f, 0.85f));
			ActionHUD.GetComponent<CanvasGroup>().alpha = 0.75f;
		}

		// Wait 5 seconds
		yield return new WaitForSeconds(5);

		// After waiting
		if (whatDo == "Surf") {
			SurfMove.transform.localScale = new Vector3 (0, 0, 0);
		} else if (whatDo == "UpdateHUD") {
			ActionHUD.GetComponent<CanvasGroup>().alpha = 0.0f;
		}
	}

	void AITurn() {
		print ("Here");
		mewtwoScript.AI();
	}

	// Updates the HUD UI with the result of the Pokemon's turn
	void UpdateActionHUD(string moveName, bool hit) {
		if (hit) {
			if (moveName == "Hyperbeam") {
				ActionHUD.GetComponentInChildren<Text> ().text = "Snorlax used Hyper Beam!";
			} else if (moveName == "Icebeam") {
				ActionHUD.GetComponentInChildren<Text> ().text = "Snorlax used Ice Beam!";
			} else {
				ActionHUD.GetComponentInChildren<Text> ().text = "Snorlax used " + moveName + "!";
			}
		} else {
			ActionHUD.GetComponentInChildren<Text>().text = "Snorlax's attack missed!";
		}
		StartCoroutine(DoAndWait("UpdateHUD"));
	}


}



//	// Plays Earthquake particle system
//	void UseEarthquake() {
//		StartCoroutine(DoAndWait("Earthquake"));
//	}
//
//	// Plays Hyper Beam particle system
//	void UseHyperbeam() {
//		StartCoroutine(DoAndWait("Hyperbeam"));
//	}
//
//	// Plays Ice Beam particle system
//	void UseIcebeam() {
//		StartCoroutine(DoAndWait("Icebeam"));
//	}
//
//	// Plays Surf 
//	void UseSurf() {
//		StartCoroutine(DoAndWait("Surf"));
//	}
