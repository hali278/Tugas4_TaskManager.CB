using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Panggil fungsi untuk memuat proses saat form dibuka
            LoadProcesses();
        }

        private void LoadProcesses()
        {
            // Bersihkan item yang ada di ListView
            listView1.Items.Clear();

            // Ambil daftar proses yang sedang berjalan
            Process[] processes = Process.GetProcesses();

            foreach (Process proc in processes)
            {
                try
                {
                    // Buat item untuk setiap proses
                    ListViewItem item = new ListViewItem(proc.ProcessName); // Kolom 1: Process Name
                    item.SubItems.Add(proc.Id.ToString()); // Kolom 2: Process ID
                    item.SubItems.Add((proc.WorkingSet64 / 1024).ToString("N0")); // Kolom 3: Memory Usage (KB)

                    // Tambahkan item ke ListView
                    listView1.Items.Add(item);
                }
                catch (Exception)
                {
                    // Jika proses gagal diakses, lewati
                    continue;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Muat ulang proses saat tombol Refresh diklik
            LoadProcesses();
        }
    }
}
