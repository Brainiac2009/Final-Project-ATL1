using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    PlayerMovement moveScript;
    EnemyMovement moveScriptEnemy;

    public float dashSpeed;

    public float dashTime;

    public bool isPlayer1;

    // Start is called before the first frame update
    void Start()
    {
        moveScript =isPlayer1 ? GetComponent<PlayerMovement>() : null;
        moveScriptEnemy = !isPlayer1 ? GetComponent<EnemyMovement>() : null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && isPlayer1);  // Changed to GetMouseButtonDown for single click detection
        {
            StartCoroutine(DashCoroutine());  // Updated method name to DashCoroutine to avoid confusion with class name
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isPlayer1);  // Changed to GetMouseButtonDown for single click detection
        {
            StartCoroutine(DashCoroutine());  // Updated method name to DashCoroutine to avoid confusion with class name
        }
    }

    IEnumerator DashCoroutine()  // Updated method name to DashCoroutine to avoid confusion with class name
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)  // Changed While to while
        {
            if (isPlayer1)
            {
                if (moveScript.isFacingRight){
                moveScript.GetComponent<CharacterController>().Move(new Vector3(0,0,1) * dashSpeed * Time.deltaTime);
                }
                else 
                {
                    moveScript.GetComponent<CharacterController>().Move(new Vector3(0,0,-1) * dashSpeed * Time.deltaTime);

                }
            }
            else
            {
                if (moveScriptEnemy.isFacingRight){
                    moveScriptEnemy.GetComponent<CharacterController>().Move(new Vector3(0,0,1) * dashSpeed * Time.deltaTime);
                }
                else 
                {
                    moveScriptEnemy.GetComponent<CharacterController>().Move(new Vector3(0,0,-1) * dashSpeed * Time.deltaTime);

                }
                yield return null;  // Corrected 'yeild' to 'yield'
            }
        }
    }
}