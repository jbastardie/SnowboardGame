using UnityEngine;
using System.Collections;

public class moveTelecabine : MonoBehaviour {
    public Vector3 xyz;
    public float speed;
    private bool insideCabine = false;
    public GameObject snowboarder;
    public GameObject porteGauche;
    public GameObject porteDroite;
    private bool doorOpen = false;
    private bool doorAreOpening = false;

    void Start()
    {
        openDoor();
        xyz.z = 64;
    }
    
    void Update()
    {
        if (insideCabine)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, xyz, step); 
            if(transform.position == xyz && !doorOpen && !doorAreOpening)
            {
                openDoor();
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        insideCabine = true;
        snowboarder.transform.parent = transform;
        closeDoor();
    }

    void OnTriggerExit(Collider other)
    {
        insideCabine = false;
        snowboarder.transform.parent = null;
    }

    void openDoor()
    {
        var startPositiond = porteDroite.transform.localPosition;
        var endPositiond = new Vector3(porteDroite.transform.localPosition.x - 70, porteDroite.transform.localPosition.y, porteDroite.transform.localPosition.z + 10);
        StartCoroutine(MoveFromTo(startPositiond, endPositiond, 1, porteDroite));
        var startPositiong = porteGauche.transform.localPosition;
        var endPositiong = new Vector3(porteGauche.transform.localPosition.x + 70, porteGauche.transform.localPosition.y, porteGauche.transform.localPosition.z - 10);
        StartCoroutine(MoveFromTo(startPositiong, endPositiong, 1, porteGauche));
        doorOpen = true;
    }

    void closeDoor()
    {
        var startPositiond = porteDroite.transform.localPosition;
        var endPositiond = new Vector3(porteDroite.transform.localPosition.x + 70, porteDroite.transform.localPosition.y, porteDroite.transform.localPosition.z-10);
        StartCoroutine(MoveFromTo(startPositiond, endPositiond, 1, porteDroite));
        var startPositiong = porteGauche.transform.localPosition;
        var endPositiong = new Vector3(porteGauche.transform.localPosition.x - 70, porteGauche.transform.localPosition.y, porteGauche.transform.localPosition.z + 10);
        StartCoroutine(MoveFromTo(startPositiong, endPositiong, 1, porteGauche));
        doorOpen = false;
    }

    IEnumerator MoveFromTo(Vector3 pointA, Vector3 pointB, float time, GameObject porte)
    {
        
         // do nothing if already moving
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / time; // sweeps from 0 to 1 in time seconds
            porte.transform.localPosition = Vector3.Lerp(pointA, pointB, t); // set position proportional to t
            doorAreOpening = true;
            yield return 0; // leave the routine and return here in the next frame
        }
        doorAreOpening = false;

    }

    IEnumerator Timeout()
    {
        //disable the desired script here
        yield return new WaitForSeconds(1F);
        //enable it here
    }

}
