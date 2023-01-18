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
                    if (networkObjects[i].Id.Raw == i + 3)
                    {
                        transform.parent = networkObjects[i].transform;
                        transfered = true;
                    }

                }
            }
        }
    }
}
