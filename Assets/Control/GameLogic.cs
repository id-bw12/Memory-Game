using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEditor;
using System.Collections;

public class GameLogic : MonoBehaviour {

	[SerializeField] private TextMesh scoreLabel, missLabel;

	private int score = 0, missMatch = 0;

	private bool checkingMatch = false;

	private MemoryCard firstCard, secondCard;

	// Use this for initialization
	void Start () {
	
		scoreLabel = GameObject.Find ("Score Label").GetComponent<TextMesh> ();
		missLabel = GameObject.Find ("Miss Label").GetComponent <TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CheckRevealedCards(MemoryCard card){

		if (firstCard != null) {
		
			secondCard = card;

			checkingMatch = true;

			StartCoroutine (CheckMatch());

		} else {
			firstCard = card;
		}
	}

	private IEnumerator CheckMatch(){

        yield return new WaitForSeconds(2.5f);

        if (secondCard.Image == firstCard.Image) {

            firstCard.FlipFaceUp();
            secondCard.FlipFaceUp();

            this.GetComponent<ControlStart>().PlaySoundEffects(true);

            EditorUtility.DisplayDialog ("Match", "Its a match", "Okay");

			score++;

			scoreLabel.text = "Score: " + score;



		} else {

            this.GetComponent<ControlStart>().PlaySoundEffects(false);

            EditorUtility.DisplayDialog ("Miss Match", "Its a miss match", "Okay");

			secondCard.FlipFaceDown ();
			firstCard.FlipFaceDown ();

            missMatch++;

			missLabel.text = "Miss: " + missMatch;

			yield return new WaitForSeconds (1.5f);

		}
	
		CheckWinConditions ();

		secondCard = null;
		firstCard = null;

		checkingMatch = false;

	}

	private void CheckWinConditions(){

		if (score == 8) {
			this.GetComponent<ControlStart> ().Fliped = true;

			this.GetComponent<GameMode> ().ToggleButtons ();

			EditorUtility.DisplayDialog ("Game over", "Game over. Hit the start button to play again.", "Okay");

		}
	}

	public void Restart(){

		SceneManager.LoadScene ("Menu_Scene");

	}

	public bool IsMatch(){
		return checkingMatch;
	}
		
	public int Score{
		get { return score;}
		set{ score = value;}
	}

	public int Misses{
	
		get { return missMatch;}
		set{ missMatch = value;}
	}

}
