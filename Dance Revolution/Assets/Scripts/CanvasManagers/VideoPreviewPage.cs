using TMPro;
using UnityEngine;

public class VideoPreviewPage : MonoBehaviour
{
    [Header("Song UI Elements")]
    public TextMeshProUGUI songTitle;
    public TextMeshProUGUI artistTitle;
    public UnityEngine.UI.Image songImage;

    [Header("Song UI Elements")]
    public TextMeshProUGUI userName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Initialize(string songName, string artistName, UnityEngine.Sprite sprite) //, Sprite albumArt)
    {
        songTitle.text = songName;
        artistTitle.text = artistName;
        songImage.sprite = sprite;
        gameObject.SetActive(true);
        // songImage.sprite = albumArt;
    }
}
