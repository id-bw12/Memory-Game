using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class MakeDeck : MonoBehaviour {

	private List<GameObject> deck = new List<GameObject> ();

	private Sprite[] cardImages = new Sprite[4];

	// Use this for initialization
	void Start () {

		float x = -8.0f, y = 2.0f, z = 2.0f;
	
		LoadCardImages ();
	
		for (int i = 0; i < 8; ++i) {

			MakeMemoryCard (cardImages [i % 4], new Vector3 (x, y, z));

			x += 3.0f;

			if (i == 3) {
				y = -1.0f;
				x = -8.0f;
			}
		}

		//ShuffleImages ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadCardImages(){

		cardImages [0] = Resources.Load ("fire", typeof(Sprite)) as Sprite;
		cardImages [1] = Resources.Load ("frost", typeof(Sprite)) as Sprite;
		cardImages [2] = Resources.Load ("lighting", typeof(Sprite)) as Sprite;
		cardImages [3] = Resources.Load ("eel", typeof(Sprite)) as Sprite;
	}

	void MakeMemoryCard(Sprite cardImage , Vector3 position){

		GameObject memoryCard = new GameObject ("Card");

		Sprite cardSprite = Resources.Load ("bioshock-logo", typeof(Sprite)) as Sprite;

		memoryCard.transform.position = position;

		memoryCard.transform.localScale = new Vector3 (0.75f, 0.75f, 1.0f);

		memoryCard.AddComponent<SpriteRenderer> ();

		memoryCard.AddComponent<BoxCollider2D> ().enabled = false;

		memoryCard.GetComponent<SpriteRenderer> ().sprite = cardSprite;

		memoryCard.AddComponent<MemoryCard> ();

		memoryCard.GetComponent<MemoryCard> ().Image = cardImage;

		deck.Add(memoryCard.gameObject);

	}

	public void ShuffleImages(){

		Sprite tempSprite;

		int j;

		for(int i = 0; i < 8; ++i){

			tempSprite = deck[i].gameObject.GetComponent<MemoryCard>().Image;

			j = Random.Range (0,7);

			deck[i].gameObject.GetComponent<MemoryCard>().Image = deck[j].gameObject.GetComponent<MemoryCard>().Image;

			deck[j].gameObject.GetComponent<MemoryCard>().Image = tempSprite;

		}
	}

	public List<GameObject> GetDeck() {
		return deck;

    }

}
