using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e){

    }

    protected void ASPxGridView1_CustomColumnSort(object sender, DevExpress.Web.CustomColumnSortEventArgs e){
        CompareColumnValues(e);
    }

    protected void ASPxGridView1_CustomColumnGroup(object sender, DevExpress.Web.CustomColumnSortEventArgs e){
        CompareColumnValues(e);
    }

    private void CompareColumnValues(DevExpress.Web.CustomColumnSortEventArgs e) {
        if (e.Column.FieldName == "UnitPrice"){
            int res = 0;

            double x = Math.Floor(Convert.ToDouble(e.Value1) / 10);
            double y = Math.Floor(Convert.ToDouble(e.Value2) / 10);
            res = Comparer.Default.Compare(x, y);
            if (res < 0) res = -1;
            else if (res > 0) res = 1;
            if (res == 0 || (x > 9 && y > 9)) res = 0;

            e.Result = res;
            e.Handled = true;
        }
    }

    protected void ASPxGridView1_CustomGroupDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e){
        if (e.Column.FieldName == "UnitPrice"){
            double d = Math.Floor(Convert.ToDouble(e.Value) / 10);
            string displayText = string.Format("{0:c} - {1:c} ", d * 10, (d + 1) * 10);
            if (d > 9) displayText = string.Format(">= {0:c} ", 100);
            e.DisplayText = displayText;
        }
    }
}
