using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Security.Cryptography;
using System.Text;


namespace MyFirstApp
{
    public partial class Login : Form
    {
        // DB 전역변수 선언
        private string connectionString;

        // 로그인 시 DB정보와 비교 후 일치유무 확인 /  Is 맞니 아니니 여부
        public bool IsAuthenticated { get; set; } = false;

        public Login()
        {
            InitializeComponent();
            connectionString = Program.Configuration.GetConnectionString("MySqlConnectionString");
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string password = txtPassword.Text;

            if (AuthenticateUser(userName, password))
            {
                IsAuthenticated = true;
                this.Close(); // 로그인 성공 시 폼 닫음
            }
            else
            {
                MessageBox.Show("Invalid User", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        //DB 연동해서 실행 
        private bool AuthenticateUser(string userName, string password)
        {
            // 비밀번호를 SHA256으로 해싱
            string enPassword = EncryptPassword(password);
            int result = 0;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(1) FROM users WHERE username = @userName AND password_hash = @password";


                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@userName", userName);
                            cmd.Parameters.AddWithValue("@password", enPassword);

                            // 단일 값 가져올 때 
                            result = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                        catch (Exception ex)
                        {
                            // 예외처리 발생
                            MessageBox.Show($"Eerror : {ex.Message}");
                        }
                        return result > 0;
                    }
                }
                catch (Exception ex)
                {
                    // 예외처리 발생
                    MessageBox.Show($"Eerror : {ex.Message}");
                }
            }
            return result > 0;
        }

        private string EncryptPassword(string password)
        {
            // 실제 암호화 로직을 여기에 구현해야 합니다.

            // 예: SHA-256 해시

            //SHA - 256은 Secure Hash Algorithm 256 - bit의 약자로, 256비트 길이의 해시 값을 생성하는 암호학적 해시 함수입니다.

            //SHA256.Create() 메서드는 SHA-256 해시 알고리즘을 구현한 객체를 생성합니다.

            //해시 함수는 바이트 배열을 입력으로 받기 때문에 문자열을 바이트 배열로 변환하는 과정이 필요

            //x2 형식 지정자는 각 바이트를 두 자리 16진수로 나타내며, 결과적으로 모든 바이트가 16진수 문자열로 변환됩니다.

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(sender, e);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
