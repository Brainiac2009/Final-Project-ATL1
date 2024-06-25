using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class PlayerMovement2 : MonoBehaviour

{

    public float moveSpeed = 5f;

    public float jumpForce = 10f;

    private Rigidbody rb;
 

    public GameObject rightTrigger, leftTrigger;

    [SerializeField] private Transform groundCheck;

    public bool isFacingRight;
    [SerializeField] private KeyCode AttackKey = KeyCode.DownArrow;
    void Start()

    {

        rb = GetComponent<Rigidbody>();

    }
    private bool IsGrounded()
    {
        bool isGrounded = false;
        Collider[] hitColliders = Physics.OverlapSphere(groundCheck.transform.position, 1);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.name == "Ground") isGrounded = true;
            else isGrounded = false;
        }

        return isGrounded;
    }
    void Update()
    {
        if (rightTrigger.GetComponent<AttackTrigger1>().canAttack || leftTrigger.GetComponent<AttackTrigger1>().canAttack)
        {
            if (Input.GetKeyDown(AttackKey))
            {
                FindObjectOfType<PlayerMovement>().GetComponent<AttributesManager>().health -= this.GetComponent<AttributesManager>().attack;
            }
        }

        // Move forward

        if (Input.GetKey(KeyCode.D))

        {
            foreach(AttackTrigger1 trigger in FindObjectsOfType<AttackTrigger1>())
                if (trigger.name == "leftTrigger") trigger.canAttack = false;
            isFacingRight = true;
            rb.MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime);

        }
        if(isFacingRight){
            rightTrigger.SetActive(true);
            leftTrigger.SetActive(false);
        }
        else{
            rightTrigger.SetActive(false);
            leftTrigger.SetActive(true);
        }
        // Move backward

        if (Input.GetKey(KeyCode.A))

        {
            foreach(AttackTrigger1 trigger in FindObjectsOfType<AttackTrigger1>())
                if (trigger.name == "rightTrigger") trigger.canAttack = false;


            isFacingRight = false;
            rb.MovePosition(transform.position - transform.forward * moveSpeed * Time.deltaTime);

        }

        // Jump

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())

        {

            rb.AddForce(new Vector3(0,1,0) * jumpForce, ForceMode.Impulse);

        }
        if(GetComponent<AttributesManager>().health <= 0)
        {
            Debug.Log("<color=red>Player2 has died!");
            Destroy(GetComponent<PlayerMovement2>().gameObject);
            this.enabled = false;

        }
    }

}