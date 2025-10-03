using System;
using UnityEngine;

public class PopupManager : MonoBehaviour
{


    [Header("Preview Pages")]
    public SongPreviewPage SongPreviewPage;
    public VideoPreviewPage VideoPreviewPage;
    public EventPreviewPopup EventPreviewPopup;
    // public static PopupManager Instance { get; internal set; }

    internal void CloseAllPopups()
    {
        SongPreviewPage.gameObject.SetActive(false);
        VideoPreviewPage.gameObject.SetActive(false);
    }

    internal void OpenEventDetailPopup(EventItem evnt)
    {
        EventPreviewPopup.Initialize(evnt);
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
