using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;

namespace WFapp_S7NET
{
    public partial class MainForm : Form
    {
        private Plc plc = null;
        private ErrorCode errorState = ErrorCode.NoError;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                cboxCputype.DataSource = Enum.GetNames(typeof(CpuType));
                cboxCputype.SelectedIndex = 3; //for 1200 CPU
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (plc != null)
                {
                    plc.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                CpuType cpuType = (CpuType)Enum.Parse(typeof(CpuType), cboxCputype.SelectedValue.ToString());
                string ipAddress = txtIPAddress.Text;
                short rack = short.Parse(txtRack.Text);
                short slot = short.Parse(txtSlot.Text);
                plc = new Plc(cpuType, ipAddress, rack, slot);
                errorState = plc.Open();
                if (errorState != ErrorCode.NoError) throw new Exception(errorState.ToString());
                btnConnect.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (plc != null)
                {
                    plc.Close();
                }
                btnConnect.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (plc != null)
            //    {
            //        string variable = txtMAddress.Text;
            //        object result = plc.Read(variable);
            //        txtPV.Text = string.Format("{0}", result.ToString());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(this, ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void Read_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (plc != null)
                {
                    string variable = txtMAddress.Text;
                    object result = plc.Read(variable);
                    txtPV.Text = string.Format("{0}", result.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                if (plc != null)
                {
                    string variable = txtMAddress.Text;
                    object value = txtSV.Text;
                    plc.Write(variable, value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cboxCputype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtIPAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRack_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSlot_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPV_TextChanged(object sender, EventArgs e)
        {

        }
        //------------------ Connection ------------------// 
        //--------------Read/Write M Menory --------------//
    }
}
