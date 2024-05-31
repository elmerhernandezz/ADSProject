using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Migrations;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class CarreraRepository : ICarrera
    {
        /*private List<Carrera> lstCarreras = new List<Carrera>
        {
            new Carrera{ Id = 1, Codigo = "I04",
            Nombre = "Ing. Sistemas"
            }
        };*/

        private readonly ApplicationDbContext applicationDbContext;

        public CarreraRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int ActualizarCarrera(int idCarrera, Carrera carrera)
        {
            try
            {
                //int indice = lstCarreras.FindIndex(tmp => tmp.Id == idCarrera);

                //lstCarreras[indice] = carrera;

                var item = applicationDbContext.Carreras.SingleOrDefault(x => x.Id == idCarrera);
                applicationDbContext.Entry(item).CurrentValues.SetValues(carrera);
                applicationDbContext.SaveChanges();

                return idCarrera;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AgregarCarrera(Carrera carrera)
        {
            try
            {
                /*if (lstCarreras.Count > 0)
                {
                    carrera.Id = lstCarreras.Last().Id + 1;
                }

                lstCarreras.Add(carrera);*/

                applicationDbContext.Carreras.Add(carrera);
                applicationDbContext.SaveChanges();

                return carrera.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarCarrera(int idCarrera)
        {
            try
            {
                var item = applicationDbContext.Carreras.SingleOrDefault(x => x.Id == idCarrera);
                applicationDbContext.Carreras.Remove(item);
                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Carrera ObtenerCarreraPorID(int idCarrera)
        {
            try
            {
                //Carrera carrera = lstCarreras.FirstOrDefault(tmp => tmp.Id == idCarrera);
                var carrera = applicationDbContext.Carreras.SingleOrDefault(x => x.Id == idCarrera);
                return carrera;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Carrera> ObtenerTodosLasCarreras()
        {
            try
            {
                //return lstCarreras;
                return applicationDbContext.Carreras.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
