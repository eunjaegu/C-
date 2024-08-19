using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Reflection;

namespace MyFirstApp
{
    internal static class Program
    {
        // 전역변수의 프로퍼티 생성
        public static IConfiguration? Configuration { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // JDON 파일 전체 가져오기
            // 위치 정해주면 내가 다 가져올게 
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            
            //필요할때마다 가져다 써
            Configuration = builder.Build();

            // 다중 프로세스
            bool createNew = false;

            // 소유권 정보 세팅(소유권여부, 소유자)
            Mutex mutex = new Mutex(true,Assembly.GetEntryAssembly().FullName, out createNew);

            // 소유권 받았을 경우 생성
            if (createNew == true)
            {
                // 소유권을 받지 않았을 경우 메세지 박스 띄우기
                ApplicationConfiguration.Initialize();

                using (Login login = new Login())
                {
                    login.ShowDialog();
                    if (login.IsAuthenticated == true)
                    {
                        // form 창 열림
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