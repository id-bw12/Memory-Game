using UnityEngine;

using UnityEngine.Events;
using UnityEngine.EventSystems;

using System.Collections;
using System.Collections.Generic;

public class MakeDeck : MonoBehaviour {

	private List<GameObject> deck = new List<GameObject> ();

	private Sprite[] cardImages = new Sprite[8];

	// Use this for initialization
	void Start () {

		float x = -8.5f, y = 3.0f, z = 2.0f;
	
		LoadCardImages ();
	
		for (int i = 0; i < 16; ++i) {

			MakeMemoryCard (cardImages [i % 8], new Vector3 (x, y, z));

			x += 2.5f;

			if (i == 3) {
				y = 0.5f;
				x = -8.5f;
			} else if (i == 7) {
				y = -2.0f;
				x = -8.5f;
				
			} else if (i == 11) {
				y = -4.5f;
				x = -8.5f;

			}
		}

		//ShuffleImages ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/**********************************************************
	 * 	NAME: 			LoadCardImages
	 *  DESCRIPTION:	Loads the card images in an array
	 * 
	 * 
	 * ********************************************************/
	void LoadCardImages(){

		cardImages [0] = Resources.Load ("fire", typeof(Sprite)) as Sprite;
		cardImages [1] = Resources.Load ("frost", typeof(Sprite)) as Sprite;
		cardImages [2] = Resources.Load ("lighting", typeof(Sprite)) as Sprite;
		cardImages [3] = Resources.Load ("eel", typeof(Sprite)) as Sprite;
		cardImages [4] = Resources.Load ("bees", typeof(Sprite)) as Sprite;
		cardImages [5] = Resources.Load ("alarm", typeof(Sprite)) as Sprite;
		cardImages [6] = Resources.Load ("anger", typeof(Sprite)) as Sprite;
		cardImages [7] = Resources.Load ("telekinesis", typeof(Sprite)) as Sprite;
	}

	/**********************************************************
	 * 	NAME: 			MakeMemoryCard
	 *  DESCRIPTION:	Gets the card image and the card position
	 * 					and uses it to make the memory card.
	 * 
	 * ********************************************************/
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

	/**********************************************************
	 * 	NAME: 			ShuffleImage
	 *  DESCRIPTION:	Shuffles the images in the memory cards
	 * 
	 * ********************************************************/
	public void ShuffleImages(){

		Sprite tempSprite;

		int j;

		for(int i = 0; i < 16; ++i){

			tempSprite = deck[i].gameObject.GetComponent<MemoryCard>().Image;

			j = Random.Range (0,7);

			deck[i].gameObject.GetComponent<MemoryCard>().Image = deck[j].gameObject.GetComponent<MemoryCard>().Image;

			deck[j].gameObject.GetComponent<MemoryCard>().Image = tempSprite;

		}
	}

	/**********************************************************
	 * 	NAME: 			GetDeck
	 *  DESCRIPTION:	Returns the deck
	 * 
	 * 
	 * ********************************************************/
	public List<GameObject> GetDeck() {
		return deck;

    }

}
