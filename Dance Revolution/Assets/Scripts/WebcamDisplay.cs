using UnityEngine;
using UnityEngine.UI;

public class WebcamDisplay : MonoBehaviour
{
    private WebCamTexture webcamTexture;
    private RawImage rawImage;

    void Start()
    {
        rawImage = GetComponent<RawImage>();
        string cameraName = null;
        foreach (var device in WebCamTexture.devices)
        {
            if (device.isFrontFacing)
            {
                cameraName = device.name;
                break;
            }
        }

        webcamTexture = cameraName != null ? new WebCamTexture(cameraName) : new WebCamTexture();
        rawImage.texture = webcamTexture;
        rawImage.material.mainTexture = webcamTexture;
        webcamTexture.Play();

        // Wait for webcam to start before adjusting aspect
        StartCoroutine(AdjustAspect());
    }

    System.Collections.IEnumerator AdjustAspect()
    {
        // Wait until the webcamTexture is initialized
        while (webcamTexture.width <= 16)
            yield return null;

        float videoAspect = (float)webcamTexture.width / webcamTexture.height;
        RectTransform rt = rawImage.rectTransform;

        // Option 1: Adjust RawImage size to match aspect ratio (if you want to resize RawImage)
        // rt.sizeDelta = new Vector2(rt.sizeDelta.y * videoAspect, rt.sizeDelta.y);

        // Option 2: Keep RawImage size, adjust UVRect to letterbox/pillarbox
        float imageAspect = rt.rect.width / rt.rect.height;
        if (videoAspect > imageAspect)
        {
            // Pillarbox: add horizontal bars
            float scale = imageAspect / videoAspect;
            rawImage.uvRect = new Rect((1 - scale) / 2, 0, scale, 1);
        }
        else
        {
            // Letterbox: add vertical bars
            float scale = videoAspect / imageAspect;
            rawImage.uvRect = new Rect(0, (1 - scale) / 2, 1, scale);
        }
    }

    void OnDestroy()
    {
        if (webcamTexture != null)
        {
            webcamTexture.Stop();
        }
    }
}