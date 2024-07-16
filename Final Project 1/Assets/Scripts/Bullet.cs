using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    
    [Range(1,10)]
    public int damage;

    public bool shrekBullet;

    void Start()
    {
       Destroy(gameObject, life); 
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy") && !shrekBullet)
        {

            collision.gameObject.GetComponent<AttributesManager>().health -= damage;

            Debug.Log("Do damage");

            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Friend") && shrekBullet)
        {
            collision.gameObject.GetComponent<AttributesManager>().health -= damage;

            Debug.Log("Do damage");

            Destroy(gameObject);
        }
        
    }
}
