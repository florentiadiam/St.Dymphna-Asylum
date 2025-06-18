using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (UIAudioManager.instance != null)
                UIAudioManager.instance.PlayClick();
        });
    }
}
