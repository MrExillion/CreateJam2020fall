﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPuzzleController : MonoBehaviour
{
    public int id;
    [SerializeField]
    private GameObject letterGraphics;
    
    private void Start()
    {
        EventSystemManager.EventSystemManagerSingleton.onLetterSwitch += OnLetterSwitch;

        //gameObject.SetActive(false);
    }

    private void OnLetterSwitch(int id, bool state, int targetId, bool inverseLink, GameObject go)
    {

        //gameObject.SetActive(true);
        //do something with id
        if (id == this.id)
        {
            go.GetComponent<PropProperties>().value = !state;
        }
        if (targetId == this.id)
        {
            gameObject.GetComponent<PropProperties>().value = (inverseLink == state);

        }

    }

    public MeshRenderer[] bookPieces = new MeshRenderer[3];
    private void Update()
    {
        bookPieces = letterGraphics.GetComponentsInChildren<MeshRenderer>();
        if (gameObject.GetComponent<PropProperties>().value)
        {
            
            for (int i = 0; i < bookPieces.Length; i++)
            {
                //letterGraphics.GetComponentInChildren<MeshRenderer>().enabled = true;

                bookPieces[i].enabled = true;
            }

        }
        else
        {
            for (int i = 0; i < bookPieces.Length; i++)
            {
                //letterGraphics.GetComponentInChildren<MeshRenderer>().enabled = false;
                bookPieces[i].enabled = false;
            }
        }

        //Debug.Log(id + " - " + gameObject.GetComponent<PropProperties>().value);

        //if (Input.GetButtonDown("Cancel"))
        //{
        //    gameObject.SetActive(false);
        //}
    }


}
