using System.IO;
using UnityEngine;

public class LoadJSON : MonoBehaviour
{
    static public T LoadingJSON<T>()
    {
        if (File.Exists(GameController.path))
        {
            return JsonUtility.FromJson<T>(File.ReadAllText(GameController.path));
        }
        else return default(T);
    }
}
