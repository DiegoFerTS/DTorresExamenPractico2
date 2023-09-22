using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Disco
    {
        public static ML.Result Add(ML.Disco disco)
        {
            ML.Result resultado = new ML.Result();

            try
            {
                using (DL.DTorresExamenPractico2Entities conexion = new DL.DTorresExamenPractico2Entities())
                {
                    var query = conexion.DiscoAdd(disco.Titulo, 
                                                    disco.Artista,
                                                    disco.GeneroMusical,
                                                    disco.Duracion,
                                                    disco.Anio,
                                                    disco.Distribuidora,
                                                    disco.Ventas,
                                                    disco.Disponibilidad);

                    if (query > 0)
                    {
                        resultado.Correct = true;
                    } else
                    {
                        resultado.Correct = false;
                        resultado.ErrorMessage = "No se pudo registrar el disco " + disco.Titulo + ".";
                    }
                }
            } catch (Exception ex)
            {
                resultado.Correct = false;
                resultado.ErrorMessage = ex.InnerException.Message;
                resultado.Ex = ex;
            }

            return resultado;
        }

        public static ML.Result Update(ML.Disco disco)
        {
            ML.Result resultado = new ML.Result();

            try
            {
                using (DL.DTorresExamenPractico2Entities conexion = new DL.DTorresExamenPractico2Entities())
                {
                    var query = conexion.DiscoUpdate(disco.Id,
                                                    disco.Titulo,
                                                    disco.Artista,
                                                    disco.GeneroMusical,
                                                    disco.Duracion,
                                                    disco.Anio,
                                                    disco.Distribuidora,
                                                    disco.Ventas,
                                                    disco.Disponibilidad);

                    if (query > 0)
                    {
                        resultado.Correct = true;
                    }
                    else
                    {
                        resultado.Correct = false;
                        resultado.ErrorMessage = "No se pudo actualizar el disco " + disco.Titulo + ".";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Correct = false;
                resultado.ErrorMessage = ex.InnerException.Message;
                resultado.Ex = ex;
            }

            return resultado;
        }

        public static ML.Result Delete(int idDisco)
        {
            ML.Result resultado = new ML.Result();

            try
            {
                using (DL.DTorresExamenPractico2Entities conexion = new DL.DTorresExamenPractico2Entities())
                {
                    var query = conexion.DiscoDelete(idDisco);

                    if (query > 0)
                    {
                        resultado.Correct = true;
                    }
                    else
                    {
                        resultado.Correct = false;
                        resultado.ErrorMessage = "No se pudo eliminar el disco con id " + idDisco + ".";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Correct = false;
                resultado.ErrorMessage = ex.InnerException.Message;
                resultado.Ex = ex;
            }

            return resultado;
        }

        public static ML.Result GetAll()
        {
            ML.Result resultado = new ML.Result();

            try
            {
                using (DL.DTorresExamenPractico2Entities conexion = new DL.DTorresExamenPractico2Entities())
                {
                    var query = conexion.DiscoGetAll().ToList();

                    if (query != null)
                    {
                        resultado.Objects = new List<object>();

                        foreach (var discoResult in query)
                        {
                            ML.Disco disco = new ML.Disco();
                            
                            disco.Id = discoResult.Id;
                            disco.Titulo = discoResult.Titulo;
                            disco.Artista = discoResult.Artista;
                            disco.GeneroMusical = discoResult.GeneroMusical;
                            disco.Duracion = discoResult.Duracion.Value;
                            disco.Anio = discoResult.Anio.Value;
                            disco.Distribuidora = discoResult.Distribuidora;
                            disco.Ventas = discoResult.Ventas.Value;
                            disco.Disponibilidad = discoResult.Disponibilidad.Value;

                            resultado.Objects.Add(disco);
                        }

                        resultado.Correct = true;
                    }
                    else
                    {
                        resultado.Correct = false;
                        resultado.ErrorMessage = "No se encontraron discos.";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Correct = false;
                resultado.ErrorMessage = ex.InnerException.Message;
                resultado.Ex = ex;
            }

            return resultado;
        }

        public static ML.Result GetById(int idDisco)
        {
            ML.Result resultado = new ML.Result();

            try
            {
                using (DL.DTorresExamenPractico2Entities conexion = new DL.DTorresExamenPractico2Entities())
                {
                    var query = conexion.DiscoGetById(idDisco).FirstOrDefault();

                    if (query != null)
                    {                                        
                        ML.Disco disco = new ML.Disco();
                        
                        disco.Id = query.Id;
                        disco.Titulo = query.Titulo;
                        disco.Artista = query.Artista;
                        disco.GeneroMusical = query.GeneroMusical;
                        disco.Duracion = query.Duracion.Value;
                        disco.Anio = query.Anio.Value;
                        disco.Distribuidora = query.Distribuidora;
                        disco.Ventas = query.Ventas.Value;
                        disco.Disponibilidad = query.Disponibilidad.Value;

                        resultado.Object = disco;
                        
                        resultado.Correct = true;
                    }
                    else
                    {
                        resultado.Correct = false;
                        resultado.ErrorMessage = "No se encontro el disco con el id " + idDisco + ".";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Correct = false;
                resultado.ErrorMessage = ex.InnerException.Message;
                resultado.Ex = ex;
            }

            return resultado;
        }
    }
}
