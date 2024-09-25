using System;
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

        protected void cmdEnviar_Click(object sender, EventArgs e)
        {
           
        }

        protected void CalendarNacimiento_SelectionChanged(object sender, EventArgs e)
        {
            DateTime calendarDateBirthDay = CalendarNacimiento.SelectedDate;
            DateTime calendarDateEntry = CalendarIngreso.SelectedDate;

            BirthdayIsBiggerEntry(calendarDateEntry, calendarDateBirthDay);
            BirthdayIsBiggerThanToday(calendarDateBirthDay);
            // Add calendarDateBirthday to txtNacimiento.
            txtNacimiento.Text = calendarDateBirthDay.ToString();
        }

        protected void CalendarIngreso_SelectionChanged(object sender, EventArgs e)
        {
            bool birthdayIsBigger;
            bool entryIsBigger;
            // Select calendarDateEntry
            DateTime calendarDateEntry = CalendarIngreso.SelectedDate;
            DateTime calendarDateBirthDay = CalendarNacimiento.SelectedDate;

            birthdayIsBigger = BirthdayIsBiggerEntry(calendarDateEntry, calendarDateBirthDay);
            entryIsBigger = EntryIsBiggerThanToday(calendarDateEntry);
            if (!birthdayIsBigger && !entryIsBigger)
                CalcSeniority();
            else
            {
                ResetSeniority();
            }

            txtIngreso.Text = calendarDateEntry.ToString();
        }

        private bool BirthdayIsBiggerEntry(DateTime calendarDateEntry, DateTime calendarDateBirthDay)
        {
            if (calendarDateEntry.ToString() != "01/01/0001 0:00:00" && calendarDateEntry <= calendarDateBirthDay)
            {
                lblError1.Visible = true;
                lblError1.Text = "La fecha de ingreso a la compañia no puede ser menor que la fecha de nacimiento";
                return true;
            }
            lblError1.Visible = false;
            return false;

           
        }
        private bool EntryIsBiggerThanToday(DateTime calendarEntry)
        {
            DateTime today = System.DateTime.Now;
            if (calendarEntry.ToString() != "01/01/0001 0:00:00" && calendarEntry > today)
            {
                lblError2.Visible = true;
                lblError2.Text = "La fecha de ingreso no puede ser mayor a la fecha de del dia hoy.";
                return true;
            }
            lblError2.Visible = false;
            return false;
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
        private void CalcSeniority()
        {
            DateTime dtToday = System.DateTime.Now;
            TimeSpan minus = dtToday - CalendarIngreso.SelectedDate;
            DateTime dtMinDate = new DateTime(1, 1, 1);

            txtYears.Text = ((dtMinDate + minus).Year - 1).ToString();
            txtMonth.Text = ((dtMinDate + minus).Month - 1).ToString();
            txtDay.Text = ((dtMinDate + minus).Day).ToString();
        }
        private void ResetSeniority()
        {
            txtYears.Text = "";
            txtMonth.Text = "";
            txtDay.Text = "";
        }

        protected void txtNacimiento_TextChanged(object sender, EventArgs e)
        {
            CalendarNacimiento.SelectedDate = Convert.ToDateTime(txtNacimiento.Text);
            CalendarNacimiento.VisibleDate = Convert.ToDateTime(txtNacimiento.Text);
        }
    }
}