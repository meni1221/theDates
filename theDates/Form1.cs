using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//יבוא של ספריית XML
using System.Xml;
using static System.Windows.Forms.LinkLabel;
using System.Xml.Linq;
using System.Collections;

namespace theDates
{
    public partial class Form1 : Form
    {
        XmlDocument xmlDocument; // משתנה לאחסון מסמך ה-XML
        string pathName = Directory.GetCurrentDirectory() + "\\theDatesData.xml"; // מחרוזת שמייצגת את הנתיב לקובץ ה-XML
            //יצירת אלמנט בשם תוצאה
            XmlNode result;
        public Form1()
        {
            InitializeComponent();
            xmlDocument = new XmlDocument(); // יצירת אובייקט XML חדש

            if (File.Exists(pathName)) // בדיקה אם קובץ ה-XML קיים
            {
                try
                {
                    xmlDocument.Load(pathName); // טעינת קובץ ה-XML אם קיים
                }
                catch (Exception ex) // במקרה של שגיאה בטעינת הקובץ
                {
                    MessageBox.Show("Error loading XML file: " + ex.Message); // הצגת הודעת שגיאה
                }
            }
            else // אם קובץ ה-XML לא קיים
            {
                XmlNode root = xmlDocument.CreateElement("Querys"); // יצירת אלמנט שורש "Drinks"

                xmlDocument.AppendChild(root); // הוספת אלמנט השורש למסמך ה-XML
                xmlDocument.Save(pathName); // שמירת קובץ ה-XML
            }
        }
        //פונקציה לכתיבת התאריך בכתובה
        private void btnSave_Click(object sender, EventArgs e)
        {
            result = xmlDocument.CreateElement("result");
            //יצירת אלמנט בשם קווארי
            XmlNode Query = xmlDocument.CreateElement("Query");
            //יצירת אלמנט בשם יום
            XmlNode day = xmlDocument.CreateElement("day");
            //יצירת אלמנט בשם יום בחודש
            XmlNode day_of_the_month = xmlDocument.CreateElement("day_of_the_month");
            //יצירת אלמנט בשם חודש
            XmlNode month = xmlDocument.CreateElement("month");
            //יצירת אלמנט בשם שנה
            XmlNode year = xmlDocument.CreateElement("year");


            day.InnerText = cmbDay.Text; // קביעת יום
            day_of_the_month.InnerText = cmbDayOfTheMonth.Text; // קביעת היום בחודש
            month.InnerText = cmbMonth.Text; // קביעת החודש
            year.InnerText = cmbYear.Text; // קביעת השנה
            result.InnerText = FnDay() + FnDayMonth() + FnMonth() + FnYear();

            // הוספת האלמנטים לאלמנט "query"
            xmlDocument.FirstChild.AppendChild(Query);
            Query.AppendChild(day);
            Query.AppendChild(day_of_the_month);
            Query.AppendChild(month);
            Query.AppendChild(year);
        }

        private string FnDay()
        {
            string day = "";
            switch (cmbDay.Text) // בדיקת שם התגית ועדכון המשתנה המתאים
            {
                case "ראשון": // 
                    day = cmbDay.Text; 
                    break;
                case "שני": 
                    day = cmbDay.Text; 
                    break;
                case "שלישי": 
                    day = cmbDay.Text; 
                    break;
                case "רביעי": 
                    day = cmbDay.Text; 
                    break;
                case "חמישי": 
                    day = cmbDay.Text;
                    break;
                case "שישי": 
                    day = cmbDay.Text; 
                    break;
                case "שבת":
                    day = cmbDay.Text; 
                    break;
            }
            return day;
        }
        private string FnDayMonth()
        {
            string day_of_the_month = "";
            switch (cmbDayOfTheMonth.Text) // בדיקת שם התגית ועדכון המשתנה המתאים
            {
                case "1": 
                    day_of_the_month = cmbDay.Text; 
                    break;
                case "2": 
                    day_of_the_month = cmbDay.Text; 
                    break;
                case "3": 
                    day_of_the_month = cmbDay.Text; 
                    break;
                case "4": 
                    day_of_the_month = cmbDay.Text; 
                    break;
                case "5": 
                    day_of_the_month = cmbDay.Text; 
                    break;
                case "6": 
                    day_of_the_month = cmbDay.Text;
                    break;
                case "7": 
                    day_of_the_month = cmbDay.Text; 
                    break;
                case "8":
                    day_of_the_month = cmbDay.Text;
                    break;
                case "9":
                    day_of_the_month = cmbDay.Text;
                    break;
                case "10":
                    day_of_the_month = cmbDay.Text;
                    break;
                case "11":
                    day_of_the_month=cmbDay.Text;
                    break;



            }
            return day_of_the_month;
        }

        private string FnMonth()
        {
            return "";
        }

        private string FnYear()
        {
            return "";

        }

        // פונקציה להצגת התוצאה

        // פונקציה לניקוי כל הקונטרולים
        private void CleanAllControls()
        {
            foreach (Control ctr in Controls) // מעבר על כל הקונטרולים בטופס
            {
                if (ctr is TextBox) ctr.Text = ""; // איפוס טקסט בוקסים
            }
        }

    }
}
