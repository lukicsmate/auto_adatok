using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
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
        static List<autok> autokLista()
        {
            var lista = new List<autok>();

            using (StreamReader sr = new StreamReader("auto_adatok.csv"))
            {   
                sr.ReadLine ();
                try
                {
                    using (MySqlConnection conn = new MySqlConnection())
                    {
                        conn.ConnectionString = "Server=127.0.0.1;Port=3307;Database=auto_adatok;Uid=root";
                        conn.Open();

                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            while (!sr.EndOfStream) 
                            {
                                var srsplit = sr.ReadLine();
                                var row = srsplit.Split(',');
                                var ID = row[0];
                                var márka = row[1];
                                var tipus = row[2];
                                var üzemanyag = row[3];
                                var teljesítmény = row[4];
                                var vételár = row[5];
                                var gyártásiÉv = row[6];
                                var átlagosCo2 = row[7];

                                int.TryParse(ID, out int IDD);
                                márka.ToString();
                                tipus.ToString();
                                üzemanyag.ToString();
                                int.TryParse(teljesítmény, out int teljesítményINT);
                                int.TryParse(vételár, out int vételárINT);
                                short.TryParse(gyártásiÉv, out short gyártásiévINT);
                                int.TryParse(átlagosCo2, out int átlagosCo2INT);


                                cmd.CommandText = "SELECT MárkaID FROM Márka WHERE @Márkaa = MárkaNév";
                                cmd.Parameters["@Márkaa"].Value = márka;
                                var cmdexecute = cmd.ExecuteReader();
                                bool found = cmdexecute.Read();
                                if (!found)
                                {
                                    cmd.CommandText = "INSERT INTO Márka(MárkaNév) VALUES(@márkaérték)";
                                    cmd.Parameters["@márkaérték"].Value = márka;
                                    cmd.ExecuteNonQuery();
                                }



                            }
                        }
                    }
                }
                    catch (Exception)
                {

                    throw;
                }
                return lista;
            }
        }

    }
}