using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;


namespace Dao
{
    public class DaoProducto
    {
        AccesoDatos ds = new AccesoDatos();
        public Productos getProducto(Productos pro)
        {
            DataTable tabla = ds.ObtenerTabla("Productos", "Select * from Productos where Id_Productos=" + pro.get_Id_Productos());
            //pro.set_codigo_producto(Convert.ToInt32(tabla.Rows[0][0].ToString()));
            pro.set_Id_Productos(tabla.Rows[0][1].ToString());
            pro.set_Descripcion_Productos(tabla.Rows[0][2].ToString());
            return pro;
        }

        public Boolean existeProducto(Productos pro)
        {
            String consulta = "Select * from producto where NombreProducto='" + pro.get_codigo_producto() + "'";
            return ds.existe(consulta);
        }

        public DataTable getTablaCategorias()
        {
            // List<Producto> lista = new List<Producto>();
            DataTable tabla = ds.ObtenerTabla("Producto", "Select * from producto");
            return tabla;
        }

        public int eliminarProducto(Productos pro)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosProductoEliminar(ref comando, pro);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarProducto");
        }


        /*public int agregarProducto(Productos pro)
        {

            //pro.set_codigo_producto(ds.ObtenerMaximo("SELECT max(idProducto) FROM Producto") + 1);
            SqlCommand comando = new SqlCommand();
            ArmarParametrosProductoAgregar(ref comando, pro);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarProducto");
        }
        */
        private void ArmarParametrosProductoEliminar(ref SqlCommand Comando, Productos pro)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDPRODUCTO", SqlDbType.Int);
            SqlParametros.Value = pro.get_codigo_producto();
        }

        private void ArmarParametrosProductoAgregar(ref SqlCommand Comando, Productos pro)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDPRODUCTO", SqlDbType.Int);
            SqlParametros.Value = pro.get_codigo_producto();
            SqlParametros = Comando.Parameters.Add("@NOMBREPRO", SqlDbType.VarChar);
            SqlParametros.Value = pro.get_nombre_producto();
        }


        
    }
}
