using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int wood = 10;
    public int iron = 10;
    public float[] zoom;

    public void Save()
    {
        SaveSystem.SavePlayer(this);
    }

    public void Load()
    {
        PlayerData data = SaveSystem.LoadPlayer();


        wood = data.wood;
        iron = data.iron;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        GetComponent<CameraController>().newPosition = position;
    }

}
