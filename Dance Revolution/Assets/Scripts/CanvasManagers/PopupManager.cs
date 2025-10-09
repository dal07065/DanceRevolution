using System;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance;

    [Header("Preview Pages")]
    public SongPreviewPage SongPreviewPage;
    public VideoPreviewPage VideoPreviewPage;
    public EventPreviewPopup EventPreviewPopup;
    public ShowAllSongsPopup ShowAllSongsPopup;

    public GameObject SongListPopup;

    public GameObject PlayWithFriends;

    [Header("Preview Pages")]
    public GameObject BackgroundOverlay;

    public GameObject LoadingScreen;

    // public static PopupManager Instance { get; internal set; }
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
    public void CloseAllPopups()
    {
        ToggleBackgroundOverlay(false);
        SongPreviewPage.gameObject.SetActive(false);
        VideoPreviewPage.gameObject.SetActive(false);
        EventPreviewPopup.gameObject.SetActive(false);
        ShowAllSongsPopup.gameObject.SetActive(false);
        PlayWithFriends.gameObject.SetActive(false);
        SongListPopup.SetActive(false);
    }

    internal void OpenEventDetailPopup(EventItem evnt)
    {
        ToggleBackgroundOverlay(true);
        EventPreviewPopup.Initialize(evnt);
    }
    internal void OpenShowAllSongsPopup(User user)
    {
        ToggleBackgroundOverlay(true);
        ShowAllSongsPopup.Initialize(user);
        ShowAllSongsPopup.gameObject.SetActive(true);
    }

    public void ToggleBackgroundOverlay(bool toggle)
    {
        BackgroundOverlay.SetActive(toggle);
    }

    internal void ShowLoadingScreen(bool show)
    {
        ToggleBackgroundOverlay(show);
        LoadingScreen.SetActive(show);
    }

    internal void ShowPlayWithFriendsPopup()
    {
        ToggleBackgroundOverlay(true);
        PlayWithFriends.SetActive(true);
    }

    // void Start()
    // {
    //     if (Instance != null && Instance != this)
    //     {
    //         Destroy(this.gameObject);
    //         return;
    //     }
    //     Instance = this;
    //     DontDestroyOnLoad(this.gameObject);
    // }




}
