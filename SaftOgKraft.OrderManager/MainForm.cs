using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SaftOgKraft.OrderManager;    

// Main form that acts as the central UI for managing orders and order lines
public partial class MainForm : Form
{
    // The ID of the currently selected order
    private int currentOrderId;

    public MainForm()
    {
        // Initialize UI components
        InitializeComponent();
    }

    // Event handler to commit edits in the current cell in dataGridOrderLines
    private void DataGridOrderLines_CurrentCellDirtyStateChanged(object sender, EventArgs e) 
    { 
        if (dataGridOrderLines.IsCurrentCellDirty) 
        { 
            dataGridOrderLines.CommitEdit(DataGridViewDataErrorContexts.Commit); 
        } 
    }

    // Load event for the form
    private void MainForm_Load(object sender, EventArgs e)
    {
        // Events for handling cell value and state changes
        dataGridOrderLines.CellValueChanged += DataGridOrderLines_CellValueChanged;
        dataGridOrderLines.CurrentCellDirtyStateChanged += DataGridOrderLines_CurrentCellDirtyStateChanged;

    }

    // Handles the Orders button event 
    private void btnOrders_Click(object sender, EventArgs e)
    {
        //	•	Hente ordrer fra API’et.
        //  •	Indlæse data i dataGridOrders.
        //  •	Gøre dataGridOrders synlig.
        //  •   Indlæse data fra REST API

        // Hide the other controls in content panel
        foreach (Control control in panelContent.Controls)
        {
            control.Visible = false;
        }

        // Make dataGridOrders visible to display the order list
        dataGridOrders.Visible = true;

        // Load orders data from API
        //LoadOrders();

        // LoadDummyOrders for testing 
        LoadDummyOrders();

        // Add a Status column to dataGridOrders if it doesn't exist
        if (!dataGridOrders.Columns.Contains("PackedStatus"))
        {
            var statusColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Status",
                Name = "PackedStatus",
                ReadOnly = true,
                Width = 100
            };
            dataGridOrders.Columns.Add(statusColumn);
        }

    }

    // Load orders from an API
    private void LoadOrders()
    {
        try
        {
            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://your-api-url/");
            //    var response = client.GetAsync("orders").Result;
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var orders = response.Content.ReadAsAsync<List<Order>>().Result;
            //        dataGridOrders.DataSource = orders;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Kunne ikke hente ordrer.");
            //    }
            //}
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Der skete en fejl: {ex.Message}");
        }
    }

    // Handles a click on a cell in dataGridOrders
    private void dataGridOrders_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        //•Tage ordre-ID’et fra den valgte række.
        //•	Skjule dataGridOrders.
        //•	Gøre dataGridOrderLines synlig og indlæse ordrelinjer baseret på ordre - ID’et.
        if (e.RowIndex >= 0) // Ensure that the click is on a valid row
        {
            // Retrieve the order ID from the selected row
            currentOrderId = Convert.ToInt32(dataGridOrders.Rows[e.RowIndex].Cells["OrderId"].Value);

            // Display details for the selected order
            ShowOrderDetails(currentOrderId);
        }
    }

    // Display order line details for a given order ID
    private void ShowOrderDetails(int orderId)
    {
        // Hide the order list and show the order lines
        dataGridOrders.Visible = false;
        dataGridOrderLines.Visible = true;
        btnBack.Visible = true;

        // Load order lines for the selected order
        //LoadOrderLines(orderId);

        // LoadDummyOrders for testing 
        LoadDummyOrderLines();

    }

    // Load order lines from an API
    private void LoadOrderLines(int orderId)
    {
        try
        {
            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://your-api-url/");
            //    var response = client.GetAsync($"orders/{orderId}/lines").Result;
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var orderLines = response.Content.ReadAsAsync<List<OrderLine>>().Result;
            //        dataGridOrderLines.DataSource = orderLines;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Kunne ikke hente ordrelinjer.");
            //    }
            //}
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Fejl ved hentning af ordrelinjer: {ex.Message}");
        }


    }

    // Load dummy data for orders 
    private void LoadDummyOrders()
    {
        // Lav en liste af dummy ordrer
        var dummyOrders = new List<Order>
    {
        new Order { OrderId = 1, CustomerName = "Kunde A", OrderDate = DateTime.Now.AddDays(-2) },
        new Order { OrderId = 2, CustomerName = "Kunde B", OrderDate = DateTime.Now.AddDays(-1) },
        new Order { OrderId = 3, CustomerName = "Kunde C", OrderDate = DateTime.Now }
    };

        // Send dummy data to the DataOrderGridView
        dataGridOrders.DataSource = dummyOrders;
    }

    // Load dummy data for order lines
    private void LoadDummyOrderLines()
    {
        var dummyOrderLines = new List<OrderLine>
    {
        new OrderLine { ProductId = 101, ProductName = "Produkt 1", Quantity = 2,},
        new OrderLine { ProductId = 102, ProductName = "Produkt 2", Quantity = 1,},
        new OrderLine { ProductId = 103, ProductName = "Produkt 3", Quantity = 5,}
    };

        // Send dummy data to the DataOrderLineGridView 
        dataGridOrderLines.DataSource = dummyOrderLines;

        // Add a "Packed" checkbox column if it doesn't exist
        if (!dataGridOrderLines.Columns.Contains("Packed"))
        {
            var checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Pakket",
                Name = "Packed",
                Width = 100,
                ReadOnly = false
            };
            dataGridOrderLines.Columns.Add(checkBoxColumn);
        }

        // Set all other columns to read-only
        foreach (DataGridViewColumn column in dataGridOrderLines.Columns)
        {
            if (column.Name != "Packed")
            {
                column.ReadOnly = true;
            }
        }

    }

    // Handles changes to the Packed checkbox values in dataGridOrderLines
    private void DataGridOrderLines_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (dataGridOrderLines.Columns[e.ColumnIndex].Name == "Packed")
        {
            // Check if all order lines are marked as packed
            bool allPacked = true;

            foreach (DataGridViewRow row in dataGridOrderLines.Rows)
            {
                var packedValue = row.Cells["Packed"].Value;
                if (packedValue == null || !(bool)packedValue)
                {
                    allPacked = false;
                    break;
                }
            }

            if (allPacked)
            {
                MarkOrderAsPacked();
            }
            else
            {
                RemovePackedStatus(); 
            }
        }
    }

    // Marks the current order as packed in dataGridOrders
    private void MarkOrderAsPacked()
    {
        foreach (DataGridViewRow row in dataGridOrders.Rows)
        {
            // Use ordrId to find the current ordre
            if ((int)row.Cells["OrderId"].Value == currentOrderId) 
            {
                // Set the packed status
                row.Cells["PackedStatus"].Value = "✔️ Pakket"; 
                break;
            }
        }

        MessageBox.Show("Ordren er pakket!", "Status");
    }

    // Removes the packed status for the current order in dataGridOrders
    private void RemovePackedStatus()
    {
        foreach (DataGridViewRow row in dataGridOrders.Rows)
        {
            // Use ordrId to find the current ordre
            if ((int)row.Cells["OrderId"].Value == currentOrderId)
            {
                // Reset the packed status
                row.Cells["PackedStatus"].Value = "Ikke pakket"; 
                break;
            }
        }
    }
}
