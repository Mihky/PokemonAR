﻿﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Mewtwo : MonoBehaviour {
	private Component[] moveParticles;
	private Dictionary<string, ParticleSystem> moves = new Dictionary<string, ParticleSystem> ();
	private float randomMove;
	private GameObject ActionHUD;

	// Use this for initialization
	void Start () {
		moveParticles = GetComponentsInChildren<ParticleSystem>();
		foreach (ParticleSystem move in moveParticles) {
			switch (move.name) {
			case "Swift":
				moves.Add("Swift", move);
				break;
			case "Psychic":
				moves.Add("Psychic", move);
				break;
			case "Thunder":
				moves.Add("Thunder", move);
				break;
			case "RockSlide":
				moves.Add ("RockSlide", move);
				break;
			default:
				break;
			}
		}

		// Access the Action HUD
		ActionHUD = GameObject.Find("ActionHUD");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			AI ();
		}
	}

	public void AI()
	{
		// Before Mewtwo does a move check to see if game is still going. Game is going if:
		// 1. Mewtwo or Snorlax has health above 0

		string moveName = "";
		bool hit = true;
		randomMove = float.Parse(Random.value.ToString("F2"));
		// Swift
		if (randomMove < 0.25) {
			moveName = "Swift";
		// Psychic
		} else if (randomMove < 0.5)
		{
			moveName = "Psychic";
		// Thunder
		} else if (randomMove < .75)
		{
			if (MoveHit(0.7f)) {
				moveName = "Thunder";
			} else
			{
				hit = false;
			}
		// Rock Slide
		} else
		{
			if (MoveHit(0.9f))
			{
				moveName = "RockSlide";
			} else
			{
				hit = false;
			}
		}

		UseMove(moveName);
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
		if (whatDo == "Swift") {
			moves ["Swift"].Play ();
		} else if (whatDo == "Psychic") {
			moves ["Psychic"].Play ();
		} else if (whatDo == "Thunder") {
			moves ["Thunder"].Play ();
		} else if (whatDo == "RockSlide") {
			moves ["RockSlide"].Play ();
		} else if (whatDo == "UpdateHUD") {
			ActionHUD.GetComponent<CanvasRenderer>().SetColor (new Color (181f, 0f, 251f, 0.85f));
			ActionHUD.GetComponent<CanvasGroup>().alpha = 0.75f;
		}

		// Wait 6 seconds
		yield return new WaitForSeconds(6);

		// After waiting
		if (whatDo == "UpdateHUD") {
			ActionHUD.GetComponent<CanvasGroup>().alpha = 0.0f;
		}
	}

	// Updates the HUD UI with the result of the Pokemon's turn
	void UpdateActionHUD(string moveName, bool hit) {
		if (hit) {
			if (moveName == "RockSlide") {
				ActionHUD.GetComponentInChildren<Text>().text = "Mewtwo used Rock Slide!";
			} else {
				ActionHUD.GetComponentInChildren<Text>().text = "Mewtwo used " + moveName + "!";
			}
		} else {
			ActionHUD.GetComponentInChildren<Text>().text = "Mewtwo's attack missed!";
		}
		StartCoroutine(DoAndWait("UpdateHUD"));
	}
}
