using UnityEngine;
using UnityEngine.UI;

using System.Collections;

//09:10 A.M. - 11:29 P.M.
//10:12 A.M. - 12:52 P.M.
//03:20 P.M. - 03:51 P.M.

public class ControlStart : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        SetupBackgorund();

        MakeScoreText();

        MakeButton();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetupBackgorund()
    {

        GameObject background = new GameObject("Background");

        Sprite backgroundSprite = Resources.Load("table_top", typeof(Sprite)) as Sprite;

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

    void MakeButton()
    {

        GameObject button = new GameObject("UIButton");

        button.transform.position = new Vector3(8.0f, 4.25f, 1.0f);

        button.AddComponent<SpriteRenderer>().sprite = Resources.Load("start-button", typeof(Sprite)) as Sprite;

        button.AddComponent<BoxCollider2D>();

        button.AddComponent<UIButton>();

    }
}
