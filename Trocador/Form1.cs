using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trocador.Core;
using Trocador.Core.DataContracts;


namespace Trocador {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void UxBtnCalculate_Click(object sender, EventArgs e) {
            this.UxTxtChange.Text = string.Empty;

            TrocadorManager trocadorManager = new TrocadorManager();

            CalculateChangeRequest request = new CalculateChangeRequest();

            request.PaidAmount = Convert.ToInt32(this.UxTxtAmountPaid.Text);

            request.ProductAmount = Convert.ToInt32(this.UxTxtProductAmount.Text);

            CalculateChangeResponse response = trocadorManager.CalculateChange(request);

            if (response.Errors.Any()) {
                foreach (string error in response.Errors) {
                    this.UxTxtChange.Text += error + "\r\n";
                }
            }
            else {
                foreach (KeyValuePair<int, int> coin in response.Coins) {
                    this.UxTxtChange.Text += string.Format("{0} coins of {1} cents \r\n", coin.Value, coin.Key);
                }
            }
        }
    }
}
