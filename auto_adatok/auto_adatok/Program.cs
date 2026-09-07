using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto_adatok
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            CreateTable();

        }
        static void CreateTable()
        {
            


            using (MySqlConnection conn = new MySqlConnection())
            {
                conn.ConnectionString = "Server=127.0.0.1;Port=3307;Database=auto_adatok;Uid=root";
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS autok(
                        id INTEGER PRIMARY KEY AUTO_INCREMENT,
                        MárkaID int,
                        TipusID int,
                        üzemanyagID int,
                        Teljesítmény int,
                        Vételár_EUR int,
                        Gyártási_Év short,
                        Átlagos_CO2_g_km
                                                      )";

                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Márka(
                        MárkaID INTEGER PRIMARY KEY AUTO_INCREMENT,
                        MárkaNév varchar(100)
                                        )";
                    cmd.ExecuteNonQuery ();
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS TIPUS(
                        TipusID INTEGER PRIMARY KEY AUTO_INCREMENT,
                        TipusNév varchar(100)
                                                                   )";
                    cmd.ExecuteNonQuery () ;
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Üzemanyag(
                         ÜzemanyagID INTEGER PRIMARY KEY AUTO_INCREMENT,
                         ÜzemanyagNév varchar(100)
                                        )";

                }

            }
        }

    }
}