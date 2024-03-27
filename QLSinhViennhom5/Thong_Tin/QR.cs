using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ZXing;
using System.Drawing.Imaging;
using System.IO;

namespace QLSinhViennhom5.Thong_Tin
{
    public partial class QR : Form
    {
        public QR()
        {
            InitializeComponent();
        }

        private void btntao_Click(object sender, EventArgs e)
        {

        }

        private void QR_Load(object sender, EventArgs e)
        {
            string data = tt_sinhvien.thongtinsinhvien;

          
            if (!string.IsNullOrEmpty(data))
            {
              
                BarcodeWriter barcodeWriter = new BarcodeWriter();

             
                barcodeWriter.Format = BarcodeFormat.QR_CODE;

            
                barcodeWriter.Options = new ZXing.Common.EncodingOptions
                {
                    Width = 400,
                    Height = 400,
                    Margin = 0,
                    PureBarcode = true
                };

                barcodeWriter.Options.Hints.Add(ZXing.EncodeHintType.CHARACTER_SET, "UTF-8");

                


                var qrCodeBitmap = barcodeWriter.Write(data);

             
                picQRCode.Image = qrCodeBitmap;
                SaveQRCodeImage(qrCodeBitmap, "QRCodeImage.png");
            }
            else
            {
                // Display an error message if there is no data
                MessageBox.Show("Không có dữ liệu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void SaveQRCodeImage(Bitmap qrCodeBitmap, string fileName)
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, fileName);

               
                qrCodeBitmap.Save(filePath, ImageFormat.Png);

                MessageBox.Show($"Hình ảnh đã được lưu tại {filePath}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Lỗi khi lưu hình ảnh: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
