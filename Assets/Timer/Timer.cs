using UnityEngine;
using System.Collections;
using System.Timers;

public class Timer : MonoBehaviour {

    private System.Timers.Timer time;

    private double timeLimit;

	// Use this for initialization
	public void Start () {
        time = new System.Timers.Timer();
        time.Elapsed += Time_Elapsed;
	}

    private void Time_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        time.Enabled = false;
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void SetTimeLimit(int timeLimt) {
        time.Interval = 4000;
    }

    public bool Enable {
        get { return time.Enabled; }
        set { time.Enabled = value; }
    }

    public void StartTimer() {
        time.Start();
    }
}
