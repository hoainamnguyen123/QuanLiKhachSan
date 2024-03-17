using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QuanLiKhachSan
{
    class function
    {
        protected SqlConnection getConnection()// Phương thức để lấy đối tượng kết nối SQL
        {
            SqlConnection con = new SqlConnection();// Tạo một đối tượng kết nối SQL mới
            con.ConnectionString = "Data Source=LANPHUOWNGG\\SQLEXPRESS;Initial Catalog=QLKhachSan;Integrated Security=True";
            return con;// Trả về đối tượng kết nối
        }

        public DataSet GetData(string query) // Phương thức công khai để lấy dữ liệu từ cơ sở dữ liệu
        {
            SqlConnection con = getConnection(); // Lấy đối tượng kết nối từ phương thức getConnection()
            SqlCommand cmd = new SqlCommand(query,con); // Tạo một đối tượng SqlCommand với truy vấn SQL và kết nối
            SqlDataAdapter da = new SqlDataAdapter(cmd); // Tạo một đối tượng SqlDataAdapter từ đối tượng SqlCommand
            DataSet ds = new DataSet(); // Tạo một DataSet mới để chứa dữ liệu
            da.Fill(ds); // Đổ dữ liệu từ SqlDataAdapter vào DataSet
            return ds; // Trả về DataSet chứa dữ liệu
        }

        public void setData(String query, String message) // Phương thức công khai để thực thi truy vấn SQL và hiển thị thông báo
        {
            SqlConnection con = getConnection(); // Lấy đối tượng kết nối từ phương thức getConnection()
            SqlCommand cmd = new SqlCommand(); // Tạo một đối tượng SqlCommand mới
            cmd.Connection = con; // Gán kết nối cho đối tượng SqlCommand
            con.Open(); // Mở kết nối
            cmd.CommandText = query; // Gán truy vấn SQL cho đối tượng SqlCommand
            cmd.ExecuteNonQuery(); // Thực thi truy vấn SQL không trả về dữ liệu
            con.Close(); // Đóng kết nối
            MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information); // Hiển thị thông báo thành công
        }
        public SqlDataReader getForCombo(String query) // Phương thức công khai để lấy dữ liệu từ cơ sở dữ liệu và trả về SqlDataReader
        {
            SqlConnection con = getConnection(); // Lấy đối tượng kết nối từ phương thức getConnection()
            SqlCommand cmd = new SqlCommand(); // Tạo một đối tượng SqlCommand mới
            cmd.Connection = con; // Gán kết nối cho đối tượng SqlCommand
            con.Open(); // Mở kết nối
            cmd = new SqlCommand(query, con); // Tạo một đối tượng SqlCommand mới với truy vấn SQL và kết nối
            SqlDataReader sdr = cmd.ExecuteReader(); // Thực thi truy vấn SQL và lấy SqlDataReader
            return sdr; // Trả về SqlDataReader
        }
    }
}
