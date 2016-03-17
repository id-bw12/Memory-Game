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

    private int gameCount = 0, matchs = 0, missMatch = 0;

	private bool cardFlip = false;

	private string backgroundMusic = "BioShock Soundtrack_ 02 Welcome to Rapture",
	farewellMusic = "Bioshock Credits [720p]", matchMusic = "Welcome To The Circus Of Value!", missmusic = "EL AMMO BANDITO SENIOR";

	private AudioClip farewellClip;

    private AudioSource soundEffects;

    // Use this for initialization
    void Start()
    {
   
		farewellClip = Resources.Load(farewellMusic,typeof(AudioClip))as AudioClip;

		this.gameObject.AddComponent<AudioSource> ().clip = Resources.Load(backgroundMusic,typeof(AudioClip))as AudioClip;

		this.gameObject.GetComponent<AudioSource> ().loop = true;

		this.GetComponent<AudioSource> ().Play();

        this.GetComponent<AudioSource>().Play(44100);

        soundEffects = this.gameObject.AddComponent<AudioSource>();

        soundEffects.volume = soundEffects.volume / 2;


    }

    // Update is called once per frame
    void Update()
    {
		
    }

	/**********************************************************
	 * 	NAME: 			Gamenumber
	 *  DESCRIPTION:	The gameCount integer property
	 * 
	 * 
	 * ********************************************************/
    public int GameNumber {

        set { this.gameCount = value; }

        get { return this.gameCount; }
        
    }

	/**********************************************************
	 * 	NAME: 			Matchs
	 *  DESCRIPTION:	The match integer property
	 * 
	 * 
	 * ********************************************************/
    public int Matchs {

        set { this.matchs = value; }
        get { return this.matchs; }
    }

	/**********************************************************
	 * 	NAME: 			MissMatchs
	 *  DESCRIPTION:	The miss matchs integer property
	 * 
	 * 
	 * ********************************************************/
    public int MissMatchs
    {

        set { this.missMatch = value; }
        get { return this.missMatch; }
    }


	/**********************************************************
	 * 	NAME: 			Flipped
	 *  DESCRIPTION:	The isFlip boolean property 
	 * 
	 * 
	 * ********************************************************/
    public bool isFlip{

		set{ this.cardFlip = value; }

		get{ return this.cardFlip;}

	}

	/**********************************************************
	 * 	NAME: 			FarewellMusic
	 *  DESCRIPTION:	Stops the current music and switchs it 
	 * 					with the farewell music.
	 * 
	 * ********************************************************/
	public void FarewellMusic(){
	
		this.GetComponent<AudioSource> ().Stop();

		this.GetComponent<AudioSource> ().clip = farewellClip;

		this.GetComponent<AudioSource> ().loop = true;

		this.GetComponent<AudioSource> ().Play();

        this.GetComponent<AudioSource>().Play(44100);
    }

	/**********************************************************
	 * 	NAME: 			PlaySoundEffects
	 *  DESCRIPTION:	Gets the match boolean variable and 
	 * 					choose which audioclip to play.
	 * 
	 * ********************************************************/
    public void PlaySoundEffects(bool match) {

        if (match)
            soundEffects.clip = Resources.Load(matchMusic, typeof(AudioClip)) as AudioClip;
        else
            soundEffects.clip = Resources.Load(missmusic, typeof(AudioClip)) as AudioClip;

        soundEffects.Play();

        soundEffects.Play();

    }
   


}
