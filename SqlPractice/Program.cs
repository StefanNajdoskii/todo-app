using Microsoft.Data.Sqlite;

using var connection = new SqliteConnection("Data Source=practice.db");
connection.Open();

var cmd = connection.CreateCommand();
cmd.CommandText = "CREATE TABLE IF NOT EXISTS Tasks (Id INTEGER PRIMARY KEY, Title TEXT, IsDone INTEGER)";
cmd.ExecuteNonQuery();

cmd.CommandText = "INSERT INTO Tasks (Title, IsDone) VALUES ('Buy milk', 0)";
cmd.ExecuteNonQuery();

Console.WriteLine("Table ready.");

cmd.CommandText = "DROP TABLE IF EXISTS Tasks";
cmd.ExecuteNonQuery();
cmd.CommandText = "DROP TABLE IF EXISTS Categories";
cmd.ExecuteNonQuery();

cmd.CommandText = "CREATE TABLE Categories (Id INTEGER PRIMARY KEY, Name TEXT)";
cmd.ExecuteNonQuery();
cmd.CommandText = "CREATE TABLE Tasks (Id INTEGER PRIMARY KEY, Title TEXT, IsDone INTEGER, CategoryId INTEGER)";
cmd.ExecuteNonQuery();

cmd.CommandText = "INSERT INTO Categories (Name) VALUES ('Work'), ('Personal')";
cmd.ExecuteNonQuery();
cmd.CommandText = "INSERT INTO Tasks (Title, IsDone, CategoryId) VALUES ('Study C#', 0, 1), ('Pay rent', 1, 2), ('Call Anna', 0, 2)";
cmd.ExecuteNonQuery();

cmd.CommandText = "SELECT Categories.Name, COUNT(*) FROM Tasks JOIN Categories ON Tasks.CategoryId = Categories.Id GROUP BY Categories.Name";
using var reader = cmd.ExecuteReader();
while (reader.Read())
{
Console.WriteLine(reader.GetString(0) + " - " + reader.GetInt32(1));
}