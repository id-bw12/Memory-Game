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

    private int gameCount = 0;

    // Use this for initialization
    void Start()
    {
   

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GameNumber {

        set { this.gameCount = value; }

        get { return this.gameCount; }
        
    }
}
