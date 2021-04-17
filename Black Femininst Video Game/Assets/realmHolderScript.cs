using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realmHolderScript : MonoBehaviour
{
    public GameObject stage;
    public GameObject forest;
    public GameObject ForestPos;
    public GameObject StagePos;
    public GameObject sabinePos;
    public GameObject jonasPos;
    public GameObject jonas;
    public GameObject sabine;

    public bool moving;
    public bool movingLeft;

    public GameObject levelStarter;
    public GameObject WhatsHappDBp26;

    public bool movingIntoPlace;
    public float movingIPTimer;

    public bool movingApart;
    public float movingApartSpeed;

    // Start is called before the first frame update
    void Start()
    {
        stage = GameObject.Find("StageHolder");
        forest = GameObject.Find("ForestHolder");
        ForestPos = GameObject.Find("Forest Pos");
        StagePos = GameObject.Find("Stage Pos");
        sabinePos = GameObject.Find("SabineJumpToPos");
        jonasPos = GameObject.Find("JonasJumpToPos");
        jonas = GameObject.Find("Player");
        sabine = GameObject.Find("Sabine");

        Invoke(nameof(StartLevelDialogue), 2);
        Invoke(nameof(MoveToStage), 8);
        Invoke(nameof(Places), 8);

        movingIPTimer = 1.5f;
    }

    private void Update()
    {
        if (moving)
        {
            if (!movingLeft)
            {
                transform.position = Vector3.MoveTowards(transform.position, StagePos.transform.position, 100 * Time.deltaTime);
                
            }
        }

        if (moving)
        {
            if (movingLeft)
            {
                transform.position = Vector3.MoveTowards(transform.position, ForestPos.transform.position, 100 * Time.deltaTime);
            }
        }

        if(movingIntoPlace == true)
        {
            movingIPTimer -= Time.deltaTime;
            if(movingIPTimer > 0)
            {
                jonas.transform.position = Vector3.MoveTowards(jonas.transform.position, jonasPos.transform.position, 15 * Time.deltaTime);
                sabine.transform.position = Vector3.MoveTowards(sabine.transform.position, sabinePos.transform.position, 15 * Time.deltaTime);
            } else
            {
                movingIntoPlace = false;
                movingIPTimer = 1.5f;
                MoveApart();
                p26Dialogue();
            }
        }

        //moving apart
        if(movingApart == true)
        {
            jonas.transform.Translate(-movingApartSpeed, 0, 0);
            sabine.transform.Translate(movingApartSpeed, 0, 0);

        }
        


        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    MoveToStage();
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    MoveToForest();
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    GoToStage();
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    GoToForest();
        //}
    }

    public void MoveToStage()
    {
        moving = true;
        movingLeft = false;
    }

    public void MoveToForest()
    {
        moving = true;
        movingLeft = true;
    }

    public void GoToStage()
    {
        stage.SetActive(true);
        forest.SetActive(false);
    }

    public void GoToForest()
    {
        stage.SetActive(false);
        forest.SetActive(true);
    }

    public void StartLevelDialogue()
    {
        Instantiate(levelStarter, transform.position, Quaternion.identity);
    }

    public void Places()
    {
        movingIntoPlace = true;
    }

    public void MoveApart()
    {
        movingApart = true;
    }

    public void p26Dialogue()
    {
        Instantiate(WhatsHappDBp26, transform.position, Quaternion.identity);
    }


}
