using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SongItem : MonoBehaviour
{
    public TextMeshProUGUI songTitle;
    public TextMeshProUGUI artistTitle;
    public TextMeshProUGUI score;
    public Image songImage;
    public Button button;

    public string songName;
    public string artistName;
    // private string albumName;

    void OnEnable()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    public void Initialize(string song, string artist, int scoreInt = 0) //, string albumName)
    {
        Debug.Log($"Initializing SongItem: {song} by {artist} with score {scoreInt}");
        songName = song;
        artistName = artist;

        songTitle.text = song;
        artistTitle.text = artist;
        score.text = scoreInt.ToString();// Default score, can be updated later
    }

    private void OnButtonClick()
    {
        Debug.Log($"Selected song: {songName} by {artistName}");
        CanvasManager.Instance.PopupManager.SongPreviewPage.Initialize(songName, artistName, songImage.sprite);
    }

}
