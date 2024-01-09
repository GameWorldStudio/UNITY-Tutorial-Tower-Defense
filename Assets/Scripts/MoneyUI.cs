using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{

    public TextMeshProUGUI moneyText;

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + PlayerStats._money.ToString();
    }
}
