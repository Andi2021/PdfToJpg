using System;
using System.Windows.Forms;


namespace Pdf2Jpg
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run( new FormMain(args) );
        }
    }
}