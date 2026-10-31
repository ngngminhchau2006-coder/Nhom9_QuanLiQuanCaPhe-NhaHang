namespace Nhom9_QuanLiQuanCaPhe_NhaHang;
using System;
using System.Windows.Forms;
using Nhom9_QuanLiQuanCaPhe_NhaHang.DAL;
static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        try
        {
            // Khoi tao database
            DatabaseHelper.InitializeDatabase();

            // Kiem tra ket noi
            if (!DatabaseHelper.KiemTraKetNoi())
            {
                MessageBox.Show(
                    "Database chua duoc tao dung!",
                    "Loi database",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            MessageBox.Show(
                "Ket noi SQLite thanh cong!",
                "Thong bao",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Mo giao dien chinh
            Application.Run(new DSBan());
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Loi khoi dong:\n" + ex.Message,
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}