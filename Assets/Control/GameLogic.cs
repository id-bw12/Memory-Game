using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	private int score = 0;

	private MemoryCard firstCard, secondCard;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CheckRevealedCards(MemoryCard card){

		if (firstCard != null) {
		
			secondCard = card;
			StartCoroutine (CheckMatch());

		} else {
			firstCard = card;
		}
	}

	private IEnumerator CheckMatch(){

		if (secondCard.Image == firstCard.Image) {
			score += 10;

			Debug.Log ("Score: " + score);
		} else {

			yield return new WaitForSeconds (0.5f);
			secondCard.FlipFaceDown ();
			firstCard.FlipFaceDown ();
		}
	
		secondCard = null;
		firstCard = null;

	}
		
}
