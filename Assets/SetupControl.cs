using UnityEngine;
using System.Collections;

public class SetupControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		MakeControlObject ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void MakeControlObject(){

		GameObject control = new GameObject ();

		control.name = "Control Object";

		control.AddComponent<ControlStart> ();

		control.AddComponent<MakeDeck> ();
	}
}
