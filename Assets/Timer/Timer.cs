using UnityEngine;
using System.Collections;
using System.Timers;

public class Timer : MonoBehaviour {

    private System.Timers.Timer time;

	// Use this for initialization
	public void Start () {
		
        time = new System.Timers.Timer();
		time.Elapsed += Time_Elapsed;
	}

	void Time_Elapsed (object sender, ElapsedEventArgs e)
	{

		time.Enabled = false;

	}


    // Update is called once per frame
	void Update () {

	
	}
		

    public void SetTimeLimit() {
		time.Interval = 1100;
    }

    public bool Enable {
        get { return time.Enabled; }
        set { time.Enabled = value; }
    }

}