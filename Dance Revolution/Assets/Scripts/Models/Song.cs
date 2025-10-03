

public class Song
{
    public string songName;
    public string artistName;
    public float popularityScore;

    public Song(string v1, string v2, float popularity = 0)
    {
        songName = v1;
        artistName = v2;
        popularityScore = popularity;
    }

    public void Initialize(string songName, string artistName) 
    {
        this.songName = songName; 
        this.artistName = artistName;
        
    }
}
