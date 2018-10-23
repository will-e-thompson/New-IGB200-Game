using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Variables to control door and windows
    public GameObject door;
    public GameObject window1;
    public GameObject window2;
    public GameObject window3;

    // Variables to control door and window text boxes
    public Text txtDoor;
    public Text txtWindowOpen;
    public Text txtWindowClose;

    // Variables to check if player is standing in colliders
    public bool standingDoor = false;
    public bool standingWindow1 = false;
    public bool standingWindow2 = false;
    public bool standingWindow3 = false;

    // Variables to determine window movement direction
    public bool window1Up = false;
    public bool window2Up = false;
    public bool window3Up = false;

    // Use this for initialization
    void Start()
    {       

        // Make text boxes invisible
        txtDoor.gameObject.SetActive(false);
        txtWindowOpen.gameObject.SetActive(false);
        txtWindowClose.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Open door
        if (standingDoor == true && Input.GetKeyDown("e") && GameManager.instance.guestAtDoor == true)
        {            
            GameManager.instance.examineMode = true;
            OpenDoor();
        }

        // Open and close windows
        if (standingWindow1 == true && Input.GetKeyDown("e"))
        {
            MoveWindow1();
        }
        if (standingWindow2 == true && Input.GetKeyDown("e"))
        {
            MoveWindow2();
        }
        if (standingWindow3 == true && Input.GetKeyDown("e"))
        {
            MoveWindow3();
        }

        // Show open door text
        if (standingDoor == true && GameManager.instance.examineMode == false && GameManager.instance.guestAtDoor == true)
        {
            txtDoor.gameObject.SetActive(true);
        }
        else
        {
            txtDoor.gameObject.SetActive(false);
        }

        // Show open window text
        if (standingWindow1 == true && window1Up == false)
        {
            txtWindowOpen.gameObject.SetActive(true);
        }
        else if (standingWindow2 == true && window2Up == false)
        {
            txtWindowOpen.gameObject.SetActive(true);
        }
        else if (standingWindow3 == true && window3Up == false)
        {
            txtWindowOpen.gameObject.SetActive(true);
        }
        else
        {
            txtWindowOpen.gameObject.SetActive(false);
        }

        // Show close window text
        if (standingWindow1 == true && window1Up == true)
        {
            txtWindowClose.gameObject.SetActive(true);
        }
        else if (standingWindow2 == true && window2Up == true)
        {
            txtWindowClose.gameObject.SetActive(true);
        }
        else if (standingWindow3 == true && window3Up == true)
        {
            txtWindowClose.gameObject.SetActive(true);
        }
        else
        {
            txtWindowClose.gameObject.SetActive(false);
        }
    }

    // Enter door and window colliders
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Door")
        {
            standingDoor = true;
            if (GameManager.instance.guestAtDoor == true)
            {
                door.GetComponent<Outline>().enabled = true;
            }
        }
        if (other.transform.tag == "Window 1")
        {
            standingWindow1 = true;
            window1.GetComponent<Outline>().enabled = true;
        }
        if (other.transform.tag == "Window 2")
        {
            standingWindow2 = true;
            window2.GetComponent<Outline>().enabled = true;
        }
        if (other.transform.tag == "Window 3")
        {
            standingWindow3 = true;
            window3.GetComponent<Outline>().enabled = true;
        }
    }

    // Exit door and window colliders
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Door")
        {
            standingDoor = false;
            door.GetComponent<Outline>().enabled = false;
        }
        if (other.transform.tag == "Window 1")
        {
            standingWindow1 = false;
            window1.GetComponent<Outline>().enabled = false;
        }
        if (other.transform.tag == "Window 2")
        {
            standingWindow2 = false;
            window2.GetComponent<Outline>().enabled = false;
        }
        if (other.transform.tag == "Window 3")
        {
            standingWindow3 = false;
            window3.GetComponent<Outline>().enabled = false;
        }
    }

    private void OpenDoor()
    {
        door.transform.Rotate(0, -270, 0);
    }

    private void MoveWindow1()
    {
        if (window1Up == false)
        {
            window1.transform.Translate(0, 1, 0);
            window1Up = true;
            GameManager.instance.mood.value -= 10;
            GameManager.instance.outbreak.value -= 10;
        }
        else
        {
            window1.transform.Translate(0, -1, 0);
            window1Up = false;
            GameManager.instance.mood.value += 10;
            GameManager.instance.outbreak.value += 10;
        }        
    }

    private void MoveWindow2()
    {
        if (window2Up == false)
        {
            window2.transform.Translate(0, 1, 0);
            window2Up = true;
            GameManager.instance.mood.value -= 10;
            GameManager.instance.outbreak.value -= 10;
        }
        else
        {
            window2.transform.Translate(0, -1, 0);
            window2Up = false;
            GameManager.instance.mood.value += 10;
            GameManager.instance.outbreak.value += 10;
        }
    }

    private void MoveWindow3()
    {
        if (window3Up == false)
        {
            window3.transform.Translate(0, 1, 0);
            window3Up = true;
            GameManager.instance.mood.value -= 10;
            GameManager.instance.outbreak.value -= 10;
        }
        else
        {
            window3.transform.Translate(0, -1, 0);
            window3Up = false;
            GameManager.instance.mood.value += 10;
            GameManager.instance.outbreak.value += 10;
        }

    }

}
