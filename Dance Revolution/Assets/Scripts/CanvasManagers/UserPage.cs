using ReadyPlayerMe.Core;
using TMPro;
using UnityEngine;

public class UserPage : MonoBehaviour
{
    public GameObject avatar;
    public TextMeshProUGUI userNameText;
    public TextMeshProUGUI followersText;
    public TextMeshProUGUI dancesText;
    public TextMeshProUGUI pointsText;
    public GameObject closeButton;
    public GameObject settingsButton;
    public GameObject challengeButton;
    public SongItem[] songItems;
    public UnityEngine.UI.Button ShowAllButton;
    private User user;
    private string[] avatarUrls;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Initialize(bool isMainUser, User usr)
    {

        if (!isMainUser)
        {
            closeButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener
            (() =>
            {
                CanvasManager.Instance.CloseUserPreviewPage();
            });
            challengeButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener
            (() =>
            {
                ChallengeClicked();
                GameManager.Instance.ChallengeStart();
            });
        }


        // if (isMainUser)
        // {
        //     closeButton.SetActive(false);
        //     settingsButton.SetActive(true);
        //     challengeButton.SetActive(false);
        // }
        // else
        // {
        //     closeButton.SetActive(true);
        //     settingsButton.SetActive(false);
        //     challengeButton.SetActive(true);
        // }

        Debug.Log("HomePage Initialize");
        Debug.Log($"User: {usr}");
        user = usr;
        userNameText.text = user.userName;
        followersText.text = user.followers.ToString();
        dancesText.text = user.dances.ToString();
        pointsText.text = user.points.ToString() + "k";

        songItems[0].Initialize(user.firstSong.songName, user.firstSong.artistName, 99);
        songItems[1].Initialize(user.secondSong.songName, user.secondSong.artistName, 99);
        songItems[2].Initialize(user.thirdSong.songName, user.thirdSong.artistName, 99);

        // Load User Avatar
        avatarUrls = new string[]
        {
                "https://models.readyplayer.me/638df5fc5a7d322604bb3a58.glb",
                "https://models.readyplayer.me/638df70ed72bffc6fa179596.glb",
                "https://models.readyplayer.me/638df75e5a7d322604bb3dcd.glb",
                "https://models.readyplayer.me/638df7d1d72bffc6fa179763.glb"
        };
        var avatarLoader = new AvatarObjectLoader();
        // use the OnCompleted event to set the avatar and setup animator
        avatarLoader.OnCompleted += (_, args) =>
        {
            avatar = args.Avatar;
            AvatarAnimationHelper.SetupAnimator(args.Metadata, args.Avatar);
        };
        int randomIndex = UnityEngine.Random.Range(1, 4);
        // avatarLoader.LoadAvatar(avatarUrls[randomIndex]);

        ShowAllButton.onClick.AddListener(() =>
        {
            CanvasManager.Instance.PopupManager.OpenShowAllSongsPopup(user);
        });

        gameObject.SetActive(true);
        
    }

    public void Close()
    {
        ShowAllButton.onClick.RemoveAllListeners();
    }

    public void ChallengeClicked()
    {
        PlayerPrefs.SetString("Player", userNameText.text);
        PlayerPrefs.SetString("firstSongName", user.firstSong.songName);
        PlayerPrefs.SetString("firstSongArtist", user.firstSong.artistName);
        PlayerPrefs.SetString("secondSongName", user.secondSong.songName);
        PlayerPrefs.SetString("secondSongArtist", user.secondSong.artistName);
        PlayerPrefs.SetString("thirdSongName", user.thirdSong.songName);
        PlayerPrefs.SetString("thirdSongArtist", user.thirdSong.artistName);
        PlayerPrefs.SetInt("firstSongScore", 99);
        PlayerPrefs.SetInt("secondSongScore", 99);
        PlayerPrefs.SetInt("thirdSongScore", 99);

        PlayerPrefs.Save();
    }
}
