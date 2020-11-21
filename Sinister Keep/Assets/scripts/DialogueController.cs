using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public int id;

    private void Start()
    {
        EventSystemManager.EventSystemManagerSingleton.onInteractProp += OnDialogueOpen;

        gameObject.SetActive(false);
    }

    private void OnDialogueOpen(int id)
    {

        gameObject.SetActive(true);
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
