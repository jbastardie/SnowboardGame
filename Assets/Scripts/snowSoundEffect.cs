using UnityEngine;
using System.Collections;

public class snowSoundEffect : MonoBehaviour {
    private float distToGround;
    public float maxSpeed = 30;
    public AudioSource snowAudioSource;
    // Use this for initialization
    void Start () {
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }
	
	// Update is called once per frame
	void Update () {
        if (!IsGrounded())
        {
            snowAudioSource.volume = 0;
        }
        else if(switchWalkSnowboard.isSnowboarding)
        {
            var vel = GetComponent<Rigidbody>().velocity;      //to get a Vector3 representation of the velocity
            var speed = vel.magnitude;
            var volumeSnowEffect = speed / maxSpeed;
            snowAudioSource.volume = volumeSnowEffect /3;
            snowAudioSource.pitch = volumeSnowEffect;


        }
    }

    bool IsGrounded() {

        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
