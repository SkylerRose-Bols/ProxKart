using UnityEngine;


public class KartFollower : MonoBehaviour
{
    Transform objectToFollow = null;
    RoomPlayer roomPlayer = null;
    void Start()
    {
        roomPlayer = GetComponent<RoomPlayer>();
        if(roomPlayer)
        {
            if(roomPlayer.Kart)
            {
                objectToFollow = GetComponent<RoomPlayer>().Kart.transform;
            }
        }
    }

    void FixedUpdate()
    {
        if(objectToFollow == null)
        {
            if (roomPlayer)
            {
                if (roomPlayer.Kart)
                {
                    objectToFollow = roomPlayer.Kart.transform;
                }
            }
        }
        else
        {
            transform.position = objectToFollow.position;
        }
    }
}
