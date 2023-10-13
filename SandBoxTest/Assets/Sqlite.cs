using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;

public class Sqlite : MonoBehaviour
{
    // Start is called before the first frame update
    private string dbName = "URI=file:gamedata "
    
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateDB()
    {
        using(var connction = new SqliteConnection(dbName))
        {
            connction.Open();

                using(var command = connction.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS gamesave (username VARCHAR(20), password INT);";
                command.ExecuteNonQuery();
                connction.Close();
            }
        } 
    }







}
