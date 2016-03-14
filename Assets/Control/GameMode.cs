using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class GameMode : MonoBehaviour {

	private UIMakerScript ui;

	private List<GameObject> buttons = new List<GameObject> ();

	private GameObject dateTime;

	private bool isFlip = false;

	// Use this for initialization
	void Start () {

		dateTime = new GameObject ("Date Label");

		ui = new UIMakerScript ();

        SetupBackgorund();

        MakeScoreText();

		MakeMissText ();

		MakeDateTime ();

		buttons.Add(MakePlayButton ());

		buttons.Add(MakeToggleButton ());

		buttons.Add(MakeShuffleButton ());

	}

	void Update(){
		
		dateTime.GetComponent<TextMesh> ().text = System.DateTime.Now.ToString();
	}

	void SetupBackgorund()
	{

		GameObject background = new GameObject("Background");

		Sprite backgroundSprite = Resources.Load ("1-01-E-01", typeof(Sprite))as Sprite;

		background.transform.position = new Vector3(0.0f, 0.0f, 5f);

		background.transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);

		background.AddComponent<SpriteRenderer>();

		background.GetComponent<SpriteRenderer>().sprite = backgroundSprite;

	}

    void MakeScoreText()
    {

        GameObject text = new GameObject("Score Label");

        text.transform.position = new Vector3(-8.75f, 4.65f, 1.0f);

        text.transform.localScale = new Vector3(0.1f, 0.1f, 1.0f);

        text.AddComponent<MeshRenderer>();

        text.AddComponent<TextMesh>();

        text.GetComponent<TextMesh>().text = "Score: ";

        text.GetComponent<TextMesh>().fontSize = 80;

    }

	void MakeMissText(){
		
		GameObject text = new GameObject("Miss Label");

		text.transform.position = new Vector3(-4.75f, 4.65f, 1.0f);

		text.transform.localScale = new Vector3(0.1f, 0.1f, 1.0f);

		text.AddComponent<MeshRenderer>();

		text.AddComponent<TextMesh>();

		text.GetComponent<TextMesh>().text = "Miss: ";

		text.GetComponent<TextMesh>().fontSize = 80;
	}

	void MakeDateTime(){

		dateTime.transform.position = new Vector3 (3.0f, 4.75f, 1.0f);

		dateTime.transform.localScale = new Vector3 (0.1f, 0.1f, 1.0f);

		dateTime.AddComponent<MeshRenderer> ();

		dateTime.AddComponent<TextMesh> ().text = System.DateTime.Now.ToString ();

		dateTime.GetComponent<TextMesh> ().fontSize = 60;

	}

	void MakeRestartButton()
    {

        GameObject button = new GameObject("UIButton");

        button.transform.position = new Vector3(8.0f, 4.25f, 1.0f);

        button.AddComponent<SpriteRenderer>().sprite = Resources.Load("start-button", typeof(Sprite)) as Sprite;

        button.AddComponent<BoxCollider2D>();

        button.AddComponent<UIButton>();

    }

	GameObject MakePlayButton(){
		GameObject canvas = GameObject.Find ("Canvas");

		GameObject button = ui.CreateButton (canvas.transform, 80, 20, 100, 28, "Start", delegate {StartGame ();});

		button.GetComponent<Image> ().color = Color.cyan;

		button.GetComponentInChildren<Text> ().color = Color.gray;

		return button;
	}

	GameObject MakeToggleButton (){
		GameObject canvas = GameObject.Find ("Canvas");

		GameObject button = ui.CreateButton (canvas.transform, 80, 00, 100, 28, "Display", delegate {ShowCards ();});

		button.GetComponent<Image> ().color = Color.cyan;

		button.GetComponentInChildren<Text> ().color = Color.gray;

		return button;

	}

	GameObject MakeShuffleButton(){
		GameObject canvas = GameObject.Find ("Canvas");

		GameObject button = ui.CreateButton (canvas.transform, 80, -20, 100, 28, "Shuffle", delegate {ShuffleCards ();});

		button.GetComponent<Image> ().color = Color.cyan;

		button.GetComponentInChildren<Text> ().color = Color.gray;

		return button;
	}

	void StartGame(){

		buttons [1].GetComponent<Button> ().enabled = false;
		buttons [2].GetComponent<Button> ().enabled = false;

		var deck = gameObject.GetComponent<MakeDeck> ().GetDeck ();

		if (isFlip)
			isFlip = false;

		for (int i = 0; i < deck.Count; i++) {
			deck [i].GetComponent<BoxCollider2D> ().enabled = true;
			deck [i].GetComponent<MemoryCard> ().ToggleCards (isFlip);
		}
	}

	void ShowCards(){

		var deck = gameObject.GetComponent<MakeDeck> ().GetDeck ();

		var bttnText = buttons [1].GetComponentInChildren<Text> ();

		if (isFlip) {
			isFlip = false;
			bttnText.text = "Display";
		} else{
			isFlip = true;
			bttnText.text = "Hide";
		}
		for (int i = 0; i < deck.Count; i++){
				deck [i].GetComponent<MemoryCard> ().ToggleCards (isFlip);
		}


	}

	void ShuffleCards(){
		gameObject.GetComponent<MakeDeck> ().ShuffleImages();

		var deck = gameObject.GetComponent<MakeDeck> ().GetDeck ();

		if (isFlip)
			for (int i = 0; i < deck.Count; i++)
					deck [i].GetComponent<MemoryCard> ().ToggleCards (isFlip);
	
}
}