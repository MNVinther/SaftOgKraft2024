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
using SaftOgKraft.OrderManager.ApiClient;
using SaftOgKraft.OrderManager.ApiClient.DTOs;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SaftOgKraft.OrderManager;

// Main form that acts as the central UI for managing orders and order lines
public partial class MainForm : Form
{
    // The ID of the currently selected order
    private int currentOrderId;

    // REST API for ordrer
    //private IOrderRestClient _orderRestClientStub;
    private readonly IOrderRestClient _orderRestClient;

    // Cache for order lines
   // private List<OrderLineDto> _orderLinesCache;


    public MainForm()
    {
        // Initialize UI components
        InitializeComponent();

        // Dependency injection here
        //_orderRestClientStub = new OrderRestClientStub();


        // Set the API base URL
        string baseApiUrl = "https://localhost:7106/api/v1/";
        _orderRestClient = new OrderRestClient(baseApiUrl);
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

        // Responsive window size
        //int minimumWidth = panelNavigation.Width + panelContent.PreferredSize.Width;
        //int minimumHeight = Math.Max(panelNavigation.Height, panelContent.PreferredSize.Height);
        //this.MinimumSize = new Size(minimumWidth, minimumHeight);
        //this.Size = new Size(minimumWidth, minimumHeight);
    }

    // Handles the Orders button event - slettet async
    private void BtnOrders_Click(object sender, EventArgs e)
    {
        // Hide the other controls in content panel
        foreach (Control control in panelContent.Controls)
        {
            control.Visible = false;
        }

        // Make dataGridOrders visible to display the order list
        dataGridOrders.Visible = true;

        //Load a list of orders - slettet await async fra navn
        LoadOrders();

        // LoadDummyOrders for testing 
        //await LoadDummyOrdersAsync();

        // Set all other columns to read-only
        foreach (DataGridViewColumn column in dataGridOrderLines.Columns)
        {
            if (column.Name != "Packed")
            {
                column.ReadOnly = true;
            }
        }
    }

    // Load orders from an API - slettet async og task
    private async void LoadOrders()
    {
        try
        {
            // Get orders from the API - slettet await
            var orders = await _orderRestClient.GetAllOrdersAsync();

            // Put data to DataGridView - slettet toList()
            dataGridOrders.DataSource = orders.ToList();
        }
        catch (Exception ex)
        {
            // Handle failure by throwing an exception
            MessageBox.Show($"Der skete en fejl: {ex.Message}");
        }
    }

    // Handles a click on a cell in dataGridOrders
    private void DataGridOrders_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        // Ensure that the click is on a valid row
        if (e.RowIndex >= 0)
        {
            // Retrieve the order ID from the selected row
            currentOrderId = Convert.ToInt32(dataGridOrders.Rows[e.RowIndex].Cells["OrderId"].Value);

            // Display details for the selected order
            ShowOrderDetails(currentOrderId);
        }
    }

    // Display order line details for a given order ID
    private async void ShowOrderDetails(int orderId)
    {
        // Hide the order list and show the order lines
        dataGridOrders.Visible = false;
        dataGridOrderLines.Visible = true;
        btnBack.Visible = true;

        // Load order lines for the selected order
        await LoadOrderLinesAsync(orderId);

        // LoadDummyOrders for testing 
        //await LoadDummyOrderLinesAsync(orderId);

        // Set all other columns to read-only
        foreach (DataGridViewColumn column in dataGridOrderLines.Columns)
        {
            if (column.Name != "Packed")
            {
                column.ReadOnly = true;
            }
        }

        //// Add a "Packed" checkbox column if it doesn't exist
        //if (!dataGridOrderLines.Columns.Contains("Packed"))
        //{
        //    var checkBoxColumn = new DataGridViewCheckBoxColumn
        //    {
        //        HeaderText = "Pakket",
        //        Name = "Packed",
        //        Width = 100,
        //        ReadOnly = false
        //    };
        //    dataGridOrderLines.Columns.Add(checkBoxColumn);
        //}

    }

    // Load order lines from an API
    private async Task LoadOrderLinesAsync(int orderId)
    {
        try
        {
            // Get orderLine from the API
            var orderLines = await _orderRestClient.GetOrderLinesAsync(orderId);

            // Cache order lines
            //_orderLinesCache = orderLines.ToList();

            // Put data to DataGridView
            dataGridOrderLines.DataSource = orderLines.ToList();

            //.DataSource = _orderLinesCache;

            //// Set the value of "Packed" checkbox based on cached data
            //foreach (var orderLine in _orderLinesCache)
            //{
            //    var rowIndex = dataGridOrderLines.Rows.Cast<DataGridViewRow>()
            //        .FirstOrDefault(row => (int)row.Cells["OrderLineId"].Value == orderLine.OrderLineId)?.Index;

            //    if (rowIndex != null)
            //    {
            //        dataGridOrderLines.Rows[rowIndex.Value].Cells["Packed"].Value = orderLine.Packed;
            //    }
            //}
        }
        catch (Exception ex)
        {
            // Handle failure by throwing an exception
            MessageBox.Show($"Fejl ved hentning af ordrelinjer: {ex.Message}");
        }
    }

    // Load dummy data for orders 
    //private async Task LoadDummyOrdersAsync()
    //{
    //    try
    //    {
    //        var dummyOrders = await _orderRestClientStub.GetAllOrdersAsync();

    //        // Send dummy data to the DataOrderGridView
    //        dataGridOrders.DataSource = dummyOrders;
    //    }
    //    catch (Exception ex)
    //    {
    //        // Handle failure by throwing an exception
    //        MessageBox.Show($"Der skete en fejl: {ex.Message}");
    //    }
    //}

    // Load dummy data for order lines
    //private async Task LoadDummyOrderLinesAsync(int orderId)
    //{
    //    try
    //    {
    //        var dummyOrderLines = await _orderRestClientStub.GetOrderLinesAsync(orderId);

    //        // Cache order lines
    //        _orderLinesCache = dummyOrderLines.ToList();


    //        // Send dummy data to the DataOrderLineGridView 
    //        //dataGridOrderLines.DataSource = dummyOrderLines;
    //        dataGridOrderLines.DataSource = _orderLinesCache;
    //    }
    //    catch (Exception ex)
    //    {
    //        // Handle failure by throwing an exception
    //        MessageBox.Show($"Fejl ved hentning af ordrelinjer: {ex.Message}");
    //    }
    //}

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
                MarkOrderAsPackedAsync();
            }
            else
            {
                RemovePackedStatus();
            }
        }
    }

    // Marks the current order as packed in dataGridOrders
    private async Task MarkOrderAsPackedAsync()
    {
        foreach (DataGridViewRow row in dataGridOrders.Rows)
        {
            // Use ordrId to find the current ordre
            if ((int)row.Cells["OrderId"].Value == currentOrderId)
            {
                // Set the packed status
                row.Cells["Status"].Value = "Packed";

                // Update the order status in the database
                bool isUpdated = await _orderRestClient.UpdateOrderStatusAsync(currentOrderId, "Packed");
                if (isUpdated)
                {
                    MessageBox.Show("Ordren er pakket og status er opdateret i databasen!", "Status");
                }
                else
                {
                    MessageBox.Show("Fejl ved opdatering af ordren i databasen.", "Fejl");
                }
                break;
            }
        }
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
                row.Cells["Status"].Value = "Ikke pakket";
                break;
            }
        }
    }

    private void dataGridOrderLines_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    //private void DataGridOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
    //{

    //}
}
