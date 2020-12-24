using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Components;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            double genMin = double.Parse(GeneratorMinTimeTextBox.Text);
            double genMax = double.Parse(GeneratorMaxTimeTextBox.Text);
            double prob = double.Parse(LeftProb.Text);
            double procMin = double.Parse(ProcMin.Text);
            double procMax = double.Parse(ProcMax.Text);
            double operMin = double.Parse(OperMin.Text);
            double operMax = double.Parse(OperMax.Text);
            double timeStep = double.Parse(TimeStepTextBox.Text);
            int qLength = int.Parse(Length.Text);
            int amount = int.Parse(ProcessedRequestTextBox.Text);

            ResultTextBlock.Text = new ModellingSystem(genMin, genMax, prob, qLength, 
                procMin, procMax, operMin, operMax, timeStep).Modelling(amount).ToString();
        }
    }
}
