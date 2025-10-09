using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [Header("Main Canvas")]
    public GameObject UserAvatarEnvironment;
    public GameObject PlayerAvatarEnvironment;
    public GameObject HomeCanvas;
    public GameObject ChallengeCanvas;
    public GameObject EventCanvas;
    public GameObject RankingCanvas;

    public Button HomeButton;
    public Button ChallengeButton;
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
        RankingCanvas.GetComponent<RankingCanvasManager>().Initialize(GameManager.Instance.songs, GameManager.Instance.users);
        EventCanvas.GetComponent<EventCanvasManager>().Initialize(GameManager.Instance.events);

        // Reset to Home Canvas
        currentCanvas = HomeCanvas;
        currentButton = HomeButton;

        SetCurrentButton(HomeButton);

        ChallengeCanvas.SetActive(false);
        EventCanvas.SetActive(false);
        RankingCanvas.SetActive(false);

        HomeButton.onClick.AddListener(() => SetCurrentButton(HomeButton));
        ChallengeButton.onClick.AddListener(() => SetCurrentButton(ChallengeButton));
        EventButton.onClick.AddListener(() => SetCurrentButton(EventButton));
        RankingButton.onClick.AddListener(() => SetCurrentButton(RankingButton));
    }

    public void SetCurrentButton(Button button)
    {
        // if Popup is open, close all popups (including User Detail Preview)
        PopupManager.Instance.CloseAllPopups();
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
            OpenUserPreviewPage(true, GameManager.Instance.users[0]);
        }
        else
        {
            if (button == RankingButton)
                currentCanvas = RankingCanvas;
            else if (button == EventButton)
                currentCanvas = EventCanvas;
            else if (button == ChallengeButton)
                currentCanvas = ChallengeCanvas;
            else
                Debug.LogError("CanvasManager: Unknown button clicked");

        }
        currentCanvas.SetActive(true);
    }

    public void OpenUserPreviewPage(bool isMainUser, User user)
    {
        if (isMainUser)
        {
            GameManager.Instance.MainCamera.transform.position = new Vector3(4.13f, 2.42f, -3.63f);

            HomeCanvas.SetActive(true);
            UserAvatarEnvironment.SetActive(true);
            UserPage.Initialize(isMainUser, user);
        }
        else
        {
            GameManager.Instance.MainCamera.transform.position = new Vector3(7.66f, 2.42f, -3.63f);
            UserAvatarEnvironment.SetActive(false);
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
        PlayerPage.Close();
    }

    public void ShowSongList()
    {
        PopupManager.Instance.SongListPopup.SetActive(true);
        //PopupManager.SongListPopup.GetComponent<SongListPopup>().Initialize(songs);
    }



    internal void ShowLoadingScreen(bool show)
    {
        PopupManager.Instance.ShowLoadingScreen(show);
    }
}
