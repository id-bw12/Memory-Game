using UnityEngine;
using UnityEngine.UI;

using System.Collections;

//9:10A.M. - 11:29P.M.
//10:12A.M - 12:52P.M.

public class ControlStart : MonoBehaviour {

	// Use this for initialization
	void Start () {

		SetupLevel ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetupLevel(){

		GameObject background = new GameObject ("Background");

		Sprite backgroundSprite = Resources.Load ("table_top", typeof(Sprite)) as Sprite;

		background.transform.position = new Vector3(0.0f,0.0f,5f);

		background.transform.localScale = new Vector3 (2.0f, 2.0f, 1.0f);

		background.AddComponent<SpriteRenderer> ();

		background.GetComponent<SpriteRenderer> ().sprite = backgroundSprite;

	}
		
}
