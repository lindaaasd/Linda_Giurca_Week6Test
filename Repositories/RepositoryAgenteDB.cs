using System;
using System.Data.SqlClient;
using Test_Week6.Entities;

namespace Test_Week6.Repositories
{
	public class RepositoryAgenteDB:IRepository
	{
        const string connectionString = @"Server=localhost; Database=Agenti; User Id = sa; Password = popdocker356..9!";
        public List<Agente> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("select * from Agente", connection);
                SqlDataReader reader = command.ExecuteReader();

                List<Agente> ListaAgenti = new List<Agente>();

                while (reader.Read())
                {
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    var codiceFiscale = (string)reader["CodiceFiscale"];
                    var annoInizioAttivita = (int)reader["AnnoInizioAttivita"];
                    var areaGeografica = (string)reader["AreaGeografica"];

                    Agente agente = new Agente(nome, cognome, codiceFiscale, areaGeografica, annoInizioAttivita);
                    ListaAgenti.Add(agente);

                }
                connection.Close();

                return ListaAgenti;
            }
        }

        public List<Agente> GetInfoAnniServizio(int anniServizio)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                SqlCommand command = new SqlCommand("select * from Agente where 2022 - AnnoInizioAttivita >= @anniServ", connection);
                command.Parameters.AddWithValue("@anniServ", anniServizio);
                SqlDataReader reader = command.ExecuteReader();

                List<Agente> ListaAgentiAnniServizio = new List<Agente>();

                while (reader.Read())
                {
                    var nome = (string)reader["Nome"];
                    var cognome = (string)reader["Cognome"];
                    var codiceFiscale = (string)reader["CodiceFiscale"];
                    var areaGeografica = (string)reader["AreaGeografica"];
                    var annoInizioAttivita = (int)reader["AnnoInizioAttivita"];


                    Agente agente = new Agente(nome, cognome, codiceFiscale, areaGeografica, annoInizioAttivita);
                    ListaAgentiAnniServizio.Add(agente);
                }
                connection.Close();

                return ListaAgentiAnniServizio;
            }

        }

        public List<Agente> GetInfoAreaGeografica(string areaGeografica)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

            connection.Open();

            SqlCommand command = new SqlCommand("select * from Agente where AreaGeografica = @areaG", connection);
            command.Parameters.AddWithValue("@areaG", areaGeografica);
            SqlDataReader reader = command.ExecuteReader();

            List<Agente> ListaAgentiAreaGeografica = new List<Agente>();

            while (reader.Read())
            {
                string nome = (string)reader["Nome"];
                string cognome = (string)reader["Cognome"];
                var codiceFiscale = (string)reader["CodiceFiscale"];
                var annoInizioAttivita = (int)reader["AnnoInizioAttivita"];

                Agente agente = new Agente(nome, cognome, codiceFiscale, areaGeografica, annoInizioAttivita);
                ListaAgentiAreaGeografica.Add(agente);
            }
            connection.Close();

            return ListaAgentiAreaGeografica;
            }

        }

        public bool InserisciAgente(Agente agente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                SqlCommand command = new SqlCommand("insert into Agente values(@nomeAgente, @cognomeAgente, @CFAgente," +
                    "@annoInizioAgente, @areaGeoAgente)", connection);
                command.Parameters.AddWithValue("@nomeAgente", agente.Nome);
                command.Parameters.AddWithValue("@cognomeAgente", agente.Cognome);
                command.Parameters.AddWithValue("@CFAgente", agente.CodiceFiscale);
                command.Parameters.AddWithValue("@areaGeoAgente", System.Data.SqlDbType.VarChar).Value = agente.AreaGeografica;
                command.Parameters.AddWithValue("@annoInizioAgente", agente.AnnoInizioAttivita);

                int numRighe = command.ExecuteNonQuery();
                if (numRighe == 1)
                {
                    connection.Close();
                    Console.WriteLine("Inserimento avvenuto con successo!");
                    return true;
                }
                connection.Close();
                Console.WriteLine("Error, riprova");
                return false;
            }
        }

        public bool VerificaAgenteEsistente(string codiceFiscale)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                SqlCommand command = new SqlCommand("select * from Agente where CodiceFiscale = @codiceFiscale", connection);
                command.Parameters.AddWithValue("@codiceFiscale", codiceFiscale);

               
                SqlDataReader risultato = command.ExecuteReader();

                if (risultato.HasRows)
                {
                    return true;
                } 
                return false;
            }
        }
    }
}

