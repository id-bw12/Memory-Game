using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class MemoryCard : MonoBehaviour {

	[SerializeField] private GameLogic logic;

    private Timer gameTimer;

	private Sprite card, backImage;

    private bool cardFlip = false;

	// Use this for initialization
	void Start () {

        gameTimer = GameObject.Find("Control Object").GetComponent<Timer>();

        gameTimer.enabled = false;
        backImage = this.gameObject.GetComponent<SpriteRenderer> ().sprite;
		logic = GameObject.Find ("Control Object").GetComponent<GameLogic> ();

	}
	
	// Update is called once per frame
	void Update () {

        if (gameTimer.enabled)
        {
            this.transform.Rotate(0.0f, -5.0f, 0.0f);

            CardFlips(this.transform.rotation.eulerAngles.y);
        }
        else
            if (!gameTimer.enabled && cardFlip) {

            this.transform.Rotate(0.0f, 0.0f, 0.0f);

            this.gameObject.GetComponent<SpriteRenderer>().sprite = card;

            cardFlip = false;

        }
	
	}

	void OnMouseDown(){

        gameTimer.SetTimeLimit(4000);

        gameTimer.enabled = true;

        logic.CheckRevealedCards(this);

        cardFlip = true;
    }

    void CardFlips( float yRotation) {

        int y = (int)yRotation;

        if (y >= 0 && y <= 90)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = backImage;
        else
            if (y >= 90 && y <= 270)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = card;
        else
            if (y >= 270 && y <= 360)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = backImage;

    }

    public Sprite Image{
		get{ return this.card;}
		set{ this.card = value;}
	}

	public void FlipFaceDown(){

		this.gameObject.GetComponent<SpriteRenderer> ().sprite = backImage;
	}
}
