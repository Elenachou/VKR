﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MieCalc
{
    public partial class IntegralResultDataControl : UserControl
    {
        public ResultData CalculationResult
        {
            set
            {
                DiffractionParameterTB.Text = value.diffractionParametr.ToString();
            }
        }

        public IntegralResultDataControl()
        {
            InitializeComponent();
        }
        
        private void DiffractionParameterTB_TextChanged(object sender, EventArgs e) //Показатель дифракции
        {
             
        }

        private void RefractiveIndexTB_TextChanged(object sender, EventArgs e) // Показатель преломления
        {

        }

    }
}