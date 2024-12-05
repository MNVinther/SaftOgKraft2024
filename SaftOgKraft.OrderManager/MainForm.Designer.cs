
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
        panelNavigation.Margin = new Padding(2, 2, 2, 2);
        panelNavigation.Name = "panelNavigation";
        panelNavigation.Size = new Size(123, 362);
        panelNavigation.TabIndex = 0;
        // 
        // btnOrders
        // 
        btnOrders.Dock = DockStyle.Top;
        btnOrders.Location = new Point(0, 0);
        btnOrders.Margin = new Padding(2, 2, 2, 2);
        btnOrders.Name = "btnOrders";
        btnOrders.Size = new Size(123, 29);
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
        panelContent.Location = new Point(123, 0);
        panelContent.Margin = new Padding(2, 2, 2, 2);
        panelContent.Name = "panelContent";
        panelContent.Size = new Size(599, 600);
        panelContent.TabIndex = 1;
        // 
        // btnBack
        // 
        btnBack.Dock = DockStyle.Bottom;
        btnBack.Location = new Point(0, 333);
        btnBack.Margin = new Padding(2, 2, 2, 2);
        btnBack.Name = "btnBack";
        btnBack.Size = new Size(599, 29);
        btnBack.TabIndex = 1;
        btnBack.Text = "Back";
        btnBack.UseVisualStyleBackColor = true;
        btnBack.Visible = false;
        btnBack.Click += back_Click;
        // 
        // dataGridOrderLines
        // 
        dataGridOrderLines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridOrderLines.Dock = DockStyle.Fill;
        dataGridOrderLines.Location = new Point(0, 0);
        dataGridOrderLines.Margin = new Padding(2, 2, 2, 2);
        dataGridOrderLines.Name = "dataGridOrderLines";
        dataGridOrderLines.RowHeadersWidth = 82;
        dataGridOrderLines.Size = new Size(599, 362);
        dataGridOrderLines.TabIndex = 1;
        dataGridOrderLines.Visible = false;
        dataGridOrderLines.CellContentClick += dataGridOrderLines_CellContentClick;
        // 
        // dataGridOrders
        // 
        dataGridOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridOrders.Dock = DockStyle.Fill;
        dataGridOrders.Location = new Point(0, 0);
        dataGridOrders.Margin = new Padding(2, 2, 2, 2);
        dataGridOrders.Name = "dataGridOrders";
        dataGridOrders.RowHeadersWidth = 82;
        dataGridOrders.Size = new Size(599, 362);
        dataGridOrders.TabIndex = 0;
        dataGridOrders.Visible = false;
        dataGridOrders.CellClick += DataGridOrders_CellClick;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSize = true;
        ClientSize = new Size(722, 362);
        Controls.Add(panelContent);
        Controls.Add(panelNavigation);
        Margin = new Padding(2, 2, 2, 2);
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
