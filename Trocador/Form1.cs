﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trocador.Core;
using Trocador.Core.DataContracts;
using Trocador.Core.LogSystem;

namespace Trocador {

    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();

            // Exibe a versão e o build da aplicação na barra de título.
            this.Text = Application.ProductName + " - versão " + Assembly.GetExecutingAssembly().GetName().Version;
        }

        private void UxBtnCalculate_Click(object sender, EventArgs e) {

			FileLog fileLog = new FileLog();

            this.UxTxtChange.Text = string.Empty;

            TrocadorManager trocadorManager = new TrocadorManager();

            CalculateChangeRequest request = new CalculateChangeRequest();

            request.PaidAmount = Convert.ToInt32(this.UxTxtAmountPaid.Text);
            request.ProductAmount = Convert.ToInt32(this.UxTxtProductAmount.Text);            

            CalculateChangeResponse response = trocadorManager.CalculateChange(request);

            if (response.ErrorReportList.Any()) {

                foreach (ErrorReport errorReport in response.ErrorReportList) {
                    
                    this.UxTxtChange.Text += string.Format("Campo: {0}, Mensagem: {1}\r\n",
                        errorReport.FieldName, errorReport.Message);
                }
            }
            else {
                foreach (KeyValuePair<int, MoneyUnit> coin in response.Change) {
                    this.UxTxtChange.Text += string.Format("{0} {1} of {2} \r\n", coin.Key,  coin.Value.Name, coin.Value.AmountInCents);

                }
            }
        }
    }
}
