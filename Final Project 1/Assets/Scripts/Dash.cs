using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    PlayerMovement moveScript;

    public float dashSpeed;
    public float dashTime;


    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButton(0))
        (
            StartCoroutine(Dash());
        )

    }
}
