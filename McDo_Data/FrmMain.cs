using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McDoData
{
    public partial class FrmMain : Form
    {
        private DataNL mDataNL;
        private DataBE mDataBE;
        private List<Resto> mRestos;

        private delegate void dFillResult();
        private dFillResult hFillResult;

        public FrmMain()
        {
            InitializeComponent();
            hFillResult = new dFillResult(sFillResult);
            mDataNL = new DataNL();
            mDataNL.eReadComplete += hCompleteNL;
            mDataBE = new DataBE();
            mDataBE.eReadComplete += hCompleteBE;
        }

        private void BtnNL_Click(object sender, EventArgs e)
        {
            sStartAction();
            mDataNL.xInit();
        }

        private void BtnBE_Click(object sender, EventArgs e)
        {
            sStartAction();
            mDataBE.xInit();
        }

        private void sStartAction()
        {
            BtnNL.Enabled = false;
            BtnBE.Enabled = false;
            DgrdResult.RowCount = 0;
            DgrdResult.Invalidate();
        }

        private void hCompleteNL(Object pSender, EventArgs pArgs)
        {
            mRestos = mDataNL.xRestos();
            this.Invoke(hFillResult);
        }

        private void hCompleteBE(Object pSender, EventArgs pArgs)
        {
            mRestos = mDataBE.xRestos();
            this.Invoke(hFillResult);
        }

        private void sFillResult()
        {
            DgrdResult.RowCount = mRestos.Count;
            DgrdResult.Invalidate();
            BtnNL.Enabled = true;
            BtnBE.Enabled = true;
        }

        private void DgrdResult_CellValueNeeded(object sender, DataGridViewCellValueEventArgs pArgs)
        {
            Resto lResto;

            if (pArgs.RowIndex < mRestos.Count)
            {
                lResto = mRestos.ElementAt(pArgs.RowIndex);
                switch (pArgs.ColumnIndex)
                {
                    case 0:
                        pArgs.Value = lResto.xName;
                        break;
                    case 1:
                        pArgs.Value = lResto.xDescr;
                        break;
                    case 2:
                        pArgs.Value = lResto.xAddress;
                        break;
                    case 3:
                        pArgs.Value = lResto.xPostalCode;
                        break;
                    case 4:
                        pArgs.Value = lResto.xCity;
                        break;
                    case 5:
                        pArgs.Value = lResto.xHoursMonday;
                        break;
                    case 6:
                        pArgs.Value = lResto.xDriveHoursMonday;
                        break;
                    case 7:
                        pArgs.Value = lResto.xHoursTuesday;
                        break;
                    case 8:
                        pArgs.Value = lResto.xDriveHoursTuesday;
                        break;
                    case 9:
                        pArgs.Value = lResto.xHoursWednesday;
                        break;
                    case 10:
                        pArgs.Value = lResto.xDriveHoursWednesday;
                        break;
                    case 11:
                        pArgs.Value = lResto.xHoursThursday;
                        break;
                    case 12:
                        pArgs.Value = lResto.xDriveHoursThursday;
                        break;
                    case 13:
                        pArgs.Value = lResto.xHoursFriday;
                        break;
                    case 14:
                        pArgs.Value = lResto.xDriveHoursFriday;
                        break;
                    case 15:
                        pArgs.Value = lResto.xHoursSaturday;
                        break;
                    case 16:
                        pArgs.Value = lResto.xDriveHoursSaturday;
                        break;
                    case 17:
                        pArgs.Value = lResto.xHoursSunday;
                        break;
                    case 18:
                        pArgs.Value = lResto.xDriveHoursSunday;
                        break;
                }
            }
        }
    }
}
