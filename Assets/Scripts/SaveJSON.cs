using System.IO;
using UnityEngine;

public class SaveJSON : MonoBehaviour
{
    static public void SaveFileJSON(object obj)
    {
        File.WriteAllText(GameController.path, JsonUtility.ToJson(obj));
    }
}
