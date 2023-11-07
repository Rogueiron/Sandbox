using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]
public class PlayerData
{

    public int wood;
    public int iron;
    public float[] position;

    public PlayerData (Player player)
    {
        wood = player.wood;
        iron = player.iron;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
