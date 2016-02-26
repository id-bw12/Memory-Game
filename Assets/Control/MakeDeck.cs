using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class MakeDeck : MonoBehaviour {

	private List<GameObject> deck;

	private Sprite[] cardImages = new Sprite[4];

	// Use this for initialization
	void Start () {
	
		LoadCardImages ();

		MakeMemoryCard ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadCardImages(){

		cardImages [0] = Resources.Load ("crescent-symbol", typeof(Sprite)) as Sprite;
		cardImages [1] = Resources.Load ("diamond-symbol", typeof(Sprite)) as Sprite;
		cardImages [2] = Resources.Load ("heart-symbol", typeof(Sprite)) as Sprite;
		cardImages [3] = Resources.Load ("square-symbol", typeof(Sprite)) as Sprite;
	}

	void MakeMemoryCard(){

		GameObject memoryCard = new GameObject ("Card");

		Sprite cardSprite = Resources.Load ("card_back", typeof(Sprite)) as Sprite;

		memoryCard.transform.position = new Vector3 (-2.0f, 0.0f, 1.0f);

		memoryCard.AddComponent<SpriteRenderer> ();

		memoryCard.AddComponent<BoxCollider2D> ();

		memoryCard.GetComponent<SpriteRenderer> ().sprite = cardSprite;

		memoryCard.AddComponent<MemoryCard> ();

		SendCardImages (memoryCard);

	}

	void SendCardImages(GameObject memoryCard){


		memoryCard.GetComponent<MemoryCard> ().SetCardImage (cardImages[2]);

	}
}
