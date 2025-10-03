using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RankingCanvasManager : MonoBehaviour
{
    [Header("Ranking Canvas")]

    public Toggle SongTabToggle;
    public Toggle DancersTabToggle;

    public GameObject SongsTab;
    public GameObject DancersTab;

    public GameObject MainSongItem;
    public GameObject MainDancerItem1;
    public GameObject MainDancerItem2;
    public GameObject MainDancerItem3;
    private GameObject[] SongItems;
    private GameObject[] DancerItems;

    public GameObject SongItemPrefab;
    public GameObject UserItemPrefab;
    public Transform SongItemsContainer;
    public Transform UserItemsContainer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Initialize(Song[] songs, User[] users)
    {
        SongItems = new GameObject[10];
        DancerItems = new GameObject[10];


        // Initialize top song item
        MainSongItem.GetComponent<RankingSongItem>().Initialize(1, "Haru Haru", "Big Bang", 9.4f);
        SongItems.Append(MainSongItem);

        // Initialize the song item list
        GameObject temp;
        for (int i = 1; i < songs.Length; i++)
        {
            var song = songs[i];
            temp = Instantiate(SongItemPrefab, SongItemsContainer);
            temp.GetComponent<RankingSongItem>().Initialize(i + 1, song.songName, song.artistName, song.popularityScore);
            SongItems.Append(temp);
        }

        Debug.Log($"Initialized {SongItems.Length} song items");

        MainDancerItem1.GetComponent<UserItem>().Initialize(users[0]);
        MainDancerItem2.GetComponent<UserItem>().Initialize(users[1]);
        MainDancerItem3.GetComponent<UserItem>().Initialize(users[2]);

        // Initialize the user item list
        for (int i = 3; i < users.Length; i++)
        {
            var user = users[i];
            temp = Instantiate(UserItemPrefab, UserItemsContainer);
            temp.GetComponent<UserItem>().Initialize(users[i]);
            DancerItems.Append(temp);
        }

        Debug.Log($"Initialized {DancerItems.Length} dancer items");

    }

    void OnEnable()
    {
        DancersTab.SetActive(true);
        SongsTab.SetActive(false);
        SongTabToggle.onValueChanged.AddListener((value) => SetRankingTab(SongTabToggle));
        DancersTabToggle.onValueChanged.AddListener((value) => SetRankingTab(DancersTabToggle));
        DancersTabToggle.isOn = true;
    }

    void OnDisable()
    {
        SongTabToggle.onValueChanged.RemoveAllListeners();
        DancersTabToggle.onValueChanged.RemoveAllListeners();
    }

    public void SetRankingTab(Toggle button)
    {
        if (button == SongTabToggle)
        {
            // Debug.Log("Song tab selected");
            //DancersTabButton.GetComponentInChildren<UnityEngine.UI.Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            SongsTab.SetActive(true);
            DancersTab.SetActive(false);
        }
        else if (button == DancersTabToggle)
        {
            // Debug.Log("Dancers tab selected");
            //DancersTabButton.GetComponentInChildren<UnityEngine.UI.Image>().color = Color.white;
            //SongTabButton.GetComponentInChildren<UnityEngine.UI.Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            DancersTab.SetActive(true);
            SongsTab.SetActive(false);
        }
        else
        {
            Debug.LogError("CanvasManager: Unknown ranking tab button clicked");
        }
    }

}
