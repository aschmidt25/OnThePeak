using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private Vector3 forceToApply;
    public float windStrengthMultiplyer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forceToApply = Vector3.left * this.transform.position.y * windStrengthMultiplyer;

        //apply the force
        //for the mountain use ().force
        this.GetComponent<ConstantForce>().relativeForce = forceToApply;
    }
}
