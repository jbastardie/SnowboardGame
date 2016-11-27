using UnityEngine;
using System.Collections;

public class scoreHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<TextMesh>().text = "Race 1: " + convertTime(PlayerPrefs.GetFloat("race1"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    string convertTime(float time)
    {
        var minutes = (int)(time / 60f);
        var seconds = (int)(time % 60f);
        var milliseconds = (int)((time * 1000) % 1000);
        var text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("000");
        return text;
    }
}
