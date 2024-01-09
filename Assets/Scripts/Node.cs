using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    private Color startColor;
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Renderer rend;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretModel turretModel;
    [HideInInspector]
    public bool isUpgraded = false;

    public Vector3 positionUpset;

    private BuildManager buildManager;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition() => transform.position + positionUpset;  


    private void BuildTurret(TurretModel _turret)
    {
        if (PlayerStats._money < _turret.cost)
        {
            Debug.Log("Not much money for this");
            return;
        }

        PlayerStats._money -= _turret.cost;
        turretModel = _turret;
        GameObject turret = Instantiate(_turret.prefab, GetBuildPosition(), Quaternion.identity);
        this.turret = turret;

        GameObject buildEffect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(buildEffect, 1.5f);
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretModel());

    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats._money < turretModel.upgradeCost)
        {
            Debug.Log("Not much money for this upgrade");
            return;
        }

        PlayerStats._money -= turretModel.upgradeCost;
        Destroy(this.turret);
        GameObject turret = Instantiate(turretModel.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        this.turret = turret;

        GameObject buildEffect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(buildEffect, 1.5f);

        isUpgraded = true;
    }
}
