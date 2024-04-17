using Microsoft.VisualBasic;

namespace quality_testlabel;

partial class Form1
{

    public Label titleApp = new Label();
    public TabControl labelForEvaluationTabControl = new TabControl();
    public TabPage labelForEvaluationTabPage = new TabPage();
    public Label labelNameForEvaluationTab = new Label();
    public TabControl labelValidationTabControl = new TabControl();
    public TabPage labelValidationTabPage = new TabPage(); 
    public Label labelValidationNameTab = new Label();
    public Label printerSNlabel = new Label();
    public Button focusCallPrintButton = new Button();
    public TextBox printerSNtextBox = new TextBox();
    public Button printButtonEvaluation = new Button();
    public CheckBox automaticPrintingEvaluationPage = new CheckBox();
    public Label barcodeOneLabel = new Label();
    public TextBox barcodeOneTextBox = new TextBox();
    public Label barcodeTwoLabel = new Label();
    public TextBox barcodeTwoTextBox = new TextBox();
    public Label barcodeThreeLabel = new Label();
    public TextBox barcodeThreeTextBox = new TextBox();
    public Label qrCodeLabel = new Label();
    public TextBox qrCodeTextBox = new TextBox();
    public CheckBox isLineValidated = new CheckBox();
    public Button validateButton = new Button();
    public Button closeButton = new Button();
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        StartPosition = FormStartPosition.CenterScreen; 

        titleApp.Text = "Impressão Etiqueta p/ Avaliação";
        titleApp.AutoSize = true;
        titleApp.Location = new Point(385, 10);
        titleApp.Font = new Font("Arial", 15, FontStyle.Bold);

        //Tab Control para a avaliação
        labelForEvaluationTabControl.Size = new System.Drawing.Size(1225,650);
        labelValidationTabControl.Size = new System.Drawing.Size(1225,650);
        labelForEvaluationTabControl.Location = new Point(10, 60);
        
        //Elementos presentes na tab page para avaliação
        printerSNlabel.Text = "S/N Impressora: ";
        printerSNlabel.Font = new Font("Arial", 20, FontStyle.Bold);
        printerSNlabel.Location = new Point(10, 230);
        printerSNlabel.AutoSize = true;

        printerSNtextBox.Location = new Point(350,225);
        printerSNtextBox.Font = new Font("Arial", 25, FontStyle.Bold);
        printerSNtextBox.Width = 550;
        //printerSNtextBox.Text = "2302S000995";
        labelForEvaluationTabPage.Text = "Avaliação";

        focusCallPrintButton.Location = new Point(920, 223);
        focusCallPrintButton.Height = 70;
        focusCallPrintButton.Width = 100;
        focusCallPrintButton.Image = Image.FromFile(@"C:\Program Files\printer-quality-test\icons\right-arrow.png");
        focusCallPrintButton.BackgroundImageLayout = ImageLayout.Stretch;

        printButtonEvaluation.Location = new Point(1025,223);
        printButtonEvaluation.Height = 70;
        printButtonEvaluation.Width = 100;
        printButtonEvaluation.Image = Image.FromFile(@"C:\Program Files\printer-quality-test\icons\print.png");
        printButtonEvaluation.BackgroundImageLayout = ImageLayout.Stretch;

        automaticPrintingEvaluationPage.Checked = true;
        automaticPrintingEvaluationPage.Location = new Point(1008, 18);
        automaticPrintingEvaluationPage.Text = "Impressão Automática";
        automaticPrintingEvaluationPage.AutoSize = true;
    

        labelValidationTabPage.Text = "Validação";

        //Elementos presentes na tab page para avaliação
        barcodeOneLabel.Text = "1º Código de Barras:";
        barcodeOneLabel.AutoSize = true;
        barcodeOneLabel.Font = new Font("Arial", 17, FontStyle.Bold);
        barcodeOneLabel.Location = new Point(50, 100);

        barcodeOneTextBox.Location = new Point(415,102);
        barcodeOneTextBox.Font = new Font("Arial", 17, FontStyle.Bold);
        barcodeOneTextBox.Width = 550;
        //barcodeOneTextBox.Text = "iNETCEED#202404101140#1";

        barcodeTwoLabel.Text = "2º Código de Barras:";
        barcodeTwoLabel.AutoSize = true;
        barcodeTwoLabel.Font = new Font("Arial", 17, FontStyle.Bold);
        barcodeTwoLabel.Location = new Point(50, 175);

        barcodeTwoTextBox.Location = new Point(415, 177);
        barcodeTwoTextBox.Font = new Font("Arial", 17, FontStyle.Bold);
        barcodeTwoTextBox.Width = 550;
        //barcodeTwoTextBox.Text = "iNETCEED#202404101140#2";

        barcodeThreeLabel.Text = "3º Código de Barras:";
        barcodeThreeLabel.AutoSize = true;
        barcodeThreeLabel.Font = new Font("Arial", 17, FontStyle.Bold);
        barcodeThreeLabel.Location = new Point(50, 250);

        barcodeThreeTextBox.Location = new Point(415, 252);
        barcodeThreeTextBox.Font = new Font("Arial", 17, FontStyle.Bold);
        barcodeThreeTextBox.Width = 550;
        //barcodeThreeTextBox.Text = "iNETCEED#202404101140#3";

        qrCodeLabel.Text = "QR Code:";
        qrCodeLabel.AutoSize = true;
        qrCodeLabel.Font = new Font("Arial", 17, FontStyle.Bold);
        qrCodeLabel.Location = new Point(50, 325);

        qrCodeTextBox.Location = new Point(415, 327);
        qrCodeTextBox.Font = new Font("Arial", 17, FontStyle.Bold);
        qrCodeTextBox.Width = 550;
        //qrCodeTextBox.Text = "iNETCEED Print Quality Test Printer sn 2302P000225#User202404101140";

        isLineValidated.Checked = false;
        isLineValidated.Location = new Point(985, 335);
        isLineValidated.Text = "Linha OK ?";
        isLineValidated.AutoSize = true;

        validateButton.Text = "Validar";
        validateButton.Font = new Font("Arial", 8);
        validateButton.Width = 150;
        validateButton.Height = 75;
        validateButton.Location = new Point(627, 405);

        closeButton.Image = Image.FromFile(@"C:\Program Files\printer-quality-test\icons\exit_icon.ico"); 
        //closeButtonForm.Image = Image.FromFile(@"C:\Program Files\Label Generator\icons\exit_icon.ico"); 
        closeButton.BackgroundImageLayout = ImageLayout.Stretch;
        closeButton.Width = 50;
        closeButton.Height = 50;
        closeButton.Location = new Point(1200, 10);
        closeButton.BackColor = Color.Transparent;

        //Adição de tab pages ao Tab Control
        labelForEvaluationTabControl.TabPages.AddRange([labelForEvaluationTabPage, labelValidationTabPage]);

        labelForEvaluationTabPage.Controls.AddRange([labelNameForEvaluationTab, printerSNlabel, printerSNtextBox, focusCallPrintButton, printButtonEvaluation, automaticPrintingEvaluationPage]);
        labelValidationTabPage.Controls.AddRange([labelValidationNameTab, barcodeOneLabel, barcodeOneTextBox, barcodeTwoLabel, barcodeTwoTextBox,
        barcodeThreeLabel, barcodeThreeTextBox, qrCodeLabel, qrCodeTextBox, isLineValidated, validateButton]);

        closeButton.Click += closeButtonClick;
        printButtonEvaluation.Click += printButtonEvaluation_Click;
        validateButton.Click += validateButton_Click;
        focusCallPrintButton.GotFocus += focusCallPrintButton_OnFocus;

        //barcodeTwoTextBox.Leave += barcodeTwoTextBox_Leave;
        //barcodeThreeTextBox.Leave += barcodeThreeTextBox_Leave;
        //qrCodeTextBox.Leave += qrCodeTextBox_Leave;

        automaticPrintingEvaluationPage.CheckedChanged += automaticPrintingEvaluationPage_CheckedChanged;

        this.Controls.AddRange([titleApp, labelForEvaluationTabControl, closeButton]);
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1250, 750);
        this.Text = "Quality Test Labels";
    }

    #endregion
}
