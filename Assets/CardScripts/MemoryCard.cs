using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class MemoryCard : MonoBehaviour {

	[SerializeField] private GameLogic logic;

    private Timer gameTimer;

	private Sprite faceCard, backCard;

	private bool isSelected = false, isMatched = false;

	// Use this for initialization
	void Start () {

        gameTimer = GameObject.Find("Control Object").GetComponent<Timer>();

        backCard = this.gameObject.GetComponent<SpriteRenderer> ().sprite;
		logic = GameObject.Find ("Control Object").GetComponent<GameLogic> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (gameTimer.Enable && isSelected && !isMatched) {
			this.transform.Rotate (0.0f, -2.75f, 0.0f);

			CardFlips ();
		} 
		else 
			if(isSelected)
				isSelected = false;
		
	}

	void OnMouseDown(){
		
		if(!gameTimer.Enable && !isSelected){

			isSelected = true;

	        gameTimer.SetTimeLimit();

			gameTimer.Enable = true;

	        logic.CheckRevealedCards(this);
	    }
	}

    private void CardFlips() {

		int y = (int)transform.rotation.eulerAngles.y;

		if (y >= 0 && y <= 89)
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = backCard;
		else if (y >= 90 && y <= 269)
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = faceCard;
		else if (y >= 270 && y <= 359)
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = backCard;

    }

   public Sprite Image{
		get{ return this.faceCard;}
		set{ this.faceCard = value;}
	}

	public void FlipFaceDown(){

		isSelected = true;

		gameTimer.Enable = true;
	}

	public void FlipFaceUp(){

		this.gameObject.GetComponent<SpriteRenderer>().sprite = faceCard;

		isMatched = true;

	}
}
