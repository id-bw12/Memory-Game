using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEditor;
using System.Collections;

public class GameLogic : MonoBehaviour {

	[SerializeField] private TextMesh scoreLabel, missLabel;

    private int score = 0;

	private bool checkingMatch = false;

	private MemoryCard firstCard, secondCard;

    private ControlStart control;

	// Use this for initialization
	void Start () {
	
		scoreLabel = GameObject.Find ("Score Label").GetComponent<TextMesh> ();
		missLabel = GameObject.Find ("Miss Label").GetComponent <TextMesh> ();

        control = GameObject.Find("Control Object").GetComponent<ControlStart>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/**********************************************************
	 * 	NAME: 			CheckRevealedCards
	 *  DESCRIPTION:	Gets the selected memory card and sees
	 * 					if one is already selected. If one is it
	 * 					is saved and the CheckMatch method is 
	 * 					called. If not then its just saved.
	 * 
	 * ********************************************************/
	public void CheckRevealedCards(MemoryCard card){

		if (firstCard != null) {
		
			secondCard = card;

			checkingMatch = true;

			StartCoroutine (CheckMatch());

		} else {
			firstCard = card;
		}
	}

	/**********************************************************
	 * 	NAME: 			CheckMatch
	 *  DESCRIPTION:	Checks to see if the two selected cards
	 * 					match. ifThey match then play a sound
	 * 					effect and a pop up box that say they
	 * 					match. If not then play a sound effect
	 * 					and a pop up box saying they don't match
	 * 
	 * ********************************************************/
	private IEnumerator CheckMatch(){

        yield return new WaitForSeconds(2.5f);

        if (secondCard.Image == firstCard.Image) {

            this.GetComponent<ControlStart>().PlaySoundEffects(true);

            EditorUtility.DisplayDialog ("Match", "Its a match", "Okay");
     
            ++control.Matchs;

            scoreLabel.text = "Matchs: " + control.Matchs;

            CheckWinConditions();

        } else {

            this.GetComponent<ControlStart>().PlaySoundEffects(false);

            EditorUtility.DisplayDialog ("Miss Match", "Its a miss match", "Okay");

			secondCard.FlipFaceDown ();
			firstCard.FlipFaceDown ();

            this.GetComponent<ControlStart>().MissMatchs += 1;

            missLabel.text = "Miss: " + this.GetComponent<ControlStart>().MissMatchs;

			yield return new WaitForSeconds (1.5f);

		}	

		secondCard = null;
		firstCard = null;

		checkingMatch = false;

	}

	/**********************************************************
	 * 	NAME: 			CheckWinConditions
	 *  DESCRIPTION:	Checks to see if the game is over. If
	 * 					it is then enable the buttons and make 
	 * 					a pop up box that tells the player that
	 * 					the game is over and how to play again
	 * 
	 * ********************************************************/
	private void CheckWinConditions(){

        int cardsPairslimit = 8;

		if (control.Matchs == cardsPairslimit) {
			this.GetComponent<ControlStart> ().Fliped = true;

			this.GetComponent<GameMode> ().ToggleButtons ();

			EditorUtility.DisplayDialog ("Game over", "Game over. Hit the start button to play again.", "Okay");

		}
	}

	/**********************************************************
	 * 	NAME: 			Restart
	 *  DESCRIPTION:	Restarts the whole scene
	 * 
	 * 
	 * ********************************************************/
	public void Restart(){

		SceneManager.LoadScene ("Menu_Scene");

	}

	/**********************************************************
	 * 	NAME: 			IsMatch
	 *  DESCRIPTION:	returns the checkingMatch boolean
	 * 
	 * 
	 * ********************************************************/
	public bool IsMatch(){
		return checkingMatch;
	}
		
	/**********************************************************
	 * 	NAME: 			Score
	 *  DESCRIPTION:	Gets and set the score number
	 * 
	 * 
	 * ********************************************************/
	public int Score{
		get { return score;}
		set{ score = value;}
	}
}
