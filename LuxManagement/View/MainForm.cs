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
        private Label luminosityTitle;
        private Label label2;
        private Label BedTimeTitle;
        private DateTimePicker dateTimePicker1;
        private RichTextBox textBoxDebug;
        private CheckBox Debug;
        private Button applyButton;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.trackBarLuminosity = new System.Windows.Forms.TrackBar();
            this.applyButton = new System.Windows.Forms.Button();
            this.luminosityTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BedTimeTitle = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBoxDebug = new System.Windows.Forms.RichTextBox();
            this.Debug = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuminosity)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarLuminosity
            // 
            this.trackBarLuminosity.Location = new System.Drawing.Point(12, 85);
            this.trackBarLuminosity.Maximum = 100;
            this.trackBarLuminosity.Minimum = 10;
            this.trackBarLuminosity.Name = "trackBarLuminosity";
            this.trackBarLuminosity.Size = new System.Drawing.Size(282, 45);
            this.trackBarLuminosity.TabIndex = 0;
            this.trackBarLuminosity.Value = 50;
            this.trackBarLuminosity.ValueChanged += new System.EventHandler(this.TrackBarLuminosity_ValueChanged);

            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(12, 201);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Statistics";
            this.applyButton.Click += new EventHandler(this.Statistics_Click);
            // 
            // label1
            // 
            this.luminosityTitle.AutoSize = true;
            this.luminosityTitle.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.luminosityTitle.Location = new System.Drawing.Point(12, 9);
            this.luminosityTitle.Name = "LuminosityTitle";
            this.luminosityTitle.Size = new System.Drawing.Size(282, 41);
            this.luminosityTitle.TabIndex = 2;
            this.luminosityTitle.Text = "Luminosity Changer";
            this.luminosityTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.BedTimeTitle.AutoSize = true;
            this.BedTimeTitle.Location = new System.Drawing.Point(10, 152);
            this.BedTimeTitle.Name = "bedTimeTitle";
            this.BedTimeTitle.Size = new System.Drawing.Size(56, 15);
            this.BedTimeTitle.TabIndex = 6;
            this.BedTimeTitle.Text = "Bed Time";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(72, 146);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(66, 23);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // textBoxDebug
            // 
            this.textBoxDebug.Location = new System.Drawing.Point(12, 239);
            this.textBoxDebug.Name = "textBoxDebug";
            this.textBoxDebug.Size = new System.Drawing.Size(519, 208);
            this.textBoxDebug.TabIndex = 8;
            this.textBoxDebug.Text = "";
            this.textBoxDebug.Visible = false;
            // 
            // Debug
            // 
            this.Debug.AutoSize = true;
            this.Debug.Location = new System.Drawing.Point(470, 204);
            this.Debug.Name = "Debug";
            this.Debug.Size = new System.Drawing.Size(61, 19);
            this.Debug.TabIndex = 9;
            this.Debug.Text = "Debug";
            this.Debug.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Debug.UseVisualStyleBackColor = true;
            this.Debug.CheckedChanged += new System.EventHandler(debug_checkedChanged);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(543, 469);
            this.Controls.Add(this.Debug);
            this.Controls.Add(this.textBoxDebug);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.BedTimeTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.luminosityTitle);
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
            Log("Not yet implemented");
        }

        private void TrackBarLuminosity_ValueChanged(object? sender, EventArgs e)
        {
            try
            {
                LuxManagementServices.SetBrightness(trackBarLuminosity.Value);
            }
            catch (Exception ex)
            {
                Log($"SetBrightness failed {ex.Message}");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void debug_checkedChanged(object sender, EventArgs e)
        {
            // Enable or disable the logging based on the checkbox state
            if (Debug.Checked)
            {
                Log("Debugging enabled.");
                textBoxDebug.Visible = true;
            }
            else
            {
                Log("Debugging disabled.");
                textBoxDebug.Visible = false;

            }

        }

        private void Log(string message)
        {
            if (Debug.Checked)
            {
                textBoxDebug.AppendText($"{DateTime.Now}: {message}\r\n");
            }
        }
    }



}
