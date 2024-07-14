using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report
{
    public partial class Charts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Now Create a class in domain and a class in DAL for fetching data in database ...

            var list = DAL.dalViews.FetchList();

            // Now check -- Data Fetched successfully
            // Now assign this data to chart
            // For this purpose we define 2 variables at front end then assign that labels and data from back end ...

            if (list.Count > 0)
            {
                string chartData = "";
                string views = "";
                string labels = "";

                chartData += "<script>";

                foreach (var item in list)
                {
                    views += item.TotalViews + ",";
                    labels += "\"" + item.ViewsMonth + "\",";
                }

                views = views.Substring(0, views.Length - 1);
                labels = labels.Substring(0, labels.Length - 1);

                chartData += " chartLabels = ["+labels+"]; chartData = ["+views+"]";

                chartData += "</script>";

                ltChartData.Text = chartData;

                // Now Run and Check Data -- Remove last coma and also show heading in string format

                // Data showed successfully - Now Remove Dollar sign and change heading
            }

        }
    }
}