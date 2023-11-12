using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Sante.Models;
using System.Data.SqlClient;

namespace Sante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonneController : ControllerBase
    {
        [HttpGet("lisTPersonne")]
        public List<Personne> listPersonne()
        {
            SqlConnection connection = Connexion.getConnection();
            connection.Open();
            List<Personne> list = Personne.getListPersonne(connection);
            connection.Close();
            return list;
        }
        [HttpGet("getPersonne/{cin}")]
        public Personne getPersonne(int cin)
        {
            SqlConnection connection = Connexion.getConnection();
            connection.Open();
            Personne pers = Personne.getPersonne(connection,cin);
            connection.Close();
            return pers;
        }
        [HttpGet("getAllergiePersonne/{cin}")]
        public List<Allergie> GetAllergies(int cin)
        {
            SqlConnection connection = Connexion.getConnection();
            connection.Open();
            List<Allergie> list_Allergie = Allergie.getListByCin(connection,cin);
            connection.Close();
            return list_Allergie;
        }
        [HttpGet("getListAntecedantMaladie/{cin}")]
        public List<AntecedantMaladie> listMaladie(int cin)
        {
            SqlConnection connection = Connexion.getConnection();
            connection.Open();
            List<AntecedantMaladie> list_antecedantMaladie = AntecedantMaladie.getListMaladie(connection, cin);
            connection.Close();
            return list_antecedantMaladie;
        }
        [HttpGet("getDeviseDay/{code}")]
        public Devise getDeviseDay(string code)
        {
            // get date et heure actuel
            DateTime date = DateTime.Now;
            SqlConnection connection = Connexion.getConnection();
            connection.Open();
            Devise devise_day = Devise.getDevise(connection, date, code);
            connection.Close();
            return devise_day;
        }
        [HttpGet("getListVola")]
        public List<Vola> getListVola()
        {
            SqlConnection connection = Connexion.getConnection();
            connection.Open();
            List<Vola> list_vola = Vola.getList(connection);
            connection.Close();
            return list_vola;
        }
    }
}
