using UnityEngine;
using System.Collections;
using UnityEngine.Windows.Speech;

public class SpeechRecognition : MonoBehaviour
{
	[SerializeField]
	private Microphone mic;
	private string[] keywords;
	private KeywordRecognizer recognizer;
	//private int currentPlayer;

	// Use this for initialization
	void Start()
	{
		Debug.Log("OPEN");
		//Debug.Log (PhraseRecognitionSystem.isSupported);
		keywords = new string[] { "earthquake", "hyperbeam", "icebeam", "surf" };
		recognizer = new KeywordRecognizer(keywords);
		recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
		//StartGame();
		recognizer.Start();
	}

	private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		Debug.Log("hi");
		Debug.Log(args.text);
		//string[] input = args.text.Split(' ');
		//string move = "filler";
		//switch (move)
		//{
		//    case "earthquake":
		//        recognizer.Stop();
		//        UseEarthquake();
		//        break;
		//    case "hyperbeam":
		//        recognizer.Stop();
		//        UseHyperbeam();
		//        break;
		//    case "icebeam":
		//        recognizer.Stop();
		//        UseIcebeam();
		//        break;
		//    case "surf":
		//        recognizer.Stop();
		//        UseSurf();
		//        break;
		//    default:
		//        break;
		//}

	}
//
//	//Update is called once per frame
//	//void Update()
//	//{
//	//    if (currentPlayer == 0)
//	//    {
//	//        recognizer.Start();
//	//    }
//	//    else
//	//    {
//
//	//    }
//	//}
//
//	//void UseEarthquake()
//	//{
//	//    // Turn on Snorlax's Earthquake particle system
//	//    100 %
//	//    100att
//	//}
//
//	//void UseHyperbeam()
//	//{
//	//    // Turn on Snorlax's Hyperbeam particle system
//	//    90 %
//	//    150att
//	//    cooldown 1 turn
//	//}
//
//	//void UseIcebeam()
//	//{
//	//    // Turn on Snorlax's Icebeam particle system
//	//    100 %
//	//    90att
//	//}
//
//	//void UseSurf()
//	//{
//	//    // Turn on Snorlax's Surf particle system for 5 seconds then turn off.
//	//    100 %
//	//    90att
//	//}
//
//	void StartGame()
//	{
//		//currentPlayer = 0;
//	}
}