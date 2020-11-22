using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle1Logic : MonoBehaviour
{
    public static puzzle1Logic singleton;
    public GameObject endDoorPuzzle1;

    public bool puzzle1Complete = false;
    public int puzzle1DoorId;

    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        EventSystemManager.EventSystemManagerSingleton.onPuzzleComplete += OnPuzzleComplete;
    }

    private void OnPuzzleComplete(int id)
    {
        endDoorPuzzle1.transform.localPosition.Set(0.17f, 1.07f, 5f);
        //gameObject.SetActive(true);
        //do something with id
        if (id == puzzle1DoorId)
        {
            //endDoorPuzzle1.transform.localRotation = Quaternion.Euler(, 90f, 0f);
            

        }
    }



    // Update is called once per frame
    void Update()
    {

        //endDoorPuzzle1.transform.position = new Vector3(0.17f, 1.07f, 5f);
        if (puzzle1Complete)
        {

            EventSystemManager.EventSystemManagerSingleton.PuzzleComplete(puzzle1DoorId);
            endDoorPuzzle1.transform.localPosition = new Vector3(0.17f, 1.07f, 5f);
            //endDoorPuzzle1.transform.position = new Vector3(0.17f, 1.07f, 5f);
        }

    }
}
