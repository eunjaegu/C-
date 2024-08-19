using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    internal class ClsInfo
    {

        // DB -> Cls -> Controller

        public int ClsNum { get; set; }
        public string ClsName { get; set; }
        
        // 
        public int ImageIndex
        {
            get { return ClsNum; }
        }

        // 데이터 다중선택
        public bool IsDirty { get; set; } = false;

        // Monitoring.cs 파일에서 체크박스
        public override string ToString()
        {
            return ClsName;
        }

       
    }
}
