using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caveFlasher : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;
    public GameObject image6;
    public GameObject image7;
    public GameObject image8;
    public GameObject image9;
    public GameObject image10;
    public GameObject image11;
    public GameObject image12;
    public GameObject image13;
    public GameObject image14;
    public GameObject image15;
    public GameObject image16;
    public GameObject image17;
    public GameObject image18;
    public GameObject image19;
    public GameObject image20;
    public GameObject image21;
    public GameObject image22;
    public GameObject image23;
    public GameObject currentImage;
    public GameObject previousImage;

    public float timer;
    public bool activated;

    public bool visibleImages;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(image1, transform.position, Quaternion.identity);
        timer = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            visibleImages = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            visibleImages = false;
        }

        if (activated)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                RandomImage();
                if(visibleImages == true)
                {
                    previousImage = Instantiate(currentImage, transform.position, Quaternion.identity);
                }
                
                Invoke(nameof(DestroyImage), 0.99f);
                timer = 1f;
            }
        }

        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    RandomImage();
        //    previousImage = Instantiate(currentImage, transform.position, Quaternion.identity);
        //    Invoke(nameof(DestroyImage), 0.3f);
        //}
    }

    //choose a random photo
    public void RandomImage()
    {
        int imageChoice;
        imageChoice = Random.Range(1, 24);
        if (imageChoice == 1)
        {
            currentImage = image1;
        }
        else if (imageChoice == 2)
        {
            currentImage = image2;
        }
        else if (imageChoice == 3)
        {
            currentImage = image3;
        }
        else if (imageChoice == 4)
        {
            currentImage = image4;
        }
        else if (imageChoice == 5)
        {
            currentImage = image6;
        }
        else if (imageChoice == 7)
        {
            currentImage = image7;
        }
        else if (imageChoice == 8)
        {
            currentImage = image8;
        }
        else if (imageChoice == 9)
        {
            currentImage = image9;
        }
        else if (imageChoice == 10)
        {
            currentImage = image10;
        }
        else if (imageChoice == 11)
        {
            currentImage = image11;
        }
        else if (imageChoice == 12)
        {
            currentImage = image12;
        }
        else if (imageChoice == 13)
        {
            currentImage = image13;
        }
        else if (imageChoice == 14)
        {
            currentImage = image14;
        }
        else if (imageChoice == 15)
        {
            currentImage = image15;
        }
        else if (imageChoice == 16)
        {
            currentImage = image16;
        }
        else if (imageChoice == 17)
        {
            currentImage = image17;
        }
        else if (imageChoice == 18)
        {
            currentImage = image18;
        }
        else if (imageChoice == 19)
        {
            currentImage = image19;
        }
        else if (imageChoice == 20)
        {
            currentImage = image20;
        }
        else if (imageChoice == 21)
        {
            currentImage = image21;
        }
        else if (imageChoice == 22)
        {
            currentImage = image22;
        }
        else if (imageChoice == 23)
        {
            currentImage = image23;
        }
    }

    //destroy the current random image
    public void DestroyImage()
    {
        Destroy(previousImage);
    }
}
