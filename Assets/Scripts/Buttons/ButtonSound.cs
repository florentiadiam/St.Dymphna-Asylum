using UnityEngine;
using UnityEngine.UI;

//add a button sound when clicked
public class ButtonSound : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (UIAudioManager.instance!= null)
                UIAudioManager.instance.PlayClick();
        });
    }
}
