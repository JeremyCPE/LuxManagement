using System;
using System.Drawing;
using System.Windows.Forms;

namespace LuxManagement
{


    public partial class MainForm : Form
    {
        private ColorDialog colorDialog;
        private TrackBar trackBarLuminosity;
        private Button applyButton;

        public MainForm()
        {
            InitializeComponent();

            colorDialog = new ColorDialog();
            trackBarLuminosity = new TrackBar();
            applyButton = new Button();

            trackBarLuminosity.Minimum = 0;
            trackBarLuminosity.Maximum = 100;
            trackBarLuminosity.Value = 50;

            applyButton.Text = "Apply";
            applyButton.Click += ApplyButton_Click;

            Controls.Add(trackBarLuminosity);
            Controls.Add(applyButton);
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = colorDialog.Color;
                float luminosity = trackBarLuminosity.Value / 100f;
                Color adjustedColor = ChangeColorLuminosity(selectedColor, luminosity);

                ChangeDesktopColor(ColorTranslator.ToHtml(adjustedColor));
            }
        }

        public Color ChangeColorLuminosity(Color color, float luminosity)
        {
            float r = color.R * luminosity;
            float g = color.G * luminosity;
            float b = color.B * luminosity;

            return Color.FromArgb((int)r, (int)g, (int)b);
        }

        public void ChangeDesktopColor(string colorHex)
        {
            // This is just a placeholder. To change the actual desktop color, 
            // you would typically change the wallpaper or system theme color.
            // For example, set a solid color wallpaper.
            NativeMethods.SystemParametersInfo(NativeMethods.SPI_SETDESKWALLPAPER, 0, colorHex, NativeMethods.SPIF_UPDATEINIFILE | NativeMethods.SPIF_SENDCHANGE);
        }
    }



}
