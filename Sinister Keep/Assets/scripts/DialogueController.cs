using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public int id;
    private GameObject dialogueMessageObj;
    private void Start()
    {
        EventSystemManager.EventSystemManagerSingleton.onInteractProp += OnDialogueOpen;

        gameObject.SetActive(false);
    }

    private void OnDialogueOpen(int id,string message)
    {




        gameObject.SetActive(true);
        dialogueMessageObj = GameObject.Find("DialogueMessageObj");

        dialogueMessageObj.GetComponent<Text>().text = message;
        //do something with id
        if (id == this.id)
        {

        }
    }


    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            gameObject.SetActive(false);
        }
    }


}
