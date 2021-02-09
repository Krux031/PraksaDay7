using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Data;
using CityRepositoryCommon;
using CityModelCommon;
using CityModel;

namespace CityRepository
{
    public class Repository : ICityRepository
    {
        SqlCommand zahtjev = null;
        SqlTransaction transaction;
        public static SqlConnection konekcija = new SqlConnection(@"Server=tcp:kruninserver.database.windows.net,1433;Initial Catalog=kruninabaza;Persist Security Info=False;User ID=krux031;Password=sifra;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        public async Task<ICity> GetCityRep(int id)
        {
            zahtjev = new SqlCommand("select * from grad where pbr=@id", konekcija);
            zahtjev.Parameters.AddWithValue("@id", id);
            ICity grad = new City();
            try
            {
                if (konekcija.State == ConnectionState.Closed)
                {
                    konekcija.Open();
                }

                SqlDataReader reader = zahtjev.ExecuteReader();

                while (await reader.ReadAsync())
                {
                    grad.Id = reader.GetInt32(0);
                    grad.Naziv = reader.GetString(1);
                }

            }
            catch (SqlException Ex)
            {
                transaction.Rollback();
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                    konekcija.Close();
            }

            return grad;
        }


        public async Task<List<ICity>> GetAllCityRep()
        {
            zahtjev = new SqlCommand("select * from grad", konekcija);
            List<ICity> gradovi = new List<ICity>();
            try
            {
                if (konekcija.State == ConnectionState.Closed)
                {
                    konekcija.Open();
                }

                SqlDataReader reader = zahtjev.ExecuteReader();

                while (await reader.ReadAsync())
                {
                    ICity grad = new City();
                    grad.Id = reader.GetInt32(0);
                    grad.Naziv = reader.GetString(1);
                    gradovi.Add(grad);
                }

            }
            catch (SqlException Ex)
            {
                transaction.Rollback();
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                    konekcija.Close();
            }

            return gradovi;
        }

        public async Task<bool> DeleteresidentRep(int id)
        {
            zahtjev = new SqlCommand("delete from stanovnici where jmbg=@id", konekcija);
            zahtjev.Parameters.AddWithValue("@id", id);
            try
            {
                if (konekcija.State == ConnectionState.Closed)
                {
                    konekcija.Open();
                }

                if(await zahtjev.ExecuteNonQueryAsync()==0)
                {
                    return false;
                }
            }
            catch (SqlException Ex)
            {
                transaction.Rollback();
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                    konekcija.Close();
            }

            return true;
        }

        public async Task<bool> PostResidentRep(IResidents res, int id)
        {
            zahtjev = new SqlCommand("insert into stanovnici values (@id, @ime, @prezime, @pbr, @spol)", konekcija);
            zahtjev.Parameters.AddWithValue("@id", id);
            zahtjev.Parameters.AddWithValue("@ime", res.Ime);
            zahtjev.Parameters.AddWithValue("@prezime", res.Prezime);
            zahtjev.Parameters.AddWithValue("@pbr", res.Pbr);
            zahtjev.Parameters.AddWithValue("@spol", res.Spol);
            try
            {
                if (konekcija.State == ConnectionState.Closed)
                {
                    konekcija.Open();
                }
                await zahtjev.ExecuteNonQueryAsync();
            }
            catch (SqlException Ex)
            {
                return false;
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                    konekcija.Close();
            }
            
            return true;
        }
    }
}
