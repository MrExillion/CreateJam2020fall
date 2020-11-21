using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public int id;
    [SerializeField]
    private GameObject leverHandle;

    private void Start()
    {
        EventSystemManager.EventSystemManagerSingleton.onLeverSwitch += OnLeverSwitch;

        //gameObject.SetActive(false);
    }

    private void OnLeverSwitch(int id, bool state,int targetId,bool inverseLink, GameObject go)
    {

        //gameObject.SetActive(true);
        //do something with id
        if (id == this.id)
        {
            go.GetComponent<PropProperties>().value = !state;
        }
        if(targetId == this.id)
        {
            gameObject.GetComponent<PropProperties>().value = (inverseLink == state);

        }

    }


    private void Update()
    {

        if (gameObject.GetComponent<PropProperties>().value)
        {
            leverHandle.transform.localRotation = Quaternion.Euler(-45, -270f, 0f);

        }
        else
        {
            leverHandle.transform.localRotation = Quaternion.Euler(45, -270f, 0f);
        }

            //Debug.Log(id + " - " + gameObject.GetComponent<PropProperties>().value);
        
        //if (Input.GetButtonDown("Cancel"))
        //{
        //    gameObject.SetActive(false);
        //}
    }


}
