using System.IO;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static public string path;
    [SerializeField] private ObjectMovement _objectMovement;

    private void Start()
    {
        path = Path.Combine(Application.dataPath, "Save.json");
        _objectMovement.DownloadData(LoadJSON.LoadingJSON<DataPoint>());
    }

    public void StartMovement(int amount)
    {
        _objectMovement.InversIsMoving();
        _objectMovement.SetMaxAmountPoint(amount);
    }
}
