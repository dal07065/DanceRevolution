using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallengeManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI userNameText;

    public SongItem firstSongItem;
    public SongItem secondSongItem;
    public SongItem thirdSongItem;
    private string userName;

    void Start()
    {
        userName = "Uzutrap1020";
    }

    void OnEnable()
    {
        string name = PlayerPrefs.GetString("Player", "Guest");
        Debug.Log($"Loaded player: {name}");
        userNameText.text = name;

        firstSongItem.Initialize(
            PlayerPrefs.GetString("firstSongName", "Default Song 1"),
            PlayerPrefs.GetString("firstSongArtist", "Unknown Artist 1"),
            PlayerPrefs.GetInt("firstSongScore", 0)
        );
        secondSongItem.Initialize(
            PlayerPrefs.GetString("secondSongName", "Default Song 2"),
            PlayerPrefs.GetString("secondSongArtist", "Unknown Artist 2"),
            PlayerPrefs.GetInt("secondSongScore", 0)
        );
        thirdSongItem.Initialize(
            PlayerPrefs.GetString("thirdSongName", "Default Song 3"),
            PlayerPrefs.GetString("thirdSongArtist", "Unknown Artist 3"),
            PlayerPrefs.GetInt("thirdSongScore", 0)
        );
    }

    public void ChallengeFinished()
    {
        SceneManager.LoadScene("MainScene");
    }
}
