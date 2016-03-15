using UnityEngine;
using UnityEngine.UI;

using UnityEditor;

using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {

    private List<GameObject> buttons = new List<GameObject>();

    private UIMakerScript menuMaker = new UIMakerScript();

    private GameObject canvas, dateText;

	private Sprite background = Resources.Load ("1-01-E-01", typeof(Sprite))as Sprite;

    // Use this for initialization
    void Start () {

        canvas = menuMaker.CreateCanvas(this.transform);

        menuMaker.CreateEventSystem(canvas.transform);

        MakeMainMenu();

    }
	
	// Update is called once per frame
	void Update () {
	
		dateText.GetComponent<Text> ().text = System.DateTime.Now.ToString ();
	}

    void MakeMainMenu() {

		GameObject mainMenupanel = menuMaker.CreatePanel(canvas.transform, background);

        GameObject text = menuMaker.CreateText(mainMenupanel.transform, 0, 50, 160, 50, "Eddie's Memory Game", 14);

		dateText = menuMaker.CreateText (mainMenupanel.transform, 100, -50, 100, 25, System.DateTime.Now.ToString(), 8);

        buttons.Add(menuMaker.CreateButton(mainMenupanel.transform, 0, 32, 125, 25, "Play", delegate { PlayGame(mainMenupanel); }));
		buttons.Add(menuMaker.CreateButton (mainMenupanel.transform, 0, 12, 125, 25, "Instructions", delegate {GameInstruct(mainMenupanel);}));
        buttons.Add(menuMaker.CreateButton(mainMenupanel.transform, 0, -10, 125, 25, "ID Info", delegate { IdInfo(mainMenupanel); }));
        buttons.Add(menuMaker.CreateButton(mainMenupanel.transform, 0, -30, 125, 25, "Options", delegate { Options(mainMenupanel); }));
        buttons.Add(menuMaker.CreateButton(mainMenupanel.transform, 0, -50, 125, 25, "Exit", delegate { Exit(); }));
    }

    void PlayGame(GameObject panel)
    {
        DestoryPanel(panel);

		GameObject.Destroy (dateText);

        this.gameObject.AddComponent<GameMode>();

        this.gameObject.AddComponent<GameLogic>();

        this.gameObject.AddComponent<MakeDeck>();

		Destroy (this.GetComponent<MainMenu>());

    }

	void GameInstruct(GameObject panel){

		DestoryPanel (panel);

		string message = "The player starts the game by hitting the start button and selecting a card.\n"
		                 + " The cards are not shuffled. To shuffle hit the shuffle button on the right\n"
		                 + " side of the screen. There 8 pairs of cards to match with a sound effect\n"
		                 + " for each match or mismatch. For every match the player gets one point. The\n"
		                 + " miss matchs are also counted. The game ends when the all card are matched\n"
		                 + " with another card of the same image. To start another game hit the start\n"
		                 + " again.\n";

		GameObject instructPanel = menuMaker.CreatePanel(canvas.transform, background);

		GameObject instructText = menuMaker.CreateText (instructPanel.transform, -50,00,100,100, message,8);

		instructText.GetComponent<Text> ().alignment = TextAnchor.MiddleLeft;

		dateText = menuMaker.CreateText (instructPanel.transform, 100, -50, 100, 25, System.DateTime.Now.ToString(), 8);

		buttons.Add(menuMaker.CreateButton(instructPanel.transform, 0, -50, 125, 25, "back", delegate { Back(instructPanel); }));
	}

    void IdInfo(GameObject panel) {

        DestroyObject(panel);

		GameObject idPanel = menuMaker.CreatePanel(canvas.transform, background);

        GameObject headerText = menuMaker.CreateText(idPanel.transform, 0, 55, 160, 50, "Id Information", 14);

		GameObject idText = menuMaker.CreateText(idPanel.transform, 35, 05, 160, 90,"", 08);

		dateText = menuMaker.CreateText (idPanel.transform, 100, 50, 100, 25, System.DateTime.Now.ToString(), 8);

		GameObject idBttn = menuMaker.CreateButton(idPanel.transform, -120, -50, 100, 25, "Id Info", 
			delegate { displayId(idPanel,idText); });

		GameObject crdeitsBttn = menuMaker.CreateButton(idPanel.transform, -60, -50, 100, 25, "Credits", 
			delegate { displayCredits(idPanel,idText); });

		GameObject mediaBttn = menuMaker.CreateButton(idPanel.transform, 0, -50, 100, 25, "Media",
			delegate { displayMedia(idPanel,idText); });
		
		GameObject starBttn = menuMaker.CreateButton(idPanel.transform, 60, -50, 100, 25, "Stars",
			delegate { displayStar(idPanel,idText); });
		
		GameObject backBttn = menuMaker.CreateButton(idPanel.transform, 120, -50, 100, 25, "back", 
			delegate { Back(idPanel); });
    }

	void displayId(GameObject panel, GameObject text){

		string message = "Programmers\t\t\t\t: Eddie Meza\n"+
			"Assignment #\t\t\t\t: Program 3.MM\n"+
			"Assignment Name\t\t: Memory Game\n"+
			"Course # and Title    : CISC 221 - C#\n"+
			"Class Meeting Time  : TTH 09:35 - 12:35\n"+
			"Instructor\t\t\t\t    : Professor Forman\n"+
			"Hours\t\t\t\t\t\t\t: 20\n"+
			"Difficulty\t\t\t\t        : 7\n"+
			"Completion Date\t\t: 03/14/2016\n"+
			"Project Name\t\t\t    : Memory_Game";


		text.GetComponent<Text> ().text = message;

		text.GetComponent<RectTransform> ().anchoredPosition = new Vector2(35, 05);

		text.GetComponent<Text> ().alignment = TextAnchor.MiddleLeft;
	}

	void displayCredits(GameObject panel, GameObject text){

		//GameObject.Destroy (text);

		string message = "Credits\n";

		text.GetComponent<Text> ().text = message;

		text.GetComponent<Text> ().alignment = TextAnchor.MiddleLeft;
	}

	void displayMedia(GameObject panel, GameObject text){

		string message = "Pictures\n" +
		                 "Bioshock Logo http://tinyurl.com/bioshockLogo\n" +
		                 "Plasmids pics http://tinyurl.com/plasmids\n" +
		                 "City wallpaper http://tinyurl.com/mk3kfg4\n" +
		                 "Bathysphere http://tinyurl.com/l4m9ety\n" +
		                 "Rapture gate http://tinyurl.com/m48kj4n\n" +
		                 "Ruin party http://tinyurl.com/ktm9v3z\n\n" +
		                 "Sound\n" +
		                 "Weclome to Rapture http://tinyurl.com/yh2y5t5\n" +
		                 "Circus of Values http://tinyurl.com/ykdnv8l\n" +
		                 "El Ammo Bandito http://tinyurl.com/m72tven\n";

		text.GetComponent<Text> ().text = message;

		text.GetComponent<RectTransform> ().anchoredPosition = new Vector2(-30, 05);

		text.GetComponent<Text> ().alignment = TextAnchor.MiddleLeft;
	}

	void displayStar(GameObject panel, GameObject text){

		string message = "Stars\n\n"+
			"Star 1: Instead of using cards from the book, find really dazzling ones.\n"+
			"Star 2: Also display the current date and time.\n"+
			"Star 3(2): Add a 'toggle' button for displaying/hiding all cards.\n"+
			"Star 4(3): Generate 'everything' during run-time, not in the design mode";

		text.GetComponent<Text> ().text = message;

		text.GetComponent<RectTransform> ().anchoredPosition = new Vector2(-50, 05);

		text.GetComponent<Text> ().alignment = TextAnchor.MiddleLeft;
	}

    void Options(GameObject panel)
    {
        DestoryPanel(panel);

		GameObject optionsPanel = menuMaker.CreatePanel(canvas.transform, background);

        GameObject text = menuMaker.CreateText(optionsPanel.transform, 0, 50, 160, 50, "Options", 14);

		dateText = menuMaker.CreateText (optionsPanel.transform, 100, -50, 100, 25, System.DateTime.Now.ToString(), 8);

        buttons.Add(menuMaker.CreateButton(optionsPanel.transform, 0, -30, 125, 25, "back", delegate { Back(optionsPanel); }));
    }

    void Exit() {

        this.GetComponent<ControlStart>().PlayFarewellMusic();

		EditorUtility.DisplayDialog ("Farewell", "Thank you playing Eddie's Memory Game.", "Exit");

        EditorUtility.DisplayDialog("Game Matchs", "The number of games played were "+ this.GetComponent<ControlStart>().GameNumber, "Exit");

        UnityEditor.EditorApplication.isPlaying = false;
    }

    void Back(GameObject panel) {

        DestoryPanel(panel);

        MakeMainMenu();
    }


     void DestoryPanel(GameObject panel) { 

        GameObject.Destroy(panel);

        buttons.Clear();
    }
}
