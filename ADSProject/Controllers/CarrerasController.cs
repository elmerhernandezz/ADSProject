﻿using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADSProject.Controllers
{
    [Route("api/carreras/")]
    public class CarrerasController : ControllerBase
    {
        private readonly ICarrera carrera;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public CarrerasController(ICarrera carrera)
        {
            this.carrera = carrera;
        }

        [HttpPost("agregarCarrera")]
        public ActionResult<string> AgregarCarrera([FromBody] Carrera carrera)
        {
            try
            {
                int contador = this.carrera.AgregarCarrera(carrera);

                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro insertado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al insertar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("actualizarCarrera/{idCarrera}")]
        public ActionResult<string> ActualizarCarrera(int idCarrera, [FromBody] Carrera carrera)
        {
            try
            {
                int contador = this.carrera.ActualizarCarrera(idCarrera, carrera);
                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro actualizado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al actualizar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("eliminarCarrera/{idCarrera}")]
        public ActionResult<string> EliminarCarrera(int idCarrera)
        {
            try
            {
                bool eliminado = this.carrera.EliminarCarrera(idCarrera);

                if (eliminado)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro eliminado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al eliminar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("obtenerCarreraPorID/{idCarrera}")]
        public ActionResult<Carrera> ObtenerCarreraPorID(int idCarrera)
        {
            try
            {
                Carrera carrera = this.carrera.ObtenerCarreraPorID(idCarrera);
                if (carrera != null)
                {
                    return Ok(carrera);
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontraron datos del estudiante";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("obtenerCarreras")]
        public ActionResult<List<Carrera>> ObtenerCarreras()
        {
            try
            {
                List<Carrera> lstCarreras = this.carrera.ObtenerTodosLasCarreras();

                return Ok(lstCarreras);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
