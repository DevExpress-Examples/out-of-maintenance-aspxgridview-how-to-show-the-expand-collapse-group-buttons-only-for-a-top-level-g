using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;

public partial class _Default : System.Web.UI.Page
{
    protected void grid_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
    {
        ASPxGridView g = sender as ASPxGridView;
        int groupIndex = g.GetRowLevel(e.VisibleIndex);
        if ((e.RowType == GridViewRowType.Group) && (groupIndex > 0))
        {

            if (e.Row.Cells.Count > groupIndex && e.Row.Cells[groupIndex] != null && e.Row.Cells[groupIndex].Controls.Count > 0)
                e.Row.Cells[groupIndex].Controls[0].Visible = false;
        }
    }
    protected void grid_BeforeGetCallbackResult(object sender, EventArgs e)
    {
        ASPxGridView g = sender as ASPxGridView;
        for (int i = 0; i < g.VisibleRowCount; i++)
        {
            if (g.IsGroupRow(i) && !g.IsRowExpanded(i) && g.GetRowLevel(i) > 0)
            {
                g.ExpandRow(i, true);
            }
        }

    }
}