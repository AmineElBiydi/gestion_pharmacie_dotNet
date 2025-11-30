using GestionPharmacie.Forms;
using GestionPharmacie.Controls;
using GestionPharmacie.Data;
using GestionPharmacie.Utils;

namespace GestionPharmacie;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object? sender, EventArgs e)
    {
        // Update status bar with user info
        if (Session.CurrentUser != null)
        {
            statusLabel.Text = $"👤 {Session.CurrentUser.FullName} ({Session.CurrentUser.Role})";
        }
        statusDateLabel.Text = "🕒 " + DateTime.Now.ToString("dd MMMM yyyy - HH:mm");

        // Load dashboard on startup
        LoadDashboard();
    }

    private void LoadDashboard()
    {
        LoadControl(new DashboardControl());
    }

    public void LoadControl(UserControl control)
    {
        // Clear all existing controls first to prevent overlapping
        while (contentPanel.Controls.Count > 0)
        {
            var oldControl = contentPanel.Controls[0];
            contentPanel.Controls.RemoveAt(0);
            oldControl.Dispose();
        }

        // Add new control
        control.Dock = DockStyle.Fill;
        contentPanel.Controls.Add(control);
        control.BringToFront();

        // Force refresh
        contentPanel.Refresh();
    }

    private void MenuHome_Click(object? sender, EventArgs e)
    {
        LoadDashboard();
    }

    private void MenuMedGerer_Click(object? sender, EventArgs e)
    {
        LoadControl(new MedicamentControl());
    }

    private void MenuMedRechercher_Click(object? sender, EventArgs e)
    {
        LoadControl(new MedicamentSearchControl());
    }

    private void MenuMedAlertes_Click(object? sender, EventArgs e)
    {
        LoadControl(new MedicamentAlertControl());
    }

    private void MenuCmdDashboard_Click(object? sender, EventArgs e)
    {
        LoadControl(new CommandeDashboardControl());
    }

    private void MenuCmdNouvelle_Click(object? sender, EventArgs e)
    {
        LoadControl(new CommandeControl());
    }

    private void MenuCmdRechercher_Click(object? sender, EventArgs e)
    {
        LoadControl(new CommandeSearchControl());
    }

    private void MenuCliGerer_Click(object? sender, EventArgs e)
    {
        LoadControl(new ClientControl());
    }

    private void MenuCliRechercher_Click(object? sender, EventArgs e)
    {
        LoadControl(new ClientSearchControl());
    }

    private void MenuStatTableau_Click(object? sender, EventArgs e)
    {
        LoadDashboard();
    }

    private void MenuCompteGérer_Click(object? sender, EventArgs e)
    {
        LoadControl(new UserManagementControl());
    }

    private void MenuCompteLogout_Click(object? sender, EventArgs e)
    {
        var result = MessageBox.Show("Voulez-vous vraiment vous déconnecter?",
            "Déconnexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            Session.Logout();
            this.Close();

            // Show login form again
            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Restart();
            }
            else
            {
                Application.Exit();
            }
        }
    }

    private void menuCompte_Click(object sender, EventArgs e)
    {

    }

    private void menuStatistiques_Click(object sender, EventArgs e)
    {

    }
}
