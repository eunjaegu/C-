using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using System.Globalization;

namespace MyFirstApp
{
    public partial class Monitoring : Form
    {
        // 전역변수
        private string connectionString;

        public Monitoring()  
        {
            InitializeComponent();
            string spreadPath = Program.Configuration["XmlFilePaths:detected_result_cols"];
            LoadDataGridViewColumns(spreadPath);
            // Program.cs 파일에서 Configuration / appettiongs.json
            connectionString = Program.Configuration.GetConnectionString("MySqlConnectionString");
        }

        private void Monitoring_Load(object sender, EventArgs e)
        {
            imageRadioButton.Checked = true;
            LoadClassInfo();
            /* foreach (string key in imageList.Images.Keys)
             {
                 int idx = imageList.Images.IndexOfKey(key);
                 ListViewItem item = new ListViewItem(key, idx);
                 classListView.Items.Add(item);

             }
            */
        }

        private void LoadClassInfo()
        {
            //using = context : open 시 close 보장(open 시켜주지 않음) ex. 파일오픈시, 네트워크통신 할때, DB통신 할때
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT cls_num, cls_name FROM cls_info";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ClsInfo clsInfo = new ClsInfo
                        {
                            ClsNum = reader.GetInt32("cls_num"),
                            ClsName = reader.GetString("cls_name")
                        };

                        ListViewItem item = new ListViewItem(clsInfo.ClsName)
                        {
                            ImageIndex = clsInfo.ImageIndex,
                            Tag = clsInfo
                        };
                        classListView.Items.Add(item);
                        classCheckedListBox.Items.Add(clsInfo);


                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error{ex.Message}");
                }
            }

            // connectionString


        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // 선택된 아이템을 하나씩 꺼내기
            foreach (ListViewItem item in classListView.SelectedItems)
            {
                item.Selected = false;  // selected 된 경우에 해제
                                        // true 일 경우 전체선택으로 됨
            }
        }

        private void clear2Button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < classCheckedListBox.Items.Count; i++)
            {
                classCheckedListBox.SetItemChecked(i, false);   // 전제를 확인 후 false 인 경우 선택 해제
            }

        }

        private void imageRadioButton_Click(object sender, EventArgs e)
        {
            RadioButton? temp = sender as RadioButton;
            if (temp != null && temp.Checked)
            {
                clear2Button_Click(sender, e); // clear 버튼 호출

                textGroupBox.Enabled = false;
                imagegroupBox.Enabled = true;
            }

            /* if (imageRadioButton.Checked)
             {

                 textGroupBox.Enabled = false;
                 imagegroupBox.Enabled = true;
             } */
        }

        private void textRadioButton_Click(object sender, EventArgs e)
        {
            if (textRadioButton.Checked)
            {
                clearButton_Click(sender, e); // clear 버튼 호출

                textGroupBox.Enabled = true;
                imagegroupBox.Enabled = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InquiryButton_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = BuildQuery();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView.DataSource = dataTable;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error {ex.Message}");
                }


            }
        }

        private string BuildQuery()
        {
            // string a = "안녕", string a = "안녕!" 은 메모리가 늘어나는 구조
            // 필터링 할때마다 메모리가 늘어나서 늘어나지 않는 구조 => StringBuilder 
            StringBuilder query = new StringBuilder("SELECT * FROM detected_result where 1 = 1 ");

            List<string> selectedItems = new List<string>();
            if (imageRadioButton.Checked == true)
            {
                // 아이템 선택 여부 확인(ListView Item)
                foreach (ListViewItem item in classListView.SelectedItems)
                {
                    // cls형변환
                    selectedItems.Add($"{((ClsInfo)item.Tag).ClsNum}");
                }
            }
            else if (textRadioButton.Checked == true)
            {
                // (object Item)
                foreach (object item in classCheckedListBox.CheckedItems)
                {
                    selectedItems.Add($"{((ClsInfo)item).ClsNum}");
                }
            }

            if (selectedItems.Count > 0)
            {
                string inWhere = string.Join(",", selectedItems);
                query.Append($" AND cls_num IN({inWhere})");
            }

            
            //Conf 0.0>= <=1.0 이상 관련 코드
            string input = conTextBox.Text;
            if (!string.IsNullOrWhiteSpace(input))
            {
                query.Append($" AND cls_conf >= {input}");
            }
            

            //Area. 
            string input2 = textNum.Text;
            if (!string.IsNullOrWhiteSpace(input2))
            {
                query.Append($" AND area >= {input2}");
            }


            DateTime fromDate = fromDateTimePicker.Value.Date;
            DateTime toDate = toDateTimePicker.Value.Date;
            query.Append($" AND date >= '{fromDate:yyyy-MM-dd}' AND date <= '{toDate:yyyy-MM-dd 23:59:59}'");

            return query.ToString();
        }


        // 유효성 검사
        private void conTextBox_TextChanged(object sender, EventArgs e)
        {
            // 입력된 텍스트를 double로 변환 시도
            if (double.TryParse(conTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
            {
                // 값이 0.0과 1.0 사이에 있는지 확인
                if (!(value >= 0.0 && value <= 1.0))
                {
                    conTextBox.Text = "";
                }
            }
        }

        private void conTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자 또는 제어 문자인지 확인
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자 또는 제어 문자인지 확인
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
