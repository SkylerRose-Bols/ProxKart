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
                for (int i = 1; i < gl.playerIndex + 1; i++)
                {
                    if (name.Contains("p#" + i))
                    {
                        transform.parent = GameObject.Find("Player " + (i - 1)).transform;
                        transfered = true;
                    }
                }
            }
            else
            {
                gl = FindObjectOfType<GameLauncher>();
            }
        }
    }
}
