using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public class BrightpearlAccount
    {
        public BrightpearlAccount()
        {
            // return FirstOrDefault(IsInUse == false)
            // change IsInUse = true
            // save to context
        }
        public int BrightpearlAccountId { get; set; }
        public bool IsInUse { get; set; }
        public string AccountName { get; set; }
        public string AccountPassword { get; set; }
        
        public void ReleaseSession()
        {
            // this.IsInUse = false and save to context
        }
        
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EventsAndDelegatesForm());
        }
    }
}
