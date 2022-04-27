using System;
using System.Windows.Forms;

namespace LoadImage
{
    public partial class Main : Form
    {
        private FileHelper _fileHelper = new FileHelper(Program.FilePath);

        private string _imagePath;

        public Main()
        {
            InitializeComponent();

            _imagePath = _fileHelper.DeserializeFromFile();

            if(_imagePath != null)
            {
                pbLoadPicture.Load(_imagePath);
            }
            
            if(pbLoadPicture.Image == null)
            {
                btnDelete.Visible = false;
            }
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _imagePath = openFileDialog.FileName;

                btnDelete.Visible = true;

                _fileHelper.SerializeToFile(_imagePath);

                pbLoadPicture.Load(_imagePath);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            pbLoadPicture.Image = null;
            btnDelete.Visible = false;
            _fileHelper.SerializeToFile(null);
        }
    }
}
