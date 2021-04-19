using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realmHolderScript : MonoBehaviour
{
    public GameObject stage;
    public GameObject forest;
    public GameObject ForestPos;
    public GameObject StagePos;
    public GameObject CavePos;
    public GameObject sabinePos;
    public GameObject jonasPos;
    public GameObject jonas;
    public GameObject sabine;


    public bool moving;
    public int movingTo;
    //1 Forest
    //2 Stage
    //3 Cave

    public GameObject levelStarter;
    public GameObject WhatsHappDBp26;

    public bool movingIntoPlace;
    public float movingIPTimer;

    public bool movingApart;
    public float movingApartSpeed;

    public GameObject cam;

    public GameObject spotlights;

    public GameObject movingBeam;
    public bool beamActivated;
    public bool beamMovingLeft;
    public float beamZAngle;
    public float beamRotateSpeed;

    public GameObject theaterBackground;
    public GameObject whiteBackground;
    public GameObject db54;

    public GameObject wallFlasher;

    public GameObject KarenSpawner;
    public GameObject karen;

    public GameObject leftCurtain;
    public GameObject rightCurtain;
    public GameObject LCurtainDest;
    public GameObject RCurtainDest;
    public bool stageExpanding;
    public GameObject topLights;

    public GameObject bombKaren;

    public GameObject sabinePos2;
    public GameObject jonasPos2;
    public bool movingToCave;

    public GameObject telescope;
    public bool TelescopeMoving;

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
        spotlights = GameObject.Find("Spotlights");
        movingBeam = GameObject.Find("Moving Beam Holder");
        theaterBackground = GameObject.Find("Theater Background");
        whiteBackground = GameObject.Find("White Theater Background");
        wallFlasher = GameObject.Find("Wall Flasher");
        KarenSpawner = GameObject.Find("Karen Spawner");
        leftCurtain = GameObject.Find("Left Curtain");
        rightCurtain = GameObject.Find("Right Curtain");
        LCurtainDest = GameObject.Find("LCurtainDest");
        RCurtainDest = GameObject.Find("RCurtainDest");
        CavePos = GameObject.Find("Cave Pos");
        sabinePos2 = GameObject.Find("SabineJumpToPos2");
        jonasPos2 = GameObject.Find("JonasJumpToPos2");
        

        spotlights.SetActive(false);
        movingBeam.SetActive(false);
        whiteBackground.SetActive(false);

        Invoke(nameof(StartLevelDialogue), 2);
        Invoke(nameof(MoveToStage), 8);
        Invoke(nameof(Places), 8);
        Invoke(nameof(LightsOn), 8.75f);

        movingIPTimer = 1.5f;
        beamRotateSpeed = .05f;
        movingToCave = false;
    }

    private void Update()
    {
        if (moving)
        {
            if (movingTo == 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, StagePos.transform.position, 100 * Time.deltaTime);
                
            }
            if (movingTo == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, ForestPos.transform.position, 100 * Time.deltaTime);
            }
            //to the cave
            if (movingTo == 3)
            {
                transform.position = Vector3.MoveTowards(transform.position, CavePos.transform.position, 100 * Time.deltaTime);
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
                Invoke(nameof(MoveApart), 1);
                Invoke(nameof(p26Dialogue), 2);
                //MoveApart();
                //p26Dialogue();
                
            }
        }

        //moving apart
        if(movingApart == true)
        {
            jonas.transform.Translate(-movingApartSpeed, 0, 0);
            sabine.transform.Translate(movingApartSpeed, 0, 0);

        }

        //once Jonas and Sabine are manually touching again, manually make them hold hands.
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            jonas.transform.position = jonasPos.transform.position;
            sabine.transform.position = new Vector3(jonas.transform.position.x + 1.3f, sabine.transform.position.y, sabine.transform.position.z);
            movingApart = false;
            cam.transform.position = new Vector3(196.68f, 2.8f, -3.22f);
            Invoke(nameof(ReturnCam), 3f);
        }

        //make the beam move from left to right
        if (beamActivated)
        {
            beamZAngle = movingBeam.transform.rotation.z;
            if (beamMovingLeft)
            {
                //float zAngle;
                movingBeam.transform.Rotate(0, 0, -beamRotateSpeed);
                //beamZAngle -= .01f;
                if(beamZAngle < -.3f)
                {
                    beamMovingLeft = false;
                }
            }
            else
            {
                movingBeam.transform.Rotate(0, 0, beamRotateSpeed);
                //beamZAngle += .01f;
                if (beamZAngle > .3f)
                {
                    beamMovingLeft = true;
                }
            }
        }

        //make the curtains expand and the level grow
        if (stageExpanding)
        {
            leftCurtain.transform.position = Vector3.MoveTowards(leftCurtain.transform.position, LCurtainDest.transform.position, .2f * Time.deltaTime);
            rightCurtain.transform.position = Vector3.MoveTowards(rightCurtain.transform.position, RCurtainDest.transform.position, .2f * Time.deltaTime);
            jonas.transform.Translate(-.01f, 0, 0);
            sabine.transform.Translate(.01f, 0, 0);
        }

        if(movingToCave == true)
        {
            jonas.transform.position = Vector3.MoveTowards(jonas.transform.position, jonasPos2.transform.position, 15 * Time.deltaTime);
            sabine.transform.position = Vector3.MoveTowards(sabine.transform.position, sabinePos2.transform.position, 15 * Time.deltaTime);
        }

        if (TelescopeMoving)
        {
            telescope.transform.position = Vector3.MoveTowards(telescope.transform.position, jonas.transform.position, 3 * Time.deltaTime);
            if (Vector3.Distance(telescope.transform.position, jonas.transform.position) < .2f)
            {
                Destroy(telescope);
            }
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
        movingTo = 2;
    }

    public void MoveToForest()
    {
        moving = true;
        movingTo = 1;
    }

    public void MoveToCave()
    {
        moving = true;
        movingTo = 3;
        movingToCave = true;
    }

    public void ToCaveStop()
    {
        movingToCave = false;
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

    public void LightsOn()
    {
        spotlights.SetActive(true);
    }

    public void ReturnCam()
    {
        cam.transform.position = new Vector3(196.31f, 5.08f, -11.02f);
        //turn on the moving jbeam just after that
        Invoke(nameof(TurnOnBeam), 1);
        Invoke(nameof(WhiteBackground), 5);
    }

    public void TurnOnBeam()
    {
        movingBeam.SetActive(true);
        beamActivated = true;
    }

    public void WhiteBackground()
    {
        whiteBackground.SetActive(true);
        theaterBackground.SetActive(false);

        //start the images of whiteness wall flashing
        Invoke(nameof(ImageFlashes), 2.0f);
        Invoke(nameof(SpawnKarens), 8f);
        Invoke(nameof(ExpandStage), 13);
        Invoke(nameof(DropBombKaren), 18);
        Invoke(nameof(MoveToCave), 25);
        Invoke(nameof(ToCaveStop), 27);

        //didn't need to do that
        Instantiate(db54, transform.position + new Vector3(0, 100, 0), Quaternion.identity);
    }

    public void DBp54()
    {
        Instantiate(db54, transform.position + new Vector3(0, 100, 0), Quaternion.identity);
    }

    public void ImageFlashes()
    {
        wallFlasher.GetComponent<WallFlasherScript>().activated = true;
    }

    public void SpawnKarens()
    {
        //Instantiate(karen, KarenSpawner.transform.position, Quaternion.identity);
        Instantiate(karen, KarenSpawner.transform.position + new Vector3(-4, 0, 0), Quaternion.identity);
        Instantiate(karen, KarenSpawner.transform.position + new Vector3(4, 0, 0), Quaternion.identity);
        Instantiate(karen, KarenSpawner.transform.position + new Vector3(-7, 0, 0), Quaternion.identity);
        Instantiate(karen, KarenSpawner.transform.position + new Vector3(7, 0, 0), Quaternion.identity);
    }

    public void ExpandStage()
    {
        stageExpanding = true;
    }

    public void DropBombKaren()
    {
        Instantiate(bombKaren, KarenSpawner.transform.position + new Vector3(0, 20, 0), Quaternion.identity);
    }

    public void SabineGiveTelescope()
    {
        Instantiate(telescope, sabine.transform.position, Quaternion.identity);
        TelescopeMoving = true;
        
    }


}
