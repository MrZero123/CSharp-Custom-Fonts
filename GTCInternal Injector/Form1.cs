using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.IO;
using System.Reflection;

namespace GTCInternal_Injector
{
    public partial class Form1 : Form
    {
        private PrivateFontCollection privateFonts;
        private FontFamily customFontFamily;

        // Font sizes presets for easy use
        public enum FontSize
        {
            Small = 12,
            Medium = 16,
            Large = 24,
            ExtraLarge = 32
        }

        public Form1()
        {
            InitializeComponent();
            LoadCustomFont();
        }

        private void LoadCustomFont()
        {
            try
            {
                privateFonts = new PrivateFontCollection();
                
                // Load font directly from file
                string fontPath = Path.Combine(Application.StartupPath, "SuperFunky-lgmWw.ttf");
                if (File.Exists(fontPath))
                {
                    privateFonts.AddFontFile(fontPath);
                    if (privateFonts.Families.Length > 0)
                    {
                        customFontFamily = privateFonts.Families[0];
                        SetupInitialLabels();
                    }
                    else
                    {
                        MessageBox.Show("No font families were loaded!", "Font Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"Font file not found at: {fontPath}", "Font Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading custom font: {ex.Message}", "Font Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Easy method to apply custom font to any label
        private void SetCustomFont(Label label, FontSize size, string text = null, FontStyle style = FontStyle.Regular)
        {
            if (customFontFamily != null && label != null)
            {
                label.Font = new Font(customFontFamily, (float)size, style);
                if (text != null)
                {
                    label.Text = text;
                }
            }
        }

        // Easy method to apply custom font with exact size
        private void SetCustomFontExact(Label label, float exactSize, string text = null, FontStyle style = FontStyle.Regular)
        {
            if (customFontFamily != null && label != null)
            {
                label.Font = new Font(customFontFamily, exactSize, style);
                if (text != null)
                {
                    label.Text = text;
                }
            }
        }

        private void SetupInitialLabels()
        {
            // Example of using the helper method with preset sizes
            SetCustomFont(label1, FontSize.Large, "GTCInternal Injector");
            
            // You can easily add more labels here like this:
            // SetCustomFont(label2, FontSize.Medium, "Another Label");
            // SetCustomFont(label3, FontSize.Small, "Small Label", FontStyle.Bold);
            
            // Or if you want an exact size:
            // SetCustomFontExact(label4, 18.5f, "Custom Size Label");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (privateFonts != null)
            {
                privateFonts.Dispose();
                privateFonts = null;
            }
            base.OnFormClosing(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // The fonts are already set in SetupInitialLabels
        }

        // Example of how to change font size dynamically
        private void UpdateLabelFont(Label label, FontSize newSize)
        {
            SetCustomFont(label, newSize);
        }
    }
}
