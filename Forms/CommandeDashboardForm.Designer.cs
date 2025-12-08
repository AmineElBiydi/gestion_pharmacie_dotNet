namespace GestionPharmacie.Forms
{
    partial class CommandeDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        // UI Controls
        private Panel container;
        private Label lblTitle;
        private Label lblUpdate;
        private Panel navPanel;
        private Button btnNew;
        private Button btnSearch;
        private Button btnModify;
        private Panel cardTotalCmd;
        private Panel cardCmdToday;
        private Panel cardCmdMonth;
        private Panel cardRevenue;
        private Panel cardPending;
        private Panel cardDelivered;
        private Panel cardCancelled;
        private Panel cardUnpaid;
        private Panel recentCard;
        private Label lblRecentTitle;
        private DataGridView dgvRecent;

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            container = new Panel();
            lblTitle = new Label();
            lblUpdate = new Label();
            navPanel = new Panel();
            btnNew = new Button();
            btnSearch = new Button();
            btnModify = new Button();
            recentCard = new Panel();
            lblRecentTitle = new Label();
            dgvRecent = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            container.SuspendLayout();
            navPanel.SuspendLayout();
            recentCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecent).BeginInit();
            SuspendLayout();
            // 
            // container
            // 
            container.Controls.Add(lblTitle);
            container.Controls.Add(lblUpdate);
            container.Controls.Add(navPanel);
            container.Controls.Add(recentCard);
            container.Location = new Point(0, 0);
            container.Name = "container";
            container.Size = new Size(200, 100);
            container.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(100, 23);
            lblTitle.TabIndex = 0;
            // 
            // lblUpdate
            // 
            lblUpdate.Location = new Point(0, 0);
            lblUpdate.Name = "lblUpdate";
            lblUpdate.Size = new Size(100, 23);
            lblUpdate.TabIndex = 1;
            // 
            // navPanel
            // 
            navPanel.Controls.Add(btnNew);
            navPanel.Controls.Add(btnSearch);
            navPanel.Controls.Add(btnModify);
            navPanel.Location = new Point(0, 0);
            navPanel.Name = "navPanel";
            navPanel.Size = new Size(200, 100);
            navPanel.TabIndex = 2;
            navPanel.Paint += navPanel_Paint;
            // 
            // btnNew
            // 
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.Location = new Point(0, 0);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(75, 23);
            btnNew.TabIndex = 0;
            btnNew.Click += BtnNew_Click;
            // 
            // btnSearch
            // 
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Location = new Point(0, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 1;
            btnSearch.Click += BtnSearch_Click;
            // 
            // btnModify
            // 
            btnModify.FlatAppearance.BorderSize = 0;
            btnModify.Location = new Point(0, 0);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(75, 23);
            btnModify.TabIndex = 2;
            btnModify.Click += BtnModify_Click;
            // 
            // recentCard
            // 
            recentCard.Controls.Add(lblRecentTitle);
            recentCard.Controls.Add(dgvRecent);
            recentCard.Location = new Point(0, 0);
            recentCard.Name = "recentCard";
            recentCard.Size = new Size(200, 100);
            recentCard.TabIndex = 3;
            // 
            // lblRecentTitle
            // 
            lblRecentTitle.Location = new Point(0, 0);
            lblRecentTitle.Name = "lblRecentTitle";
            lblRecentTitle.Size = new Size(100, 23);
            lblRecentTitle.TabIndex = 0;
            // 
            // dgvRecent
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 126, 167);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRecent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRecent.ColumnHeadersHeight = 29;
            dgvRecent.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewCheckBoxColumn1, dataGridViewTextBoxColumn6 });
            dgvRecent.Location = new Point(0, 0);
            dgvRecent.Name = "dgvRecent";
            dgvRecent.RowHeadersWidth = 51;
            dgvRecent.Size = new Size(240, 150);
            dgvRecent.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.MinimumWidth = 6;
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            dataGridViewCheckBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.Width = 125;
            // 
            // CommandeDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1200, 900);
            Controls.Add(container);
            Name = "CommandeDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tableau de Bord - Commandes";
            container.ResumeLayout(false);
            navPanel.ResumeLayout(false);
            recentCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRecent).EndInit();
            ResumeLayout(false);
        }

        private Panel CreateStatCard(string name, string title, string value, Color color, int x, int y)
        {
            var card = new Panel
            {
                Name = name,
                Location = new Point(x, y),
                Size = new Size(225, 120),
                BackColor = Color.White
            };

            // Top color bar
            var colorBar = new Panel
            {
                Size = new Size(225, 4),
                Location = new Point(0, 0),
                BackColor = color
            };
            card.Controls.Add(colorBar);

            // Value
            var lblValue = new Label
            {
                Name = "lblValue",
                Text = value,
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                ForeColor = color,
                AutoSize = true,
                Location = new Point(15, 25)
            };
            card.Controls.Add(lblValue);

            // Title
            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(15, 75)
            };
            card.Controls.Add(lblTitle);

            return card;
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}
