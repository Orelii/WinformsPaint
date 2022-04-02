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
using Newtonsoft.Json;

namespace Paint
{
    public partial class FormOne : System.Windows.Forms.Form
    {
        Button[,] buttonarray = new Button[8, 8];
        int[,] array = new int[8, 8];
        string mode;
        bool pencilSwitch = false;
        bool gridlines = false;

        public FormOne()
        {
            InitializeComponent();
            string path = Directory.GetCurrentDirectory();
            path = path.Replace(@"bin\Debug", @"saves");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            #region definitions
            buttonarray[0, 0] = Cell0;
            buttonarray[1, 0] = Cell1;
            buttonarray[2, 0] = Cell2;
            buttonarray[3, 0] = Cell3;
            buttonarray[4, 0] = Cell4;
            buttonarray[5, 0] = Cell5;
            buttonarray[6, 0] = Cell6;
            buttonarray[7, 0] = Cell7;
            buttonarray[0, 1] = Cell8;
            buttonarray[1, 1] = Cell9;
            buttonarray[2, 1] = Cell10;
            buttonarray[3, 1] = Cell11;
            buttonarray[4, 1] = Cell12;
            buttonarray[5, 1] = Cell13;
            buttonarray[6, 1] = Cell14;
            buttonarray[7, 1] = Cell15;
            buttonarray[0, 2] = Cell16;
            buttonarray[1, 2] = Cell17;
            buttonarray[2, 2] = Cell18;
            buttonarray[3, 2] = Cell19;
            buttonarray[4, 2] = Cell20;
            buttonarray[5, 2] = Cell21;
            buttonarray[6, 2] = Cell22;
            buttonarray[7, 2] = Cell23;
            buttonarray[0, 3] = Cell24;
            buttonarray[1, 3] = Cell25;
            buttonarray[2, 3] = Cell26;
            buttonarray[3, 3] = Cell27;
            buttonarray[4, 3] = Cell28;
            buttonarray[5, 3] = Cell29;
            buttonarray[6, 3] = Cell30;
            buttonarray[7, 3] = Cell31;
            buttonarray[0, 4] = Cell32;
            buttonarray[1, 4] = Cell33;
            buttonarray[2, 4] = Cell34;
            buttonarray[3, 4] = Cell35;
            buttonarray[4, 4] = Cell36;
            buttonarray[5, 4] = Cell37;
            buttonarray[6, 4] = Cell38;
            buttonarray[7, 4] = Cell39;
            buttonarray[0, 5] = Cell40;
            buttonarray[1, 5] = Cell41;
            buttonarray[2, 5] = Cell42;
            buttonarray[3, 5] = Cell43;
            buttonarray[4, 5] = Cell44;
            buttonarray[5, 5] = Cell45;
            buttonarray[6, 5] = Cell46;
            buttonarray[7, 5] = Cell47;
            buttonarray[0, 6] = Cell48;
            buttonarray[1, 6] = Cell49;
            buttonarray[2, 6] = Cell50;
            buttonarray[3, 6] = Cell51;
            buttonarray[4, 6] = Cell52;
            buttonarray[5, 6] = Cell53;
            buttonarray[6, 6] = Cell54;
            buttonarray[7, 6] = Cell55;
            buttonarray[0, 7] = Cell56;
            buttonarray[1, 7] = Cell57;
            buttonarray[2, 7] = Cell58;
            buttonarray[3, 7] = Cell59;
            buttonarray[4, 7] = Cell60;
            buttonarray[5, 7] = Cell61;
            buttonarray[6, 7] = Cell62;
            buttonarray[7, 7] = Cell63;
            #endregion
        }
        private void colourDisplayClick(object sender, EventArgs e)
        {
            colourSelect.FullOpen = true;
            colourSelect.AllowFullOpen = true;
            colourSelect.AnyColor = true;
            colourSelect.ShowDialog();  
            colourDisplayLC.BackColor = colourSelect.Color;
        }

        private void colourDisplayAltClick(object sender, EventArgs e)
        {
            colourSelect2.FullOpen = true;
            colourSelect2.AllowFullOpen = true;
            colourSelect2.AnyColor = true;
            colourSelect2.ShowDialog();
            colourDisplayRC.BackColor = colourSelect2.Color;
        }

        private void clickButton(object sender, MouseEventArgs e)
        {
            Button source = sender as Button;

            switch (mode)
            {
                case "pencil":
                    if (e.Button == MouseButtons.Left)
                    {
                        source.BackColor = colourDisplayLC.BackColor;
                        source.ForeColor = colourDisplayLC.BackColor;
                        source.FlatAppearance.BorderColor = colourDisplayLC.BackColor;
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        source.BackColor = colourDisplayRC.BackColor;
                        source.ForeColor = colourDisplayRC.BackColor;
                        source.FlatAppearance.BorderColor = colourDisplayRC.BackColor;
                    }
                    break;
                case "eraser":
                    source.BackColor = SystemColors.Control;
                    source.ForeColor = SystemColors.Control;
                    source.FlatAppearance.BorderColor = SystemColors.Control;
                    break;
                case "eyedropper":
                    if (e.Button == MouseButtons.Left)
                    {
                        colourDisplayLC.BackColor = source.BackColor;
                        if (pencilSwitch == true)
                        {
                            mode = "pencil";
                            toolIcon.Image = Properties.Resources.pencil;
                            Settings0.Visible = true;
                            Settings0.Enabled = true;
                            Settings0.Text = "Fill Canvas With Primary Colour";
                            Settings1.Visible = true;
                            Settings1.Enabled = true;
                            Settings1.Text = "Fill Canvas With Secondary Colour";
                        }
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        colourDisplayRC.BackColor = source.BackColor;
                        if (pencilSwitch == true)
                        {
                            mode = "pencil";
                            toolIcon.Image = Properties.Resources.pencil;
                            Settings0.Visible = true;
                            Settings0.Enabled = true;
                            Settings0.Text = "Fill Canvas With Primary Colour";
                            Settings1.Visible = true;
                            Settings1.Enabled = true;
                            Settings1.Text = "Fill Canvas With Secondary Colour";
                        }
                    }
                    break;

            }
        }
        private void SwitchMode(object sender, EventArgs e)
        {
            Button source = sender as Button;
            switch (source.Text)
            {
                case "Pencil":
                    mode = "pencil";
                    toolIcon.Image = Properties.Resources.pencil;
                    Settings0.Visible = true;
                    Settings0.Enabled = true;
                    Settings0.Text = "Fill Canvas With Primary Colour";
                    Settings1.Visible = true;
                    Settings1.Enabled = true;
                    Settings1.Text = "Fill Canvas With Secondary Colour";
                    break;
                case "Eraser":
                    mode = "eraser";
                    toolIcon.Image = Properties.Resources.eraser;
                    Settings0.Visible = true;
                    Settings0.Enabled = true;
                    Settings0.Text = "Clear Canvas";
                    Settings1.Visible = false;
                    Settings1.Enabled = false;
                    break;
                case "Eyedropper":
                    mode = "eyedropper";
                    toolIcon.Image = Properties.Resources.eyedropper;
                    Settings0.Visible = true;
                    Settings0.Enabled = true;
                    Settings0.Text = "Reset Colours";
                    Settings1.Visible = true;
                    Settings1.Enabled = true;
                    if (pencilSwitch == true)
                    {
                        Settings1.Text = "Keep Tool";
                    }
                    else
                    {
                        Settings1.Text = "Switch to Pencil";
                    }
                    break;
            }
        }
        private void Settings0_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case "pencil":
                    foreach (Button iteration in buttonarray)
                    {
                        iteration.BackColor = colourDisplayLC.BackColor;
                        iteration.FlatAppearance.BorderColor = colourDisplayLC.BackColor;
                    }
                    break;
                case "eraser":
                    foreach (Button iteration in buttonarray)
                    {
                        iteration.BackColor = SystemColors.Control;
                        iteration.FlatAppearance.BorderColor = SystemColors.Control;
                    }
                    break;
                case "eyedropper":
                    colourDisplayLC.BackColor = Color.White;
                    colourDisplayRC.BackColor = SystemColors.ActiveCaptionText;
                    break;
            }
        }

        private void Settings1_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case "pencil":
                    foreach (Button iteration in buttonarray)
                    {
                        iteration.BackColor = colourDisplayRC.BackColor;
                        iteration.FlatAppearance.BorderColor = colourDisplayRC.BackColor;
                    }
                    break;
                case "eyedropper":
                    if (pencilSwitch == true)
                    {
                        pencilSwitch = false;
                        Settings1.Text = "Switch to Pencil";
                    }
                    else
                    {
                        pencilSwitch = true;
                        Settings1.Text = "Keep Tool";
                    }
                    break;
            }
        }

        private void GridlinesButton_Click(object sender, EventArgs e)
        {
            if (gridlines == false)
            {
                foreach (Button iteration in buttonarray)
                {
                    iteration.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
                }
                gridlines = true;
            }
            else
            {
                foreach (Button iteration in buttonarray)
                {
                    iteration.FlatAppearance.BorderColor = iteration.BackColor;
                }
                gridlines = false;
            }
        }
        private void SaveAs(object sender, EventArgs e)
        {
            try
            {
                Button source = sender as Button;
                string path = Directory.GetCurrentDirectory();
                path = path.Replace(@"bin\Debug", @"saves\");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                saveDialog.InitialDirectory = path;
                saveDialog.AddExtension = true;
                saveDialog.Filter = "Save File | *.json";
                saveDialog.DefaultExt = "json";
                saveDialog.ShowDialog();
                #region chunky bunky flunky code
                array[0, 0] = Cell0.BackColor.ToArgb();
                array[1, 0] = Cell1.BackColor.ToArgb();
                array[2, 0] = Cell2.BackColor.ToArgb();
                array[3, 0] = Cell3.BackColor.ToArgb();
                array[4, 0] = Cell4.BackColor.ToArgb();
                array[5, 0] = Cell5.BackColor.ToArgb();
                array[6, 0] = Cell6.BackColor.ToArgb();
                array[7, 0] = Cell7.BackColor.ToArgb();
                array[0, 1] = Cell8.BackColor.ToArgb();
                array[1, 1] = Cell9.BackColor.ToArgb();
                array[2, 1] = Cell10.BackColor.ToArgb();
                array[3, 1] = Cell11.BackColor.ToArgb();
                array[4, 1] = Cell12.BackColor.ToArgb();
                array[5, 1] = Cell13.BackColor.ToArgb();
                array[6, 1] = Cell14.BackColor.ToArgb();
                array[7, 1] = Cell15.BackColor.ToArgb();
                array[0, 2] = Cell16.BackColor.ToArgb();
                array[1, 2] = Cell17.BackColor.ToArgb();
                array[2, 2] = Cell18.BackColor.ToArgb();
                array[3, 2] = Cell19.BackColor.ToArgb();
                array[4, 2] = Cell20.BackColor.ToArgb();
                array[5, 2] = Cell21.BackColor.ToArgb();
                array[6, 2] = Cell22.BackColor.ToArgb();
                array[7, 2] = Cell23.BackColor.ToArgb();
                array[0, 3] = Cell24.BackColor.ToArgb();
                array[1, 3] = Cell25.BackColor.ToArgb();
                array[2, 3] = Cell26.BackColor.ToArgb();
                array[3, 3] = Cell27.BackColor.ToArgb();
                array[4, 3] = Cell28.BackColor.ToArgb();
                array[5, 3] = Cell29.BackColor.ToArgb();
                array[6, 3] = Cell30.BackColor.ToArgb();
                array[7, 3] = Cell31.BackColor.ToArgb();
                array[0, 4] = Cell32.BackColor.ToArgb();
                array[1, 4] = Cell33.BackColor.ToArgb();
                array[2, 4] = Cell34.BackColor.ToArgb();
                array[3, 4] = Cell35.BackColor.ToArgb();
                array[4, 4] = Cell36.BackColor.ToArgb();
                array[5, 4] = Cell37.BackColor.ToArgb();
                array[6, 4] = Cell38.BackColor.ToArgb();
                array[7, 4] = Cell39.BackColor.ToArgb();
                array[0, 5] = Cell40.BackColor.ToArgb();
                array[1, 5] = Cell41.BackColor.ToArgb();
                array[2, 5] = Cell42.BackColor.ToArgb();
                array[3, 5] = Cell43.BackColor.ToArgb();
                array[4, 5] = Cell44.BackColor.ToArgb();
                array[5, 5] = Cell45.BackColor.ToArgb();
                array[6, 5] = Cell46.BackColor.ToArgb();
                array[7, 5] = Cell47.BackColor.ToArgb();
                array[0, 6] = Cell48.BackColor.ToArgb();
                array[1, 6] = Cell49.BackColor.ToArgb();
                array[2, 6] = Cell50.BackColor.ToArgb();
                array[3, 6] = Cell51.BackColor.ToArgb();
                array[4, 6] = Cell52.BackColor.ToArgb();
                array[5, 6] = Cell53.BackColor.ToArgb();
                array[6, 6] = Cell54.BackColor.ToArgb();
                array[7, 6] = Cell55.BackColor.ToArgb();
                array[0, 7] = Cell56.BackColor.ToArgb();
                array[1, 7] = Cell57.BackColor.ToArgb();
                array[2, 7] = Cell58.BackColor.ToArgb();
                array[3, 7] = Cell59.BackColor.ToArgb();
                array[4, 7] = Cell60.BackColor.ToArgb();
                array[5, 7] = Cell61.BackColor.ToArgb();
                array[6, 7] = Cell62.BackColor.ToArgb();
                array[7, 7] = Cell63.BackColor.ToArgb();
                #endregion
                string filename = saveDialog.FileName;
                filename.Replace(' ', '_');
                if (filename != null)
                {
                    File.WriteAllText(filename, JsonConvert.SerializeObject(array));
                }
            }
            catch
            {
                Console.WriteLine("darn looks like an error i guess lmaooo");
            }
        }

        private void LoadSave(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Replace(@"bin\Debug", @"saves\");
            openDialog.InitialDirectory = path;
            openDialog.AddExtension = true;
            openDialog.Filter = "Load File | *.json";
            openDialog.DefaultExt = "json";
            openDialog.ShowDialog();
            try
            {
                if (openDialog.FileName != null)
                {
                    int[,] array = JsonConvert.DeserializeObject<int[,]>(File.ReadAllText(openDialog.FileName));
                    if (gridlines)
                    {
                        #region hunka bunka burning bluster
                        Cell0.BackColor = Color.FromArgb(array[0, 0]);
                        Cell1.BackColor = Color.FromArgb(array[1, 0]);
                        Cell2.BackColor = Color.FromArgb(array[2, 0]);
                        Cell3.BackColor = Color.FromArgb(array[3, 0]);
                        Cell4.BackColor = Color.FromArgb(array[4, 0]);
                        Cell5.BackColor = Color.FromArgb(array[5, 0]);
                        Cell6.BackColor = Color.FromArgb(array[6, 0]);
                        Cell7.BackColor = Color.FromArgb(array[7, 0]);
                        Cell8.BackColor = Color.FromArgb(array[0, 1]);
                        Cell9.BackColor = Color.FromArgb(array[1, 1]);
                        Cell10.BackColor = Color.FromArgb(array[2, 1]);
                        Cell11.BackColor = Color.FromArgb(array[3, 1]);
                        Cell12.BackColor = Color.FromArgb(array[4, 1]);
                        Cell13.BackColor = Color.FromArgb(array[5, 1]);
                        Cell14.BackColor = Color.FromArgb(array[6, 1]);
                        Cell15.BackColor = Color.FromArgb(array[7, 1]);
                        Cell16.BackColor = Color.FromArgb(array[0, 2]);
                        Cell17.BackColor = Color.FromArgb(array[1, 2]);
                        Cell18.BackColor = Color.FromArgb(array[2, 2]);
                        Cell19.BackColor = Color.FromArgb(array[3, 2]);
                        Cell20.BackColor = Color.FromArgb(array[4, 2]);
                        Cell21.BackColor = Color.FromArgb(array[5, 2]);
                        Cell22.BackColor = Color.FromArgb(array[6, 2]);
                        Cell23.BackColor = Color.FromArgb(array[7, 2]);
                        Cell24.BackColor = Color.FromArgb(array[0, 3]);
                        Cell25.BackColor = Color.FromArgb(array[1, 3]);
                        Cell26.BackColor = Color.FromArgb(array[2, 3]);
                        Cell27.BackColor = Color.FromArgb(array[3, 3]);
                        Cell28.BackColor = Color.FromArgb(array[4, 3]);
                        Cell29.BackColor = Color.FromArgb(array[5, 3]);
                        Cell30.BackColor = Color.FromArgb(array[6, 3]);
                        Cell31.BackColor = Color.FromArgb(array[7, 3]);
                        Cell32.BackColor = Color.FromArgb(array[0, 4]);
                        Cell33.BackColor = Color.FromArgb(array[1, 4]);
                        Cell34.BackColor = Color.FromArgb(array[2, 4]);
                        Cell35.BackColor = Color.FromArgb(array[3, 4]);
                        Cell36.BackColor = Color.FromArgb(array[4, 4]);
                        Cell37.BackColor = Color.FromArgb(array[5, 4]);
                        Cell38.BackColor = Color.FromArgb(array[6, 4]);
                        Cell39.BackColor = Color.FromArgb(array[7, 4]);
                        Cell40.BackColor = Color.FromArgb(array[0, 5]);
                        Cell41.BackColor = Color.FromArgb(array[1, 5]);
                        Cell42.BackColor = Color.FromArgb(array[2, 5]);
                        Cell43.BackColor = Color.FromArgb(array[3, 5]);
                        Cell44.BackColor = Color.FromArgb(array[4, 5]);
                        Cell45.BackColor = Color.FromArgb(array[5, 5]);
                        Cell46.BackColor = Color.FromArgb(array[6, 5]);
                        Cell47.BackColor = Color.FromArgb(array[7, 5]);
                        Cell48.BackColor = Color.FromArgb(array[0, 6]);
                        Cell49.BackColor = Color.FromArgb(array[1, 6]);
                        Cell50.BackColor = Color.FromArgb(array[2, 6]);
                        Cell51.BackColor = Color.FromArgb(array[3, 6]);
                        Cell52.BackColor = Color.FromArgb(array[4, 6]);
                        Cell53.BackColor = Color.FromArgb(array[5, 6]);
                        Cell54.BackColor = Color.FromArgb(array[6, 6]);
                        Cell55.BackColor = Color.FromArgb(array[7, 6]);
                        Cell56.BackColor = Color.FromArgb(array[0, 7]);
                        Cell57.BackColor = Color.FromArgb(array[1, 7]);
                        Cell58.BackColor = Color.FromArgb(array[2, 7]);
                        Cell59.BackColor = Color.FromArgb(array[3, 7]);
                        Cell60.BackColor = Color.FromArgb(array[4, 7]);
                        Cell61.BackColor = Color.FromArgb(array[5, 7]);
                        Cell62.BackColor = Color.FromArgb(array[6, 7]);
                        Cell63.BackColor = Color.FromArgb(array[7, 7]);
                        #endregion
                    }
                    else
                    {
                        #region hunka bunka burning bluster
                        Cell0.BackColor = Color.FromArgb(array[0, 0]);
                        Cell0.FlatAppearance.BorderColor = Cell0.BackColor;
                        Cell1.BackColor = Color.FromArgb(array[1, 0]);
                        Cell1.FlatAppearance.BorderColor = Cell1.BackColor;
                        Cell2.BackColor = Color.FromArgb(array[2, 0]);
                        Cell2.FlatAppearance.BorderColor = Cell2.BackColor;
                        Cell3.BackColor = Color.FromArgb(array[3, 0]);
                        Cell3.FlatAppearance.BorderColor = Cell3.BackColor;
                        Cell4.BackColor = Color.FromArgb(array[4, 0]);
                        Cell4.FlatAppearance.BorderColor = Cell4.BackColor;
                        Cell5.BackColor = Color.FromArgb(array[5, 0]);
                        Cell5.FlatAppearance.BorderColor = Cell5.BackColor;
                        Cell6.BackColor = Color.FromArgb(array[6, 0]);
                        Cell6.FlatAppearance.BorderColor = Cell6.BackColor;
                        Cell7.BackColor = Color.FromArgb(array[7, 0]);
                        Cell7.FlatAppearance.BorderColor = Cell7.BackColor;
                        Cell8.BackColor = Color.FromArgb(array[0, 1]);
                        Cell8.FlatAppearance.BorderColor = Cell8.BackColor;
                        Cell9.BackColor = Color.FromArgb(array[1, 1]);
                        Cell9.FlatAppearance.BorderColor = Cell9.BackColor;
                        Cell10.BackColor = Color.FromArgb(array[2, 1]);
                        Cell10.FlatAppearance.BorderColor = Cell10.BackColor;
                        Cell11.BackColor = Color.FromArgb(array[3, 1]);
                        Cell11.FlatAppearance.BorderColor = Cell11.BackColor;
                        Cell12.BackColor = Color.FromArgb(array[4, 1]);
                        Cell12.FlatAppearance.BorderColor = Cell12.BackColor;
                        Cell13.BackColor = Color.FromArgb(array[5, 1]);
                        Cell13.FlatAppearance.BorderColor = Cell13.BackColor;
                        Cell14.BackColor = Color.FromArgb(array[6, 1]);
                        Cell14.FlatAppearance.BorderColor = Cell14.BackColor;
                        Cell15.BackColor = Color.FromArgb(array[7, 1]);
                        Cell15.FlatAppearance.BorderColor = Cell15.BackColor;
                        Cell16.BackColor = Color.FromArgb(array[0, 2]);
                        Cell16.FlatAppearance.BorderColor = Cell16.BackColor;
                        Cell17.BackColor = Color.FromArgb(array[1, 2]);
                        Cell17.FlatAppearance.BorderColor = Cell17.BackColor;
                        Cell18.BackColor = Color.FromArgb(array[2, 2]);
                        Cell18.FlatAppearance.BorderColor = Cell18.BackColor;
                        Cell19.BackColor = Color.FromArgb(array[3, 2]);
                        Cell19.FlatAppearance.BorderColor = Cell19.BackColor;
                        Cell20.BackColor = Color.FromArgb(array[4, 2]);
                        Cell20.FlatAppearance.BorderColor = Cell20.BackColor;
                        Cell21.BackColor = Color.FromArgb(array[5, 2]);
                        Cell21.FlatAppearance.BorderColor = Cell21.BackColor;
                        Cell22.BackColor = Color.FromArgb(array[6, 2]);
                        Cell22.FlatAppearance.BorderColor = Cell22.BackColor;
                        Cell23.BackColor = Color.FromArgb(array[7, 2]);
                        Cell23.FlatAppearance.BorderColor = Cell23.BackColor;
                        Cell24.BackColor = Color.FromArgb(array[0, 3]);
                        Cell24.FlatAppearance.BorderColor = Cell24.BackColor;
                        Cell25.BackColor = Color.FromArgb(array[1, 3]);
                        Cell25.FlatAppearance.BorderColor = Cell25.BackColor;
                        Cell26.BackColor = Color.FromArgb(array[2, 3]);
                        Cell26.FlatAppearance.BorderColor = Cell26.BackColor;
                        Cell27.BackColor = Color.FromArgb(array[3, 3]);
                        Cell27.FlatAppearance.BorderColor = Cell27.BackColor;
                        Cell28.BackColor = Color.FromArgb(array[4, 3]);
                        Cell28.FlatAppearance.BorderColor = Cell28.BackColor;
                        Cell29.BackColor = Color.FromArgb(array[5, 3]);
                        Cell29.FlatAppearance.BorderColor = Cell29.BackColor;
                        Cell30.BackColor = Color.FromArgb(array[6, 3]);
                        Cell30.FlatAppearance.BorderColor = Cell30.BackColor;
                        Cell31.BackColor = Color.FromArgb(array[7, 3]);
                        Cell31.FlatAppearance.BorderColor = Cell31.BackColor;
                        Cell32.BackColor = Color.FromArgb(array[0, 4]);
                        Cell32.FlatAppearance.BorderColor = Cell32.BackColor;
                        Cell33.BackColor = Color.FromArgb(array[1, 4]);
                        Cell33.FlatAppearance.BorderColor = Cell33.BackColor;
                        Cell34.BackColor = Color.FromArgb(array[2, 4]);
                        Cell34.FlatAppearance.BorderColor = Cell34.BackColor;
                        Cell35.BackColor = Color.FromArgb(array[3, 4]);
                        Cell35.FlatAppearance.BorderColor = Cell35.BackColor;
                        Cell36.BackColor = Color.FromArgb(array[4, 4]);
                        Cell36.FlatAppearance.BorderColor = Cell36.BackColor;
                        Cell37.BackColor = Color.FromArgb(array[5, 4]);
                        Cell37.FlatAppearance.BorderColor = Cell37.BackColor;
                        Cell38.BackColor = Color.FromArgb(array[6, 4]);
                        Cell38.FlatAppearance.BorderColor = Cell38.BackColor;
                        Cell39.BackColor = Color.FromArgb(array[7, 4]);
                        Cell39.FlatAppearance.BorderColor = Cell39.BackColor;
                        Cell40.BackColor = Color.FromArgb(array[0, 5]);
                        Cell40.FlatAppearance.BorderColor = Cell40.BackColor;
                        Cell41.BackColor = Color.FromArgb(array[1, 5]);
                        Cell41.FlatAppearance.BorderColor = Cell41.BackColor;
                        Cell42.BackColor = Color.FromArgb(array[2, 5]);
                        Cell42.FlatAppearance.BorderColor = Cell42.BackColor;
                        Cell43.BackColor = Color.FromArgb(array[3, 5]);
                        Cell43.FlatAppearance.BorderColor = Cell43.BackColor;
                        Cell44.BackColor = Color.FromArgb(array[4, 5]);
                        Cell44.FlatAppearance.BorderColor = Cell44.BackColor;
                        Cell45.BackColor = Color.FromArgb(array[5, 5]);
                        Cell45.FlatAppearance.BorderColor = Cell45.BackColor;
                        Cell46.BackColor = Color.FromArgb(array[6, 5]);
                        Cell46.FlatAppearance.BorderColor = Cell46.BackColor;
                        Cell47.BackColor = Color.FromArgb(array[7, 5]);
                        Cell47.FlatAppearance.BorderColor = Cell47.BackColor;
                        Cell48.BackColor = Color.FromArgb(array[0, 6]);
                        Cell48.FlatAppearance.BorderColor = Cell48.BackColor;
                        Cell49.BackColor = Color.FromArgb(array[1, 6]);
                        Cell49.FlatAppearance.BorderColor = Cell49.BackColor;
                        Cell50.BackColor = Color.FromArgb(array[2, 6]);
                        Cell50.FlatAppearance.BorderColor = Cell50.BackColor;
                        Cell51.BackColor = Color.FromArgb(array[3, 6]);
                        Cell51.FlatAppearance.BorderColor = Cell51.BackColor;
                        Cell52.BackColor = Color.FromArgb(array[4, 6]);
                        Cell52.FlatAppearance.BorderColor = Cell52.BackColor;
                        Cell53.BackColor = Color.FromArgb(array[5, 6]);
                        Cell53.FlatAppearance.BorderColor = Cell53.BackColor;
                        Cell54.BackColor = Color.FromArgb(array[6, 6]);
                        Cell54.FlatAppearance.BorderColor = Cell54.BackColor;
                        Cell55.BackColor = Color.FromArgb(array[7, 6]);
                        Cell55.FlatAppearance.BorderColor = Cell55.BackColor;
                        Cell56.BackColor = Color.FromArgb(array[0, 7]);
                        Cell56.FlatAppearance.BorderColor = Cell56.BackColor;
                        Cell57.BackColor = Color.FromArgb(array[1, 7]);
                        Cell57.FlatAppearance.BorderColor = Cell57.BackColor;
                        Cell58.BackColor = Color.FromArgb(array[2, 7]);
                        Cell58.FlatAppearance.BorderColor = Cell58.BackColor;
                        Cell59.BackColor = Color.FromArgb(array[3, 7]);
                        Cell59.FlatAppearance.BorderColor = Cell59.BackColor;
                        Cell60.BackColor = Color.FromArgb(array[4, 7]);
                        Cell60.FlatAppearance.BorderColor = Cell60.BackColor;
                        Cell61.BackColor = Color.FromArgb(array[5, 7]);
                        Cell61.FlatAppearance.BorderColor = Cell61.BackColor;
                        Cell62.BackColor = Color.FromArgb(array[6, 7]);
                        Cell62.FlatAppearance.BorderColor = Cell62.BackColor;
                        Cell63.BackColor = Color.FromArgb(array[7, 7]);
                        Cell63.FlatAppearance.BorderColor = Cell63.BackColor;
                        #endregion   
                    }
                }
            }
            catch
            {
                Console.WriteLine("darn looks like an error i guess lmaooo");
            }
        }
    }
}