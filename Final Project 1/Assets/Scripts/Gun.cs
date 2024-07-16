using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public bool isPO = true;
    public Transform BulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public bool isRightSide = true; 
    public KeyCode FireKey = KeyCode.Q;

    void Update()
    {
        if(Input.GetKeyDown(FireKey) && FindObjectOfType<PlayerMovement>().gameObject.GetComponent<Stats>().canFire && isPO) 
        {
            FindObjectOfType<PlayerMovement>().gameObject.GetComponent<Stats>().StartCoroutine(FindObjectOfType<PlayerMovement>().gameObject.GetComponent<Stats>().Cooldown());

            var bullet = Instantiate(bulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
           
           if (isRightSide)
             bullet.GetComponent<Rigidbody>().AddForce(new Vector3(0,0, 1 * bulletSpeed), ForceMode.Impulse);
            else 
             bullet.GetComponent<Rigidbody>().AddForce(new Vector3(0,0, -1 * bulletSpeed), ForceMode.Impulse);

        }

        if(Input.GetKeyDown(FireKey) && FindObjectOfType<EnemyMovement>().gameObject.GetComponent<Stats>().canFire && !isPO) 
        {
            FindObjectOfType<EnemyMovement>().gameObject.GetComponent<Stats>().StartCoroutine(FindObjectOfType<EnemyMovement>().gameObject.GetComponent<Stats>().Cooldown());

            var bullet = Instantiate(bulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
           
           if (isRightSide)
             bullet.GetComponent<Rigidbody>().AddForce(new Vector3(0,0, 1 * bulletSpeed), ForceMode.Impulse);
            else 
             bullet.GetComponent<Rigidbody>().AddForce(new Vector3(0,0, -1 * bulletSpeed), ForceMode.Impulse);

        }
    }
}
