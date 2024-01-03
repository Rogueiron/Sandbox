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


public class InsertToDB : MonoBehaviour
{
   
    private string dbName = "URI=file:game.db";
    public TMP_InputField InputName;
    public UnitToMake unitToMake;
    private int lastIndex = 0;
    private int ROWIDUNIT = 0;
    private string ROWIDDATA;
    [SerializeField] private GameObject Manor;
    [SerializeField] private GameObject WaterPump;
    [SerializeField] private GameObject WaterTower;
    [SerializeField] private GameObject Observoatory;
    [SerializeField] private GameObject Woodh;
    [SerializeField] private GameObject stoneh;
    [SerializeField] private GameObject closerange;
    [SerializeField] private GameObject cannon;
    [SerializeField] private GameObject rcannon;

    // "','" + playerloc.x + "','" + playerloc.y + "','" + playerloc.z + "' 


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
            foreach(var unit in GameObject.FindGameObjectsWithTag("Unit"))
            {
                command.CommandText = "UPDATE units SET xloc = " + unit.transform.position.x + ", yloc = " + unit.transform.position.y + ", zloc = " + unit.transform.position.z + " WHERE ROWID = " + unit.GetComponent<GoToNearestResource>().ROWID + ";";
                command.ExecuteNonQuery();
            }
                }
        connction.Close();
        }
    // inserts the name and loc and type of the building
    public void Building(GameObject building)
    {
        lastIndex += 1;
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {


            if (building == Observoatory)
                {
                command.CommandText = "INSERT INTO building ( Name, xloc, yloc, zloc, type ) VALUES ('" + Randomname() + "' , '" + movePoint[0] + "' , '" + movePoint[1] + "' , '" + movePoint[2] + "' , '" + 1 + "');";
                command.ExecuteNonQuery();
                }
                else if (building == Manor)
                {
                    command.CommandText = "INSERT INTO building ( Name, xloc, yloc, zloc, type ) VALUES ('" + Randomname() + "' , '" + movePoint[0] + "' , '" + movePoint[1] + "' , '" + movePoint[2] + "' , '" + 2 + "');";
                    command.ExecuteNonQuery();
                }
                else if (building == WaterPump)
                {
                    command.CommandText = "INSERT INTO building ( Name, xloc, yloc, zloc, type ) VALUES ('" + Randomname() + "' , '" + movePoint[0] + "' , '" + movePoint[1] + "' , '" + movePoint[2] + "' , '" + 3 + "');";
                    command.ExecuteNonQuery();
                }
                else if (building == WaterTower)
                {
                    command.CommandText = "INSERT INTO building ( Name, xloc, yloc, zloc, type ) VALUES ('" + Randomname() + "' , '" + movePoint[0] + "' , '" + movePoint[1] + "' , '" + movePoint[2] + "' , '" + 4 + "');";
                    command.ExecuteNonQuery();
                }

               
            
            
           
        }
        connction.Close();
    }




public void Units(GameObject unit)
    {
    ROWIDUNIT += 1;
        unit.GetComponent<GoToNearestResource>().ROWID = 0;
        unit.GetComponent<GoToNearestResource>().ROWID = ROWIDUNIT;
        unit.GetComponent<UnitToMake>().Make();
        using var connction = new SqliteConnection(dbName);
        connction.Open();
        using (var command = connction.CreateCommand())
        {

            if (unit.GetComponent<GoToNearestResource>())
            {
                if (unit.GetComponent<GoToNearestResource>().name == "Wood")
                {
                    command.CommandText = "INSERT INTO units (Name, xloc, yloc, zloc, type ) VALUES ('" + Randomname() + "' , '" + unit.transform.position.x + "' , '" + unit.transform.position.y + "' , '" + unit.transform.position.z + "' , '" + 1 + "');";
                }
                else if (unit.GetComponent<GoToNearestResource>().name == "Stone")
                {
                    command.CommandText = "INSERT INTO units (Name, xloc, yloc, zloc, type ) VALUES ('" + Randomname() + "' , '" + unit.transform.position.x + "' , '" + unit.transform.position.y + "' , '" + unit.transform.position.z + "' , '" + 2 + "');";
                }
            }
            else if(unit.GetComponent<stats>())
            {
                if(unit.GetComponent<stats>().name == "Melee")
                {
                    command.CommandText = "INSERT INTO units (Name, xloc, yloc, zloc, type ) VALUES ('" + Randomname() + "' , '" + unit.transform.position.x + "' , '" + unit.transform.position.y + "' , '" + unit.transform.position.z + "' , '" + 3 + "');";
                }
            }
            else if (unit == cannon)
            {
                command.CommandText = "INSERT INTO units (Name, xloc, yloc, zloc, type ) VALUES ('" + Randomname() + "' , '" + unit.transform.position.x + "' , '" + unit.transform.position.y + "' , '" + unit.transform.position.z + "' , '" + 4 + "');";

            }

            else if (unit == rcannon)
            {
                command.CommandText = "INSERT INTO units (Name, xloc, yloc, zloc, type ) VALUES ('" + Randomname() + "' , '" + unit.transform.position.x + "' , '" + unit.transform.position.y + "' , '" + unit.transform.position.z + "' , '" + 5 + "');";
            }
            else
            {
                command.ExecuteNonQuery();
            }   

            
        }
        
        connction.Close();
    }

    // updates all the data 
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
