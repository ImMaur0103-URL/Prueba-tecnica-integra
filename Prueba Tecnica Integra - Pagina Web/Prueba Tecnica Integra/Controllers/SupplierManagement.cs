using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Prueba_Tecnica_Integra.Data;
using Prueba_Tecnica_Integra.Models;
using System.Data;
using System.Text;

namespace Prueba_Tecnica_Integra.Controllers
{
    public class SupplierManagement : Controller
    {
        private readonly DatabaseConnection _dbConnection;

        public SupplierManagement(IConfiguration configuration)
        {
            _dbConnection = new DatabaseConnection(configuration);
        }

        public async Task<IActionResult> Index()
        {
            List<T_PROVEEDOR> proveedores = new List<T_PROVEEDOR>();

            using (SqlConnection connection = _dbConnection.GetConnection())
            {
                connection.Open();
                string sql = "SELECT * FROM T_PROVEEDOR";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            proveedores.Add(new T_PROVEEDOR
                            {
                                ID = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Telefono = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Correo = reader.IsDBNull(3) ? null : reader.GetString(3),
                                NIT = reader.GetString(4),
                                Direccion = reader.GetString(5),
                                IDGrupoProv = (int)(reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6))
                            });
                        }
                    }
                }
            }

            return View(proveedores);
        }

        // GET: SupplierManagement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SupplierManagement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplierManagement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierManagement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SupplierManagement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierManagement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SupplierManagement/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
