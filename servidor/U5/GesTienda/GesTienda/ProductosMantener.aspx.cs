using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GesTienda
{
    public partial class ProductosMantener : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            FnDeshabilitarControles();
            string StrIdProducto = grdProductos.SelectedRow.Cells[1].Text;
            string StrCadenaConexion =
               ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string StrComandoSql = "SELECT IdProducto,DesPro,PrePro,IdUnidad,PRODUCTO.IdTipo,DesTip " +
                        " FROM PRODUCTO INNER JOIN TIPO ON PRODUCTO.IdTipo = TIPO.IdTipo " +
                        "WHERE PRODUCTO.IdProducto = '" + StrIdProducto + "';";
            using (SqlConnection conexion = new SqlConnection(StrCadenaConexion))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = conexion.CreateCommand();
                    comando.CommandText = StrComandoSql;
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        txtIdProducto.Text = reader.GetString(0);
                        txtDesPro.Text = reader.GetString(1);
                        txtPrePro.Text = string.Format("{0:C}", reader.GetDecimal(2));
                        ddlIdUnidad.SelectedItem.Selected = false;
                        ddlIdUnidad.SelectedItem.Text = reader.GetString(3);
                        ddlIdTipo.SelectedItem.Selected = false;
                        ddlIdTipo.SelectedItem.Text = reader.GetString(5);
                    }
                    else
                    {
                        lblMensajes.Text = "No existen registros resultantes de la consulta";
                    }
                    reader.Close();
                    btnNuevo.Visible = true;
                    btnEditar.Visible = true;
                    btnEliminar.Visible = true;
                    btnInsertar.Visible = false;
                    btnModificar.Visible = false;
                    btnBorrar.Visible = false;
                    btnCancelar.Visible = false;
                }
                catch (SqlException ex)
                {
                    string StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
                    StrError = StrError + "<div>Código: " + ex.Number + "</div>";
                    StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
                    lblMensajes.Text = StrError;
                    return;
                }
            }
        }
        protected void FnDeshabilitarControles()
        {
            txtIdProducto.Enabled = false;
            txtDesPro.Enabled = false;
            txtPrePro.Enabled = false;
            ddlIdUnidad.Enabled = false;
            ddlIdTipo.Enabled = false;
        }

        protected void FnHabilitarControles()
        {
            txtIdProducto.Enabled = true;
            txtDesPro.Enabled = true;
            txtPrePro.Enabled = true;
            ddlIdUnidad.Enabled = true;
            ddlIdTipo.Enabled = true;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnInsertar.Visible = true;
            btnModificar.Visible = false;
            btnBorrar.Visible = false;
            btnCancelar.Visible = true;
            txtIdProducto.Text = "";
            txtDesPro.Text = "";
            txtPrePro.Text = Convert.ToString(0);
            ddlIdUnidad.DataBind();      // Vuelve a enlazar el control para que se actualicen los datos 
            ddlIdTipo.DataBind();
            grdProductos.SelectedIndex = -1;
            FnHabilitarControles();
            txtIdProducto.Focus();
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            String strIdProducto, strDescripcion, strIdUnidad, strIdTipo;
            Decimal dcPrecio;

            strIdProducto = txtIdProducto.Text;
            strDescripcion = txtDesPro.Text;
            dcPrecio = Convert.ToDecimal(txtPrePro.Text);
            strIdUnidad = ddlIdUnidad.SelectedItem.Text;
            strIdTipo = ddlIdTipo.SelectedItem.Value;
            string StrCadenaConexion =
               ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string StrComandoSql = "INSERT PRODUCTO " +
                       "(IdProducto,DesPro,PrePro,IdUnidad,IdTipo) VALUES (" +
                       "'" + strIdProducto + "','" + strDescripcion +
                       "'," + FnComaPorPunto(dcPrecio) +
                       ",'" + strIdUnidad + "','" + strIdTipo + "');";
            using (SqlConnection conexion = new SqlConnection(StrCadenaConexion))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = conexion.CreateCommand();
                    comando.CommandText = StrComandoSql;
                    int inRegistrosAfectados = comando.ExecuteNonQuery();
                    if (inRegistrosAfectados == 1)
                        lblMensajes.Text = "Registro insertado correctamente";
                    else
                        lblMensajes.Text = "Error al insertar el registro";
                    btnNuevo.Visible = true;

                    btnEditar.Visible = true;
                    btnEliminar.Visible = false;
                    btnInsertar.Visible = false;
                    btnModificar.Visible = false;
                    btnBorrar.Visible = false;
                    btnCancelar.Visible = false;
                }
                catch (SqlException ex)
                {
                    string StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
                    StrError = StrError + "<div>Código: " + ex.Number + "</div>";
                    StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
                    lblMensajes.Text = StrError;
                    return;
                }
            }
            grdProductos.DataBind();         // Vuelve a enlazar el GridView para que se actualicen los datos 
            grdProductos.SelectedIndex = -1;
            FnDeshabilitarControles();
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            // PREPARAMOS LOS PARAMETROS
            lblMensajes.Text = "";
            String strIdProducto, strDescripcion, strIdUnidad, strIdTipo;
            Decimal dcPrecio;

            strIdProducto = txtIdProducto.Text;
            strDescripcion = txtDesPro.Text;
            if (decimal.TryParse(FnPuntoPorComa(txtPrePro.Text), out decimal precio))
            {
                dcPrecio = precio;

            } else
            {
                return;
            }

            strIdUnidad = ddlIdUnidad.SelectedItem.Text;
            strIdTipo = ddlIdTipo.SelectedItem.Value;

            // PREPARAMOS LA CADENA DE CONEXION
            string StrCadenaConexion =
              ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // UPDATE
            string comandoSQLUpdate = $"UPDATE PRODUCTO " +
                $"SET Despro = '{strDescripcion}', PrePro = {FnComaPorPunto(dcPrecio)}, IdUnidad = '{strIdUnidad}', IdTipo = '{strIdTipo}'" +
                $"WHERE IdProducto = '{strIdProducto}'";
            // CONECTAMOS
            using(SqlConnection con = new SqlConnection(StrCadenaConexion))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = comandoSQLUpdate;
                    int registrosAfectados = cmd.ExecuteNonQuery();
                    if (registrosAfectados == 1)
                    {
                        lblMensajes.Text = "Cambios Realizados Correctamente";
                    }
                    else
                    {
                        lblMensajes.Text = "Error al actualizar el registro";
                        
                    }
                }
                catch(SqlException ex)
                {
                    string StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
                    StrError = StrError + "<div>Código: " + ex.Number + "</div>";
                    StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
                    lblMensajes.Text = StrError;
                    return;
                }
                grdProductos.DataBind();         // Vuelve a enlazar el GridView para que se actualicen los datos 
                grdProductos.SelectedIndex = -1;
                FnDeshabilitarControles();
                btnNuevo.Visible = true;
                btnEditar.Visible = true;
                btnEliminar.Visible = true;
                btnInsertar.Visible = false;
                btnModificar.Visible = false;
                btnBorrar.Visible = false;
                btnCancelar.Visible = false;
            }

        }
        protected string FnComaPorPunto(decimal Numero)
        {
            string StrNumero = Convert.ToString(Numero);
            string stNumeroConPunto = String.Format("{0}", StrNumero.Replace(',', '.'));
            return (stNumeroConPunto);
        }
        protected string FnPuntoPorComa(String numero)
        {
            string stNumeroConPunto = numero.Replace('.', ',');
            return (stNumeroConPunto);
        }

        protected void FnResetTxtBox()
        {
            txtIdProducto.Text = "";
            txtDesPro.Text = "";
            txtPrePro.Text = "";

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            btnNuevo.Visible = true;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnInsertar.Visible = false;
            btnModificar.Visible = false;
            btnBorrar.Visible = false;
            btnCancelar.Visible = false;
            txtIdProducto.Text = "";
            txtDesPro.Text = "";
            txtPrePro.Text = Convert.ToString(0);
            ddlIdUnidad.DataBind();
            ddlIdTipo.DataBind();
            grdProductos.SelectedIndex = -1;
            FnDeshabilitarControles();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            // HABILITAR TODOS LOS CONTROLES EXCEPTO EL txtIdProducto.
            FnHabilitarControles();
            txtIdProducto.Enabled = false;

            // GESTIONAMOS LOS BOTONES
            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnInsertar.Visible = false;
            btnModificar.Visible = true;
            btnBorrar.Visible = false;
            btnCancelar.Visible = true;
        }

        

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            String strIdProducto;
            strIdProducto = txtIdProducto.Text;

            // PREPARAMOS LA CADENA DE CONEXION
            string StrCadenaConexion =
              ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // UPDATE
            string comandoSQLDelete = $"DELETE FROM PRODUCTO WHERE IdProducto = '{strIdProducto}'";

            // REALIZAMOS LA CONEXIÓN
            using (SqlConnection con = new SqlConnection(StrCadenaConexion))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = comandoSQLDelete;
                    int registrosAfectados = cmd.ExecuteNonQuery();
                    if (registrosAfectados == 1)
                    {
                        lblMensajes.Text = "El producto ha sido borrado correctamente";
                    } else
                    {
                        lblMensajes.Text = "Error al borrar el registro";
                    }

                }
                catch (SqlException ex)
                {
                    string StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
                    StrError = StrError + "<div>Código: " + ex.Number + "</div>";
                    StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
                    lblMensajes.Text = StrError;
                    return;
                }
                grdProductos.DataBind();         // Vuelve a enlazar el GridView para que se actualicen los datos 
                grdProductos.SelectedIndex = -1;
                FnDeshabilitarControles();
                FnResetTxtBox();
                btnNuevo.Visible = true;
                btnEditar.Visible = true;
                btnEliminar.Visible = false;
                btnInsertar.Visible = false;
                btnModificar.Visible = false;
                btnBorrar.Visible = false;
                btnCancelar.Visible = false;
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            // GESTIONAMOS LOS BOTONES
            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnInsertar.Visible = false;
            btnModificar.Visible = false;
            btnBorrar.Visible = true;
            btnCancelar.Visible = true;
        }
    }
}