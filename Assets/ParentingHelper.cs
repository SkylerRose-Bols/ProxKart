using Fusion;
using UnityEngine;

public class ParentingHelper : MonoBehaviour
{
    bool transfered = false;

    void Update()
    {
        if (!transfered)
        {
            NetworkObject[] networkObjects = FindObjectsOfType<NetworkObject>();

            for (int i = 0; i < networkObjects.Length; i++)
            {
                if (name.Contains("p#" + i + 1))
                {
                    if (networkObjects[i].Id.Raw.ToString() == (i + 3).ToString())
                    {
                        transform.parent = networkObjects[i].transform;
                        transfered = true;
                    }
                }
            }
        }
    }
}
