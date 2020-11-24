using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HingeDoorController : MonoBehaviour
{

    public int id;
    public int dominantId;

    private void Start()
    {
        EventSystemManager.EventSystemManagerSingleton.onLetterSwitch += OnLetterSwitch;

    }

    private void OnLetterSwitch(int id, bool state, int targetId, bool inverseLink, GameObject go)
    {


        if (id == this.id)
        {
            if (gameObject.GetComponent<PropProperties>().interactSound != null)
            {
                gameObject.GetComponent<PropProperties>().interactSound.Play();
            }
            gameObject.GetComponent<PropProperties>().value = !state;
        }
        if (targetId == this.id)
        {
            if (gameObject.GetComponent<PropProperties>().interactSound != null)
            {
                gameObject.GetComponent<PropProperties>().interactSound.Play();
            }
            gameObject.GetComponent<PropProperties>().value = (inverseLink == state);

        }
        if (go.GetComponent<PropProperties>().targetId2 == this.id)
        {
            if (gameObject.GetComponent<PropProperties>().interactSound != null)
            {
                gameObject.GetComponent<PropProperties>().interactSound.Play();
            }
            if(dominantId == id)
            {
                gameObject.GetComponent<PropProperties>().value = (inverseLink == state);
            }
            else
            {
                gameObject.GetComponent<PropProperties>().value = (inverseLink == go.GetComponent<PropProperties>().linkedGameObject.GetComponent<PropProperties>().value);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<PropProperties>().type == "HingeDoor")
        {
            if (gameObject.GetComponent<PropProperties>().value)
            {
                gameObject.transform.localRotation = Quaternion.Euler(145f, 90f, -90f);

            }
            else
            {
                gameObject.transform.localRotation = Quaternion.Euler(0f, 90f, -90f);
            }
        }
        else
        {
            if (gameObject.GetComponent<PropProperties>().value)
            {
                //gameObject.transform.localRotation = Quaternion.Euler(-45, -270f, 0f);

            }
            else
            {
                //gameObject.transform.localRotation = Quaternion.Euler(45, -270f, 0f);
            }
        }
    }
}
