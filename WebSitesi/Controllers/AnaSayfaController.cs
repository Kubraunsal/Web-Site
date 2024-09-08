using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using WebSitesi.Models.Siniflar;

namespace WebSitesi.Controllers
{
    public class AnaSayfaController : Controller
    {
        // GET: AnaSayfa
        Context c = new Context();
        private string connectionString;

        public ActionResult Index()
        {
            var deger = c.AnaSayfas.ToList();
            return View(deger);
        }

        public PartialViewResult ikonlar()
        {
            var deger = c.iconlars.ToList();
            return PartialView(deger);
        }
        public void VeriCek()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM KullaniciTablosu"; // Örnek bir sorgu, kullanıcı tablosundan veri çekiyoruz
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        // Verileri işleyebilir veya kullanıcı sayfasına aktarabilirsiniz
                        string kullaniciAdi = reader["KullaniciAdi"].ToString();
                        string email = reader["Email"].ToString();
                        // ... diğer sütunları da benzer şekilde okuyabilirsiniz
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Veri çekme sırasında hata oluştu: " + ex.Message);
                }
            }
        }
    }
    }
