using System;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{


    [Header("Preview Pages")]
    public SongPreviewPage SongPreviewPage;
    public VideoPreviewPage VideoPreviewPage;
    public EventPreviewPopup EventPreviewPopup;
    public ShowAllSongsPopup ShowAllSongsPopup;

    [Header("Preview Pages")]
    public GameObject BackgroundOverlay;
    // public static PopupManager Instance { get; internal set; }

    public void CloseAllPopups()
    {
        ToggleBackgroundOverlay(false);
        SongPreviewPage.gameObject.SetActive(false);
        VideoPreviewPage.gameObject.SetActive(false);
        EventPreviewPopup.gameObject.SetActive(false);
        ShowAllSongsPopup.gameObject.SetActive(false);
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
