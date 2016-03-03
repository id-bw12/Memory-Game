using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {

    private List<GameObject> buttons = new List<GameObject>();

    private UIMakerScript menuMaker = new UIMakerScript();

    private GameObject canvas, panel, text;

    // Use this for initialization
    void Start () {

        canvas = menuMaker.CreateCanvas(this.transform);

        menuMaker.CreateEventSystem(canvas.transform);

        panel = menuMaker.CreatePanel(canvas.transform);

        MakeMainMenu();

        print(buttons.Count);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void MakeMainMenu() {
        
        text = menuMaker.CreateText(panel.transform, 0, 50, 160, 50, "Memory Game", 14);
  
        buttons.Add(menuMaker.CreateButton(panel.transform, 0, 22, 125, 25, "Play", delegate { PlayGame(); }));
        buttons.Add(menuMaker.CreateButton(panel.transform, 0, 2, 125, 25, "ID Info", delegate { IdInfo(); }));
        buttons.Add(menuMaker.CreateButton(panel.transform, 0, -20, 125, 25, "Options", delegate { Options(); }));
        buttons.Add(menuMaker.CreateButton(panel.transform, 0, -40, 125, 25, "Exit", delegate { Exit(); }));
    }

    void OptionsMenu() {


        text = text = menuMaker.CreateText(panel.transform, 0, 50, 160, 50, "Options", 14);

        buttons.Add(menuMaker.CreateButton(panel.transform, 0, 2, 125, 25, "back", delegate { Back(); }));

    }

    void PlayGame()
    {
        MakeScoreText();

        MakeButton();

        GameObject.Destroy(text);

        for (int i = 0; i < buttons.Count; ++i)
            GameObject.Destroy(buttons[i]);

        GameObject.Destroy(panel);

        this.gameObject.AddComponent<GameLogic>();

        this.gameObject.AddComponent<MakeDeck>();

        this.gameObject.AddComponent<Timer>();

    }

    void IdInfo() {
        GameObject.Destroy(text);

        for (int i = 0; i < buttons.Count; ++i)
            GameObject.Destroy(buttons[i]);

        text = text = menuMaker.CreateText(panel.transform, 0, 50, 160, 50, "Id Information", 14);

        buttons.Add(menuMaker.CreateButton(panel.transform, 0, 2, 125, 25, "back", delegate { Back(); }));
    }

    void Options()
    {
        GameObject.Destroy(text);

        for(int i = 0; i < buttons.Count; ++i)
            GameObject.Destroy(buttons[i]);

        buttons.Clear();

        OptionsMenu();
    }

    void Exit() {
        UnityEditor.EditorApplication.Exit(0);
    }

    void Back() {

        GameObject.Destroy(text);

        for (int i = 0; i < buttons.Count; ++i)
            GameObject.Destroy(buttons[i]);

        buttons.Clear();

        text = null;

        MakeMainMenu();
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

    void MakeButton()
    {

        GameObject button = new GameObject("UIButton");

        button.transform.position = new Vector3(8.0f, 4.25f, 1.0f);

        button.AddComponent<SpriteRenderer>().sprite = Resources.Load("start-button", typeof(Sprite)) as Sprite;

        button.AddComponent<BoxCollider2D>();

        button.AddComponent<UIButton>();

    }


}
