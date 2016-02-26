using UnityEngine;
using System.Collections;

public class MemoryCard : MonoBehaviour {

	private Sprite card;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){

		this.gameObject.GetComponent<SpriteRenderer> ().sprite = card;
		Debug.Log ("Testing 1 2 3");
	}

	public void SetCardImage(Sprite card){

		this.card = card;
	}
}
