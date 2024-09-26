using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GesPresta
{
    public partial class EmpleadosCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodEmp.Focus();
        }

        protected void CmdEnviar_Click(object sender, EventArgs e)
        {
           
        }

        protected void CalendarNacimiento_SelectionChanged(object sender, EventArgs e)
        {
            DateTime calendarDateBirthDay = CalendarNacimiento.SelectedDate;

            txtNacimiento.Text = calendarDateBirthDay.ToShortDateString();
            lblError4.Visible = false;
            // Checkeamos ambos, simplemente por el display de los textbox de error.
            FindDateError();

        }

        protected void txtNacimiento_TextChanged(object sender, EventArgs e)
        {
            // Si la fecha escrita por el usuario en el txt es valida.
            if (isDateValid(txtNacimiento.Text))
            {
                
                // Cambio la fecha seleccionada y la fecha visible.
                CalendarNacimiento.SelectedDate = Convert.ToDateTime(txtNacimiento.Text);
                CalendarNacimiento.VisibleDate = Convert.ToDateTime(txtNacimiento.Text);
                lblError4.Visible = false;
                // Checkeamos ambos, simplemente por el display de los textbox de error.
                FindDateError();
            }
            else
            {
                // Mostramos el error
                lblError4.Visible = true;
                ResetSeniority();
            }
        }

        protected void txtIngreso_TextChanged(object sender, EventArgs e)
        {
            // Si la fecha escrita por el usuario en el txt es valida.
            if (isDateValid(txtIngreso.Text))
            {
                // Cambio la fecha seleccionada y la fecha visible.
                CalendarIngreso.SelectedDate = Convert.ToDateTime(txtIngreso.Text);
                CalendarIngreso.VisibleDate = Convert.ToDateTime(txtIngreso.Text);
                lblError4.Visible = false;
                bool errorExists = FindDateError();
                if (!errorExists)
                {
                    CalcSeniority();
                }
                else
                {
                    ResetSeniority();
                }
            }
            else
            {
                HideLblErrors();
                // Mostramos el error
                lblError4.Visible = true;
                ResetSeniority();
            }
        }

        protected void CalendarIngreso_SelectionChanged(object sender, EventArgs e)
        {
            // SELECCIONAMOS LA FECHA DEL CALENDARIO.
            DateTime calendarDateEntry = CalendarIngreso.SelectedDate;

            txtIngreso.Text = calendarDateEntry.ToShortDateString();
            lblError4.Visible = false;
            // REVISAMOS SI EXISTEN ERRORES. EN CASO DE QUE LA FECHA DE INGRESO SEA MAYOR A LA FECHA DEL DIA DE HOY.
            // NO SE CALCULARÁ LA ANTIGUEDAD
            bool errorExists = FindDateError();

            if (!errorExists)
            {
                // CALCULO DE ANTIGUEDAD
                CalcSeniority();
            }
            else
            {
                ResetSeniority();
            }
        }
        protected void txtDay_TextChanged(object sender, EventArgs e)
        {
            CalcEntryDateWithSeniority();
        }
        protected void txtMonth_TextChanged(object sender, EventArgs e)
        {
            CalcEntryDateWithSeniority();
        }
        protected void txtYears_TextChanged(object sender, EventArgs e)
        {
            CalcEntryDateWithSeniority();
        }

        private bool FindDateError()
        {
            bool errorExist = false;
            DateTime dtCalendarDateBirthDay = CalendarNacimiento.SelectedDate;
            DateTime dtCalendarDateEntry = CalendarIngreso.SelectedDate;
            DateTime dtToday = System.DateTime.Now;

            HideLblErrors();
            if (dtCalendarDateBirthDay > dtCalendarDateEntry && txtIngreso.Text != "")
            {
                lblError1.Visible = true;
                lblError1.Text = "La fecha de ingreso a la compañia no puede ser menor que la fecha de nacimiento";
            }
            if (dtCalendarDateBirthDay > dtToday)
            {
                lblError3.Visible = true;
                lblError3.Text = "La fecha de nacimiento no puede ser mayor a la fecha de del dia hoy.";
            }
            if (dtCalendarDateEntry > dtToday)
            {
                lblError2.Visible = true;
                lblError2.Text = "La fecha de ingreso no puede ser mayor a la fecha de del dia hoy.";
                errorExist = true;
            }
            return errorExist;
        }

        
        private void CalcSeniority()
        {
            lblError5.Visible = false;
            DateTime dtToday = System.DateTime.Now;
            TimeSpan minus = dtToday - CalendarIngreso.SelectedDate;
            DateTime dtMinDate = new DateTime(1, 1, 1);

            txtYears.Text = ((dtMinDate + minus).Year - 1).ToString();
            txtMonth.Text = ((dtMinDate + minus).Month - 1).ToString();
            txtDay.Text = ((dtMinDate + minus).Day).ToString();
        }

        private void CalcEntryDateWithSeniority()
        {
            if (AreSeniorityInputsValid())
            {
                lblError5.Visible = false;
                DateTime dtToday = DateTime.Now;
                DateTime calculatedDate = dtToday.AddDays(int.Parse(txtDay.Text) * -1)
                                                 .AddMonths(int.Parse(txtMonth.Text) * -1)
                                                 .AddYears(int.Parse(txtYears.Text) * -1);
                txtIngreso.Text = calculatedDate.ToShortDateString();
                CalendarIngreso.SelectedDate = Convert.ToDateTime(txtIngreso.Text);
                CalendarIngreso.VisibleDate = Convert.ToDateTime(txtIngreso.Text);
            }
            else
            {
                lblError5.Visible = true;
            }
        }
        
        private void ResetSeniority()
        {
            // Reseteamos la antiguedad.
            txtYears.Text = "";
            txtMonth.Text = "";
            txtDay.Text = "";
        }
        private void HideLblErrors()
        {
            // Ocultamos los labels de error.
            lblError1.Visible = false;
            lblError3.Visible = false;
            lblError2.Visible = false;
        }



        protected bool isDateValid(String date)
        {
            // Set a pattern to follow
            string pattern = @"^(?:(?:(?:31\/(?:0[13578]|1[02]))|(?:30\/(?:0[13-9]|1[0-2]))|(?:29\/02\/(?:\d{2}(?:04|08|[2468][048]|[13579][26])|(?:[02468][048]00|[13579][26]00))))|(?:0[1-9]|1\d|2[0-8])\/(?:0[1-9]|1[0-2]))\/\d{4}$";
            Regex dateRegex = new Regex(pattern);

            return dateRegex.IsMatch(date);
        }

        private bool AreSeniorityInputsValid()
        {
            bool inputsAreValid = true;
            
            if (!int.TryParse(txtDay.Text, out int day) || !int.TryParse(txtMonth.Text, out int month) 
                || !int.TryParse(txtYears.Text, out int year))
            {
                inputsAreValid = false;
            }

            return inputsAreValid;
        }


    }
}