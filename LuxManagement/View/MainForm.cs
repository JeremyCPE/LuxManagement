using System;
using System.Drawing;
using System.Windows.Forms;
using LuxManagement.Services;

namespace LuxManagement
{


    public partial class MainForm : Form
    {
        private ColorDialog colorDialog;
        private TrackBar trackBarLuminosity;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private Button applyButton;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.trackBarLuminosity = new System.Windows.Forms.TrackBar();
            this.applyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuminosity)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarLuminosity
            // 
            this.trackBarLuminosity.Location = new System.Drawing.Point(12, 85);
            this.trackBarLuminosity.Maximum = 100;
            this.trackBarLuminosity.Name = "trackBarLuminosity";
            this.trackBarLuminosity.Size = new System.Drawing.Size(282, 45);
            this.trackBarLuminosity.TabIndex = 0;
            this.trackBarLuminosity.Value = 50;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(12, 201);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Statistics";
            this.applyButton.Click += Statistics_Click;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "Luminosity Changer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lorem Ipsum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bed Time";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(72, 146);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(66, 23);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(319, 236);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarLuminosity);
            this.Controls.Add(this.applyButton);
            this.Name = "MainForm";
            this.Text = "Color and Luminosity Changer";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuminosity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Statistics_Click(object? sender, EventArgs e)
        {
            LuxManagementServices.SetBrightness();
        }

        private void TrackBarLuminosity_ValueChanged(object? sender, EventArgs e)
        {
            /*NativeMethods.SetLayeredWindowAttributes(overlayWindow.Handle, 0, (byte)(255 - (brightness / 100f) * 255),
(int)LayeredWindowAttributeFlags.LWA_ALPHA);*/

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
            /*
            // This is just a placeholder. To change the actual desktop color, 
            // you would typically change the wallpaper or system theme color.
            // For example, set a solid color wallpaper.
            NativeMethods.SystemParametersInfo(NativeMethods.SPI_SETDESKWALLPAPER, 0, colorHex, NativeMethods.SPIF_UPDATEINIFILE | NativeMethods.SPIF_SENDCHANGE);
            */
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }



}
