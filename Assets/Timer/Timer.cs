using UnityEngine;
using System.Collections;
using System.Timers;

public class Timer : MonoBehaviour {

    private System.Timers.Timer time;

	// Use this for initialization
	private void Start () {
		
        time = new System.Timers.Timer();
		time.Elapsed += Time_Elapsed;
	}
		
	/**********************************************************
	 * 	NAME: 			Time_Elapsed
	 *  DESCRIPTION:	Disables the timer when the time limit
	 * 					is hit.
	 * 
	 * ********************************************************/
	void Time_Elapsed (object sender, ElapsedEventArgs e)
	{

		time.Enabled = false;

	}
		
	/**********************************************************
	 * 	NAME: 			SetTimeLimit
	 *  DESCRIPTION:	The isFlip boolean property 
	 * 
	 * 
	 * ********************************************************/
    public void SetTimeLimit() {
		time.Interval = 1100;
    }

	/**********************************************************
	 * 	NAME: 			Flipped
	 *  DESCRIPTION:	The isFlip boolean property 
	 * 
	 * 
	 * ********************************************************/
    public bool Enable {
        get { return time.Enabled; }
        set { time.Enabled = value; }
    }

}