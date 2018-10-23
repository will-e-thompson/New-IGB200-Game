using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

    // Variables to control player and door
    public GameObject player;
    public GameObject door;
   
    // Variable to check Game Manager variables
    public GameManager manager;

    // Variable to get guest script
    public GameObject guest;

    public Text rashWrong;
    public Text rashRight;
    public Text noseWrong;
    public Text noseRight;
    public Text coughWrong;
    public Text coughRight;
    public Text eyesWrong;
    public Text eyesRight;

    public GameObject insideGuest1;
    public GameObject insideGuest2;
    public GameObject insideGuest3;
    public GameObject insideGuest4;
    public GameObject insideGuest5;
    public GameObject insideGuest6;
    public GameObject insideGuest7;
    public GameObject insideGuest8;
    public GameObject insideGuest9;
    public GameObject insideGuest10;

    public Button btnContinue;

    public int guestsLetIn = 0;

    // Use this for initialization
    void Start() {
        manager = GameManager.instance;
        btnContinue.gameObject.SetActive(false);

        rashWrong.gameObject.SetActive(false);
        rashRight.gameObject.SetActive(false);
        noseWrong.gameObject.SetActive(false);
        noseRight.gameObject.SetActive(false);
        coughWrong.gameObject.SetActive(false);
        coughRight.gameObject.SetActive(false);
        eyesWrong.gameObject.SetActive(false);
        eyesRight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        guest = GameObject.FindGameObjectWithTag("Guest");        
    }

    // Add to score if choices were correct
    public void acceptClicked()
    {
        manager.mood.value += 10;
        guestsLetIn += 1;

        if (guest.GetComponent<Guest>().numSymptoms == 1)
        {
            manager.outbreak.value += 10;
        }
        if (guest.GetComponent<Guest>().numSymptoms == 2)
        {
            manager.outbreak.value += 20;
        }
        if (guest.GetComponent<Guest>().numSymptoms == 3)
        {
            manager.outbreak.value += 30;
        }
        if (guest.GetComponent<Guest>().numSymptoms == 4)
        {
            manager.outbreak.value += 40;
        }

        if (guest.GetComponent<Guest>().rash == true && manager.tglRash.isOn == true)
        {
            manager.score += 1;
            rashRight.gameObject.SetActive(true);
        }
        else if (guest.GetComponent<Guest>().rash == true && manager.tglRash.isOn == false)
        {
            manager.score -= 1;
            rashWrong.gameObject.SetActive(true);
        }
        else if (guest.GetComponent<Guest>().rash == false && manager.tglRash.isOn == true)
        {
            manager.score -= 1;
            rashWrong.gameObject.SetActive(true);
        }

        if (guest.GetComponent<Guest>().redEyes == true && manager.tglRedEyes.isOn == true)
        {
            manager.score += 1;
            eyesRight.gameObject.SetActive(true);
        }
        else if (guest.GetComponent<Guest>().redEyes == true && manager.tglRedEyes.isOn == false)
        {
            manager.score -= 1;
            eyesWrong.gameObject.SetActive(true);
        }
        else if (guest.GetComponent<Guest>().redEyes == false && manager.tglRedEyes.isOn == true)
        {
            manager.score -= 1;
            eyesWrong.gameObject.SetActive(true);
        }


        if (guest.GetComponent<Guest>().cough == true && manager.tglCough.isOn == true)
        {
            manager.score += 1;
            coughRight.gameObject.SetActive(true);
        }
        else if (guest.GetComponent<Guest>().cough == true && manager.tglCough.isOn == false)
        {
            manager.score -= 1;
            coughWrong.gameObject.SetActive(true);
        }
        else if (guest.GetComponent<Guest>().cough == false && manager.tglCough.isOn == true)
        {
            manager.score -= 1;
            coughWrong.gameObject.SetActive(true);
        }
        
        if (guest.GetComponent<Guest>().runnyNose == true && manager.tglRunnyNose.isOn == true)
        {
             manager.score += 1;
             noseRight.gameObject.SetActive(true);
        }
        else if (guest.GetComponent<Guest>().runnyNose == true && manager.tglRunnyNose.isOn == false)
        {
            manager.score -= 1;
            noseWrong.gameObject.SetActive(true);
        }
        else if (guest.GetComponent<Guest>().runnyNose == false && manager.tglRunnyNose.isOn == true)
        {
            manager.score -= 1;
            noseWrong.gameObject.SetActive(true);
        }

        if (guest.GetComponent<Guest>().food == true)
        {            
            manager.mood.value += 10;
        }

        if (guest.GetComponent<Guest>().present == true)
        {
            manager.score += 1;
        }

        if (guestsLetIn == 1)
        {
            insideGuest1.SetActive(true);
        }
        if (guestsLetIn == 2)
        {
            insideGuest2.SetActive(true);
        }
        if (guestsLetIn == 3)
        {
            insideGuest3.SetActive(true);
        }
        if (guestsLetIn == 4)
        {
            insideGuest4.SetActive(true);
        }
        if (guestsLetIn == 5)
        {
            insideGuest5.SetActive(true);
        }
        if (guestsLetIn == 6)
        {
            insideGuest6.SetActive(true);
        }
        if (guestsLetIn == 7)
        {
            insideGuest7.SetActive(true);
        }
        if (guestsLetIn == 8)
        {
            insideGuest8.SetActive(true);
        }
        if (guestsLetIn == 9)
        {
            insideGuest9.SetActive(true);
        }
        if (guestsLetIn == 10)
        {
            insideGuest10.SetActive(true);
        }

        manager.examineOver = true;
        btnContinue.gameObject.SetActive(true);     
    }

    // Add to score if choices were correct
    public void rejectClicked()
    {
        manager.mood.value -= 10;

        if (guest.GetComponent<Guest>().rash == true && manager.tglRash.isOn == true)
        {
            manager.score += 1;
        }
        if (guest.GetComponent<Guest>().redEyes == true && manager.tglRedEyes.isOn == true)
        {
            manager.score += 1;
        }
        if (guest.GetComponent<Guest>().cough == true == true && manager.tglCough.isOn == true)
        {
            manager.score += 1;
        }
        if (guest.GetComponent<Guest>().runnyNose == true && manager.tglRunnyNose.isOn == true)
        {
            manager.score += 1;
        }

        if (guest.GetComponent<Guest>().rash == true && manager.tglRash.isOn == true)
        {
            manager.score += 1;
            rashRight.gameObject.SetActive(true);
        }
        else if (guest.GetComponent<Guest>().rash == true && manager.tglRash.isOn == false)
        {
            manager.score -= 1;
            rashWrong.gameObject.SetActive(true);
        }
        else if (guest.GetComponent<Guest>().rash == false && manager.tglRash.isOn == true)
        {
            manager.score -= 1;
            rashWrong.gameObject.SetActive(true);
        }

        if (guest.GetComponent<Guest>().redEyes == true && manager.tglRedEyes.isOn == true)
        {
            manager.score += 1;
            eyesRight.gameObject.SetActive(true);
        }
        else if (guest.GetComponent<Guest>().redEyes == true && manager.tglRedEyes.isOn == false)
        {
            manager.score -= 1;
            eyesWrong.gameObject.SetActive(true);
        }
        else if (guest.GetComponent<Guest>().redEyes == false && manager.tglRedEyes.isOn == true)
        {
            manager.score -= 1;
            eyesWrong.gameObject.SetActive(true);
        }


        if (guest.GetComponent<Guest>().cough == true && manager.tglCough.isOn == true)
        {
            manager.score += 1;
            coughRight.gameObject.SetActive(true);
        }
        else if (guest.GetComponent<Guest>().cough == true && manager.tglCough.isOn == false)
        {
            manager.score -= 1;
            coughWrong.gameObject.SetActive(true);
        }
        else if (guest.GetComponent<Guest>().cough == false && manager.tglCough.isOn == true)
        {
            manager.score -= 1;
            coughWrong.gameObject.SetActive(true);
        }

        if (guest.GetComponent<Guest>().runnyNose == true && manager.tglRunnyNose.isOn == true)
        {
            manager.score += 1;
            noseRight.gameObject.SetActive(true);
        }
        else if (guest.GetComponent<Guest>().runnyNose == true && manager.tglRunnyNose.isOn == false)
        {
            manager.score -= 1;
            noseWrong.gameObject.SetActive(true);
        }
        else if (guest.GetComponent<Guest>().runnyNose == false && manager.tglRunnyNose.isOn == true)
        {
            manager.score -= 1;
            noseWrong.gameObject.SetActive(true);
        }

        manager.examineOver = true;
        btnContinue.gameObject.SetActive(true);      
    }

    private void CloseDoor()
    {
        door.transform.Rotate(0, 270, 0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        // Move player back
        player.transform.Translate(0, 0, -1);
        CloseDoor();

        // Exit examine mode and go to next guest
        manager.examineMode = false;

        Destroy(guest);

        manager.guestAtDoor = false;

        manager.examineOver = false;
        btnContinue.gameObject.SetActive(false);

        rashWrong.gameObject.SetActive(false);
        rashRight.gameObject.SetActive(false);
        noseWrong.gameObject.SetActive(false);
        noseRight.gameObject.SetActive(false);
        coughWrong.gameObject.SetActive(false);
        coughRight.gameObject.SetActive(false);
        eyesWrong.gameObject.SetActive(false);
        eyesRight.gameObject.SetActive(false);
    }
}
