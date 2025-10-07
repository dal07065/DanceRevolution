using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

    }

    public void ChallengeStart()
    {
        SceneManager.LoadScene("ChallengeScene");
    }

    public static void EventJoin()
    {
        SceneManager.LoadScene("EventScene");
    }

    public static void EventExit()
    {
        SceneManager.LoadScene("MainScene");
    }
}
