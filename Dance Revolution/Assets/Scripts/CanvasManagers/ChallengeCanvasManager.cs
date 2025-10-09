using UnityEngine;
using UnityEngine.UI;

public class ChallengeCanvasManager : MonoBehaviour
{
    public Button ChallengeSongButton;
    public Button ChallengeSomeoneButton;
    public Button PlayWithFriendsButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChallengeSongButton.onClick.AddListener(ChallengeSong);
        ChallengeSomeoneButton.onClick.AddListener(ChallengeSomeone);
        PlayWithFriendsButton.onClick.AddListener(PlayWithFriends);
    }

    void ChallengeSong()
    {
        CanvasManager.Instance.ShowSongList();
    }

    void ChallengeSomeone()
    {
        // Show random picked PlayerHomeCanvas AND go next button
        GameManager.Instance.FindChallenger();
    }

    void PlayWithFriends()
    {
        PopupManager.Instance.ShowPlayWithFriendsPopup();
    }

}
