﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PiramidaAnalize
{
    public partial class frmInputBox : Form
    {
        private const string defaultTitle = "Введите значение";

        public frmInputBox() : this(defaultTitle, string.Empty)
        {
        }

        public frmInputBox(string defaultValue) : this(defaultTitle, defaultValue)
        {

        }

        public frmInputBox(string title, string defaultValue)
        {
            InitializeComponent();
            this.Text = title;
            txtInput.Text = defaultValue;
        }

        public string Result
        {
        get
            {
                return txtInput.Text;
            }
        }
    }
}
