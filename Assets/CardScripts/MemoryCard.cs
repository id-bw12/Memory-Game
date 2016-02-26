using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class MemoryCard : MonoBehaviour {

	[SerializeField] private GameLogic logic;

	private Sprite card, backImage;

	// Use this for initialization
	void Start () {

		backImage = this.gameObject.GetComponent<SpriteRenderer> ().sprite;
		logic = GameObject.Find ("Control Object").GetComponent<GameLogic> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){

		this.gameObject.GetComponent<SpriteRenderer> ().sprite = card;

		logic.CheckRevealedCards(this);

	}

	public Sprite Image{
		get{ return this.card;}
		set{ this.card = value;}
	}

	public void FlipFaceDown(){

		this.gameObject.GetComponent<SpriteRenderer> ().sprite = backImage;
	}
}
