

public class Event
{
    public string eventName;
    public string eventDate;
    public string eventTime;
    public string eventLocation;
    public string eventStatus;
    public string eventDescription;

    public Event(string name, string date, string time, string location, string status, string description)
    {
        eventName = name;
        eventDate = date;
        eventTime = time;
        eventLocation = location;
        eventStatus = status;
        eventDescription = description;
    }
    
}
