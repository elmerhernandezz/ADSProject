using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class CarreraRepository : ICarrera
    {
        private List<Carrera> lstCarreras = new List<Carrera>
        {
            new Carrera{ Id = 1, Codigo = "I04",
            Nombre = "Ing. Sistemas"
            }
        };

        public int ActualizarCarrera(int idCarrera, Carrera Carrera)
        {
            try
            {
                int indice = lstCarreras.FindIndex(tmp => tmp.Id == idCarrera);

                lstCarreras[indice] = Carrera;

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
                if (lstCarreras.Count > 0)
                {
                    carrera.Id = lstCarreras.Last().Id + 1;
                }

                lstCarreras.Add(carrera);

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
                int indice = lstCarreras.FindIndex(tmp => tmp.Id == idCarrera);

                lstCarreras.RemoveAt(indice);

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
                Carrera carrera = lstCarreras.FirstOrDefault(tmp => tmp.Id == idCarrera);
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
                return lstCarreras;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
