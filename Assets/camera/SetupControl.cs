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

	/**********************************************************
	 * 	NAME: 			MakeControlObject
	 *  DESCRIPTION:	Makes the control object and give it
	 * 					the MainMenu and ControlStart script
	 * 
	 * ********************************************************/
	void MakeControlObject(){

		GameObject control = new GameObject ("Control Object");

        control.AddComponent<MainMenu>();

        control.AddComponent<ControlStart> ();

        

	}
}
