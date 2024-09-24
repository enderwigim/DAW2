using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

        protected void cmdEnviar_Click(object sender, EventArgs e)
        {
           
        }

        protected void CalendarNacimiento_SelectionChanged(object sender, EventArgs e)
        {
            DateTime calendarDateBirthDay = CalendarNacimiento.SelectedDate;
            DateTime calendarDateEntry = CalendarIngreso.SelectedDate;

            BirthdayIsBiggerEntry(calendarDateEntry, calendarDateBirthDay);
            // Add calendarDateBirthday to txtNacimiento.
            txtNacimiento.Text = calendarDateBirthDay.ToString();
        }

        protected void CalendarIngreso_SelectionChanged(object sender, EventArgs e)
        {
            // Select calendarDateEntry
            DateTime calendarDateEntry = CalendarIngreso.SelectedDate;
            DateTime calendarDateBirthDay = CalendarNacimiento.SelectedDate;

            BirthdayIsBiggerEntry(calendarDateEntry, calendarDateBirthDay);

            txtIngreso.Text = calendarDateEntry.ToString();
        }

        private void BirthdayIsBiggerEntry(DateTime calendarDateEntry, DateTime calendarDateBirthDay)
        {
            if (calendarDateEntry.ToString() != "01/01/0001 0:00:00" && calendarDateEntry < calendarDateBirthDay)
            {
                lblError1.Visible = true;
                lblError1.Text = "La fecha de ingreso a la compañia no puede ser menor que la fecha de nacimiento";
            }
            else
            {
                lblError1.Visible = false;
            }
           
        }
        private void  BirthdayIsBiggerThanToday(DateTime calendarDateBirthDay)
        {
            DateTime today = System.DateTime.Now;
            if (calendarDateBirthDay.ToString() != "01/01/0001 0:00:00" && calendarDateBirthDay > today)
            {
                lblError3.Visible = true;
                lblError3.Text = "La fecha de nacimiento no puede ser mayor a la fecha de del dia hoy.";
            }
            else
            {
                lblError3.Visible = false;
            }
        }

        private void EntryIsBiggerThanToday(DateTime calendarEntry)
        {
            DateTime today = System.DateTime.Now;
            if (calendarEntry.ToString() != "01/01/0001 0:00:00" && calendarEntry > today)
            {
                lblError3.Visible = true;
                lblError3.Text = "La fecha de ingreso no puede ser mayor a la fecha de del dia hoy.";
            }
            else
            {
                lblError3.Visible = false;
            }
        }
    }
}