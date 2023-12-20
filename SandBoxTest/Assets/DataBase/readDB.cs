using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using TMPro;
using static Storage;
using static Player;
using static OutlineBuild;
using System;
using Unity.VisualScripting;
using static UnityEngine.UI.CanvasScaler;

public class readDB : MonoBehaviour
{

    public TMP_InputField InputName;
    public UnitToMake unitToMake;
    private string dbName = "URI=file:game.db";
    public BuildIng building;
    [SerializeField] private GameObject Woodh;
    [SerializeField] private GameObject Stoneh;
    [SerializeField] private GameObject closerange;
    [SerializeField] private GameObject cannon;
    [SerializeField] private GameObject rcannon;
    [SerializeField] private GameObject Manor;
    [SerializeField] private GameObject WaterPump;
    [SerializeField] private GameObject WaterTower;
    [SerializeField] private GameObject Observoatory;


    public void User()
    {
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {
            command.CommandText = "SELECT * FROM user WHERE name= '" + InputName.text + "';";
            command.ExecuteReader();

        }
        connction.Close();
    }
    public void Building(GameObject building)
    {
        building = building.gameObject;
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {
            command.CommandText = "SELECT ROWID, xloc, yloc, zloc, type FROM building;";
            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (building == Manor )
                    {
                        Instantiate(Manor, new Vector3(reader.GetFloat(0), reader.GetFloat(1), reader.GetFloat(2)), Quaternion.identity);
                    }
                   else if (building == WaterPump)
                    {
                        Instantiate(WaterPump, new Vector3(reader.GetFloat(0), reader.GetFloat(1), reader.GetFloat(2)), Quaternion.identity);   
                    }

                    else if (building == WaterTower)
                    {
                        Instantiate(WaterTower, new Vector3(reader.GetFloat(0), reader.GetFloat(1), reader.GetFloat(2)), Quaternion.identity); 
                    }

                    else if (building == Observoatory)
                    {
                        Instantiate(WaterTower, new Vector3(reader.GetFloat(0), reader.GetFloat(1), reader.GetFloat(2)), Quaternion.identity);
                    }
                    reader.Close();
                }
            }
            connction.Close();
        }

    }
    public void Resorces()
    {
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {
            command.CommandText = "SELECT * FROM resorces;";
            command.ExecuteReader();
        }
        connction.Close();
    }
    public void Units(int type)
    {
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {
            command.CommandText = "SELECT ROWID, xloc, yloc, zloc, type FROM units;";
            using (IDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (type == 1)
                    {
                        Instantiate(closerange, new Vector3(reader.GetFloat(0), reader.GetFloat(1), reader.GetFloat(2)), Quaternion.identity);
                    }

                        else if (type == 2)
                        {
                        Instantiate(Woodh, new Vector3(reader.GetFloat(0), reader.GetFloat(1), reader.GetFloat(2)), Quaternion.identity);
                        }


                        else if (type == 3)
                        {
                        Instantiate(Stoneh, new Vector3(reader.GetFloat(0), reader.GetFloat(1), reader.GetFloat(2)), Quaternion.identity);
                        }


                        else if (type == 4)
                        {
                        Instantiate(cannon, new Vector3(reader.GetFloat(0), reader.GetFloat(1), reader.GetFloat(2)), Quaternion.identity);
                        }

                        else if (type == 5)
                        {
                        Instantiate(rcannon, new Vector3(reader.GetFloat(0), reader.GetFloat(1), reader.GetFloat(2)), Quaternion.identity);
                        }
                    reader.Close();
                }
                }
            connction.Close();
        }


    }
}
