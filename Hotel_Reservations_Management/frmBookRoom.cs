using Hotel_reservations_Api.Models;
using MetroFramework;
using MetroFramework.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Reservations_Management
{
    public partial class frmBookRoom : MetroForm
    {
        private readonly HttpClient client;
        private const string url = "https://localhost:44314/api/";

        public Token Token { get; set; }
        public string UserId { get; set; }
        public int RoomId { get; set; }
        public frmBookRoom(Token token, int roomId)
        {
            InitializeComponent();
            Token = token;
            RoomId = roomId;
            this.Text = "Book Room No." + roomId;
            client = new HttpClient();
        }

        private async void btnBook_Click(object sender, EventArgs e)
        {
            if((fromDate.Value < toDate.Value) && (fromDate.Value >= DateTime.Now && toDate.Value >= DateTime.Now))
            {
                var model = new BookRoomViewModel
                {
                    FromDate = fromDate.Value,
                    ToDate = toDate.Value,
                    HotelId = UserId,
                    RoomId = RoomId
                };
                var strObject = JsonConvert.SerializeObject(model);
                var result = await client.PostAsync(url + "HotelReservations", new StringContent(strObject, Encoding.Default, "application/json"));
                if(result.IsSuccessStatusCode)
                {
                    MetroMessageBox.Show(this, "Reservation was successful", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MetroMessageBox.Show(this, "Reservaton was not successful: " + result.ReasonPhrase, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void frmBookRoom_Load(object sender, EventArgs e)
        {
            // loading all normal users
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.access_token);
            var response = await client.GetAsync(url + "Users");

            if(response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<ApplicationUser>>(data);
                cmbUsers.DataSource = users;
                cmbUsers.DisplayMember = "Email";
                cmbUsers.ValueMember = "Id";
                UserId = cmbUsers.SelectedValue.ToString();
            }
        }

        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserId = cmbUsers.SelectedValue.ToString();
        }
    }
}
