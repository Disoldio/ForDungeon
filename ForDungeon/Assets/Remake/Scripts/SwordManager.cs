using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;

public class SwordManager : MonoBehaviour
{
    private List<Sword> _swords = new List<Sword>();
    private Sword _defaultSword;

    private MySqlConnection _connection;
    private MySqlConnectionStringBuilder _connectionBuilder = new MySqlConnectionStringBuilder();
    private void Awake()
    {
        if (_swords.Count > 0)
        {
            return;
        }

        _connectionBuilder.Server = "localhost";
        _connectionBuilder.UserID = "root";
        _connectionBuilder.Database = "for_dungeon";
        _connectionBuilder.Password = "";

        _connection = new MySqlConnection(_connectionBuilder.ConnectionString);

        LoadSwords();
    }

    private void LoadSwords()
    {
        string query = $"select * from swords";

        _connection.Open();

        MySqlCommand command = new MySqlCommand(query, _connection);
        MySqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Sword currentSword = new Sword(
                    int.Parse(reader["id"].ToString()), 
                    reader["name"].ToString(),
                    float.Parse(reader["strength"].ToString()),
                    float.Parse(reader["attack_speed"].ToString()),
                    float.Parse(reader["max_distance"].ToString()));
                _swords.Add(currentSword);
            }
            _defaultSword = _swords[0];
        }

        _connection.Close();
    }

    public Sword GetSwordById(int id)
    {
        return _swords.Find(sword =>
        {
            return sword.GetId() == id;
        });
    }

    public Sword GetDefaultSword()
    {
        return _defaultSword;
    }

    public static void SaveSwordById(int id)
    {
        PlayerPrefs.SetInt("swordId", id);
        PlayerPrefs.Save();
    }

    public List<Sword> GetAll()
    {
        return _swords;
    }
}
