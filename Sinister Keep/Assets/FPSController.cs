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
        playerBody.Rotate(Vector3.up * mouseVec.x);

        verticalDelta -= mouseVec.y;
        verticalDelta = Mathf.Clamp(verticalDelta, -90f, 90f);

        Camera.transform.localRotation = Quaternion.Euler(verticalDelta,0f,0f);

        moveVec.x = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        moveVec.z = Input.GetAxis("Vertical") * moveSpeed * Time.fixedDeltaTime;
        //moveVec.y =  rb.velocity.y;//Input.GetAxis("Jump");

        moveVec = moveVec.x * transform.right + moveVec.z * transform.forward;
        moveVec.y = rb.velocity.y;
        rb.velocity = moveVec; 


        if(Input.GetButtonDown("Jump") && Physics.CheckSphere(groundCheck.position, groundDistTolerance, groundMask))
        {
            Debug.Log("JUMP!");
            jumpforceVec = jumpforce * new Vector3(moveVec.x, 1f, moveVec.z);
            rb.AddForce(jumpforceVec);

        }

        if (Input.GetMouseButtonDown(0))
        {
            Interact();
        }

    }


    void Interact()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, interactRange))
        {
            Debug.Log(hit.transform.GetComponent<PropProperties>().id);

            if(hit.transform.GetComponent<PropProperties>().type == "Dialogue")
            {
                EventSystemManager.EventSystemManagerSingleton.InteractProp(hit.transform.GetComponent<PropProperties>().id);

            }
            if(hit.transform.GetComponent<PropProperties>().type == "Lever")
            {
                //Invoke LeverSwitch with ID
                EventSystemManager.EventSystemManagerSingleton.LeverSwitch(hit.transform.GetComponent<PropProperties>().id, hit.transform.GetComponent<PropProperties>().value, hit.transform.GetComponent<PropProperties>().targetId, hit.transform.GetComponent<PropProperties>().inverseLink,hit.transform.gameObject);
            }
            if(hit.transform.GetComponent<PropProperties>().type == "LetterSwitch")
            {
                EventSystemManager.EventSystemManagerSingleton.LetterSwitch(hit.transform.GetComponent<PropProperties>().id, hit.transform.GetComponent<PropProperties>().value, hit.transform.GetComponent<PropProperties>().targetId, hit.transform.GetComponent<PropProperties>().inverseLink, hit.transform.gameObject);
            }

        }

    }

}
