using UnityEngine;

public class SceneManager : MonoBehaviour
{

    public void ChallengeStart()
    {
        SceneManager.LoadScene("ChallengeScene");

        PlayerPrefs.SetString("User", "JSONaskdjlkja");
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
