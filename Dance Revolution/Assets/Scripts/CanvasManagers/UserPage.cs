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
        if (avatar)
        {
            Destroy(avatar);
            avatar = null;
        }

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

        ShowAllButton.onClick.AddListener(() =>
        {
            CanvasManager.Instance.PopupManager.OpenShowAllSongsPopup(user);
        });
        // Load User Avatar





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

            var avatarLoader = new AvatarObjectLoader();
            // use the OnCompleted event to set the avatar and setup animator
            avatarLoader.OnCompleted += (_, args) =>
            {
                avatar = args.Avatar;
                //AvatarAnimationHelper.SetupAnimator(args.Metadata, args.Avatar);
                avatar.transform.SetPositionAndRotation(new Vector3(7.65f, 0.13f, 1.5f), Quaternion.Euler(0, 180, 0));
                avatar.GetComponent<Animator>().runtimeAnimatorController = GameManager.Instance.avatarAnimator;
                avatar.transform.SetParent(GameManager.Instance.PlayerAvatarEnvironment.transform);
                CanvasManager.Instance.ShowLoadingScreen(false);
            };
            avatarLoader.LoadAvatar(user.avatarURL);
        }

        gameObject.SetActive(true);
        
    }

    public void Close()
    {
        ShowAllButton.onClick.RemoveAllListeners();
        closeButton.GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
        challengeButton.GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
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
