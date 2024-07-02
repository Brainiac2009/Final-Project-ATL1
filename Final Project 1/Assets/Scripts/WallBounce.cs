using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour
{
    public bool isLeftWall;

    public float bounceForce = 1000;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if  (isLeftWall && (other.CompareTag("Friend") || other.CompareTag("Enemy")))
            other.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,1) * bounceForce, ForceMode.Impulse);
        if  (!isLeftWall && (other.CompareTag("Friend") || other.CompareTag("Enemy")))
            other.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-1) * bounceForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
