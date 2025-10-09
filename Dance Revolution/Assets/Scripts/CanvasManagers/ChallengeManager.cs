using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallengeManager : MonoBehaviour
{

    private int numberOfSongs;
    private User challenger;
    private User player;
    private Song[] songs;

    [Header("UI Elements")]

    public CountdownUI CountdownUI;
    public GameObject UI;
    public ChallengeSongItem SongItem;
    private User[] others; // Challenger, Friends, Event Participants

    public event Action OnCountdownComplete;

    void Start()
    {
        OnCountdownComplete += CountdownComplete;

        CountdownUI.StartCountdown(OnCountdownComplete);

    }
    void CountdownComplete()
    {
        UI.SetActive(true);
    }

    void OnEnable()
    {
        // Challenge a Song (1 song)

        // Challenge a Person (3 songs)

        // Challenge a Song with Multiple Friends (1 song)

        // Challenge a Event (20 songs)

        string challengeType = PlayerPrefs.GetString("ChallengeType");

        string json = PlayerPrefs.GetString("Player");
        player = JsonUtility.FromJson<User>(json);

        json = PlayerPrefs.GetString("Songs");
        songs = JsonUtility.FromJson<Song[]>(json);

        json = PlayerPrefs.GetString("Other Players");
        others = JsonUtility.FromJson<User[]>(json);

        switch (challengeType)
        {
            case "Song":
                numberOfSongs = 1;

                break;
            case "Person":
                // 1 Challenger
                numberOfSongs = 3;
                break;
            case "Group":
                // Multiple Friends
                numberOfSongs = 1;
                break;
            case "Event":
                // Multiple Ppl
                numberOfSongs = 20;
                break;
            default:
                numberOfSongs = 3;
                break;
        }

    }

    public void ChallengeFinished()
    {
        SceneManager.LoadScene("MainScene");
    }
}
