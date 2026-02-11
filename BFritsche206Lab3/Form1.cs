using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace BFritsche206Lab3
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void stateInfoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.stateInfoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.stateInfoDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stateInfoDataSet.StateInfo' table. You can move, or remove it, as needed.
            this.stateInfoTableAdapter.Fill(this.stateInfoDataSet.StateInfo);
            DataTable dt = this.stateInfoDataSet.StateInfo;
            cBoxStates.DataSource = dt;
            cBoxStates.DisplayMember = "StateName";
            cBoxStates.ValueMember = "StateName";

        }

        

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //Variable for new form, data, selected state, and rows
            var stateDet = new StateDetails();
            DataTable dt = this.stateInfoDataSet.StateInfo;
            string selectedState = cBoxStates.GetItemText(cBoxStates.SelectedItem);
            DataRow[] rows = dt.Select($"StateName = '{selectedState.Replace("'", "''")}'");

            //Getting the data to appear in the labels
            if (rows.Length > 0 )
            {
                DataRow row = rows[0];

                stateDet.lblState.Text = row["StateName"].ToString();
                stateDet.lblPopulation.Text = row["StatePopulation"].ToString();
                stateDet.lblFlagDesc.Text = row["FlagDesc"].ToString();
                stateDet.lblStateFlower.Text = row["StateFlower"].ToString();
                stateDet.lblStateBird.Text = row["StateBird"].ToString();
                stateDet.lblColors.Text = row["Colors"].ToString();
                stateDet.lblFirstLargest.Text = row["FirstLargestCity"].ToString();
                stateDet.lblSecondLargest.Text = row["SecondLargestCity"].ToString();
                stateDet.lblThirdLargest.Text = row["ThirdLargestCity"].ToString();
                stateDet.lblCapital.Text = row["Capital"].ToString();
                decimal income = Convert.ToDecimal(row["MedianIncome"]);
                stateDet.lblMedIncome.Text = income.ToString("C2");
                stateDet.lblCompPercentage.Text = row["ComputerJobPercentage"].ToString();

            }

            stateDet.ShowDialog();
        }

        private void cBoxStates_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
