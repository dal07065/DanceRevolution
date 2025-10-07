using UnityEngine;
using UnityEngine.UI;

public class ShowAllSongsPopup : MonoBehaviour
{
    public Button closeButton;
    public void Initialize(User user)
    {
        closeButton.onClick.AddListener(() =>
        {
            CanvasManager.Instance.PopupManager.CloseAllPopups();
            closeButton.onClick.RemoveAllListeners();
        });
    }
}
