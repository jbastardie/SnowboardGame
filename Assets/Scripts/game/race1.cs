using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class race1 : MonoBehaviour {

    public Text chronoUI;
    public GameObject start;
    public GameObject finish;
    private float seconds, minutes, milliseconds;
    private float initialTime;
    private bool raceStart = false;
    private float raceTime;
    private bool triggerStart = false;
    private bool triggerFinish = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (triggerStart && !raceStart)
        {
            initialTime = Time.time;
            raceStart = true;
        }
        if (raceStart)
        {
            raceTime = Time.time - initialTime;
            minutes = (int)(raceTime / 60f);
            seconds = (int)(raceTime % 60f);
            milliseconds = (int)((raceTime * 1000) % 1000);
            chronoUI.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("000");
        }
        if(triggerFinish && raceStart)
        {
            raceStart = false;
            StartCoroutine(Result());
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == start)
        {
            triggerStart = true;
        }
        if(other.gameObject == finish)
        {
            triggerFinish = true;
        }
 
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == start)
        {
            triggerStart = false;
        }
        if (other.gameObject == finish)
        {
            triggerFinish = false;
        }

    }

    IEnumerator TimeoutResetUI(float time)
    {
        //disable the desired script here
        yield return new WaitForSeconds(time);
        chronoUI.text = "";
        //enable it here
    }

    IEnumerator Result()
    {
        //disable the desired script here

        Debug.Log(PlayerPrefs.GetFloat("race1")+"et race time"+raceTime);
        if (PlayerPrefs.GetFloat("race1") == 0 || PlayerPrefs.GetFloat("race1") > raceTime)
        {
            chronoUI.text = "Nouveau record!";
            yield return new WaitForSeconds(2F);
            PlayerPrefs.SetFloat("race1", raceTime);
        }
        chronoUI.text = "Temps de course: " + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("000");
        yield return new WaitForSeconds(3F);
        chronoUI.text = "";
    }

}
