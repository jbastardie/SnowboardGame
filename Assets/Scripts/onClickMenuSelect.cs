using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class onClickMenuSelect : MonoBehaviour {

    public Animator cameraAnimator;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.collider.name)
                {
                    case "Play":
                        Debug.Log("Play Game!");
                        var animationObj = parameterClass.currentCharacter.GetComponent<Animator>();
                        animationObj.CrossFade("pointing",0.05f);
                        StartCoroutine(MyCoroutine());

                        //snowboarder.transform.Translate(0, -0.10f, 0);
                        break;
                    case "Credit":
                        Debug.Log("Credit!");
                        cameraAnimator.Play("goCredit");
                        break;
                    case "BackFromCredit":
                        cameraAnimator.Play("reverseCredit");
                        break;
                    case "Score":
                        cameraAnimator.Play("cameraAnimationScore");
                        break;
                    case "BackFromScore":
                        Debug.Log("back main menu");
                        cameraAnimator.Play("revertAnimationScore");
                        break;
                    case "Quit":
                        Application.Quit();
                        break;
                    default:
                        break;
                }
                    
               
                //Debug.Log("Mouse Down hit: " + hit.collider.name);

            }
        }
    }

    IEnumerator MyCoroutine()
    {
        //disable the desired script here
        yield return new WaitForSeconds(2F);
        SceneManager.LoadScene("GameScene");
        //enable it here
    }
}
