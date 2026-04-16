using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeComputationSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Disable_textboxes();


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tstPR2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtPClassPerfAve_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void btnCompute_Click(object sender, EventArgs e)
        {
            Prelim_Computation();
            

            double prelim, midterm, final;

            if (double.TryParse(txtPrelimGrade.Text, out prelim) &&
                double.TryParse(txtMidtermGrade.Text, out midterm) &&
                double.TryParse(txtFinalGrade.Text, out final))
            {
                double finalGrade = (prelim * 0.33) + (midterm * 0.33) + (final * 0.34);
                txtGWA.Text = finalGrade.ToString("F2");
            }
            else
            {
                MessageBox.Show("Error in computing final grade.");
            }

        }

        private double ComputeAverage(double[] scores, double[] totals)
        {
            double sum = 0;
            // Validate input 
            for (int i = 0; i < scores.Length; i++)
            {
                // Check if score is non-negative and does not exceed total, and total is greater than zero
                if (scores[i] >= 0)
                {
                    if (totals[i] > 0) // Ensure total is greater than zero to avoid division by zero
                    {
                        if (scores[i] <= totals[i]) // Ensure score does not exceed total
                        {
                            double percent = (scores[i] / totals[i]) * 60 + 40;
                            sum += percent;
                        }
                        else
                        {
                            MessageBox.Show("Score cannot be greater than total.");
                            return 0;
           
                        }
                    }
                    else
                    {
                        MessageBox.Show("Total must be greater than zero.");
                        return 0;
                    }
                }
                else
                {
                    MessageBox.Show("Score cannot be negative.");
                    return 0;
                }
            }

            return sum / scores.Length;
        }

        private double ComputeSingle(double score, double total)
        {
            if (score >= 0) // Validate that score is non-negative
            {
                if (total > 0) // Validate that total is greater than zero to avoid division by zero
                {
                    if (score <= total) // Validate that score does not exceed total
                    {
                        return (score / total) * 60 + 40;
                    }
                    else
                    {
                        MessageBox.Show("Score cannot be greater than total.");
                        return 0;
                    }
                }
                else
                {
                    MessageBox.Show("Total must be greater than zero.");
                    return 0;

                }
            }
            else
            {
                MessageBox.Show("Score cannot be negative.");
                return 0;

            }
        }

        private void Prelim_Computation()
        {
            try
            {
                //class performance
                double PClassPerfAve = ComputeAverage(
                    new double[] { double.Parse(txtPA1.Text), double.Parse(txtPA2.Text), double.Parse(txtPS1.Text), double.Parse(txtPS2.Text), double.Parse(txtPR1.Text), double.Parse(txtPR2.Text) },
                    new double[] { double.Parse(txtPA1Tot.Text), double.Parse(txtPA2Tot.Text), double.Parse(txtPS1Tot.Text), double.Parse(txtPS2Tot.Text), double.Parse(txtPR1Tot.Text), double.Parse(txtPR2Tot.Text) }
                );
                txtPClassPerfAve.Text = PClassPerfAve.ToString("F2");

                //lab exercises
                double PLExerAve = ComputeAverage(
                    new double[] { double.Parse(txtPLExer1.Text), double.Parse(txtPLExer2.Text), double.Parse(txtPLExer3.Text), double.Parse(txtPLExer4.Text) },
                    new double[] { double.Parse(txtPLExer1Tot.Text), double.Parse(txtPLExer2Tot.Text), double.Parse(txtPLExer3Tot.Text), double.Parse(txtPLExer4Tot.Text) }
                );
                txtPLabExerAve.Text = PLExerAve.ToString("F2");

                //quizzes
                double PQuizAve = ComputeAverage(
                    new double[] { double.Parse(txtPQ1.Text), double.Parse(txtPQ2.Text), double.Parse(txtPQ3.Text) },
                    new double[] { double.Parse(txtPQ1Tot.Text), double.Parse(txtPQ2Tot.Text), double.Parse(txtPQ3Tot.Text) }
                );
                txtPQuizAve.Text = PQuizAve.ToString("F2");

                //lab exams
                double PLExamAve = ComputeAverage(
                    new double[] { double.Parse(txtPLExam1.Text), double.Parse(txtPLExam2.Text) },
                    new double[] { double.Parse(txtPLExam1Tot.Text), double.Parse(txtPLExam2Tot.Text) }
                );
                txtPLabExamAve.Text = PLExamAve.ToString("F2");

                //written exam
                double PExamAve = ComputeSingle(
                    double.Parse(txtPExam.Text),
                    double.Parse(txtPExamTot.Text)
                );
                txtPWritExamAve.Text = PExamAve.ToString("F2");

                //prelim grade computation
                double prelim =
                    (PClassPerfAve * 0.10) +
                    (PLExerAve * 0.10) +
                    (PQuizAve * 0.20) +
                    (PLExamAve * 0.20) +
                    (PExamAve * 0.40);

                txtPrelimGrade.Text = prelim.ToString("F2");

                Midterm_Computation();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers.");
            }
        }


        private void Midterm_Computation()
        {
            try
            {
                //class performance
                double MClassPerfAve = ComputeAverage(
                    new double[] { double.Parse(txtMA1.Text), double.Parse(txtMA2.Text), double.Parse(txtMS1.Text), double.Parse(txtMS2.Text), double.Parse(txtMR1.Text), double.Parse(txtMR2.Text) },
                    new double[] { double.Parse(txtMA1Tot.Text), double.Parse(txtMA2Tot.Text), double.Parse(txtMS1Tot.Text), double.Parse(txtMS2Tot.Text), double.Parse(txtMR1Tot.Text), double.Parse(txtMR2Tot.Text) }
                );
                txtMClassPerfAve.Text = MClassPerfAve.ToString("F2");

                //lab exercises
                double MLExerAve = ComputeAverage(
                    new double[] { double.Parse(txtMLExer1.Text), double.Parse(txtMLExer2.Text), double.Parse(txtMLExer3.Text), double.Parse(txtMLExer4.Text) },
                    new double[] { double.Parse(txtMLExer1Tot.Text), double.Parse(txtMLExer2Tot.Text), double.Parse(txtMLExer3Tot.Text), double.Parse(txtMLExer4Tot.Text) }
                );
                txtMLabExerAve.Text = MLExerAve.ToString("F2");

                //quizzes
                double MQuizAve = ComputeAverage(
                    new double[] { double.Parse(txtMQ1.Text), double.Parse(txtMQ2.Text), double.Parse(txtMQ3.Text) },
                    new double[] { double.Parse(txtMQ1Tot.Text), double.Parse(txtMQ2Tot.Text), double.Parse(txtMQ3Tot.Text) }
                );
                txtMQuizAve.Text = MQuizAve.ToString("F2");

                //lab exams
                double MLExamAve = ComputeAverage(
                    new double[] { double.Parse(txtMLExam1.Text), double.Parse(txtMLExam2.Text) },
                    new double[] { double.Parse(txtMLExam1Tot.Text), double.Parse(txtMLExam2Tot.Text) }
                );
                txtMLabExamAve.Text = MLExamAve.ToString("F2");

                //written exam
                double MExamAve = ComputeSingle(
                    double.Parse(txtMExam.Text),
                    double.Parse(txtMExamTot.Text)
                );
                txtMWritExamAve.Text = MExamAve.ToString("F2");

                //midterm grade computation
                double midterm =
                    (MClassPerfAve * 0.10) +
                    (MLExerAve * 0.10) +
                    (MQuizAve * 0.20) +
                    (MLExamAve * 0.20) +
                    (MExamAve * 0.40);

                txtMidtermGrade.Text = midterm.ToString("F2");

                Finals_Computation();
            }
            catch (FormatException) 
            {
                MessageBox.Show("Please enter valid numbers.");
            }
        }

        private void Finals_Computation()
        {
            try
            {
                //class performance
                double FClassPerfAve = ComputeAverage(
                    new double[] { double.Parse(txtFA1.Text), double.Parse(txtFA2.Text), double.Parse(txtFS1.Text), double.Parse(txtFS2.Text), double.Parse(txtFR1.Text), double.Parse(txtFR2.Text) },
                    new double[] { double.Parse(txtFA1Tot.Text), double.Parse(txtFA2Tot.Text), double.Parse(txtFS1Tot.Text), double.Parse(txtFS2Tot.Text), double.Parse(txtFR1Tot.Text), double.Parse(txtFR2Tot.Text) }
                );
                txtFClassPerfAve.Text = FClassPerfAve.ToString("F2");

                //lab exercises
                double FLExerAve = ComputeAverage(
                    new double[] { double.Parse(txtFLExer1.Text), double.Parse(txtFLExer2.Text), double.Parse(txtFLExer3.Text), double.Parse(txtFLExer4.Text) },
                    new double[] { double.Parse(txtFLExer1Tot.Text), double.Parse(txtFLExer2Tot.Text), double.Parse(txtFLExer3Tot.Text), double.Parse(txtFLExer4Tot.Text) }
                );
                txtFLabExerAve.Text = FLExerAve.ToString("F2");

                //quizzes
                double FQuizAve = ComputeAverage(
                    new double[] { double.Parse(txtFQ1.Text), double.Parse(txtFQ2.Text), double.Parse(txtFQ3.Text) },
                    new double[] { double.Parse(txtFQ1Tot.Text), double.Parse(txtFQ2Tot.Text), double.Parse(txtFQ3Tot.Text) }
                );
                txtFQuizAve.Text = FQuizAve.ToString("F2");

                //lab exams
                double FFinalProjectAve = ComputeAverage(
                    new double[] { double.Parse(txtFProjManu.Text), double.Parse(txtFProjPresent.Text) },
                    new double[] { double.Parse(txtFProjManuTot.Text), double.Parse(txtFProjPresentTot.Text) }
                );
                txtFProjAve.Text = FFinalProjectAve.ToString("F2");

                //written exam
                double FExamAve = ComputeSingle(
                    double.Parse(txtFExam.Text),
                    double.Parse(txtFExamTot.Text)
                );
                txtFWritExamAve.Text = FExamAve.ToString("F2");

                //final grade computation
                double finals =
                    (FClassPerfAve * 0.05) +
                    (FLExerAve * 0.10) +
                    (FQuizAve * 0.20) +
                    (FFinalProjectAve * 0.25) +
                    (FExamAve * 0.40);

                txtFinalGrade.Text = finals.ToString("F2");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers.");
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllTextBoxes(this);
        }

        private void ClearAllTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox)
                    c.Text = "";

                if (c.HasChildren)
                    ClearAllTextBoxes(c);
            }
        }


        private void Disable_textboxes() { 
            txtPWritExamAve.Enabled = false;
            txtPLabExamAve.Enabled = false;
            txtPQuizAve.Enabled = false;
            txtPLabExerAve.Enabled = false;
            txtPClassPerfAve.Enabled = false;
    
            txtMWritExamAve.Enabled = false;
            txtMLabExamAve.Enabled = false;
            txtMQuizAve.Enabled = false;
            txtMLabExerAve.Enabled = false;
            txtMClassPerfAve.Enabled = false;
    
            txtFWritExamAve.Enabled = false;
            txtFLabExerAve.Enabled = false;
            txtFQuizAve.Enabled = false;
            txtFLabExerAve.Enabled = false;
            txtFProjAve.Enabled = false;
            txtFClassPerfAve.Enabled = false;

            txtPrelimGrade.Enabled = false;
            txtMidtermGrade.Enabled = false;
            txtFinalGrade.Enabled = false;
            txtGWA.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }