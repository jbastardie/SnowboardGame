using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class race2 : MonoBehaviour {

    public Text chronoUI;
    public GameObject start;
    public GameObject finish;
    public GameObject[] snowmen = new GameObject[1];
    private bool triggerStart = false;
    private bool triggerFinish = false;
    private bool raceStart = false;
    private int score = 0;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (raceStart)
        {
            chronoUI.text = "Bonhommes trouves: " + score;
        }
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == start)
        {
            raceStart = true;
        }

        if (other.gameObject == finish)
        {
            raceStart = false;
            StartCoroutine(Result());
            Debug.Log("finish race 2");
            foreach (GameObject snowman in snowmen)
            {
                snowman.SetActive(true);
            }

        }

        foreach(GameObject snowman in snowmen)
        {
            if(snowman == other.gameObject)
            {
                other.gameObject.SetActive(false);
                score += 1;
            }
        }
    }

    IEnumerator Result()
    {
        //disable the desired script here
        chronoUI.text = "Score: " +score + " bonhommes trouves";
        yield return new WaitForSeconds(3F);
        chronoUI.text = "";
    }
}
