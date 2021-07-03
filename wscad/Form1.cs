using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using wscad.BusinessLogic;
using wscad.BusinessLogic.Models;
using wscad.BusinessLogic.Services;

namespace wscad
{
    public partial class Form1 : Form
    {
        private readonly IFileLoader _fileLoader;
        private List<Primitive> _figures;
        private readonly int _marginX = 50;
        private readonly int _marginY = 120;

        public Form1(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _fileLoader = serviceProvider.GetService<IFileLoader>();
        }

        private void DisplayFigures()
        {
            if (_figures == null)
            {
                return;
            }

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (var g = Graphics.FromImage(pictureBox1.Image))
            {
                var allPoints = _figures.SelectMany(x => x.GetOriginPoints).ToList();
                var scaleParameters = new ScaleParameters(allPoints, pictureBox1.Size);

                _figures.OrderByDescending(x => x.Filled).ToList()
                    .ForEach(x => x.DrawFigure(g, scaleParameters));

                pictureBox1.Refresh();
            }
        }

        private async void ReadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                DefaultExt = "json",
                Filter = "json files (*.json)|*.json",
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                _figures = await _fileLoader.LoadFileAsync(textBox1.Text);
                DisplayFigures();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Width = Width - _marginX;
            pictureBox1.Height = Height - _marginY;
            DisplayFigures();
        }
    }
}
