

public class User
{
    public string userName;

    public int followers;
    public int dances;

    public float points;
    public Song firstSong;
    public Song secondSong;
    public Song thirdSong;

    public User(string name, int f1, int dance, float totalpts, Song song1, Song song2, Song song3)
    {
        userName = name;
        followers = f1;
        dances = dance;
        points = totalpts;
        firstSong = song1;
        secondSong = song2;
        thirdSong = song3;
    }
 
}
