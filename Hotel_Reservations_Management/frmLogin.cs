using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using Newtonsoft.Json;

namespace Hotel_Reservations_Management
{
    public partial class frmLogin : MetroForm
    {
        private const string url = "https://localhost:44314/Token";
        private readonly HttpClient httpClient;
        public Token Token { get; set; }
        public frmLogin()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtUsername.Text.Trim()) && !string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
            {
                try
                {
                    btnLogin.Enabled = false;
                    btnLogin.Text = "Logging in....";
                    var response = await httpClient.PostAsync(url, new StringContent($"username={txtUsername.Text}&password={txtPassword.Text}&grant_type=password", Encoding.Default, "application/x-www-form-urlencoded"));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Token = JsonConvert.DeserializeObject<Token>(content);
                        if (Token.role == "Hotel")
                        {
                            btnLogin.Enabled = true;
                            btnLogin.Text = "Login";
                            this.Hide();
                            frmMain mainForm = new frmMain(Token, this);
                            mainForm.Show();
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "This account is not registered as a hotel please login with a hotel account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        MetroMessageBox.Show(this, "Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnLogin.Enabled = true;
                        btnLogin.Text = "Login";
                    }
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnLogin.Enabled = true;
                    btnLogin.Text = "Login";
                }
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
