using System.Diagnostics;

namespace MAUISfDataGrid.Pages;

public partial class DataGridPage : ContentPage
{
    Stopwatch Timer = new Stopwatch();

    public DataGridPage(int count)
    {
        InitializeComponent();

        BindingContext = new EmployeeViewModel(count);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Timer.Start();

        sfdatagrid.ItemsSource = (sfdatagrid.BindingContext as EmployeeViewModel)?.Employees;

        sfdatagrid.Dispatcher.Dispatch(() =>
        {
            Timer.Stop();
            label.Text = $"{Timer.ElapsedMilliseconds}ms";
            Timer.Reset();
        });
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Timer.Start();

        sfdatagrid.SortColumnDescriptions.Add(new Syncfusion.Maui.DataGrid.SortColumnDescription() { ColumnName = "EmployeeId", SortDirection = System.ComponentModel.ListSortDirection.Ascending });

        sfdatagrid.Dispatcher.Dispatch(() =>
        {
            Timer.Stop();
            label.Text = $"{Timer.ElapsedMilliseconds}ms";
            Timer.Reset();
        });
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        Timer.Start();

        sfdatagrid.GroupColumnDescriptions.Add(new Syncfusion.Maui.DataGrid.GroupColumnDescription() { ColumnName = "EmployeeId" });
  
        sfdatagrid.Dispatcher.Dispatch(() =>
        {
            Timer.Stop();
            label.Text = $"{Timer.ElapsedMilliseconds}ms";
            Timer.Reset();
        });
    }

    private void Button_Clicked_3(object sender, EventArgs e)
    {
        Timer.Start();

        if (sfdatagrid.View != null)
        {
            sfdatagrid.View.Filter = FilterRecords;
            sfdatagrid.View.RefreshFilter();
        }

        sfdatagrid.Dispatcher.Dispatch(() =>
        {
            Timer.Stop();
            label.Text = $"{Timer.ElapsedMilliseconds}ms";
            Timer.Reset();
        });
    }

    public bool FilterRecords(object record)
    {
        Employee? employee = record as Employee;

        if (employee != null && employee.Gender == "Male")
        {
            return true;
        }

        return false;
    }

    private void Button_Clicked_4(object sender, EventArgs e)
    {
        label.Text = "0ms";

        sfdatagrid.SortColumnDescriptions.Clear();

        if (sfdatagrid.View != null)
        {
            sfdatagrid.View.Filter = null;
            sfdatagrid.View.RefreshFilter();
        }
    }
}