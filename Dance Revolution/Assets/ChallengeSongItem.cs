using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeSongItem : MonoBehaviour
{
    public TextMeshProUGUI songNameText;
    public TextMeshProUGUI artistNameText;
    public TextMeshProUGUI currentTime;
    public TextMeshProUGUI totalTime;

    public Image albumImage;

    public int trackNumber;

    public void Initialize(string songName, string artistName, string time, Sprite img, int trackNumber)
    {
        songNameText.text = songName;
        artistNameText.text = artistName;
        totalTime.text = time.ToString();
        albumImage.sprite = img;
        this.trackNumber = trackNumber;

        string jsonvalue = PlayerPrefs.GetString("User");

        // Parsing User JSON value

        // Debug.Log(jsonvalue);

        // User user = JsonUtility.FromJson<User>(jsonvalue);
    }

}
