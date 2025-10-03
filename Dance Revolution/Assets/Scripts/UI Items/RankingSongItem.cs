using TMPro;
using UnityEngine;

public class RankingSongItem : SongItem
{
    public TextMeshProUGUI rankText;
    public TextMeshProUGUI popularityScoreText;
    private int rank;
    private float popularityScore;

    public void Initialize(int rnk, string song, string artist, float popularity = 0)
    {
        Debug.Log($"Initializing RankingSongItem: Rank {rnk}, {song} by {artist} with popularity {popularity}");
        rank = rnk;
        songName = song;
        artistName = artist;
        popularityScore = popularity;

        rankText.text = rank.ToString();
        songTitle.text = song;
        artistTitle.text = artist;
        popularityScoreText.text = popularity.ToString() + "k";
    }   
}
