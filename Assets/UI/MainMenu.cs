using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {

    private List<GameObject> buttons = new List<GameObject>();

    private UIMakerScript menuMaker = new UIMakerScript();

    private GameObject canvas, text;

    // Use this for initialization
    void Start () {

        canvas = menuMaker.CreateCanvas(this.transform);

        menuMaker.CreateEventSystem(canvas.transform);

        MakeMainMenu();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void MakeMainMenu() {

        GameObject mainMenupanel = menuMaker.CreatePanel(canvas.transform);

        text = menuMaker.CreateText(mainMenupanel.transform, 0, 50, 160, 50, "Memory Game", 14);

        buttons.Add(menuMaker.CreateButton(mainMenupanel.transform, 0, 22, 125, 25, "Play", delegate { PlayGame(mainMenupanel); }));
        buttons.Add(menuMaker.CreateButton(mainMenupanel.transform, 0, 2, 125, 25, "ID Info", delegate { IdInfo(mainMenupanel); }));
        buttons.Add(menuMaker.CreateButton(mainMenupanel.transform, 0, -20, 125, 25, "Options", delegate { Options(mainMenupanel); }));
        buttons.Add(menuMaker.CreateButton(mainMenupanel.transform, 0, -40, 125, 25, "Exit", delegate { Exit(); }));
    }

    void PlayGame(GameObject panel)
    {
        DestoryPanel(panel);

        this.gameObject.AddComponent<GameMode>();

        this.gameObject.AddComponent<GameLogic>();

        this.gameObject.AddComponent<MakeDeck>();

        this.gameObject.AddComponent<Timer>();

    }

    void IdInfo(GameObject panel) {

        DestroyObject(panel);

        GameObject idPanel = menuMaker.CreatePanel(canvas.transform);

        text = menuMaker.CreateText(idPanel.transform, 0, 50, 160, 50, "Id Information", 14);
        
        buttons.Add(menuMaker.CreateButton(idPanel.transform, 0, 2, 125, 25, "back", delegate { Back(idPanel); }));
    }

    void Options(GameObject panel)
    {
        DestoryPanel(panel);

        GameObject optionsPanel = menuMaker.CreatePanel(canvas.transform);

        text = menuMaker.CreateText(optionsPanel.transform, 0, 50, 160, 50, "Options", 14);

        buttons.Add(menuMaker.CreateButton(optionsPanel.transform, 0, 2, 125, 25, "back", delegate { Back(optionsPanel); }));
    }

    void Exit() {
        //UnityEditor.EditorApplication.Exit(0);
        UnityEditor.EditorApplication.isPlaying = false;
    }

    void Back(GameObject panel) {

        DestoryPanel(panel);

        text = null;

        MakeMainMenu();
    }


     void DestoryPanel(GameObject panel) { 

        GameObject.Destroy(panel);

        buttons.Clear();
    }
}
