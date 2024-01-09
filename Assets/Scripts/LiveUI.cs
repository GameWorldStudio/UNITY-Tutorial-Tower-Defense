using TMPro;
using UnityEngine;

public class LiveUI : MonoBehaviour
{

    public TextMeshProUGUI livesText;

    // Update is called once per frame
    void Update()
    {
        livesText.text = PlayerStats._lives + " Lives";
    }
}
