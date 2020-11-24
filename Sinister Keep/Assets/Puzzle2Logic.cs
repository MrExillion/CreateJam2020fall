using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2Logic : MonoBehaviour
{

    public static Puzzle2Logic singleton;
    public GameObject endDoorPuzzle2;
    private bool playOnce = false;

    public GameObject[] puzzleObjects;
    public bool[] defaultPuzzleValues;
    public bool puzzle2Complete = false;
    public int puzzle2DoorId;

    private void Awake()
    {
        if (singleton == null)
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
        playOnce = true;
    }

    private void OnPuzzleComplete(int id)
    {
        //endDoorPuzzle1.transform.localPosition.Set(0.17f, 1.07f, 5f);
        //gameObject.SetActive(true);
        //do something with id

        if (puzzleObjects[0].GetComponent<PropProperties>().value)
        {
            if (puzzleObjects[1].GetComponent<PropProperties>().value)
            {
                if (puzzleObjects[2].GetComponent<PropProperties>().value)
                {
                    if (!puzzleObjects[3].GetComponent<PropProperties>().value)
                    {
                        puzzle2Complete = true;

                    }
                    else
                    {
                        ResetPuzzle();
                    }


                }
                else
                {
                    ResetPuzzle();
                }
            }
            else
            {
                ResetPuzzle();
            }
        }
        else
        {
            ResetPuzzle();
        }


        if (id == gameObject.GetComponent<PropProperties>().id && puzzle2Complete)
        {
            //endDoorPuzzle1.transform.localRotation = Quaternion.Euler(, 90f, 0f);
            EventSystemManager.EventSystemManagerSingleton.LetterSwitch(gameObject.transform.GetComponent<PropProperties>().id, gameObject.transform.GetComponent<PropProperties>().value, gameObject.transform.GetComponent<PropProperties>().targetId, gameObject.transform.GetComponent<PropProperties>().inverseLink, gameObject);
            
        }
    }

    public void ResetPuzzle()
    {
        for(int i = 0; i < puzzleObjects.Length; i++)
        {
            puzzleObjects[i].GetComponent<PropProperties>().value = defaultPuzzleValues[i];
            //puzzle2Complete = false;
        }
        Debug.Log("puzzleReset");
    }


    // Update is called once per frame
    void Update()
    {
        if (puzzle2Complete)
        {


        }

    }
}
