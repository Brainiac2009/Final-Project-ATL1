using System.Collections;
using UnityEngine;

public class Dash : MonoBehaviour
{
    PlayerMovement moveScript;
    EnemyMovement moveScriptEnemy;

    public float dashSpeed;
    public float dashTime;
    public bool isPlayer1;
    public AudioClip DashSound;
    public AudioSource SoundObject;

    // Start is called before the first frame update
    void Start()
    {
        if (isPlayer1)
        {
            moveScript = GetComponent<PlayerMovement>();
            if (moveScript == null)
            {
                Debug.LogError("PlayerMovement component not found on this GameObject.");
            }
        }
        else
        {
            moveScriptEnemy = GetComponent<EnemyMovement>();
            if (moveScriptEnemy == null)
            {
                Debug.LogError("EnemyMovement component not found on this GameObject.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && isPlayer1)
        {
            if (moveScript != null)
            {
                SoundObject.PlayOneShot(DashSound);

                StartCoroutine(DashCoroutine());
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isPlayer1)
        {
            if (moveScriptEnemy != null)
            {
                SoundObject.PlayOneShot(DashSound);
                StartCoroutine(DashCoroutine());
            }
        }
    }

    IEnumerator DashCoroutine()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            if (isPlayer1 && moveScript != null)
            {
                Rigidbody rb = moveScript.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    if (moveScript.isFacingRight)
                    {
                        rb.AddForce(new Vector3(0,0,1) * dashSpeed,ForceMode.Impulse);
                    }
                    else
                    {
                        rb.AddForce(new Vector3(0,0,-1) * dashSpeed,ForceMode.Impulse);
                    }
                }
                else
                {
                    Debug.LogError("CharacterController component not found on this GameObject.");
                }
            }
            else if (moveScriptEnemy != null)
            {
                Rigidbody rb = moveScriptEnemy.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    if (moveScriptEnemy.isFacingRight)
                    {
                        rb.AddForce(new Vector3(0,0,1) * dashSpeed,ForceMode.Impulse);
                    }
                    else
                    {
                        rb.AddForce(new Vector3(0,0,-1) * dashSpeed,ForceMode.Impulse);
                    }
                }
                else
                {
                    Debug.LogError("CharacterController component not found on this GameObject.");
                }
            }

            yield return null;  // Ensure this is outside the if statements and inside the while loop
        }
    }
}
