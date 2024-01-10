using UnityEngine;
using Mono.Data.Sqlite;
using TMPro;
using System.IO;
using static Storage;
using static Player;
using static OutlineBuild;
using System.Data;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;


public class InsertIntoDB : MonoBehaviour
{
    // the conection string
    private string dbName = "URI=file:game.db";
    // in put a name to the save 
    public TMP_InputField InputName;
    // helps access the info of the unit prefabs
    public UnitToMake unitToMake;
    // counts the auto increment for the buildings
    private int lastIndex = 0;
    // counts the auto increment for the units
    private int ROWIDUNIT = 0;
    // the string form of ROWIDUNIT
    private string ROWIDDATA;
    // this is so the script can compare the difference prefabs
    [SerializeField] private GameObject Manor;
    [SerializeField] private GameObject WaterPump;
    [SerializeField] private GameObject WaterTower;
    [SerializeField] private GameObject Observoatory;
    [SerializeField] private GameObject Woodh;
    [SerializeField] private GameObject stoneh;
    [SerializeField] private GameObject closerange;
    [SerializeField] private GameObject cannon;
    [SerializeField] private GameObject rcannon;
    // Genartes a randomname for units and building 
    private string Randomname(int namelangth = 10)
    {
        int stringLength = namelangth - 1;
        string name = "";
        string[] characters = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        for (int i = 0; i <= stringLength; i++)
        {
            name = name + characters[Random.Range(0, characters.Length)];
        }
        return name;
    }
    public void Start()
    {
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        // makes valid locations to keep the difference resorces
        using (var command = connction.CreateCommand())
        {
            command.CommandText = "INSERT INTO resorces ( name, Stored ) VALUES ('wood'," + WoodStorage + ");";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO resorces ( name, Stored ) VALUES ('Iron'," + IronStorage + ");";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO resorces ( name, Stored ) VALUES ('Coal'," + CoalStorage + ");";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO resorces ( name, Stored ) VALUES ('maxpop'," + PopCapStorage + ");";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO resorces ( name, Stored ) VALUES ('research'," + researchStorage + ");";
            command.ExecuteNonQuery();
        }
        connction.Close();
    }

    // insert the user's name and loc
    public void User()
    {
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {
            command.CommandText = "INSERT INTO user (name, xloc, yloc, zloc) VALUES ('" + InputName.text + "' , '" + position[0] + "' , '" + position[1] + "' , '" + position[2] + "');";
            command.ExecuteNonQuery();



        }
        connction.Close();
    }
    // updates unit loc
    public void Unit()
    {
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {
            foreach (var unit in GameObject.FindGameObjectsWithTag("Unit"))
            {
                command.CommandText = "UPDATE units SET xloc = " + unit.transform.position.x + ", yloc = " + 0.9f + ", zloc = " + unit.transform.position.z + " WHERE ROWID = " + unit.GetComponent<GoToNearestResource>().ROWID + ";";
                command.ExecuteNonQuery();
            }
        }
        connction.Close();
    }
    // inserts the name and loc and type of the building
    public void Building(GameObject building)
    {
        // this is to help fined what to inserte based on the auto increment id number
        lastIndex += 1;
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        // finds what the loc of the building is and sets an type number based on what prefab it is and that type number is read by readDB.
        using (var command = connction.CreateCommand())
        {


            if (building.GetComponent<Stats>().name == "Observatory")
            {
                command.CommandText = "INSERT INTO building ( Name, xloc, yloc, zloc, type ) VALUES ('" + Randomname() + "' , '" + building.transform.position.x + "' , '" + building.transform.position.y + "' , '" + building.transform.position.z + "' , '" + 1 + "');";
                command.ExecuteNonQuery();
            }
            else if (building.GetComponent<Stats>().name == "Manor")
            {
                command.CommandText = "INSERT INTO building ( Name, xloc, yloc, zloc, type ) VALUES ('" + Randomname() + "' , '" + building.transform.position.x + "' , '" + building.transform.position.y + "' , '" + building.transform.position.z + "' , '" + 2 + "');";
                command.ExecuteNonQuery();
            }
            else if (building.GetComponent<Stats>().name == "WaterPump")
            {
                command.CommandText = "INSERT INTO building ( Name, xloc, yloc, zloc, type ) VALUES ('" + Randomname() + "' , '" + building.transform.position.x + "' , '" + building.transform.position.y + "' , '" + building.transform.position.z + "' , '" + 3 + "');";
                command.ExecuteNonQuery();
            }
            else if (building.GetComponent<Stats>().name == "WaterTower")
            {
                command.CommandText = "INSERT INTO building ( Name, xloc, yloc, zloc, type ) VALUES ('" + Randomname() + "' , '" + building.transform.position.x + "' , '" + building.transform.position.y + "' , '" + building.transform.position.z + "' , '" + 4 + "');";
                command.ExecuteNonQuery();
            }





        }
        connction.Close();
    }



    // inserts the name and loc and type of the units
    public void Units(GameObject unit)
    {
        // this is to help fined what to inserte based on the auto increment id number
        ROWIDUNIT += 1;
        unit.GetComponent<GoToNearestResource>().ROWID = 0;
        unit.GetComponent<GoToNearestResource>().ROWID = ROWIDUNIT;
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        // finds what the loc of the units is and sets an type number based on what prefab it is that is found by the name property in Stats that is read by readDB.
        using (var command = connction.CreateCommand())
        {

            if (unit.GetComponent<GoToNearestResource>())
            {
                if (unit.GetComponent<GoToNearestResource>().name == "Wood")
                {
                    // the 0.9f is to help combat the space invater bug when they spawn back unity and SQL have a issue understaning each other like a bad marriage. 
                    command.CommandText = "INSERT INTO units (Name, xloc, yloc, zloc, type ) VALUES ('" + Randomname() + "' , '" + unit.transform.position.x + "' , '" + 0.9f + "' , '" + unit.transform.position.z + "' , '" + 1 + "');";
                }
                else if (unit.GetComponent<GoToNearestResource>().name == "Stone")
                {
                    command.CommandText = "INSERT INTO units (Name, xloc, yloc, zloc, type ) VALUES ('" + Randomname() + "' , '" + unit.transform.position.x + "' , '" + 0.9f + "' , '" + unit.transform.position.z + "' , '" + 2 + "');";
                }
            }
            else if (unit.GetComponent<Stats>())
            {
                if (unit.GetComponent<Stats>().name == "Melee")
                {
                    command.CommandText = "INSERT INTO units (Name, xloc, yloc, zloc, type ) VALUES ('" + Randomname() + "' , '" + unit.transform.position.x + "' , '" + 0.9f + "' , '" + unit.transform.position.z + "' , '" + 3 + "');";
                }
                else if (unit.GetComponent<Stats>().name == "Cannon")
                {
                    command.CommandText = "INSERT INTO units (Name, xloc, yloc, zloc, type ) VALUES ('" + Randomname() + "' , '" + unit.transform.position.x + "' , '" + 0.9f + "' , '" + unit.transform.position.z + "' , '" + 4 + "');";
                }
                else if (unit.GetComponent<Stats>().name == "RCannon")
                {
                    command.CommandText = "INSERT INTO units (Name, xloc, yloc, zloc, type ) VALUES ('" + Randomname() + "' , '" + unit.transform.position.x + "' , '" + unit.transform.position.y + "' , '" + unit.transform.position.z + "' , '" + 5 + "');";
                }
            }
            
            
                command.ExecuteNonQuery();
            
        }
        connction.Close();
    }

    // updates all the data in resorces based on there location in the DB
    public void DBupdate()

    {
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {


            command.CommandText = "UPDATE resorces SET Stored=" + WoodStorage + " WHERE ROWID = 1;";
            command.ExecuteNonQuery();
            command.CommandText = "UPDATE resorces SET Stored=" + IronStorage + " WHERE ROWID = 2;";
            command.ExecuteNonQuery();
            command.CommandText = "UPDATE resorces SET Stored=" + CoalStorage + " WHERE ROWID = 3;";
            command.ExecuteNonQuery();
            command.CommandText = "UPDATE resorces SET Stored=" + PopCapStorage + " WHERE ROWID = 4;";
            command.ExecuteNonQuery();
            command.CommandText = "UPDATE resorces SET Stored=" + researchStorage + " WHERE ROWID = 5;";
            command.ExecuteNonQuery();
        }



    }

}
