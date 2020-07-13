using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Hotel_Reservations_Management.Models;
using MetroFramework;
using System.Text.RegularExpressions;

namespace Hotel_Reservations_Management
{
    public partial class frmMain : MetroForm
    {
        private readonly HttpClient httpClient;
        private const string url = "https://localhost:44314/api/";
        private List<HotelReservationViewModel> HotelReservations { get; set; }
        private List<Room> Rooms = new List<Room>();
        public Token Token { get; set; }
        public frmLogin LoginForm { get; set; }
        public frmMain(Token token, frmLogin frmLogin)
        {
            InitializeComponent();
            Token = token;
            this.Text = "Mr.Booker - Welcome " + Token.userName;
            LoginForm = frmLogin;
            httpClient = new HttpClient();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            LoginForm.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            LoginForm.Close();
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.access_token);
            var response = await httpClient.GetAsync(url + "HotelReservations?hotelId=" + Token.userId);
            if (response.IsSuccessStatusCode)
            {
                var reservations = JsonConvert.DeserializeObject<IEnumerable<Reservation>>(await response.Content.ReadAsStringAsync());
                List<HotelReservationViewModel> model = new List<HotelReservationViewModel>();
                foreach(var r in reservations)
                {
                    model.Add(new HotelReservationViewModel
                    {
                        Id = r.Id,
                        DayCount = r.DayCount,
                        StartDate = r.StartDate,
                        EndDate = r.EndDate,
                        RoomId = r.RoomId,
                        Email = r.User.Email
                    });
                }
                HotelReservations = model;
                dataGridView1.DataSource = model;
                dataGridView1.Font = new Font("Arial", 15, FontStyle.Regular);
                metroGrid1.Font = new Font("Arial", 15, FontStyle.Regular);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                dataGridView1.DataSource = HotelReservations.Where(r => r.Email.Contains(txtSearch.Text)).ToList();
            }
            else
            {
                dataGridView1.DataSource = HotelReservations;
            }
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            pnlContainer.Controls.Clear();
            pnlContainer.Controls.Add(ReservationPanel);
        }

        private async void btnManualReservation_Click(object sender, EventArgs e)
        {
            pnlContainer.Controls.Clear();
            var response = await httpClient.GetAsync(url + "Rooms?hotelId=" + Token.userId);
            if(response.IsSuccessStatusCode)
            {
                var strObj = await response.Content.ReadAsStringAsync();
                Rooms = JsonConvert.DeserializeObject<List<Room>>(strObj);
                metroGrid1.DataSource = Rooms;
                pnlContainer.Controls.Add(BookRoomPanel);
            }
            else
            {
                MetroMessageBox.Show(this, "Something went wrong, it might be due to internet connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRoomId_TextChanged(object sender, EventArgs e)
        {
            var regExp = new Regex("^[0-9]+$");
            if(!string.IsNullOrWhiteSpace(txtRoomId.Text) && regExp.IsMatch(txtRoomId.Text))
            {
                metroGrid1.DataSource = Rooms.Where(r => r.Id == Convert.ToInt32(txtRoomId.Text)).ToList();
            }
            else
            {
                metroGrid1.DataSource = Rooms;
            }
        }

        private void metroGrid1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if(metroGrid1.SelectedRows.Count == 1)
            {
                btnBookRoom.Enabled = true;
            }
            else
            {
                btnBookRoom.Enabled = false;
            }
        }
    }
}
