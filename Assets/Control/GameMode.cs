using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Events;
using UnityEngine.EventSystems;

using System.Collections;
using System.Collections.Generic;

public class GameMode : MonoBehaviour {

	private UIMakerScript ui;

    private ControlStart control;

    private GameObject dateTime;

    private List<GameObject> buttons = new List<GameObject> ();

	// Use this for initialization
	void Start () {

		ui = new UIMakerScript ();

        control = GameObject.Find("Control Object").GetComponent<ControlStart>();

        dateTime = new GameObject("Date Label");

        SetupBackgorund();

        MakeGameNumber ();

        MakeScoreText();

		MakeMissText ();

		MakeDateTime ();

		buttons.Add(MakePlayButton ());

		buttons.Add(MakeToggleButton ());

		buttons.Add(MakeShuffleButton ());

		buttons.Add (MakebackButton ());
	}

    void Update()
    {

        dateTime.GetComponent<TextMesh>().text = System.DateTime.Now.ToString();
    }

	/**********************************************************
	 * 	NAME: 			SetupBackground
	 *  DESCRIPTION:	Makes a GameObject that holds the 
	 * 					background image.
	 * 
	 * ********************************************************/
    void SetupBackgorund()
    {

        GameObject background = new GameObject("Background");

        Sprite backgroundSprite = Resources.Load("1-01-E-01", typeof(Sprite)) as Sprite;

        background.transform.position = new Vector3(0.0f, 0.0f, 5f);

        background.transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);

        background.AddComponent<SpriteRenderer>();

        background.GetComponent<SpriteRenderer>().sprite = backgroundSprite;

    }

	/**********************************************************
	 * 	NAME: 			MakeGamenumber
	 *  DESCRIPTION:	Makes a GameObject that holds and shows 
	 * 					the shows the current game number
	 * 
	 * ********************************************************/
    void MakeGameNumber()
    {

        GameObject text = new GameObject("Game Label");

        text.transform.position = new Vector3(-12.75f, 5.0f, 1.0f);

        text.transform.localScale = new Vector3(0.1f, 0.1f, 1.0f);

        text.AddComponent<MeshRenderer>();

        text.AddComponent<TextMesh>();

        text.GetComponent<TextMesh>().text = "Game: 0";

        text.GetComponent<TextMesh>().fontSize = 80;
    }

	/**********************************************************
	 * 	NAME: 			MakeScoreText
	 *  DESCRIPTION:	Makes a GameObject that holds and shows
	 * 					the shows the current Scroe
	 * 
	 * 
	 * ********************************************************/
    void MakeScoreText()
    {

        GameObject text = new GameObject("Score Label");

        text.transform.position = new Vector3(-6.75f, 5.0f, 1.0f);

        text.transform.localScale = new Vector3(0.1f, 0.1f, 1.0f);

        text.AddComponent<MeshRenderer>();

        text.AddComponent<TextMesh>();

        text.GetComponent<TextMesh>().text = "Matchs: 0";

        text.GetComponent<TextMesh>().fontSize = 80;

    }

	/**********************************************************
	 * 	NAME: 			MakemissText
	 *  DESCRIPTION:	Makes a GameObject that holds and shows  
	 * 					the shows the current miss plays
	 * 
	 * 
	 * ********************************************************/
    void MakeMissText()
    {

        GameObject text = new GameObject("Miss Label");

        text.transform.position = new Vector3(-2.75f, 5.0f, 1.0f);

        text.transform.localScale = new Vector3(0.1f, 0.1f, 1.0f);

        text.AddComponent<MeshRenderer>();

        text.AddComponent<TextMesh>();

        text.GetComponent<TextMesh>().text = "Miss: 0";

        text.GetComponent<TextMesh>().fontSize = 80;
    }

	/**********************************************************
	 * 	NAME: 			MakeDateTime
	 *  DESCRIPTION:	Makes a GameObject that holds and shows 
	 * 					the shows the current date and time
	 * 
	 * 
	 * ********************************************************/
    void MakeDateTime()
    {

        dateTime.transform.position = new Vector3(3.0f, 4.75f, 1.0f);

        dateTime.transform.localScale = new Vector3(0.1f, 0.1f, 1.0f);

        dateTime.AddComponent<MeshRenderer>();

        dateTime.AddComponent<TextMesh>().text = System.DateTime.Now.ToString();

        dateTime.GetComponent<TextMesh>().fontSize = 60;

    }

	/**********************************************************
	 * 	NAME: 			MakePlayButton
	 *  DESCRIPTION:	Makes a button a child of the canvas object
	 * 					and returns it
	 * 
	 * 
	 * ********************************************************/
    GameObject MakePlayButton()
    {
        GameObject canvas = GameObject.Find("Canvas");

        GameObject button = ui.CreateButton(canvas.transform, 80, 20, 100, 28, "Start", delegate { StartGame(); });

        button.GetComponent<Image>().color = Color.cyan;

        button.GetComponentInChildren<Text>().color = Color.gray;

        return button;
    }

	/**********************************************************
	 * 	NAME: 			MakeDateTime
	 *  DESCRIPTION:	Makes a button the child of the canvas 
	 * 					and returns it.
	 * 
	 * 
	 * ********************************************************/
    GameObject MakeToggleButton()
    {
        GameObject canvas = GameObject.Find("Canvas");

        GameObject button = ui.CreateButton(canvas.transform, 80, 00, 100, 28, "Display", delegate { ShowCards(); });

        button.GetComponent<Image>().color = Color.cyan;

        button.GetComponentInChildren<Text>().color = Color.gray;

        return button;

    }

	/**********************************************************
	 * 	NAME: 			MakeShuffleButton
	 *  DESCRIPTION:	Makes a button the child of the canvas 
	 * 					and returns it.
	 * 
	 * 
	 * ********************************************************/
    GameObject MakeShuffleButton()
    {
        GameObject canvas = GameObject.Find("Canvas");

        GameObject button = ui.CreateButton(canvas.transform, 80, -20, 100, 28, "Shuffle", delegate { ShuffleCards(); });

        button.GetComponent<Image>().color = Color.cyan;

        button.GetComponentInChildren<Text>().color = Color.gray;

        return button;
    }

	/**********************************************************
	 * 	NAME: 			MakebackButton
	 *  DESCRIPTION:	Makes a button the child of the canvas 
	 * 					and returns it.
	 * 
	 * 
	 * ********************************************************/
    GameObject MakebackButton()
    {
        GameObject canvas = GameObject.Find("Canvas");

        GameObject button = ui.CreateButton(canvas.transform, 80, -40, 100, 28, "Back", delegate { BacktoMainMenu(); });

        button.GetComponent<Image>().color = Color.cyan;

        button.GetComponentInChildren<Text>().color = Color.gray;

        return button;
    }

	/**********************************************************
	 * 	NAME: 			StartGame
	 *  DESCRIPTION:	If the cards are face up then flips them
	 * 					face down and disables the display and 
	 * 					shuffle buttons. Enables the cards collision
	 * 					and update the game number, matchs, and misses
	 * 
	 * ********************************************************/
    void StartGame(){
		
		var deck = gameObject.GetComponent<MakeDeck> ().GetDeck ();
        

        for (int i = 0; i < 3; i++) 
		    buttons [i].GetComponent<Button> ().enabled = false;

		if (control.isFlip) {
            control.isFlip = false;
			for (int i = 0; i < deck.Count; i++) {
				deck [i].GetComponent<BoxCollider2D> ().enabled = true;
				deck [i].GetComponent<MemoryCard> ().ToggleCards (control.isFlip);
			}
		} else if(this.GetComponent<ControlStart> ().GameNumber != 0){
			
			for (int i = 0; i < deck.Count; i++) {
				deck [i].GetComponent<BoxCollider2D> ().enabled = true;
				deck [i].GetComponent<MemoryCard> ().FlipFaceDown ();
			}
		}
		else
			for (int i = 0; i < deck.Count; i++) 
				deck [i].GetComponent<BoxCollider2D> ().enabled = true;


        control.GameNumber += 1;

        control.Matchs = 0;

        control.MissMatchs = 0;

        GameObject.Find ("Game Label").GetComponent<TextMesh> ().text = "Game: " + this.GetComponent<ControlStart> ().GameNumber;

        GameObject.Find("Score Label").GetComponent<TextMesh>().text  = "Matchs: 0";

        GameObject.Find("Miss Label").GetComponent<TextMesh>().text = "Miss: 0";
    }

	/**********************************************************
	 * 	NAME: 			ShowCards 
	 *  DESCRIPTION:	Flips the cards face up or face down
	 * 					base on the isFlip variable
	 * 
	 * 
	 * ********************************************************/
	void ShowCards(){

		var deck = gameObject.GetComponent<MakeDeck> ().GetDeck ();

		var bttnText = buttons [1].GetComponentInChildren<Text> ();

		if (control.isFlip) {
            control.isFlip = false;
			bttnText.text = "Display";
		} else{
            control.isFlip = true;
			bttnText.text = "Hide";
		}


        for (int i = 0; i < deck.Count; i++)
				deck [i].GetComponent<MemoryCard> ().ToggleCards (control.isFlip);
		
	}

	/**********************************************************
	 * 	NAME: 			ShuffleCards
	 *  DESCRIPTION:	Gets the deck and shuffles the deck and
	 * 					if the cards are flip then show the new 
	 * 					card positions
	 * 
	 * ********************************************************/
	void ShuffleCards ()
	{
		gameObject.GetComponent<MakeDeck> ().ShuffleImages ();

		var deck = gameObject.GetComponent<MakeDeck> ().GetDeck ();

		if (control.isFlip)
			for (int i = 0; i < deck.Count; i++)
				deck [i].GetComponent<MemoryCard> ().ToggleCards (control.isFlip);
	
	}

	/**********************************************************
	 * 	NAME: 			BacktomainMenu
	 *  DESCRIPTION:	Calls the ClearScreen method and removes
	 * 					the MakeDeck, GameLogic, and GameMode 
	 * 					scripts. Also adds the MainMenu script
	 * 
	 * ********************************************************/
	void BacktoMainMenu(){

		ClearScreen ();

		this.gameObject.AddComponent<MainMenu>();
	
		Destroy (this.GetComponent<MakeDeck>());

		Destroy (this.GetComponent<GameLogic>());

		Destroy (this.GetComponent<GameMode>());
	}

	/**********************************************************
	 * 	NAME: 			ClearScreen
	 *  DESCRIPTION:	Destorys all objects on the screen
	 * 					and clears the deck and button lists
	 * 
	 * 
	 * ********************************************************/
	void ClearScreen(){
	
		List<GameObject> deck = this.GetComponent<MakeDeck> ().GetDeck ();

		GameObject.Destroy (GameObject.Find("Background"));

		GameObject.Destroy (GameObject.Find("Date Label"));

		GameObject.Destroy (GameObject.Find("Score Label"));

		GameObject.Destroy (GameObject.Find("Miss Label"));

		for (int i = 0; i < deck.Count; ++i)
			GameObject.Destroy (deck [i]);

		GameObject.Destroy (GameObject.Find ("Canvas"));

		deck.Clear ();

		buttons.Clear ();
	}

	/**********************************************************
	 * 	NAME: 			ToggleButtons
	 *  DESCRIPTION:	Enables the display and shuffle buttons
	 * 
	 * 
	 * ********************************************************/
	public void ToggleButtons(){

        buttons [0].gameObject.GetComponent<Button>().enabled = true;
		buttons [1].gameObject.GetComponent<Button> ().enabled = true;
		buttons [2].gameObject.GetComponent<Button> ().enabled = true;
	
	}
}