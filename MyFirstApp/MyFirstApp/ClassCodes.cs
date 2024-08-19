using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace MyFirstApp
{
    public partial class classCodes : Form
    {
        // db 연결직
        private string connectionString;

        //a.  관리직
        private BindingSource bindingSource;


        public classCodes()
        {
            InitializeComponent();
            string spreadPath = Program.Configuration["XmlFilePaths:cls_info_cols"];
            LoadDataGridViewColumns(spreadPath);
            connectionString = Program.Configuration.GetConnectionString("MySqlConnectionString");


            bindingSource = new BindingSource();

            //b. 직원들 여러명
            bindingSource.DataSource = new BindingList<ClsInfo>();
            // BindingList 자동 <-> List 수동

            //DATA 숨기기 false / Data 보여주기 true
            //xml에 반영된 컬럼만 적용(Class Name, Class Code)
            dataGridView.AutoGenerateColumns = false;
            //c.  여기에 삽입
            dataGridView.DataSource = bindingSource;

            txtClsNum.DataBindings.Add("Text", bindingSource, "ClsNum", true, DataSourceUpdateMode.OnPropertyChanged);
            txtClsName.DataBindings.Add("Text", bindingSource, "ClsName", true, DataSourceUpdateMode.OnPropertyChanged);



        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            LoadData(txtFilter.Text);
        }

        // 조회
        private void LoadData(string filter = "")
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    // 1. 데이터베이스 연결 열기
                    conn.Open();
                    // 2. 쿼리 작성(쿼리문 띄어쓰기 하기)
                    string query = " SELECT * FROM cls_info ";
                    if (!string.IsNullOrEmpty(filter))
                    {
                        query += " WHERE cls_name LIKE @filter ";
                    }
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (!string.IsNullOrEmpty(filter))
                    {
                        cmd.Parameters.AddWithValue("@filter", filter + "%");
                    }

                    MySqlDataReader reader = cmd.ExecuteReader();
                    var clsInfoList = (BindingList<ClsInfo>)bindingSource.DataSource;
                    clsInfoList.Clear(); // 조회 시 기존 데이터 삭제 (후 add)

                    // d.데이터 읽어서 bindingList에 추가
                    while (reader.Read())
                    {
                        /*
                        ClsInfo clsInfo = new ClsInfo();
                        clsInfo.ClsNum = reader.GetInt32("cls_num");
                        clsInfo.ClsName = reader.GetString("cls_name");
                        clsInfoList.Add(clsInfo);
                        */

                        /*
                        ClsInfo clsInfo = new ClsInfo
                        {
                            ClsNum = reader.GetInt32("cls_num");
                            ClsName = reader.GetString("cls_name");
                        };
                        */


                        clsInfoList.Add(new ClsInfo
                        {
                            ClsNum = reader.GetInt32("cls_num"),
                            ClsName = reader.GetString("cls_name")
                        });
                    }
                    // reader.Close(); = using 사용
                    reader.Close();

                    /*
                    // 3. MySqlCommand 객체 생성
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    // 4. 쿼리 실행 및 결과를 MySqlDataReader에 저장
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    // 5. DataTable 생성 및 데이터 채우기
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    // 6. DataGridView 등 컨트롤에 DataTable을 바인딩하여 데이터 표시
                    dataGridView.DataSource = dt;
                    */



                }
                catch (Exception ex)
                {
                    // 예외 발생 시 처리
                    MessageBox.Show($"Error : {ex.Message}");
                }
            }
            bindingSource.ResetBindings(false);
        }

        //NEW 버튼 클릭 시 빈칸 추가
        private void newButton_Click(object sender, EventArgs e)
        {
            var newClsInfo = new ClsInfo();

            var clsInfoList = (BindingList<ClsInfo>)bindingSource.DataSource;
            clsInfoList.Add(newClsInfo);

            // (BindingList<ClsInfo>)bindingSource.DataSource.Add(newClsInfo);

            //위치 반환
            bindingSource.Position = bindingSource.IndexOf(newClsInfo);
            newClsInfo.ClsNum = bindingSource.Position;
        }

        // 저장
        private void saveButton_Click(object sender, EventArgs e)
        {
            // 현재 선택된 정보
            var currentClsInfo = (ClsInfo)bindingSource.Current;
            
            // 단일 저장
            // SaveData(currentClsInfo);

            //멀티저장
            SaveMultiData();

            bindingSource.ResetBindings(false);
        }

        private void SaveData(ClsInfo clsInfo)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    INSERT INTO cls_info (cls_num, cls_name)
                    VALUES(@cls_num, @cls_name)
                    ON DUPLICATE KEY 
                    UPDATE cls_name = VALUES(cls_name);
                    ";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // 파라미터를 추가하고 값을 설정
                        cmd.Parameters.AddWithValue("@cls_num", clsInfo.ClsNum);
                        cmd.Parameters.AddWithValue("@cls_name", clsInfo.ClsName);

                        // 쿼리 실행
                        cmd.ExecuteNonQuery();

                        // 저장 후 재조회
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error : {ex.Message}");
                }
                bindingSource.ResetBindings(false);
            }
        }

        // 다중 저장
        private void SaveMultiData()
        {
      
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                        {
                          string query = @"
                             INSERT INTO cls_info (cls_num, cls_name)
                             VALUES(@cls_num, @cls_name)
                             ON DUPLICATE KEY 
                             UPDATE cls_name = VALUES(cls_name);
                             ";

                             using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                             {
                             foreach (ClsInfo clsInfo in bindingSource.List)
                             {
                                 if (clsInfo.IsDirty == true)
                                  {
                                     cmd.Parameters.Clear();
                                     cmd.Parameters.AddWithValue("@cls_num", clsInfo.ClsNum);
                                     cmd.Parameters.AddWithValue("@cls_name", clsInfo.ClsName);

                                     cmd.ExecuteNonQuery();

                                     clsInfo.IsDirty = false;
                                  }
                             }
                                // 모든 데이터 처리 후에 트랜잭션 커밋
                                transaction.Commit();
                             }
                         }
                         catch(Exception ex)
                         {
                             // 예외 발생 시 트랜잭션 롤백
                             transaction.Rollback();
                             MessageBox.Show($"Error : {ex.Message}");
                         }
                     }
                    
                        
            }
        }

        //삭제
        private void deleteButton_Click(object sender, EventArgs e)
        {
            var currentClsInfo = (ClsInfo)bindingSource.Current;
            DeleteData(currentClsInfo);
            bindingSource.RemoveCurrent();
            bindingSource.ResetBindings(false);
        }

        private void DeleteData(ClsInfo clsInfo)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM cls_info WHERE cls_num = @cls_num";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // 파라미터를 추가하고 값을 설정
                        cmd.Parameters.AddWithValue("@cls_num", clsInfo.ClsNum);

                        // 쿼리 실행
                        //cmd.ExecuteNonQuery();

                        // 쿼리 실행
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // 삭제가 성공적으로 완료되었는지 확인
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Delete successfully.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // 삭제 완료 후 데이터 재조회
                            LoadData();
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Error : {ex.Message}");
                }
            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //1. 
            if (e.RowIndex >= 0)
            {
                var clsInfo = (ClsInfo)dataGridView.Rows[e.RowIndex].DataBoundItem;
                clsInfo.IsDirty = true;
            }
        }
    }
}
