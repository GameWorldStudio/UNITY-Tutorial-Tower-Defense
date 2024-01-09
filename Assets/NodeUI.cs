using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    private Node target;

    public TextMeshProUGUI upgradeCost;
    public Button upgradeButton;
    public TextMeshProUGUI sellCost;

    public void SetTarget(Node _node) 
    { 
        target = _node;
        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "-" + target.turretModel.upgradeCost + "$";
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Already upgraded";
            upgradeButton.interactable = false;
        }
   
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
            
    }

}
