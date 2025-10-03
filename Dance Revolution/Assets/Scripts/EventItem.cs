using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventItem : MonoBehaviour
{
    public enum EventStatus
    {
        Live,
        Open,
        Closed
    }
    public Button popupButton;
    public EventStatus eventStatus;
    public TextMeshProUGUI eventNameText;
    public TextMeshProUGUI eventDateText;
    public TextMeshProUGUI eventTimeText;
    public TextMeshProUGUI eventLocationText;

    public GameObject liveEventStatus;
    public GameObject openEventStatus;
    public GameObject closedEventStatus;

    public Event evnt;

    public void Initialize(Event e)
    {
        evnt = e;
        eventNameText.text = e.eventName;
        eventDateText.text = e.eventDate;
        eventTimeText.text = e.eventTime;
        eventLocationText.text = e.eventLocation;
        switch (e.eventStatus)
        {
            case "Live":
                eventStatus = EventStatus.Live;
                liveEventStatus.SetActive(true);
                break;
            case "Open":
                eventStatus = EventStatus.Open;
                openEventStatus.SetActive(true);
                break;
            case "Closed":
                eventStatus = EventStatus.Closed;
                closedEventStatus.SetActive(true);
                break;
            default:
                Debug.LogError($"Unknown event status: {e.eventStatus}");
                eventStatus = EventStatus.Closed;
                break;
        }
        
        popupButton.onClick.AddListener(() =>
        {
            CanvasManager.Instance.PopupManager.OpenEventDetailPopup(this);
        });
    }


}
