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
        private Label brightnessLabel;
        private Label bedTimeTitle;
        private DateTimePicker bedTimePicker1;
        private RichTextBox textBoxDebug;
        private CheckBox Debug;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TrackBar trackBarBlueLight;
        private Label blueLightLabel;
        private Label label1;
        private DateTimePicker wakeUpTimePicker;
        private Button applyButton;

        public MainForm()
        {
            GetCurrentBrightnessAndColor();
            InitializeComponent();
        }

        private void GetCurrentBrightnessAndColor()
        {
            // To implement
            LuxManagementServices.SetBrightness(30);

        }

        private void InitializeComponent()
        {
            this.trackBarLuminosity = new System.Windows.Forms.TrackBar();
            this.applyButton = new System.Windows.Forms.Button();
            this.luminosityTitle = new System.Windows.Forms.Label();
            this.brightnessLabel = new System.Windows.Forms.Label();
            this.bedTimeTitle = new System.Windows.Forms.Label();
            this.bedTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBoxDebug = new System.Windows.Forms.RichTextBox();
            this.Debug = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.trackBarBlueLight = new System.Windows.Forms.TrackBar();
            this.blueLightLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.wakeUpTimePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuminosity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlueLight)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarLuminosity
            // 
            this.trackBarLuminosity.Location = new System.Drawing.Point(12, 85);
            this.trackBarLuminosity.Maximum = 100;
            this.trackBarLuminosity.Minimum = 10;
            this.trackBarLuminosity.Name = "trackBarLuminosity";
            this.trackBarLuminosity.Size = new System.Drawing.Size(247, 45);
            this.trackBarLuminosity.TabIndex = 0;
            this.trackBarLuminosity.Value = LuxManagementServices._currentBrightness;
            this.trackBarLuminosity.ValueChanged += new System.EventHandler(this.TrackBarLuminosity_ValueChanged);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(12, 201);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Statistics";
            this.applyButton.Click += new System.EventHandler(this.Statistics_Click);
            // 
            // luminosityTitle
            // 
            this.luminosityTitle.AutoSize = true;
            this.luminosityTitle.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.luminosityTitle.Location = new System.Drawing.Point(12, 9);
            this.luminosityTitle.Name = "luminosityTitle";
            this.luminosityTitle.Size = new System.Drawing.Size(282, 41);
            this.luminosityTitle.TabIndex = 2;
            this.luminosityTitle.Text = "Luminosity Changer";
            this.luminosityTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // brightnessLabel
            // 
            this.brightnessLabel.AutoSize = true;
            this.brightnessLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.brightnessLabel.Location = new System.Drawing.Point(10, 63);
            this.brightnessLabel.Name = "brightnessLabel";
            this.brightnessLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.brightnessLabel.Size = new System.Drawing.Size(73, 19);
            this.brightnessLabel.TabIndex = 3;
            this.brightnessLabel.Text = "Brightness";
            // 
            // bedTimeTitle
            // 
            this.bedTimeTitle.AutoSize = true;
            this.bedTimeTitle.Location = new System.Drawing.Point(10, 172);
            this.bedTimeTitle.Name = "bedTimeTitle";
            this.bedTimeTitle.Size = new System.Drawing.Size(56, 15);
            this.bedTimeTitle.TabIndex = 6;
            this.bedTimeTitle.Text = "Bed Time";
            // 
            // bedTimePicker1
            // 
            this.bedTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.bedTimePicker1.Location = new System.Drawing.Point(72, 166);
            this.bedTimePicker1.Name = "bedTimePicker1";
            this.bedTimePicker1.Size = new System.Drawing.Size(66, 23);
            this.bedTimePicker1.TabIndex = 7;
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
            this.Debug.CheckedChanged += new System.EventHandler(this.debug_checkedChanged);
            // 
            // trackBarBlueLight
            // 
            this.trackBarBlueLight.Location = new System.Drawing.Point(265, 85);
            this.trackBarBlueLight.Maximum = 100;
            this.trackBarBlueLight.Minimum = 10;
            this.trackBarBlueLight.Name = "trackBarBlueLight";
            this.trackBarBlueLight.Size = new System.Drawing.Size(247, 45);
            this.trackBarBlueLight.TabIndex = 10;
            this.trackBarBlueLight.Value = 100;
            this.trackBarBlueLight.ValueChanged += new System.EventHandler(this.TrackBarBlueLight_ValueChanged);
            // 
            // blueLightLabel
            // 
            this.blueLightLabel.AutoSize = true;
            this.blueLightLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.blueLightLabel.Location = new System.Drawing.Point(265, 63);
            this.blueLightLabel.Name = "blueLightLabel";
            this.blueLightLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.blueLightLabel.Size = new System.Drawing.Size(66, 19);
            this.blueLightLabel.TabIndex = 11;
            this.blueLightLabel.Text = "BlueLight";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "WakeUp Time";
            // 
            // wakeUpTimePicker
            // 
            this.wakeUpTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.wakeUpTimePicker.Location = new System.Drawing.Point(443, 168);
            this.wakeUpTimePicker.Name = "wakeUpTimePicker";
            this.wakeUpTimePicker.Size = new System.Drawing.Size(66, 23);
            this.wakeUpTimePicker.TabIndex = 13;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(543, 469);
            this.Controls.Add(this.wakeUpTimePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.blueLightLabel);
            this.Controls.Add(this.trackBarBlueLight);
            this.Controls.Add(this.Debug);
            this.Controls.Add(this.textBoxDebug);
            this.Controls.Add(this.bedTimePicker1);
            this.Controls.Add(this.bedTimeTitle);
            this.Controls.Add(this.brightnessLabel);
            this.Controls.Add(this.luminosityTitle);
            this.Controls.Add(this.trackBarLuminosity);
            this.Controls.Add(this.applyButton);
            this.Name = "MainForm";
            this.Text = "Color and Luminosity Changer";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuminosity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlueLight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void TrackBarBlueLight_ValueChanged(object? sender, EventArgs e)
        {
            try
            {
                LuxManagementServices.ReduceBlueLight(trackBarBlueLight.Value);
            }
            catch (Exception ex)
            {
                Log($"SetBrightness failed {ex.Message}");
            }
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

        #region Logging
        private void Log(string message)
        {
            if (Debug.Checked)
            {
                textBoxDebug.AppendText($"{DateTime.Now}: {message}\r\n");
            }
        }

        #endregion
    }



}
