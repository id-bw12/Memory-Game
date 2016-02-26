using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections;

public class GameLogic : MonoBehaviour {

	[SerializeField] private TextMesh scoreLabel;

	private int score = 0;

	private MemoryCard firstCard, secondCard;

	// Use this for initialization
	void Start () {
	
		scoreLabel = GameObject.Find ("Score Label").GetComponent<TextMesh> ();

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
			score++;

			scoreLabel.text = "Score: " + score;
		} else {

			yield return new WaitForSeconds (0.5f);
			secondCard.FlipFaceDown ();
			firstCard.FlipFaceDown ();
		}
	
		secondCard = null;
		firstCard = null;

	}

	public void Restart(){

		SceneManager.LoadScene ("Memory_Scene");

	}
		
}
