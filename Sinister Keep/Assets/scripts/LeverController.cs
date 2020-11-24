using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public int id;
    [SerializeField]
    private GameObject leverHandle;
    [SerializeField]
    private bool extensionController;
    public GameObject linkedLever;
    bool temp;
    
    private void Start()
    {
        EventSystemManager.EventSystemManagerSingleton.onLeverSwitch += OnLeverSwitch;
        temp = gameObject.GetComponent<PropProperties>().value;
        //gameObject.SetActive(false);
    }

    private void OnLeverSwitch(int id, bool state,int targetId,bool inverseLink, GameObject go)
    {

        //gameObject.SetActive(true);
        //do something with id


        if (id == this.id)
        {

            go.GetComponent<PropProperties>().value = !state;

            if (gameObject.GetComponent<PropProperties>().interactSound != null)
            {
                gameObject.GetComponent<PropProperties>().interactSound.Play();
            }
        }
        if(targetId == this.id)
        {
            
            if (go.GetComponent<PropProperties>().dialogueMessage != "Sync")
            {
                gameObject.GetComponent<PropProperties>().value = (inverseLink == state);

            }
            else
            {
                gameObject.GetComponent<PropProperties>().inverseLink = !gameObject.GetComponent<PropProperties>().inverseLink;
                go.GetComponent<PropProperties>().inverseLink = !go.GetComponent<PropProperties>().inverseLink;
                gameObject.GetComponent<PropProperties>().value = (inverseLink == state);



            }
            if (gameObject.GetComponent<PropProperties>().interactSound != null)
            {
                gameObject.GetComponent<PropProperties>().interactSound.Play();
            }

        }
        if (go.transform.GetComponent<PropProperties>().targetId2 == this.id)
        {
            if (gameObject.GetComponent<PropProperties>().interactSound != null)
            {
                gameObject.GetComponent<PropProperties>().interactSound.Play();
            }
            if (go.GetComponent<PropProperties>().dialogueMessage != "Sync")
            {
                gameObject.GetComponent<PropProperties>().value = (inverseLink == state);
            }
            else
            {
                gameObject.GetComponent<PropProperties>().inverseLink = !gameObject.GetComponent<PropProperties>().inverseLink;
                go.GetComponent<PropProperties>().inverseLink = !go.GetComponent<PropProperties>().inverseLink;
                gameObject.GetComponent<PropProperties>().value = (inverseLink == state);
                

            }
        }

    }


    private void Update()
    {
        

        if(temp != gameObject.GetComponent<PropProperties>().value)
        {
             temp = gameObject.GetComponent<PropProperties>().value;
            //EventSystemManager.EventSystemManagerSingleton.LeverSwitch(hit.transform.GetComponent<PropProperties>().id, hit.transform.GetComponent<PropProperties>().value, hit.transform.GetComponent<PropProperties>().targetId, hit.transform.GetComponent<PropProperties>().inverseLink, hit.transform.gameObject);
            //Debug.Log("Fire Event");

        }


        if (!extensionController)
        {


        if (gameObject.GetComponent<PropProperties>().type == "FloorLever")
        {
            if (gameObject.GetComponent<PropProperties>().value)
            {
                leverHandle.transform.localRotation = Quaternion.Euler(-170f, 90f, 0f);

            }
            else
            {
                leverHandle.transform.localRotation = Quaternion.Euler(-10f, 90f, 0f);
            }
        }
        else
        {
            if (gameObject.GetComponent<PropProperties>().value)
            {
                leverHandle.transform.localRotation = Quaternion.Euler(-45, -270f, 0f);

            }
            else
            {
                leverHandle.transform.localRotation = Quaternion.Euler(45, -270f, 0f);
            }
        }
        }
        //Debug.Log(id + " - " + gameObject.GetComponent<PropProperties>().value);

        //if (Input.GetButtonDown("Cancel"))
        //{
        //    gameObject.SetActive(false);
        //}
    }


}
