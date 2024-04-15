using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.Remoting.Contexts;
namespace DESAlgrorithms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog open;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            open =new OpenFileDialog();
            open.Filter = "|*.txt";
            if(open.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = open.FileName; 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] keyBytes = new byte[8];

            // Sử dụng RNGCryptoServiceProvider để tạo số ngẫu nhiên để làm khóa
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(keyBytes);
            }

            // Chuyển đổi mảng byte sang dạng hex string
            string keyHex = BitConverter.ToString(keyBytes).Replace("-", "");
            textBox2.Text = keyHex;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamReader streamReader1 = new StreamReader(textBox1.Text);
            String plain_Text= streamReader1.ReadToEnd().ToString();
            String key =textBox2.Text; 
            String cipher_Text = DesEncryption.EncryptAllMessages(plain_Text, key);
            string fileName = "file_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            // Thư mục mặc định để lưu file (ví dụ: thư mục chương trình)
            string directoryPath = "C:\\Users\\Acer\\Downloads";

            // Đường dẫn đến file
            string filePath = Path.Combine(directoryPath, fileName);
            File.WriteAllText(filePath, cipher_Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamReader streamReader2 = new StreamReader(textBox1.Text);
            String cipher_Text = streamReader2.ReadToEnd().ToString();
            String key = textBox2.Text;
            String plain_Text=DesEncryption.DecryptAllMessages(cipher_Text, key);
            string fileName = "file_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            // Thư mục mặc định để lưu file (ví dụ: thư mục chương trình)
            string directoryPath = "C:\\Users\\Acer\\Downloads";

            // Đường dẫn đến file
            string filePath = Path.Combine(directoryPath, fileName);
            File.WriteAllText(filePath, cipher_Text);
        }
    }
}
