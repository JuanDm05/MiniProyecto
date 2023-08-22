using MiniProyecto.Models;
using System.Data.SqlClient;
using System.Data;

namespace MiniProyecto.Datos
{
    public class AsesorDatos
    {
        public List<AsesorModel> Listar()
        {
            var oLista = new List<AsesorModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_ListarAsesor", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new AsesorModel()
                        {
                            NroEmpleado = Convert.ToInt32(dr["IdContacto"]),
                            Nombres = dr["Nombre"].ToString(),
                            ApePat = dr["ApePat"].ToString(),
                            ApeMat = dr["ApeMat"].ToString(),
                            CURP = dr["CURP"].ToString(),
                            RFC = dr["RFC"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            NivEstudios = dr["NivEstudios"].ToString(),


                        });
                    }
                }
            }
            return oLista;
        }
        public AsesorModel ObtenerAsesor(int NroEmpleado)
        {
            var oAsesor = new AsesorModel();
            var cn = new Conexion();
            using (var conexion = new SqlCommand("sp_ObtenerAsesor", conexion);
    }
}
