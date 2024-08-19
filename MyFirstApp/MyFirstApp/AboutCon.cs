using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstApp
{
    public partial class AboutCon : UserControl
    {
        private Assembly assembly;
        public AboutCon()
        {   
            InitializeComponent();
            assembly = Assembly.GetExecutingAssembly();
            lblCompany.Text = AssemblyCompany;
            lblCpyright.Text = AssemblyCopyright;
            lblProductName.Text = AssemblyProduct;
            lblVersion.Text = AssemblyVersion;
            txtDesc.Text = AssemblyDescription;

        }

        public string AssemblyTitle 
        {
            get 
            {
                return assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title ?? "N/A";
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return assembly.GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                return assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description ?? "N/A";
            }
        }

        public string AssemblyProduct
        {
            get
            {
                return assembly.GetCustomAttribute<AssemblyProductAttribute>().Product ?? "N/A";
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                return assembly.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright ?? "N/A";
            }
        }

        public string AssemblyCompany
        {
            get
            {
                return assembly.GetCustomAttribute<AssemblyCompanyAttribute>().Company ?? "N/A";
            }
        }


    }
}
