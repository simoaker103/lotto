using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVGB07_lab2
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void BeginnButton_Click(object sender, EventArgs e)
        {
            int[] LottoRow = new int[7];
            int[] LottoRowRand = new int[7];
            int[] CheckDuplicate = new int[35];

            for (int j = 0; j < CheckDuplicate.Length; j++)
            {
                CheckDuplicate[j] = 0;
            }

            try
            {
                LottoRow[0] = int.Parse(FirstNr.Text);
                LottoRow[1] = int.Parse(SecondNr.Text);
                LottoRow[2] = int.Parse(ThirdNr.Text);
                LottoRow[3] = int.Parse(ForthNr.Text);
                LottoRow[4] = int.Parse(FifthNr.Text);
                LottoRow[5] = int.Parse(SixthNr.Text);
                LottoRow[6] = int.Parse(SeventhNr.Text);
            } catch(FormatException)
            {
                MessageBox.Show("Kontrollera att lottoraden är komplett (7 fält = 7 nr) och att bara siffror används.");
                return;
            }


            foreach (var item in LottoRow)
            {
                if(item < 1 || item > 35)
                {
                    MessageBox.Show("Kontrollera att lottotalen är mellan 1-35!");
                    return;
                }

            }

            for(int i = 0; i < LottoRow.Length; i++)
            {
                if(CheckDuplicate[LottoRow[i]-1] != 1)
                {
                    CheckDuplicate[LottoRow[i]-1] = 1;
                } else
                {
                    MessageBox.Show("Kontrollera att lottotalen är unika!");
                    return;
                }
            }

            for (int j = 0; j < CheckDuplicate.Length; j++)
            {
                CheckDuplicate[j] = 0;
            }

            Random rand = new Random();
            int NextNr, NrOfMatches = 0, NrOfSpinnsInt = 0;
            int five = 0, six = 0, seven = 0;

            try
            {
                NrOfSpinnsInt = int.Parse(NrOfSpinns.Text);

            } catch(FormatException )
            {
                MessageBox.Show("Kontrollera att du angett antal dragningar och att bara siffror används.");
                return;
            }
            for (int k = 0; k < NrOfSpinnsInt; k++)
            {
                // slumpar fram en lottorad med Random(), 7 varv
                for(int p = 0; p < LottoRowRand.Length; p++)
                {
                    do
                    {
                        NextNr = rand.Next(1, 36);

                    // kollar att talet inte redan finns med i lottoraden
                    } while (CheckDuplicate[NextNr - 1] == 1);

                    // "markerar" att talet är taget
                    CheckDuplicate[NextNr - 1] = 1;

                    // lägger till talet i lottoraden
                    LottoRowRand[p] = NextNr;
                }

                for (int m = 0; m < LottoRow.Length; m++)
                {
                    if (LottoRowRand.Contains(LottoRow[m]))
                    {
                        NrOfMatches++;
                    }
                }

                switch (NrOfMatches)
                {
                    case 5:
                        five++;
                        break;
                    case 6:
                        six++;
                        break;
                    case 7:
                        seven++;
                        break;
                    default:
                        break;
                }

                for (int j = 0; j < CheckDuplicate.Length; j++)
                {
                    CheckDuplicate[j] = 0;
                }

                NrOfMatches = 0;

            }

            FiveCorrect.Text = $"{five}";
            SixCorrect.Text = $"{six}";
            SevenCorrect.Text = $"{seven}";

        }
    }
}
