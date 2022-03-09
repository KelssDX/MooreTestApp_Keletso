using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MooreTestApp_Keletso
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txt_FIleName.ReadOnly= true;
            txt_ROC.ReadOnly = true;
            txt_RMS.ReadOnly = true;
            txt_StandarDevation.ReadOnly = true;
        }

        public bool checkFileLoaded = false;
        private SqlConnection conn = new SqlConnection("Data Source=DESKTOP-8QNA13Q\\SQLEXPRESS;Initial Catalog=MooreTest;Integrated Security=SSPI;");
        private void btn_OpenCSVFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txt_FIleName.Text = openFileDialog1.FileName;
            CSV_DataBind(txt_FIleName.Text);
        }

        private void CSV_DataBind(string filePath)
        {

            try
            {
                DataTable dt = new DataTable();
                string[] readlines = System.IO.File.ReadAllLines(filePath);
                if (readlines.Length > 0)
                {


                    //add the text options for sort by drop down 
                    combo_SortBy.Items.Add("Ascending");
                    combo_SortBy.Items.Add("Descending");

                    //create the header columns
                    string firstLine = readlines[0];
                    string[] csvSplit = firstLine.Split(',');
                    
                    foreach (string headerColumn in csvSplit)
                    {
                        dt.Columns.Add(new DataColumn(headerColumn));
                        combo_SortColumn.Items.Add(headerColumn);//adding the columns for sorting

                        if(headerColumn != "TS")
                        {
                            //add all columns except TS - the date column
                            combo_StandarDeviation.Items.Add(headerColumn);
                            combo_RMS.Items.Add(headerColumn);
                            combo_ROC.Items.Add(headerColumn);

                        }
                    }
                    //split each line and add rows to  be displayed after the header columns
                    for (int i = 1; i < readlines.Length; i++)
                    {
                        string[] linesData = readlines[i].Split(',');
                        DataRow dr = dt.NewRow();
                        int columnIndex = 0;
                        foreach (string headerColumn in csvSplit)
                        {
                            dr[headerColumn] = linesData[columnIndex++];
                        }
                        dt.Rows.Add(dr);
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                checkFileLoaded = true;
            }
            catch(Exception ex)
            {//error message
                MessageBox.Show("ERROR when trying to load CSV file: "+ex.Message);
            }

        }

        private void combo_SortColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {//check if the comboBox are not empty first
                if (combo_SortColumn.Items.Count != 0)
                {

                    Sorting();
                }
            }
            catch(Exception ex)
            {
                //error message
                MessageBox.Show("ERROR when selecting trying to sort " + ex.Message);
            }

        }

        private void combo_SortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {//check if the comboBox are not empty first
                if (combo_SortBy.Items.Count != 0)
                {
                    Sorting();


                }
            }
            catch (Exception ex)
            {
                //error message
                MessageBox.Show("ERROR when selecting trying to sort " + ex.Message);
            }
        }


        private void Sorting()
        {
            //sort the data using the selected columns and also sorting the order 
            if (combo_SortBy.Text == "" | combo_SortBy.Text == "Ascending")
            {
                if (combo_SortColumn.Text == "")
                {
                    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                }
                else
                {
                    dataGridView1.Sort(dataGridView1.Columns[combo_SortColumn.SelectedIndex], ListSortDirection.Ascending);

                }
            }
            else
            {
                if (combo_SortColumn.Text == "")
                {
                    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
                }
                else
                {
                    dataGridView1.Sort(dataGridView1.Columns[combo_SortColumn.SelectedIndex], ListSortDirection.Descending);

                }
            }
        }

        private void btn_StandarDeviation_Click(object sender, EventArgs e)
        {
            try
            {
                txt_StandarDevation.Text = StandardDeviation();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR when trying to calicluate Standard Deviation: " + ex.Message);
            }
        }

        private void btn_RMS_Click(object sender, EventArgs e)
        {
            try
            {
                txt_RMS.Text = RMS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR when trying to calicluate RMS: " + ex.Message);
            }
        }

        private void btn_ROC_Click(object sender, EventArgs e)
        {
            try {
                //ROC = Rate of Change
                txt_ROC.Text = ROC();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR when trying to calicluate ROC: " + ex.Message);
            }
        }

        private void btn_SaveToDB_Click(object sender, EventArgs e)
        {
            //Save the 3 outputs to DB through a SP 

            try
            {
                if (combo_RMS.Text != "" && combo_ROC.Text != "" && combo_StandarDeviation.Text != "")
                {


                   


 

                    var cmd = new SqlCommand("CSVCalculation", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ColStandarDev", combo_StandarDeviation.Text));
                    cmd.Parameters.Add(new SqlParameter("@ColROC", combo_ROC.Text));
                    cmd.Parameters.Add(new SqlParameter("@ColRMS", combo_RMS.Text));
                    cmd.Parameters.Add(new SqlParameter("@StandardDevOutput", StandardDeviation().Replace(",", ".")));
                    cmd.Parameters.Add(new SqlParameter("@ROCOutput", ROC().Replace(",", ".")));
                    cmd.Parameters.Add(new SqlParameter("@RMSOutput", RMS().Replace(",", ".")));


                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Calculation results saved to Database");

                }
                else
                {
                    //error or instruction message for user 
                    MessageBox.Show("Please select every column option before clicking Save Calculations To DB");
                }

            }
            catch(Exception ex)
            {
                //error saving
                MessageBox.Show("Error saving to DB: "+ ex.Message);
            }

        }

        public string StandardDeviation()
        {
            string SDEVvalue = "";
            
            //use this to check if file was loaded
            txt_StandarDevation.Text = "";

            if (checkFileLoaded == true)
            {
                //check if a column on standard devation combo was selected first
                if (combo_StandarDeviation.Text != "")
                {
                    //int i = 0;
                    //bool doneCalculating = false;
                    double sumRow = 0;
                    double squareSumRow = 0;
                    double rowVal = 0;
                    double devMean = 0;
                    double devVariance = 0;

                    //calculation for Standard Deviation 
                    foreach (DataGridViewRow rowsVal in dataGridView1.Rows)
                    {

                        if (!String.IsNullOrEmpty(rowsVal.Cells[combo_StandarDeviation.Text].Value as String))
                        {
                            rowVal = double.Parse(rowsVal.Cells[combo_StandarDeviation.Text].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            sumRow += rowVal;

                            squareSumRow += rowVal * rowVal;

                        }
                    }
                    devMean = sumRow / dataGridView1.Rows.Count;
                    devVariance = squareSumRow / dataGridView1.Rows.Count - devMean * devMean;
                    SDEVvalue = Math.Sqrt(devVariance).ToString();







                }
                else
                {
                    //error or instruction message for user 
                    MessageBox.Show("Please select the column for Standard Deviation calculation before clicking to calculate.");
                }


            }
            else
            {
                //error or instruction message for user 
                MessageBox.Show("Please add the CSV before trying to calculate, click on the Open CSV button.");
            }

            return SDEVvalue;
        }
        public string ROC()
        {
            string ROCValue = "";
            //ROC = Rate of Change
            txt_RMS.Text = "";
            double previousVal = 0;
            double currentVal = 0;
            double valTemp = 0;
            double sumValTemp = 0;
            string testVal = "";
            int n = 0; //will be used to count the number of rows(minus the firs) or ROC calculations that occured to find the difference 

            if (checkFileLoaded == true)
            {
                //calculation for ROC

                //Order the data by the date column "TS" in ascending order when iterating through the loop
                foreach (DataGridViewRow rowsVal in dataGridView1.Rows.Cast<DataGridViewRow>().OrderBy(x => x.Cells["TS"].Value))
                {

                    if (!String.IsNullOrEmpty(rowsVal.Cells[combo_ROC.Text].Value as String))
                    {

                        if (n != 0)
                        {
                            currentVal = double.Parse(rowsVal.Cells[combo_ROC.Text].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            valTemp = previousVal - currentVal;  //calculating different 
                            sumValTemp += valTemp; //adding the difference
                            previousVal = double.Parse(rowsVal.Cells[combo_ROC.Text].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture); //assigning the previous value for next calculation
                        }
                        else
                        {


                            previousVal = double.Parse(rowsVal.Cells[combo_ROC.Text].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture); //no calculation necessary for first row
                        }
                        n++;
                    }

                }
                ROCValue = Math.Round(sumValTemp, 10).ToString(); //

            }

            return ROCValue;
        }
        public string RMS()
        {
            string RMSValue = "";
            //RMS = Root Mean Square 
            //use this to check if file was loaded
            txt_RMS.Text = "";

            if (checkFileLoaded == true)
            {
                //check if a column on RMS combo was selected first
                if (combo_RMS.Text != "")
                {

                    double rowVal = 0;
                    double rmsMean = 0;

                    int rmsSquare = 0;

                    //calculation for RMS
                    foreach (DataGridViewRow rowsVal in dataGridView1.Rows)
                    {

                        if (!String.IsNullOrEmpty(rowsVal.Cells[combo_RMS.Text].Value as String))
                        {
                            rowVal = double.Parse(rowsVal.Cells[combo_RMS.Text].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            rmsSquare += (int)Math.Pow(rowVal, 2);

                        }
                    }
                    rmsMean = rmsSquare / (double)(dataGridView1.Rows.Count); //mean value


                    RMSValue = Math.Sqrt(rmsSquare).ToString(); //calculating the root value







                }
                else
                {
                    //error or instruction message for user 
                    MessageBox.Show("Please select the column for RMS calculation before clicking to calculate.");
                }


            }
            else
            {
                //error or instruction message for user 
                MessageBox.Show("Please add the CSV before trying to calculate, click on the Open CSV button.");
            }
            return RMSValue;
        }

        private void btn_SaveCSV_Click(object sender, EventArgs e)
        {

            try
            {
                if (combo_RMS.Text != "" && combo_ROC.Text != "" && combo_StandarDeviation.Text != "")
                {
                    DateTime dt = new DateTime();
                    
                    string delimiter = ",";
                    string[][] output = new string[][]{
  new string[]{"ColName", "Output", "CalculationType", "DateCalculated"}, //columns
 new string[]{combo_StandarDeviation.Text, StandardDeviation().Replace(",","."), "Standard Deviation",dt.ToShortDateString() }, //row 1
 new string[]{combo_ROC.Text, ROC(), "ROC",dt.ToShortDateString().Replace(",",".") }, //row 2
 new string[]{combo_RMS.Text, RMS(), "RMS",dt.ToShortDateString().Replace(",", ".") } //row 3
 };
                    int length = output.GetLength(0);
                    StringBuilder sb = new StringBuilder();
                    for (int index = 0; index < length; index++)
                        sb.AppendLine(string.Join(delimiter, output[index])); //

                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/test.csv", sb.ToString());

                   
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "CSV|*.csv|All file|*.*";
                    save.FilterIndex = 1;
                    save.FileName = "MooreTestOutput.CSV";
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(save.FileName, sb.ToString());
                        MessageBox.Show("CSV file saved successfully");
                    }

                }
                else
                {
                    //error or instruction message for user 
                    MessageBox.Show("Please select every column option before clicking Save Calculations To DB");
                }
            }
                 catch (Exception ex)
            {
                //error saving csv
                MessageBox.Show("Error saving calculations results to CSV: " + ex.Message);
            }
        

        }
    }
}
