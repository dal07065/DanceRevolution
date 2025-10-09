using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Resources")]

    public GameObject MainCamera;

    public AnimatorController avatarAnimator;
    public GameObject PlayerAvatarEnvironment;
    public Song[] songs;
    public User[] users;
    public Event[] events;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        // Initialize dummy data
        songs = new Song[]
        {
            new Song("Haru Haru", "Big Bang", 9.8f),
            new Song("Levitate", "Dua Lipa", 6.5f),
            new Song("Blinding Lights", "The Weeknd", 5.3f),
            new Song("Here With Me", "d4vd", 4.1f),
            new Song("Golden", "HUNTRX", 1.6f)
        };

        users = new User[]{

            new User("Uzutrap1023", 143, 425, 3.2f, songs[2], songs[4], songs[1], "https://models.readyplayer.me/638df5fc5a7d322604bb3a58.glb"),
            new User("DancingQueen", 98, 210, 5.3f,songs[0], songs[1], songs[3], "https://models.readyplayer.me/638df70ed72bffc6fa179596.glb"),
            new User("RhythmMaster", 120, 330, 9.1f, songs[1], songs[3], songs[0], "https://models.readyplayer.me/638df75e5a7d322604bb3dcd.glb"),
            new User("BeatBlaster", 75, 150, 1.4f, songs[4], songs[2], songs[3], "https://models.readyplayer.me/638df7d1d72bffc6fa179763.glb"),
            new User("GrooveGuru", 200, 600, 8.4f, songs[3], songs[0], songs[4], "https://models.readyplayer.me/638df5fc5a7d322604bb3a58.glb"),
            new User("SpinDoctor", 50, 100, 2.7f, songs[1], songs[4], songs[2], "https://models.readyplayer.me/638df70ed72bffc6fa179596.glb"),
            new User("FunkyFeet", 180, 450, 6.9f, songs[0], songs[2], songs[3], "https://models.readyplayer.me/638df75e5a7d322604bb3dcd.glb"),
            new User("DanceDynamo", 130, 300, 4.8f, songs[3], songs[1], songs[0], "https://models.readyplayer.me/638df7d1d72bffc6fa179763.glb"),
            new User("StepSensation", 90, 220, 7.5f, songs[2], songs[0], songs[4], "https://models.readyplayer.me/638df5fc5a7d322604bb3a58.glb")

        };

        events = new Event[]{
            new Event("Jazz Dance Gala", "August 18th", "17:00 PST", "Grand Theater", "Live", "3 Grand Prizes for Top 3 Winners and 10 Consolation Prizes!"),
            new Event("Hip Hop Battle", "September 5th", "19:00 PST", "City Arena", "Open", "3 Grand Prizes for Top 3 Winners and 10 Consolation Prizes!"),
            new Event("Ballet Showcase", "July 30th", "15:00 PST", "Opera House", "Closed", "3 Grand Prizes for Top 3 Winners and 10 Consolation Prizes!"),
            new Event("Salsa Night", "August 25th", "20:00 PST", "Downtown Club", "Open",  "3 Grand Prizes for Top 3 Winners and 10 Consolation Prizes!"),
            new Event("Contemporary Dance Fest", "September 10th", "18:00 PST", "Art Center", "Live",  "3 Grand Prizes for Top 3 Winners and 10 Consolation Prizes!"),
            new Event("Tap Dance Extravaganza", "July 22nd", "16:00 PST", "Main Square", "Closed",  "3 Grand Prizes for Top 3 Winners and 10 Consolation Prizes!")

        };

    }

    public User[] GetUsers()
    {
        return users;
    }

    public Song[] GetSongs()
    {
        return songs;
    }

    public void FindChallenger()
    {
        CanvasManager.Instance.ShowLoadingScreen(true);

        CanvasManager.Instance.OpenUserPreviewPage(false, CanvasManager.Instance.GetUsers()[Random.Range(0, 8)]);

    }

    public void NextChallenger()
    {
        CanvasManager.Instance.ShowLoadingScreen(true);
        CanvasManager.Instance.PlayerPage.Initialize(false, CanvasManager.Instance.GetUsers()[Random.Range(0, 8)]);

    }
}
