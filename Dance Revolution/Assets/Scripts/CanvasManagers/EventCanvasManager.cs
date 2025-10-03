using System.Linq;
using UnityEngine;

public class EventCanvasManager : MonoBehaviour
{
    public GameObject[] EventItems;

    public GameObject EventItemPrefab;
    
    public Transform EventContainer;

    public void Initialize(Event[] events)
    {
        EventItems = new GameObject[10];

        for (int i = 0; i < events.Length; i++)
        {
            var eventItem = Instantiate(EventItemPrefab, EventContainer);//new EventItem(events[i]);
            eventItem.GetComponent<EventItem>().Initialize(events[i]);
            EventItems.Append(eventItem);
        }
        Debug.Log("EventCanvasManager Initialize");
    }
}
