using UnityEngine;
using UnityEngine.UI;

using System.Collections;

//09:10 A.M. - 11:29 P.M.
//10:12 A.M. - 12:52 P.M.
//03:20 P.M. - 03:51 P.M.
//09:35 A.M. - 12:35 P.M.
//09:35 A.M. - 12:16 P.M.

public class ControlStart : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        SetupBackgorund();

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
}
