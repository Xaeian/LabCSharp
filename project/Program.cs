using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace chmsql
{
  public class Database
  {
    public string database;
    public string server;
    public int port;
    public string user;
    public string password;

    public Database(string database, string server="localhost", int port=3306, string user = "root", string password="")
    {
      this.database = database;
      this.server = server;
      this.port = port;
      this.user = user;
      this.password = password;
    }

    protected string StringConnection()
    {
      return $"server={this.server};user={this.user};database={this.database};port={this.port};password={this.password}";
    }

    protected void Execute(string sql)
    {
      MySqlConnection conn = new MySqlConnection(this.StringConnection());
      try {
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex) {
        Console.WriteLine(ex.ToString());
      }
      conn.Close();
    }

    public DataTable getTable(string sql)
    {
      MySqlConnection conn = new MySqlConnection(this.StringConnection());
      DataTable table = new DataTable();
      try {
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        MySqlDataReader reader = cmd.ExecuteReader();

        table.Columns.Clear();
        var schema = reader.GetSchemaTable();
        foreach (DataRowView row in schema.DefaultView) {
          var name = (string)row["ColumnName"];
          var type = (Type)row["DataType"];
          table.Columns.Add(name, type);
        }
        table.Load(reader);
        reader.Close(); 
      }
      catch (Exception ex) {
        Console.WriteLine(ex.ToString());
      }
      conn.Close();
      return table;
    }

    public void printTable(DataTable table)
    {
      int line = 0;
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.DarkGray;
      Console.Write("|");
      foreach(DataColumn column in table.Columns) {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(column);
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("|");
        line += 10;
      }
      Console.WriteLine();
      Console.WriteLine(String.Concat(Enumerable.Repeat("-", line)));

      foreach(DataRow row in table.Rows) {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("|");
        foreach(var item in row.ItemArray) {
          Console.ResetColor();
          Console.Write(item);
          Console.ForegroundColor = ConsoleColor.DarkGray;
          Console.Write("|");
        }
        Console.ResetColor();
        Console.WriteLine();
      }
      Console.WriteLine();
    }
  }

  public class UsersDB : Database
  {
    private string tableName;
    
    public UsersDB(Database db, string tableName) : base(db.database, db.server, db.port, db.user, db.password)
    {
      this.tableName = tableName;
    }

    public void Display()
    {
      var table = this.getTable("SELECT * FROM users");
      this.printTable(table); 
    }

    public void Add(string user, string email, string password)
    {
      this.Execute($"INSERT INTO users VALUES (null, '{user}', '{email}', '{password}')");
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      Database db = new Database("infa");
      UsersDB userDB = new UsersDB(db, "users");
      userDB.Add("malpiszon", "malpiszon@gmail.com", "TajneHasło69!");
      userDB.Display();
    }
  }
}