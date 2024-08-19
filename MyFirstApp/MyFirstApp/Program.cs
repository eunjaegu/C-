using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Reflection;

namespace MyFirstApp
{
    internal static class Program
    {
        // ���������� ������Ƽ ����
        public static IConfiguration? Configuration { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // JDON ���� ��ü ��������
            // ��ġ �����ָ� ���� �� �����ð� 
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            
            //�ʿ��Ҷ����� ������ ��
            Configuration = builder.Build();

            // ���� ���μ���
            bool createNew = false;

            // ������ ���� ����(�����ǿ���, ������)
            Mutex mutex = new Mutex(true,Assembly.GetEntryAssembly().FullName, out createNew);

            // ������ �޾��� ��� ����
            if (createNew == true)
            {
                // �������� ���� �ʾ��� ��� �޼��� �ڽ� ����
                ApplicationConfiguration.Initialize();

                using (Login login = new Login())
                {
                    login.ShowDialog();
                    if (login.IsAuthenticated == true)
                    {
                        // form â ����
                        Application.Run(new MDI());
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Another instance of the apprlication is already running");
            }
            

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            
        }
    }
}