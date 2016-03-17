using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class MemoryCard : MonoBehaviour {

	[SerializeField] private GameLogic logic;

    private Timer gameTimer;

	private Sprite faceCard, backCard;

	private bool isSelected = false;

	// Use this for initialization
	void Start () {

        gameTimer = gameObject.AddComponent<Timer>();

        backCard = this.gameObject.GetComponent<SpriteRenderer> ().sprite;
		logic = GameObject.Find ("Control Object").GetComponent<GameLogic> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (gameTimer.Enable && isSelected) {
			this.transform.Rotate (0.0f, -2.75f, 0.0f);

			CardFlips ();
		} 
		else 
			if(isSelected)
				isSelected = false;
		
	}

	/**********************************************************
	 * 	NAME: 			OnMouseDown
	 *  DESCRIPTION:	Checks to see if the current card
	 * 					is selected in a already and if isn't
	 * 					already paired off. if both are false
	 * 					then passes it to the game logic and 
	 * 					activate to the timer.
	 * 
	 * ********************************************************/
	void OnMouseDown(){
		
		if(!isSelected && !logic.IsMatch()){

			isSelected = true;

			gameTimer.SetTimeLimit();

            gameTimer.Enable = true;

	        logic.CheckRevealedCards(this);
	    }
	}

	/**********************************************************
	 * 	NAME: 			CardFlips
	 *  DESCRIPTION:	Gets the cards y rotation coordinate   
	 * 					and changes the card image base on the 
	 * 					y coordinate.
	 * 
	 * ********************************************************/
    private void CardFlips() {

		int y = (int)transform.rotation.eulerAngles.y;

		if (y >= 0 && y <= 89)
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = backCard;
		else if (y >= 90 && y <= 269)
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = faceCard;
		else if (y >= 270 && y <= 359)
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = backCard;

    }

	/**********************************************************
	 * 	NAME: 			Image
	 *  DESCRIPTION:	The Image sprite property that get and 
	 * 					returns a sprite image. 
	 * 
	 * ********************************************************/
   public Sprite Image{
		get{ return this.faceCard;}
		set{ this.faceCard = value;}
	}

	/**********************************************************
	 * 	NAME: 			FlipFaceDown
	 *  DESCRIPTION:	sets the isSelect value to true and 
	 * 					the timer time limit. Also enables the
	 * 					the timer.
	 * 
	 * ********************************************************/
	public void FlipFaceDown(){

		isSelected = true;

		gameTimer.SetTimeLimit();

		gameTimer.Enable = true;
	}

	/**********************************************************
	 * 	NAME: 			FlipFaceUp
	 *  DESCRIPTION:	Flips the cards image to the faceCard 
	 * 					image and set the disable the box collision
	 * 
	 * ********************************************************/
	public void FlipFaceUp(){

		this.gameObject.GetComponent<SpriteRenderer>().sprite = faceCard;

		this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;

	}

	/**********************************************************
	 * 	NAME: 			ToggleCards
	 *  DESCRIPTION:	Gets the isFlip bollean variable and 
	 * 					changes the card picture face up or down
	 * 					base on the the variable value
	 * 
	 * ********************************************************/
	public void ToggleCards(bool isFlip){
	
		if(isFlip)
			this.gameObject.GetComponent<SpriteRenderer>().sprite = faceCard;
		else
			this.gameObject.GetComponent<SpriteRenderer>().sprite = backCard;
	}
}
