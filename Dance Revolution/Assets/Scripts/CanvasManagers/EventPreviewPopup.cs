using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventPreviewPopup : MonoBehaviour
{
    public EventItem eventItem;

    public TextMeshProUGUI eventNameText;
    public TextMeshProUGUI eventDateText;
    public TextMeshProUGUI eventTimeText;
    public TextMeshProUGUI eventLocationText;

    public TextMeshProUGUI eventDescriptionText;

    // public GameObject eventStatusLive;
    // public GameObject eventStatusOpen;
    // public GameObject eventStatusClosed;

    public Button joinButton;
    public Button closeButton;
    
    public void Initialize(EventItem e)
    {
        Event evnt = e.evnt;
        eventNameText.text = evnt.eventName;
        eventDateText.text = evnt.eventDate;
        eventTimeText.text = evnt.eventTime;
        eventLocationText.text = evnt.eventLocation;
        eventDescriptionText.text = evnt.eventDescription;
        // switch (evnt.eventStatus)
        // {
        //     case "Live":
        //         eventStatusLive.SetActive(true);
        //         break;
        //     case "Open":
        //         eventStatusOpen.SetActive(true);
        //         break;
        //     case "Closed":
        //         eventStatusClosed.SetActive(true);
        //         break;
        //     default:
        //         Debug.LogError($"Unknown event status: {evnt.eventStatus}");
        //         eventStatusClosed.SetActive(true);
        //         break;
        // }
        closeButton.onClick.RemoveAllListeners();
        closeButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });

        gameObject.SetActive(true);
    }
}
