using Fusion;
using UnityEngine;

public class ParentingHelper : MonoBehaviour
{
    GameLauncher gl = null;

    bool transfered = false;

    void Start()
    {
        GameLauncher gl = FindObjectOfType<GameLauncher>();
    }

    void Update()
    {
        if(!transfered)
        {
            if(gl)
            {
                NetworkObject[] networkObjects = FindObjectsOfType<NetworkObject>();

                for (int i = 0; i < networkObjects.Length; i++)
                {
                    if (name.Contains("p#" + i+1))
                    {
                        if(networkObjects[i].Id.ToString() == (i+3).ToString())
                        {
                            transform.parent = networkObjects[i].transform;
                            transfered = true;
                        }
                        
                    }
                }

                for (int i = 1; i < gl.playerIndex + 1; i++)
                {

                }
            }
            else
            {
                gl = FindObjectOfType<GameLauncher>();
            }
        }
    }
}
