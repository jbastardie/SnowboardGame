using UnityEngine;
using System.Collections;

public class onHooverMenuText : MonoBehaviour {

    Renderer rend;

    // Use this for initialization
    void Start () {
        rend = gameObject.GetComponent<Renderer>();
    }

    void  OnMouseOver()
    {
        
        rend.material.color = Color.red;

    }
    void  OnMouseExit()
    {
        rend.material.color = Color.white;
    }
    // Update is called once per frame
    void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name == "Play")
            {
                //Renderer rend = GameObject.Find(hit.collider.name).GetComponent<Renderer>();
                //rend.material.color = Color.red;

            }
            //Debug.Log("Mouse Down hit: " + hit.collider.name);

        }
    }
}
