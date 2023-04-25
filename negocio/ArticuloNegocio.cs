using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, IdCategoria, IdMarca from ARTICULOS A, CATEGORIAS C, MARCAS M where IdMarca = M.Id and IdCategoria = C.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articuloAux = new Articulo();
                    int id = datos.Lector.GetInt32(0);
                    articuloAux.Id = id;
                    //articuloAux.Id = (int)datos.Lector["A.Id"];
                    articuloAux.Codigo = (string)datos.Lector["Codigo"];
                    articuloAux.Nombre = (string)datos.Lector["Nombre"];
                    string descripcion = datos.Lector.GetString(3);
                    //articuloAux.Descripcion = (string)datos.Lector["A.Descripcion"];
                    articuloAux.Descripcion = descripcion;
                    articuloAux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    articuloAux.Precio =(decimal)datos.Lector["Precio"];
                    articuloAux.Categoria = new Categorias();
                    articuloAux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    articuloAux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    articuloAux.Marca = new Marcas();
                    articuloAux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    articuloAux.Marca.Id = (int)datos.Lector["IdMarca"];

                    lista.Add(articuloAux);

                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update ARTICULOS set Codigo=@codigo, Nombre=@nombre, Descripcion=@descripcion, ImagenUrl=@urlimagen, Precio=@precio, IdMarca=@marca, IdCategoria=@categoria where Id=@id");
                datos.setearParametros("@codigo", articulo.Codigo);
                datos.setearParametros("@nombre", articulo.Nombre);
                datos.setearParametros("@descripcion", articulo.Descripcion);
                datos.setearParametros("@urlimagen", articulo.UrlImagen);
                datos.setearParametros("@precio", articulo.Precio);
                datos.setearParametros("@marca", articulo.Marca.Id);
                datos.setearParametros("@categoria", articulo.Categoria.Id);
                datos.setearParametros("@id", articulo.Id);

                datos.ejecutarLectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion();}
        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, idMarca, idCategoria, ImagenUrl, Precio)values(@codigo, @nombre, @descripcion, @idMarca , @idCategoria, @urlImagen, @precio)");
                datos.setearParametros("@codigo", nuevo.Codigo);
                datos.setearParametros("@nombre", nuevo.Nombre);
                datos.setearParametros("@descripcion", nuevo.Descripcion);
                datos.setearParametros("@idMarca", nuevo.Marca.Id);
                datos.setearParametros("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametros("@urlImagen", nuevo.UrlImagen);
                datos.setearParametros("@precio", nuevo.Precio);
                datos.insertarDatos();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion();}
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from ARTICULOS where id = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarLectura();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.cerrarConexion();}

        }

        public List<Articulo> filtro(string campo, string criterio, string parametroA, string parametroB)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();
            try
            {
                string consulta = "Select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, IdCategoria, IdMarca from ARTICULOS A, CATEGORIAS C, MARCAS M where IdMarca = M.Id and IdCategoria = C.Id and ";

                if(campo == "Codigo" || campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += campo + " like '" + parametroA + "%'";
                            break;
                        case "Contiene":
                            consulta += campo + " like '%" + parametroA + "%'";
                            break;
                        case "Termina con":
                            consulta += campo + " like '%" + parametroA + "'";
                            break;
                    }
                }
                else if(campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio >=" + parametroA;
                            break;

                        case "Entre":
                            consulta += "Precio >= " + parametroA + " and Precio <= " + parametroB;
                            break;

                        case "Menor a":
                            consulta += "Precio <=" + parametroA;
                            break;
                    }

                }
                else
                {
                    switch (criterio)
                    {
                        case "Todos":
                            consulta += "M.Descripcion = '" + parametroA + "'";
                            break;
                        case "Categoria":
                            consulta += "M.Descripcion = '" + parametroA + "'" + " and C.Descripcion = '" + parametroB + "'";
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articuloAux = new Articulo();
                    int id = datos.Lector.GetInt32(0);
                    articuloAux.Id = id;
                    articuloAux.Codigo = (string)datos.Lector["Codigo"];
                    articuloAux.Nombre = (string)datos.Lector["Nombre"];
                    string descripcion = datos.Lector.GetString(3);
                    articuloAux.Descripcion = descripcion;
                    articuloAux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    articuloAux.Precio = (decimal)datos.Lector["Precio"];
                    articuloAux.Categoria = new Categorias();
                    articuloAux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    articuloAux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    articuloAux.Marca = new Marcas();
                    articuloAux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    articuloAux.Marca.Id = (int)datos.Lector["IdMarca"];

                    lista.Add(articuloAux);
                }

                return lista;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


    }
}
