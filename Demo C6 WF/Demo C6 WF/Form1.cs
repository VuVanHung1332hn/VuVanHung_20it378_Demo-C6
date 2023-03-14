﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_C6_WF
{
    public partial class Form1 : Form
    {
        List<string> listGioiTinh = new List<string>() { "Nam", "Nu", "Khong xac dinh" };
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (KiemTraNhap())
            {
                txbThongTin.Text = "Ho ten: " + txbHoTen.Text + Environment.NewLine
                                    + "Ngay sinh: " + dtpkNgaysinh.Value.ToShortDateString() + Environment.NewLine
                                    + "Gioi tinh: " + cboGioiTinh.SelectedItem + Environment.NewLine
                                    + "Dia chi: " + txbDiaChi.Text + Environment.NewLine
                                    + "CCCD: " + txbCCCD.Text;

            }
         
        }
        bool KiemTraNhap()
        {
            string cccd = txbCCCD.Text;
            long ketqua;

            char[] mangCCCD = cccd.ToCharArray();

            if (txbHoTen.Text == "")
            {
                MessageBox.Show("Hay nhap ho ten", "Thong bao");
                txbHoTen.Focus();
                return false;
            }
            if (txbDiaChi.Text == "")
            {
                MessageBox.Show("Hay nhap dia chi", "Thong bao");
                txbDiaChi.Focus();
                return false;
            }
            if (!(long.TryParse(cccd, out ketqua)))
            {
                MessageBox.Show("Hay nhap dung so CC", "Thong bao");
                txbCCCD.Focus();
                return false;
            }
            if (ketqua < 0)
            {
                MessageBox.Show("So CCCD khong duoc am", "Thong bao");
                txbCCCD.Focus();
                return false;
            }
            if (mangCCCD.Length != 12)
            {
                MessageBox.Show("So CCCD phai du 12 so", "Thong bao");
                txbCCCD.Focus();
                return false;
            }
            return true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboGioiTinh.DataSource = listGioiTinh;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Ban co muon thoat chuong trinh?", "Canh bao", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
             e.Cancel = true;

        }

        private void txbHoTen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
