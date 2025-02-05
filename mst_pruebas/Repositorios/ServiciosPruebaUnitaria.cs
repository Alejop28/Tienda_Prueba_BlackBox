using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;

namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class ServiciosPruebaUnitaria
    {
        private IServiciosRepositorio? iRepositorio = null;
        private Servicios? entidad = null;

        public ServiciosPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=DESKTOP-S2MM97P\\DEV;database=db_Tienda_MASCOTAS;Integrated Security=True;TrustServerCertificate=True;";
            iRepositorio = new ServiciosRepositorio(conexion);
        }

        [TestMethod]
        public void Ejecutar()
        {
            Guardar();
            Listar();
            Buscar();
            Modificar();
            Borrar();


        }

        private void Guardar()
        {
            entidad = new Servicios()
            {
                Precio=32000.4m,
                Tipo_Servicio="Ba�o",
                Descripcion="con jabon sin sal",

            };
            entidad = iRepositorio!.Guardar(entidad);
            Assert.IsTrue(entidad.Id != 0);
        }

        private void Listar()
        {
            var lista = iRepositorio!.Listar();
            Assert.IsTrue(lista.Count > 0);
        }
        public void Buscar()
        {
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }
        private void Modificar()
        {
            entidad!.Tipo_Servicio = "Ba�o y corte";
            entidad = iRepositorio!.Modificar(entidad!);

            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }

        private void Borrar()
        {
            entidad = iRepositorio!.Borrar(entidad!);

            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count == 0);
        }

    }
    
}
