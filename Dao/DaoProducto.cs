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

        // me trae un registro de cada columna
        public Productos getProducto(Productos pro)
        {
            DataTable tabla = ds.ObtenerTabla("Productos", "Select * from Productos where Id_Productos=" + pro.get_Id_Productos());
            //pro.set_codigo_producto(Convert.ToInt32(tabla.Rows[0][0].ToString()));
            pro.set_Id_Productos(tabla.Rows[0][1].ToString());
            pro.set_Descripcion_Productos(tabla.Rows[0][2].ToString());
            return pro;
        }

        //metodo que verifica si la consulta existe
        public Boolean existeProducto(Productos pro)
        {
            String consulta = "Select * from Productos where Descripcion_Productos='" + pro.get_Descripcion_Productos() + "'";
            return ds.existe(consulta);
        }


        //metodo para obtener todos los productos 
        public DataTable getTablaProductos()
        {
            // List<Producto> lista = new List<Producto>();
            DataTable tabla = ds.ObtenerTabla("Productos", "Select * from Productos");
            return tabla;
        }

        public int eliminarProducto(Productos pro)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosProductoEliminar(ref comando, pro);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarProducto");
        }


        public int agregarProducto(Productos pro)
        {
            //ver codigo original, este metodo espera un string // yo agregue Convert.ToString para solucionarlo
            pro.set_Id_Productos(Convert.ToString(ds.ObtenerMaximo("SELECT* max(idProducto)FROM Productos"))+1);
            SqlCommand comando = new SqlCommand();
            ArmarParametrosProductoAgregar(ref comando, pro);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarProducto");
        }
        
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
