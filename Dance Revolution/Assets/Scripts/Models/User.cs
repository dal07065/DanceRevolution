

using System;
using System.Collections.Generic;

[Serializable]
public class User
{
    public string userName;

    public int followers;
    public int dances;

    public float points;
    public List<Song> songs;

    public string avatarURL;
    public User(string name, int f1, int dance, float totalpts, Song song1, Song song2, Song song3, string avatar)
    {
        userName = name;
        followers = f1;
        dances = dance;
        points = totalpts;
        songs = new List<Song>
        {
            song1,
            song2,
            song3
        };
        avatarURL = avatar;
    
    }
 
}
