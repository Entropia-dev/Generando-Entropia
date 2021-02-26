using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Dao;
using System.Data;

namespace Negocio
{
    // el negocio va a estar llamando a los DAOS para obtener la informacion 
    public class NegocioProducto
    {
        public bool agregarProducto(string nombre)
        {
            int cantFilas = 0;

            Productos pro = new Productos();
            pro.set_Descripcion_Productos(nombre);

            DaoProducto dao = new DaoProducto();
            if (dao.existeProducto(pro) == false)
            {
                cantFilas = dao.agregarProducto(pro);
            }
            if (cantFilas == 1)
                return true;
            else
                return false;        
            
        }

        // metodo pide una tabla 
        public DataTable getTabla()
        {
            DaoProducto dao = new DaoProducto();
            return dao.getTablaProductos();
        }

        // metodo pide una categoria
        public Productos get(string Id_Productos)
        {
            DaoProducto dao = new DaoProducto();
            Productos pro = new Productos();
            pro.set_Id_Productos(Id_Productos);
            return dao.getProducto(pro);
        }

        // metodo eliminar un producto 
        public bool eliminarProducto(string nombre)
        {
            //validar si existe 
            DaoProducto dao = new DaoProducto();
            Productos pro = new Productos();
            pro.set_Descripcion_Productos(nombre);
            int op = dao.eliminarProducto(pro);
            if (op == 1)
                return true;
            else
                return false;

        }
        


    }
}
