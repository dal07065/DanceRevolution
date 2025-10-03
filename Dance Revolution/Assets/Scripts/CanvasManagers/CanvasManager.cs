using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    private Song[] songs;
    private User[] users;
    private Event[] events;
    public GameObject MainCamera;

    public PopupManager PopupManager;

    [Header("Main Canvas")]
    public GameObject UserAvatarEnvironment;
    public GameObject PlayerAvatarEnvironment;
    public GameObject HomeCanvas;
    public GameObject FeedCanvas;
    public GameObject EventCanvas;
    public GameObject RankingCanvas;

    public Button HomeButton;
    public Button FeedButton;
    public Button EventButton;
    public Button RankingButton;

    private Button currentButton;
    private GameObject currentCanvas;

    [Header("Home Canvas")]
    public UserPage UserPage;

    [Header("Player Canvas")]
    public GameObject PlayerHomeCanvas;
    public UserPage PlayerPage;
    public static CanvasManager Instance { get; internal set; }

    private void Awake()
    {
        // Scene-local singleton: if another instance exists in this scene, destroy this one.
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        // DO NOT call DontDestroyOnLoad — keep this instance tied to the scene so
        // inspector-assigned references are valid for that scene only.
    }

    private void OnDestroy()
    {
        // Clear static reference when the scene instance is destroyed
        if (Instance == this)
            Instance = null;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize dummy data
        songs = new Song[]
        {
            new Song("Haru Haru", "Big Bang", 9.8f),
            new Song("Levitate", "Dua Lipa", 6.5f),
            new Song("Blinding Lights", "The Weeknd", 5.3f),
            new Song("Here With Me", "d4vd", 4.1f),
            new Song("Golden", "HUNTRX", 1.6f)
        };

        users = new User[]{

            new User("Uzutrap1023", 143, 425, 3.2f, songs[2], songs[4], songs[1]),
            new User("DancingQueen", 98, 210, 5.3f,songs[0], songs[1], songs[3]),
            new User("RhythmMaster", 120, 330, 9.1f, songs[1], songs[3], songs[0]),
            new User("BeatBlaster", 75, 150, 1.4f, songs[4], songs[2], songs[3]),
            new User("GrooveGuru", 200, 600, 8.4f, songs[3], songs[0], songs[4]),
            new User("SpinDoctor", 50, 100, 2.7f, songs[1], songs[4], songs[2]),
            new User("FunkyFeet", 180, 450, 6.9f, songs[0], songs[2], songs[3]),
            new User("DanceDynamo", 130, 300, 4.8f, songs[3], songs[1], songs[0]),
            new User("StepSensation", 90, 220, 7.5f, songs[2], songs[0], songs[4])

        };

        events = new Event[]{
            new Event("Jazz Dance Gala", "August 18th", "17:00 PST", "Grand Theater", "Live", "3 Grand Prizes for Top 3 Winners and 10 Consolation Prizes!"),
            new Event("Hip Hop Battle", "September 5th", "19:00 PST", "City Arena", "Open", "3 Grand Prizes for Top 3 Winners and 10 Consolation Prizes!"),
            new Event("Ballet Showcase", "July 30th", "15:00 PST", "Opera House", "Closed", "3 Grand Prizes for Top 3 Winners and 10 Consolation Prizes!"),
            new Event("Salsa Night", "August 25th", "20:00 PST", "Downtown Club", "Open",  "3 Grand Prizes for Top 3 Winners and 10 Consolation Prizes!"),
            new Event("Contemporary Dance Fest", "September 10th", "18:00 PST", "Art Center", "Live",  "3 Grand Prizes for Top 3 Winners and 10 Consolation Prizes!"),
            new Event("Tap Dance Extravaganza", "July 22nd", "16:00 PST", "Main Square", "Closed",  "3 Grand Prizes for Top 3 Winners and 10 Consolation Prizes!")
            
        };

        RankingCanvas.GetComponent<RankingCanvasManager>().Initialize(songs, users);
        EventCanvas.GetComponent<EventCanvasManager>().Initialize(events);

        // Reset to Home Canvas
        currentCanvas = HomeCanvas;
        currentButton = HomeButton;

        SetCurrentButton(HomeButton);

        FeedCanvas.SetActive(false);
        EventCanvas.SetActive(false);
        RankingCanvas.SetActive(false);

        HomeButton.onClick.AddListener(() => SetCurrentButton(HomeButton));
        FeedButton.onClick.AddListener(() => SetCurrentButton(FeedButton));
        EventButton.onClick.AddListener(() => SetCurrentButton(EventButton));
        RankingButton.onClick.AddListener(() => SetCurrentButton(RankingButton));
    }

    public void SetCurrentButton(Button button)
    {
        // if Popup is open, close all popups (including User Detail Preview)
        PopupManager.CloseAllPopups();
        CloseUserPreviewPage();

        // Deactivate current canvas and change button color to inactive
        if (currentCanvas && currentButton)
        {
            currentCanvas.SetActive(false);
            currentButton.GetComponentInChildren<UnityEngine.UI.Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        }

        // Switch button to current and change button color to active
        currentButton = button;
        currentButton.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.white;

        // Activate new corresponding canvas
        if (button == HomeButton)
        {
            currentCanvas = HomeCanvas;
            OpenUserPreviewPage(true, users[0]);
        }
        else
        {
            if (button == RankingButton)
                currentCanvas = RankingCanvas;
            else if (button == EventButton)
                currentCanvas = EventCanvas;
            else if (button == FeedButton)
                currentCanvas = FeedCanvas;
            else
                Debug.LogError("CanvasManager: Unknown button clicked");

        }
        currentCanvas.SetActive(true);
    }

    public void OpenUserPreviewPage(bool isMainUser, User user)
    {
        if (isMainUser)
        {
            MainCamera.transform.position = new Vector3(4, 2.95f, -4.14f);

            HomeCanvas.SetActive(true);
            UserAvatarEnvironment.SetActive(true);
            UserPage.Initialize(isMainUser, user);
        }
        else
        {
            MainCamera.transform.position = new Vector3(7.51f, 2.95f, -4.14f);

            currentCanvas.SetActive(false);
            PlayerHomeCanvas.SetActive(true);
            PlayerAvatarEnvironment.SetActive(true);
            PlayerPage.Initialize(isMainUser, user);
        }

    }
    public void CloseUserPreviewPage()
    {
        currentCanvas.SetActive(true);
        PlayerHomeCanvas.SetActive(false);
        PlayerAvatarEnvironment.SetActive(false);
    }

    public User[] GetUsers()
    {
        return users;
    }

    public Song[] GetSongs()
    {
        return songs;
    }

}
