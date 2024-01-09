using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Singleton
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There are two instance of BuildManager present in the scene.");
            return;
        }
        instance = this;
    }
    #endregion

    public GameObject buildEffect;

    private TurretModel turretToBuild; // Selected turret to build
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild
    {
        get
        {
            return turretToBuild != null;
        }
    }

    public bool HasMoney
    {
        get
        {
            return PlayerStats._money >= turretToBuild.cost;
        }
    }

    public TurretModel GetTurretModel() => turretToBuild;

    public void SelectTurretToBuild(TurretModel _turretToBuild) 
    { 
        turretToBuild = _turretToBuild;
        DeselectNode();
    }
    public void SelectNode(Node _node)
    {

        if (_node == selectedNode)
        {
            DeselectNode();
            return;
        }

        selectedNode = _node;
      

        turretToBuild = null;

        nodeUI.SetTarget(_node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
}
