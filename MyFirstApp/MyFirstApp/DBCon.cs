using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace MyFirstApp
{
    public partial class DBCon : UserControl
    {
        private string connectionString;
        public DBCon()
        {
            InitializeComponent();
            LoadConfiguration(); //JSON 파일을 불러오는 환경설정
            DisplayCurrentConnectionString(); // 화면상 출력
        }

        // JSON 파일을 불러오기
        private void LoadConfiguration()
        {
            connectionString = Program.Configuration.GetConnectionString("MySQLConnectionString");
        }

        // Server, Port, Database, UserId, Password 정보를 Json 파일에서 가져와서 화면에 뿌려주기 /DB Info textBox 에 채워짐
        private void DisplayCurrentConnectionString()
        {
            if (connectionString != null)
            {
                //쪼개지는 기능
                // Server=192.168.0.47;Port=3306;Database=iot_db;User Id=pi;Password=pi1234!;
                var connectionStringBuilder = new MySqlConnectionStringBuilder(connectionString);
                txtServer.Text = connectionStringBuilder.Server;
                txtPort.Text = connectionStringBuilder.Port.ToString();
                txtDatabase.Text = connectionStringBuilder.Database;
                txtUserId.Text = connectionStringBuilder.UserID;
                txtPassword.Text = connectionStringBuilder.Password; 
            }
        }

        private void textPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Save 저장
        private void btnSave_Click(object sender, EventArgs e)
        {
            //합해지는 기능
            var connectionStringBuilder = new MySqlConnectionStringBuilder()
            {
                Server = txtServer.Text,
                Port = uint.Parse(txtPort.Text),
                Database = txtDatabase.Text,
                UserID = txtUserId.Text,
                Password = txtPassword.Text,
            };

            SaveConnectionString("MySqlConnectionString", connectionStringBuilder.ConnectionString);
            MessageBox.Show("Saved successfully.");
        }
        private void SaveConnectionString(string tag, string connectionString)
        {
            var json = File.ReadAllText("appsettings.json");
            dynamic jsonObj = JsonConvert.DeserializeObject<dynamic>(json); // json 파일을 읽어들여서 
            //class: 구조와 데이터로 구성 a=10 / serialize: 구조를 제외하고 하나로 만들기/ Deserialize : 하나로 된 구조를 읽어와서 serialize로 쪼개기 

            jsonObj["ConnectionStrings"][tag] = connectionString;

            string output = JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented); // 가독성을 위해 들여쓰기를 추가

            File.WriteAllText("appsettings.json", output);
        }
    }
}
