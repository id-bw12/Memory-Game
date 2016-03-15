using UnityEngine;
using UnityEngine.UI;


using System.Collections;

//09:10 A.M. - 11:29 P.M.
//10:12 A.M. - 12:52 P.M.
//03:20 P.M. - 03:51 P.M.
//09:35 A.M. - 12:35 P.M.
//09:35 A.M. - 12:16 P.M.
//07:51 P.M. - 08:51 P.M.
//09:35 A.M. - 12:35 P.M.
//09:35 A.M. - 12:35 P.M.
//04:26 P.M. - 07:12 P.M.
//11:10 P.M. - 11:56 P.M.

public class ControlStart : MonoBehaviour
{

    private int gameCount = 0;

	private bool isFlip = false;

	private string backgroundMusic = "BioShock Soundtrack_ 02 Welcome to Rapture",
	farewellMusic = "Bioshock Credits [720p]", matchMusic = "", missmusic = "";

	private AudioClip farewellClip;

    // Use this for initialization
    void Start()
    {
   
		farewellClip = Resources.Load(farewellMusic,typeof(AudioClip))as AudioClip;

		this.gameObject.AddComponent<AudioSource> ().clip = Resources.Load(backgroundMusic,typeof(AudioClip))as AudioClip;

		this.gameObject.GetComponent<AudioSource> ().loop = true;

		this.GetComponent<AudioSource> ().Play();

    }

    // Update is called once per frame
    void Update()
    {
		
    }

    public int GameNumber {

        set { this.gameCount = value; }

        get { return this.gameCount; }
        
    }


	public bool Fliped{

		set{ this.isFlip = value; }

		get{ return this.isFlip;}

	}



	public void PlayFarewellMusic(){
	
		this.GetComponent<AudioSource> ().Stop();

		this.GetComponent<AudioSource> ().clip = farewellClip;

		this.GetComponent<AudioSource> ().loop = true;

		this.GetComponent<AudioSource> ().Play();
		
	}

}
