using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private GameObject player;
    public float stoppingPower = 20f;
    public ParticleSystem winFireworks;
    public float timeToWaitFireworks = 10f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Moving Bike");
    }

    IEnumerator TurnOffFireworks()
    {
        Debug.Log("FIREWORKS!!");
        yield return new WaitForSeconds(timeToWaitFireworks);
        winFireworks.Stop();
    }

    //if the player crosses the finish line
    private void OnTriggerEnter(Collider other)
    {
        //slow down the bike to a stop
        //other.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.left * stoppingPower, other.gameObject.transform.position, ForceMode.Acceleration);

        winFireworks.Play();
        StartCoroutine(TurnOffFireworks());


        Debug.Log("You win!");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
