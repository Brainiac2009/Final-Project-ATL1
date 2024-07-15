using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class EnemyMovement : MonoBehaviour

{

    

    public float moveSpeed = 5f;

    public float jumpForce = 10f;
    public float hitForce = 10f;

    public Rigidbody rb;
 

    public GameObject rightTrigger, leftTrigger;

    public GameObject rightHitVFX, leftHitVFX;

    public AudioSource SoundObject;

    public AudioClip HitSound;


    [SerializeField] private Transform groundCheck;

    public bool isFacingRight;
    [SerializeField] private KeyCode AttackKey = KeyCode.M;
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
        // this.transform.position = new Vector3( 133, this.transform.position.y, this.transform.position.z);

        if (rightTrigger.GetComponent<AttackTrigger>().canAttack || leftTrigger.GetComponent<AttackTrigger>().canAttack)
        {
            if (Input.GetKeyDown(AttackKey))
            {
                FindObjectOfType<PlayerMovement>().GetComponent<AttributesManager>().health -= this.GetComponent<AttributesManager>().attack;

                if (rightTrigger.GetComponent<AttackTrigger>().canAttack){
                    GameObject hitVFX = Instantiate(rightHitVFX, rightTrigger.GetComponent<Transform>());

                    hitVFX.SetActive(true);
                    SoundObject.PlayOneShot(HitSound);

                    FindObjectOfType<PlayerMovement>().GetComponent<Rigidbody>().AddForce(new Vector3(0,0,1) * hitForce, ForceMode.Impulse);
                    }
           
                if (leftTrigger.GetComponent<AttackTrigger>().canAttack){
                    GameObject hitVFX = Instantiate(leftHitVFX, leftTrigger.GetComponent<Transform>());

                    hitVFX.SetActive(true);
                    SoundObject.PlayOneShot(HitSound);


                    FindObjectOfType<PlayerMovement>().GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-1) * hitForce, ForceMode.Impulse);
                    }

            }
        }

        // Move forward

        if (Input.GetKey(KeyCode.RightArrow))

        {
            foreach(AttackTrigger trigger in FindObjectsOfType<AttackTrigger>())
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

        if (Input.GetKey(KeyCode.LeftArrow))

        {
            foreach(AttackTrigger trigger in FindObjectsOfType<AttackTrigger>())
                if (trigger.name == "rightTrigger") trigger.canAttack = false;


            isFacingRight = false;
            rb.MovePosition(transform.position - transform.forward * moveSpeed * Time.deltaTime);

        }

        // Jump

        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())

        {

            rb.AddForce(new Vector3(0,1,0) * jumpForce, ForceMode.Impulse);

        }
        if(GetComponent<AttributesManager>().health <= 0)
        {
            Debug.Log("Enemy has died!");
            Destroy(FindObjectOfType<EnemyMovement>().gameObject);
            this.enabled = false;

        }
    }

}