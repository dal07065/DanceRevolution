using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserItem : MonoBehaviour
{
    public TextMeshProUGUI userName;

    public TextMeshProUGUI userPoints;
    public Button button;

    private User user;

    public void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Initialize(User user)
    {
        Debug.Log("UserItem Initialize");
        this.user = user;
        userPoints.text = user.points.ToString() + "k";
        userName.text = user.userName;
    }

    public void OnButtonClick()
    {
        Debug.Log($"Selected user: {userName.text}");

        CanvasManager.Instance.OpenUserPreviewPage(false, user);
    }
}
