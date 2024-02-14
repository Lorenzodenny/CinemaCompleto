using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBaseEserci
{

    //Lista dei comandi:
    //    - SqlConnection => Usato per stabilire la connessione con il DataBase
    //    - SqlCommand => All' interno possiamo inserire direttamente i comandi di Sql , è una specie di traduttore per comandi e codici
    //    -ExecuteScalar => Questo è un metodo di SqlCommand stampa il primo record ed è utile in questo caso visto che il count(*) tira fuori solo un record
    //    -ExecuteReader => Stampa tutti i risultati di una Select
    //    -conn.Open() e conn.Close() apre e chiude la comunicazione col database, è sempre meglio aprirla quando ci servono dei dati e chiuderla subito dopo
    public partial class Cinema : System.Web.UI.Page
    {
        // Creo Qui la connessione almeno ce l'ho pronta per tutta la pagina

        private static string connString = ConfigurationManager.ConnectionStrings["DbCinemaConnection"].ToString();
        private SqlConnection conn = new SqlConnection(connString);

        protected void Page_Load(object sender, EventArgs e)
        {
            conn.Open();

            //Stampare il count del primo record ( la prima riga )

            SqlCommand commandCountNord = new SqlCommand("SELECT COUNT(*) FROM Utenti WHERE Sala='nord'", conn);
            string countNord = commandCountNord.ExecuteScalar().ToString();
            SqlCommand commandCountNordReduced = new SqlCommand("SELECT COUNT(*) FROM Utenti WHERE Sala='nord' AND TipoBiglietto='ridotto'", conn);
            string countNordReducer = commandCountNordReduced.ExecuteScalar().ToString();
            LblNord.Text = $"Totali: {countNord}, ridotti: {countNordReducer}";

            SqlCommand commandCountEst = new SqlCommand("SELECT COUNT(*) FROM Utenti WHERE Sala='est'", conn);
            string countEst = commandCountEst.ExecuteScalar().ToString();
            SqlCommand commandCountEstReduced = new SqlCommand("SELECT COUNT(*) FROM Utenti WHERE Sala='est' AND TipoBiglietto='ridotto'", conn);
            string countEstReducer = commandCountEstReduced.ExecuteScalar().ToString();
            LblEst.Text = $"Totali: {countEst}, ridotti: {countEstReducer}";

            SqlCommand commandCountSud = new SqlCommand("SELECT COUNT(*) FROM Utenti WHERE Sala='sud'", conn);
            string countSud = commandCountSud.ExecuteScalar().ToString();
            SqlCommand commandCountSudReduced = new SqlCommand("SELECT COUNT(*) FROM Utenti WHERE Sala='sud' AND TipoBiglietto='ridotto'", conn);
            string countSudReducer = commandCountSudReduced.ExecuteScalar().ToString();
            LblSud.Text = $"Totali: {countSud}, ridotti: {countSudReducer}";


            // Stampare tutti i nomi
            if (!IsPostBack)
            {
                SqlCommand getName = new SqlCommand("SELECT Nome, Cognome, Sala, TipoBiglietto FROM Utenti", conn);
                SqlDataReader reader = getName.ExecuteReader();

                string nomiStringati = "";
               
                while (reader.Read())
                {
                    string name = reader["Nome"].ToString();
                    string cognome = reader["Cognome"].ToString();
                    string sala = reader["Sala"].ToString();
                    string biglietto = reader["TipoBiglietto"].ToString();
                    nomiStringati += $"'{name} {cognome} {sala} {biglietto} <br /> ";
                  
                }

                reader.Close();
                LblNomi.Text = nomiStringati;
               
            }



            conn.Close();
        }

        protected void BtnCompro_Click(object sender, EventArgs e)
        {
            //prendo gli input dall'utente

            string nome = TxtNome.Text;
            string cognome = TxtCognome.Text;
            string sala = RdbSala.Text;
            string biglietto = RdbBiglietto.Text;
            
            //mi connetto al DataBase e salvo i dati dell'utente nel DataBase

            try
            {
                //Apro la connessione, la verifico e eseguo l'insert
                //nella taballe degli Utenti nel DataBase Cinema

                conn.Open();

                SqlCommand commandCountSala = new SqlCommand($"SELECT COUNT(*) FROM Utenti WHERE Sala='{sala}'", conn);
                int countSala = (int)commandCountSala.ExecuteScalar();

                if (countSala >= 120)
                {
                    Response.Write($"La sala {sala} è piena. Non è possibile acquistare altri biglietti per questa sala.");
                }
                else
                {
                    SqlCommand RegistrazioneUtenti = new SqlCommand($"INSERT INTO Utenti ( Nome, Cognome, Sala, TipoBiglietto) VALUES ('{nome}', '{cognome}', '{sala}', '{biglietto}') ", conn);
                    int affectedRows = RegistrazioneUtenti.ExecuteNonQuery();
                    if (affectedRows != 0)
                    {
                        Response.Write("Biglietto Comprato Con Successo");
                    }
                    else
                    {
                        Response.Write("Qualcosa è Andato Storto");
                    }
                }
                
            }
            catch
            {
                //Gestire l'errore
                Response.Write("Qualcosa non va");

            }
            finally
            {
                // è bene chiudere la connessione col data base
                conn.Close();
            }

        }
    }
}