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
    private User user;
    private string[] avatarUrls;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Initialize(bool isMainUser, User usr)
    {
        
        if (!isMainUser)
        closeButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener
        (() =>
        {
            CanvasManager.Instance.CloseUserPreviewPage();
        });

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
        user = usr;
        userNameText.text = user.userName;
        followersText.text = user.followers.ToString();
        dancesText.text = user.dances.ToString();
        pointsText.text = user.points.ToString() + "k";
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
        avatarLoader.LoadAvatar(avatarUrls[randomIndex]);

        gameObject.SetActive(true);
    }

    public void ChallengeClicked()
    {
        PlayerPrefs.SetString("Player", userNameText.text);
        PlayerPrefs.SetString("firstSongName", "Titatnium");
        PlayerPrefs.SetString("firstSongArtist", "Katy Perry");
        PlayerPrefs.SetString("secondSongName", "Levitating");
        PlayerPrefs.SetString("secondSongArtist", "Dua Lipa");
        PlayerPrefs.SetString("thirdSongName", "Blinding");
        PlayerPrefs.SetString("thirdSongArtist", "The Weeknd");
        PlayerPrefs.SetInt("firstSongScore", 97);
        PlayerPrefs.SetInt("secondSongScore", 87);
        PlayerPrefs.SetInt("thirdSongScore", 92);

        PlayerPrefs.Save();
    }
}
