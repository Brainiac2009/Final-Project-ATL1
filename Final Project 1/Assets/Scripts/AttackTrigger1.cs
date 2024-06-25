using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger1 : MonoBehaviour
{
    public bool canAttack;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        canAttack = true;
    }

      public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        canAttack = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
