using GLTFast.Schema;
using TMPro;
using UnityEngine;

public class SongPreviewPage : MonoBehaviour
{
    public TextMeshProUGUI songTitle;
    public TextMeshProUGUI artistTitle;

    public UnityEngine.UI.Image songImage;


    public void Initialize(string songName, string artistName ,UnityEngine.Sprite sprite) //, Sprite albumArt)
    {
        songTitle.text = songName;
        artistTitle.text = artistName;
        songImage.sprite = sprite;
        gameObject.SetActive(true);
        // songImage.sprite = albumArt;
    }
}

// public static partial class Global
// {
//     public static partial class Controller
//     {
//         public static SongPreviewPage GetSongPreviewPage()
//         {
//             return GlobalAccess<SongPreviewPage>.GetInstance(true);
//         }
//     }
// }


