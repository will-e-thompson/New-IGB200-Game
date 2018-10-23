using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public GameObject doorCamera;
    public GameObject gameOverCamera;
    public float partyTimer = 300.0f;
    public float doorTimer = 10.0f;
    public Text partyTimerText;
    public Text winText;
    public Text loseText;
    public Text moodText;
    public Text outbreakText;
    public Text win2Text;
    public Button btnRestart;
    public Button btnExit;
    public Button btnContinue;
    public bool gameOver = false;
    public bool guestAtDoor = false;

    public Text rashWrong;
    public Text rashRight;
    public Text noseWrong;
    public Text noseRight;
    public Text coughWrong;
    public Text coughRight;
    public Text eyesWrong;
    public Text eyesRight;

    // Variables to control UI elements
    public GameObject btnAccept;
    public GameObject btnReject;
    public Text txtScore;
    public Slider outbreak;
    public Slider mood;

    // Variable to enter and exit examine mode
    public bool examineMode = false;
    public bool examineOver = false;

    // Variable to track score
    public int score = 0;

    // Variable to track guest number
    public int round = 1;
    
    // Variables to control choice toggles
    public Toggle tglRash;
    public Toggle tglCough;
    public Toggle tglRedEyes;
    public Toggle tglRunnyNose;

    public GameObject spawner;
    public GameObject guest1;
    public GameObject guest2;
    public GameObject guest3;
    public GameObject guest4;
    public GameObject guest5;
    public GameObject guest6;
    public GameObject guest7;
    public GameObject guest8;
    public GameObject guest9;
    public GameObject guest10;

    //Singleton Setup
    public static GameManager instance = null;

    // Awake Checks - Singleton setup
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }            

        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
    }

        // Use this for initialization
    void Start () {
        // Make UI elements invisible
        tglRash.gameObject.SetActive(false);
        tglCough.gameObject.SetActive(false);
        tglRedEyes.gameObject.SetActive(false);
        tglRunnyNose.gameObject.SetActive(false);
        btnAccept.SetActive(false);
        btnReject.SetActive(false);
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
        moodText.gameObject.SetActive(false);
        outbreakText.gameObject.SetActive(false);
        win2Text.gameObject.SetActive(false);
        btnRestart.gameObject.SetActive(false);
        btnExit.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if (examineMode == true)
        {
            EnterExamine();
        }
        else if (examineMode == false)
        {
            ExitExamine();
        }

        // Update score text box
        txtScore.text = "Score: " + score;

        if (gameOver == false && examineMode == false)
        {
            partyTimer -= Time.deltaTime;
        }

        if (examineOver == true)
        {
            btnAccept.gameObject.SetActive(false);
            btnReject.gameObject.SetActive(false);
        }
        

        partyTimerText.text = "Time: " + partyTimer.ToString("F0");

        EndGame();

        if (examineMode == false && guestAtDoor == false)
        {
            doorTimer -= Time.deltaTime;
        }

        if (doorTimer <= 0)
        {
            round += 1;
            doorTimer = 10.0f;
        }

        SpawnGuests();
    }  

    public void SpawnGuests()
    {
        // Make different shapes invisible depending on round
        if (round == 1 && guestAtDoor == false)
        {
            spawner.GetComponent<GuestSpawner>().SpawnGuest(guest1);
            guestAtDoor = true;
        }
        if (round == 2 && guestAtDoor == false)
        {
            spawner.GetComponent<GuestSpawner>().SpawnGuest(guest2);
            guestAtDoor = true;
        }
        if (round == 3 && guestAtDoor == false)
        {
            spawner.GetComponent<GuestSpawner>().SpawnGuest(guest3);
            guestAtDoor = true;
        }
        if (round == 4 && guestAtDoor == false)
        {
            spawner.GetComponent<GuestSpawner>().SpawnGuest(guest4);
            guestAtDoor = true;
        }
        if (round == 5)
        {
            spawner.GetComponent<GuestSpawner>().SpawnGuest(guest5);
            guestAtDoor = true;
        }
        if (round == 6)
        {
            spawner.GetComponent<GuestSpawner>().SpawnGuest(guest6);
            guestAtDoor = true;
        }
        if (round == 7)
        {
            spawner.GetComponent<GuestSpawner>().SpawnGuest(guest7);
            guestAtDoor = true;
        }
        if (round == 8)
        {
            spawner.GetComponent<GuestSpawner>().SpawnGuest(guest8);
            guestAtDoor = true;
        }
        if (round == 9)
        {
            spawner.GetComponent<GuestSpawner>().SpawnGuest(guest9);
            guestAtDoor = true;
        }
        if (round == 10)
        {
            spawner.GetComponent<GuestSpawner>().SpawnGuest(guest10);
            guestAtDoor = true;
        }
    }

    public void EnterExamine()
    {
        // Enable cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Remove player controls
        player.SetActive(false);

        // Set camera to door camera
        doorCamera.SetActive(true);

        // Make UI elements visible
        tglRash.gameObject.SetActive(true);
        tglCough.gameObject.SetActive(true);
        tglRedEyes.gameObject.SetActive(true);
        tglRunnyNose.gameObject.SetActive(true);
        btnAccept.SetActive(true);
        btnReject.SetActive(true);

        
    }

    public void ExitExamine()
    {
        // Enable player controls
        player.SetActive(true);

        // Disable door camera
        doorCamera.SetActive(false);

        // Make UI elements invisible
        tglRash.gameObject.SetActive(false);
        tglCough.gameObject.SetActive(false);
        tglRedEyes.gameObject.SetActive(false);
        tglRunnyNose.gameObject.SetActive(false);
        btnAccept.SetActive(false);
        btnReject.SetActive(false);

        // Set all toggles back to unchecked
        tglRash.isOn = false;
        tglCough.isOn = false;
        tglRedEyes.isOn = false;
        tglRunnyNose.isOn = false;
    }    

    public void EndGame()
    {
        if(outbreak.value >= 100)
        {
            gameOver = true;
            player.SetActive(false);
            gameOverCamera.SetActive(true);
            loseText.gameObject.SetActive(true);
            outbreakText.gameObject.SetActive(true);
            btnRestart.gameObject.SetActive(true);
            btnExit.gameObject.SetActive(true);
            tglRash.gameObject.SetActive(false);
            tglCough.gameObject.SetActive(false);
            tglRedEyes.gameObject.SetActive(false);
            tglRunnyNose.gameObject.SetActive(false);
            btnContinue.gameObject.SetActive(false);
            rashWrong.gameObject.SetActive(false);
            rashRight.gameObject.SetActive(false);
            noseWrong.gameObject.SetActive(false);
            noseRight.gameObject.SetActive(false);
            coughWrong.gameObject.SetActive(false);
            coughRight.gameObject.SetActive(false);
            eyesWrong.gameObject.SetActive(false);
            eyesRight.gameObject.SetActive(false);

            // Enable cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (mood.value <= 0)
        {
            gameOver = true;
            player.SetActive(false);
            gameOverCamera.SetActive(true);
            loseText.gameObject.SetActive(true);
            moodText.gameObject.SetActive(true);
            btnRestart.gameObject.SetActive(true);
            btnExit.gameObject.SetActive(true);
            rashWrong.gameObject.SetActive(false);
            rashRight.gameObject.SetActive(false);
            noseWrong.gameObject.SetActive(false);
            noseRight.gameObject.SetActive(false);
            coughWrong.gameObject.SetActive(false);
            coughRight.gameObject.SetActive(false);
            eyesWrong.gameObject.SetActive(false);
            eyesRight.gameObject.SetActive(false);

            // Enable cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (partyTimer <= 0)
        {
            gameOver = true;
            player.SetActive(false);
            gameOverCamera.SetActive(true);
            winText.gameObject.SetActive(true);
            win2Text.gameObject.SetActive(true);
            btnRestart.gameObject.SetActive(true);
            btnExit.gameObject.SetActive(true);

            // Enable cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
