using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{

    public Vector2 cdGain = new Vector2(100,100);
    public Camera Camera;
    public Vector2 horizontalVec;
    public Vector2 mouseVec;
    public float verticalDelta;
    public float horizontalDelta;
    public Vector3 moveVec;
    public Transform playerBody;
    public Rigidbody rb;
    public float moveSpeed;
    public Vector3 jumpforceVec;
    public float jumpforce;
    public Transform groundCheck;
    public float groundDistTolerance;
    public LayerMask groundMask;
    public float interactRange;

    public AudioSource walkSound;

    private void Start()
    {
        Cursor.lockState  = CursorLockMode.Locked;
    }


    void Update()
    {

        mouseVec.x = Input.GetAxis("Mouse X") * cdGain.x * Time.deltaTime;
        mouseVec.y = Input.GetAxis("Mouse Y") * cdGain.y * Time.deltaTime;

        horizontalDelta -= mouseVec.x;
        //horizontalDelta = Mathf.Clamp(horizontalDelta,-90f,90f);

        //transform.localRotation = Quaternion.Euler(horizontalDelta, 0f, 0f);
        

        verticalDelta -= mouseVec.y;
        verticalDelta = Mathf.Clamp(verticalDelta, -90f, 90f);



        moveVec.x = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        moveVec.z = Input.GetAxis("Vertical") * moveSpeed * Time.fixedDeltaTime;
        //moveVec.y =  rb.velocity.y;//Input.GetAxis("Jump");



        moveVec = moveVec.x * transform.right + moveVec.z * transform.forward;
        moveVec.y = rb.velocity.y;
        //rb.velocity = moveVec; 
        if ((moveVec.x != 0f || moveVec.y != 0f || moveVec.z != 0f) && Physics.CheckSphere(groundCheck.position, groundDistTolerance, groundMask) && !walkSound.isPlaying)
        {
            walkSound.Play();
        }
        else if (walkSound.isPlaying && (moveVec.x == 0f && moveVec.z == 0f) || !Physics.CheckSphere(groundCheck.position, groundDistTolerance, groundMask))
        {
            walkSound.Stop();
        }

        if (Input.GetButtonDown("Jump") && Physics.CheckSphere(groundCheck.position, groundDistTolerance, groundMask))
        {
            Debug.Log("JUMP!");
            jumpforceVec = jumpforce * new Vector3(moveVec.x, 1f, moveVec.z);
            rb.AddForce(jumpforceVec);

        }

        if (/*Input.GetMouseButtonDown(0) || Input.GetButtonDown("RB")*/ Input.GetButtonDown("Fire1"))
        {
            Interact();
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = moveVec;
    }
    private void LateUpdate()
    {
        playerBody.Rotate(Vector3.up * mouseVec.x);
        Camera.transform.localRotation = Quaternion.Euler(verticalDelta, 0f, 0f);
    }

    int iterator = 0;
    public int[] sequence = new int[10];
    public bool[] defaultValues = new bool[10];
    public GameObject[] leverArr = new GameObject[10];
    public bool sequenceActive = false;
    void Interact()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, interactRange))
        {
            Debug.Log(hit.transform.GetComponent<PropProperties>().id);

            if(hit.transform.GetComponent<PropProperties>().type == "Dialogue")
            {
                EventSystemManager.EventSystemManagerSingleton.InteractProp(hit.transform.GetComponent<PropProperties>().id, hit.transform.GetComponent<PropProperties>().dialogueMessage);

            }
            if(hit.transform.GetComponent<PropProperties>().type == "Lever" || hit.transform.GetComponent<PropProperties>().type == "FloorLever")
            {
                //Invoke LeverSwitch with ID
                EventSystemManager.EventSystemManagerSingleton.LeverSwitch(hit.transform.GetComponent<PropProperties>().id, hit.transform.GetComponent<PropProperties>().value, hit.transform.GetComponent<PropProperties>().targetId, hit.transform.GetComponent<PropProperties>().inverseLink,hit.transform.gameObject);

                if(sequence[iterator] == hit.transform.GetComponent<PropProperties>().id && sequenceActive)
                {
                    iterator++;
                    if(sequence.Length == iterator)
                    {
                        //complete puzzle
                        Debug.Log("PuzzleComplete");
                        puzzle1Logic.singleton.puzzle1Complete = true;
                        iterator = 0;
                        sequenceActive = false;

                    }
                }
                else
                {
                    // reset the puzzle here
                    for(int i=0;i < defaultValues.Length; i++)
                    {
                        leverArr[i].transform.GetComponent<PropProperties>().value = defaultValues[i];
                        EventSystemManager.EventSystemManagerSingleton.LeverSwitch(leverArr[i].transform.GetComponent<PropProperties>().id, leverArr[i].transform.GetComponent<PropProperties>().value, leverArr[i].transform.GetComponent<PropProperties>().targetId, leverArr[i].transform.GetComponent<PropProperties>().inverseLink, leverArr[i].transform.GetComponent<PropProperties>().gameObject);
                        
                    }
                    iterator = 0;
                }


            }
            if(hit.transform.GetComponent<PropProperties>().type == "LetterSwitch" && hit.transform.GetComponent<PropProperties>().value)
            {
                EventSystemManager.EventSystemManagerSingleton.LetterSwitch(hit.transform.GetComponent<PropProperties>().id, hit.transform.GetComponent<PropProperties>().value, hit.transform.GetComponent<PropProperties>().targetId, hit.transform.GetComponent<PropProperties>().inverseLink, hit.transform.gameObject);
            }

        }

    }

}
