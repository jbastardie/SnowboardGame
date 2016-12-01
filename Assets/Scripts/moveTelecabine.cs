using UnityEngine;
using System.Collections;

public class moveTelecabine : MonoBehaviour {
    public Vector3 arrival;
    public float speed;
    private bool insideCabine = false;
    public GameObject snowboarder;
    public GameObject porteGauche;
    public GameObject porteDroite;
    public Animation animationCabine;
    private Vector3 departure;
    private bool doorOpen = false;
    private bool doorAreOpening = false;
    private bool cabineIsMoving = false;

    void Start()
    {
        departure = transform.localPosition;
        openDoor();
    }
    
    void Update()
    {
        if (insideCabine)
        {
            if (!cabineIsMoving && transform.localPosition == departure) {

                cabineIsMoving = true;
                StartCoroutine(TimeoutGoTo(arrival));
                
            }
            //float step = speed * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, xyz, step); 
            if(transform.localPosition == arrival && !doorOpen && !doorAreOpening)
            {
                openDoor();
                cabineIsMoving = false;
            }

        }
        else
        {

            if (!cabineIsMoving && transform.localPosition == arrival)
            {
                Debug.Log("go back to base");
                cabineIsMoving = true;
                StartCoroutine(TimeoutGoTo(departure));
            }

            if (transform.localPosition == departure && !doorOpen && !doorAreOpening)
            {
                openDoor();
                cabineIsMoving = false;
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
        if (doorOpen)
        {
            closeDoor();
        }
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

    IEnumerator MoveFromTo(Vector3 pointA, Vector3 pointB, float time, GameObject element)
    {
        
         // do nothing if already moving
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / time; // sweeps from 0 to 1 in time seconds
            element.transform.localPosition = Vector3.Lerp(pointA, pointB, t); // set position proportional to t
            doorAreOpening = true;
            yield return 0; // leave the routine and return here in the next frame
        }
        doorAreOpening = false;

    }

    IEnumerator TimeoutGoTo(Vector3 destination)
    {
        //disable the desired script here
        yield return new WaitForSeconds(1.5F);
        Debug.Log("travelling from: "+ transform.position+" to "+destination);
        StartCoroutine(MoveFromTo(transform.localPosition, destination, speed, gameObject));
        //enable it here
    }

    IEnumerator TimeoutAnimation()
    {
        //disable the desired script here
        yield return new WaitForSeconds(1.5F);
        Debug.Log("animation start");
        animationCabine.Play();
        //enable it here
    }

}
