using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsApp70
{
    public partial class Form1 : Form
    {
        Process[] processes;
        int[] ID;
        string[] names;


        [DllImport("kernel32.dll", SetLastError = true)]

        static extern bool WriteProcessMemory(IntPtr hProcess, 
            IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize,
            out UIntPtr lpNumberOfBytesWritten);


        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess,
            bool bInheritHandle, int dwProcessId);


        public Form1()
        {
            InitializeComponent();
        }
       // https://yadi.sk/d/LUn4RtmsKi8rsw

        private void button1_Click(object sender, EventArgs e)
        {
            processes = Process.GetProcesses();
            ID = new int[processes.Length];
            names = new string[processes.Length];

            for(int i=0; i< processes.Length;i++)
            {
                ID[i] = processes[i].Id;
                names[i] = processes[i].ProcessName;
                listBox1.Items.Add(names[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           Process myProcess= processes[listBox1.SelectedIndex];
           IntPtr GameAdress = OpenProcess(0x001F0FFF, false, myProcess.Id);
           IntPtr Lifes = (IntPtr)0x005A1290;
           byte[] num = BitConverter.GetBytes(200000);
           UIntPtr NAFIG_NE_NADO = new UIntPtr(10);
           WriteProcessMemory(GameAdress, Lifes, num, 4, out NAFIG_NE_NADO);

        }
    }
}
