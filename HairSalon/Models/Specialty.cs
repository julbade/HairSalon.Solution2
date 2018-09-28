using System;
using System.Collections.Generic;
using HairSalon;
using MySql.Data.MySqlClient;
using System.Collections;

namespace HairSalon.Models
{
  public class Specialty
  {
    private int _id;
    private string _name;
    // private int _stylistId;
    public Specialty(string name, int Id = 0)
    {
      _id = Id;
      _name = name;
      // _stylistId = stylistId;

    }
    public string GetSpecialtyName()
    {
      return _name;
    }

    public int GetSpecialtyId()
    {
      return _id;
    }
    // public int GetStylistId()
    // {
    //   return _stylistId;
    // }


    public override bool Equals(System.Object otherSpecialty)
    {
      if (!(otherSpecialty is Specialty))
      {
        return false;
      }
      else
      {
        Specialty newSpecialty = (Specialty) otherSpecialty;
        bool idEquality = (this.GetSpecialtyId() == newSpecialty.GetSpecialtyId());
        bool nameEquality = (this.GetSpecialtyName() == newSpecialty.GetSpecialtyName());

        return (idEquality && nameEquality);
      }
    }
    public override int GetHashCode()
        {
             return this.GetSpecialtyName().GetHashCode();
        }


    public static List<Specialty> GetAll()
    {
      List<Specialty> allSpecialties = new List<Specialty> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties;"; //select from specialties
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int specialtyId = rdr.GetInt32(0);
        string specialtyName = rdr.GetString(1);
        // int specialtyStylistId = rdr.GetInt32(2);


        Specialty newSpecialty = new Specialty(specialtyName, specialtyId);
        allSpecialties.Add(newSpecialty);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return allSpecialties;
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO specialties (name) VALUES (@SpecialtyName);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@SpecialtyName";
      name.Value = this._name;
      cmd.Parameters.Add(name);

      // MySqlParameter stylistId = new MySqlParameter();
      // stylistId.ParameterName = "@StylistId";
      // stylistId.Value = this._stylistId;
      // cmd.Parameters.Add(stylistId);



      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }
    public static Specialty Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `specialties` WHERE id = @searchId;";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int specialtyId = 0;
      string specialtyName = "";
      // int specialtyStylistId = 0;


      while (rdr.Read())
      {
        specialtyId = rdr.GetInt32(0);
        specialtyName = rdr.GetString(1);
        // specialtyStylistId = rdr.GetInt32(2);


      }
      Specialty foundSpecialty = new Specialty(specialtyName, specialtyId);

      conn.Close();
      if(conn != null)
        {
          conn.Dispose();
        }
        return foundSpecialty;
    }

        public static void DeleteAll()
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"TRUNCATE TABLE specialties";

          cmd.ExecuteNonQuery();

          conn.Close();
          if (conn != null)
          {
            conn.Dispose();
          }
        }
        public List<Stylist> GetStylists()
        {
            List<Stylist> allStylists = new List<Stylist> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists WHERE specialtyId = @specialtyId;";

            MySqlParameter specialtyId = new MySqlParameter();
            specialtyId.ParameterName = "@specialtyId";
            specialtyId.Value = this._id;
            cmd.Parameters.Add(stylistId);


            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
              int stylistId = rdr.GetInt32(0);
              string stylistName = rdr.GetString(1);
              int specialtyStylistId = rdr.GetInt32(2);
              Stylist newStylist = new Stylist(stylistName, specialtyStylistId, stylistId);
              allStylists.Add(newStylist);
            }
              conn.Close();
              if (conn != null)
                {
                    conn.Dispose();
                }
              return allStylistStylists;
            }

  }
}
