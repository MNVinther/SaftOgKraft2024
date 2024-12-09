
namespace SaftOgKraft.OrderManager;

partial class MainForm
{
    private Panel panelNavigation;
    private Button btnOrders;
    private Panel panelContent;
    private DataGridView dataGridOrders;
    private Button btnBack;
    private DataGridView dataGridOrderLines;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        panelNavigation = new Panel();
        btnOrders = new Button();
        panelContent = new Panel();
        btnBack = new Button();
        dataGridOrderLines = new DataGridView();
        dataGridOrders = new DataGridView();
        panelNavigation.SuspendLayout();
        panelContent.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridOrderLines).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dataGridOrders).BeginInit();
        SuspendLayout();
        // 
        // panelNavigation
        // 
        panelNavigation.BackColor = SystemColors.ControlLight;
        panelNavigation.Controls.Add(btnOrders);
        panelNavigation.Dock = DockStyle.Left;
        panelNavigation.Location = new Point(0, 0);
        panelNavigation.Name = "panelNavigation";
        panelNavigation.Size = new Size(200, 779);
        panelNavigation.TabIndex = 0;
        // 
        // btnOrders
        // 
        btnOrders.Dock = DockStyle.Top;
        btnOrders.Location = new Point(0, 0);
        btnOrders.Name = "btnOrders";
        btnOrders.Size = new Size(200, 46);
        btnOrders.TabIndex = 0;
        btnOrders.Text = "Ordre";
        btnOrders.UseVisualStyleBackColor = true;
        btnOrders.Click += BtnOrders_Click;
        // 
        // panelContent
        // 
        panelContent.AutoSize = true;
        panelContent.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        panelContent.Controls.Add(btnBack);
        panelContent.Controls.Add(dataGridOrderLines);
        panelContent.Controls.Add(dataGridOrders);
        panelContent.Dock = DockStyle.Fill;
        panelContent.Location = new Point(200, 0);
        panelContent.Name = "panelContent";
        panelContent.Size = new Size(1224, 779);
        panelContent.TabIndex = 1;
        // 
        // btnBack
        // 
        btnBack.Dock = DockStyle.Bottom;
        btnBack.Location = new Point(0, 733);
        btnBack.Name = "btnBack";
        btnBack.Size = new Size(1224, 46);
        btnBack.TabIndex = 1;
        btnBack.Text = "Back";
        btnBack.UseVisualStyleBackColor = true;
        btnBack.Visible = false;
        btnBack.Click += back_Click;
        // 
        // dataGridOrderLines
        // 
        dataGridOrderLines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        dataGridOrderLines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridOrderLines.Dock = DockStyle.Fill;
        dataGridOrderLines.Location = new Point(0, 0);
        dataGridOrderLines.Name = "dataGridOrderLines";
        dataGridOrderLines.RowHeadersWidth = 82;
        dataGridOrderLines.ScrollBars = ScrollBars.Vertical;
        dataGridOrderLines.Size = new Size(1224, 779);
        dataGridOrderLines.TabIndex = 1;
        dataGridOrderLines.Visible = false;
        dataGridOrderLines.CellContentClick += dataGridOrderLines_CellContentClick;
        // 
        // dataGridOrders
        // 
        dataGridOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridOrders.Dock = DockStyle.Fill;
        dataGridOrders.Location = new Point(0, 0);
        dataGridOrders.Name = "dataGridOrders";
        dataGridOrders.RowHeadersWidth = 82;
        dataGridOrders.ScrollBars = ScrollBars.Vertical;
        dataGridOrders.Size = new Size(1224, 779);
        dataGridOrders.TabIndex = 0;
        dataGridOrders.Visible = false;
        dataGridOrders.CellClick += DataGridOrders_CellClick;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(13F, 32F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSize = true;
        ClientSize = new Size(1424, 779);
        Controls.Add(panelContent);
        Controls.Add(panelNavigation);
        Name = "MainForm";
        Text = "MainForm";
        Load += MainForm_Load;
        panelNavigation.ResumeLayout(false);
        panelContent.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataGridOrderLines).EndInit();
        ((System.ComponentModel.ISupportInitialize)dataGridOrders).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private void back_Click(object sender, EventArgs e)
    {
        dataGridOrderLines.Visible = false;
        btnBack.Visible = false;
        dataGridOrders.Visible = true;



    }

#endregion
}
