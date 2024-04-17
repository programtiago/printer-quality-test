namespace quality_testlabel;

public partial class Form1 : Form
{
    Printer printer = new Printer();
    public LabelEvaluation labelEvaluation;
    public LabelValidated labelValidated;

    public Form1()
    {
        InitializeComponent();  

        printerSNtextBox.Focus();

        printButtonEvaluation.Enabled = false;

        notAllowResizingMaxAndMin();
    
    }

    public void automaticPrintingEvaluationPage_CheckedChanged(object sender, EventArgs e){
        checkPrintAutomatic();
    }

    public void notAllowResizingMaxAndMin(){
        FormBorderStyle = FormBorderStyle.None;
        MaximizeBox = false;
        MinimizeBox = false;   
    }

    public bool checkPrintAutomatic(){
        bool printAutomatic;

        if (automaticPrintingEvaluationPage.Checked){
            printButtonEvaluation.Enabled = false;
            printAutomatic = true;
        }else{
            printButtonEvaluation.Enabled = true;
            printAutomatic = false;
        }

        return printAutomatic;
    }

    public void printerSNtextBox_KeyDown(object sender, PreviewKeyDownEventArgs e){
    
            if (checkPrintAutomatic()){
                generateLabelValidated();
                labelEvaluation.print(printer.printerName);

            }else{
                DialogResult dr = MessageBox.Show("Número de série da impressora é inválido", "Campo inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if ( dr == DialogResult.OK){
                    focusPrinterSNbox();
                }
            }
    
    }

    public void closeButtonClick(object sender, EventArgs e){
        DialogResult dr = MessageBox.Show("Tem a certeza que deseja sair da aplicação ? ", "Tem a certeza ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (dr == DialogResult.Yes){
           System.Windows.Forms.Application.Exit();
        }
    }

    private void generateLabelValidated(){

            labelEvaluation = new LabelEvaluation();
            labelValidated = new LabelValidated();
    
            DateTime todayDate = DateTime.Now;

            printer.serialNumber = printerSNtextBox.Text;
            printer.printerName = "LABEL_CARDBOX";
            
            labelEvaluation.user = Environment.UserName;
            labelEvaluation.registryLabelDate = todayDate;
            labelEvaluation.barcodeOne = "iNET#" + todayDate.ToString("yyyyMMddHHmm") + "#1";
            labelEvaluation.barcodeTwo = "iNET#" + todayDate.ToString("yyyyMMddHHmm") + "#2";
            labelEvaluation.barcodeThree = "iNET#" + todayDate.ToString("yyyyMMddHHmm") + "#3";
            labelEvaluation.qrCode = qrCodeTextBox.Text;
            labelEvaluation.printerSN = printerSNtextBox.Text;
    
            labelValidated.printerSN = labelEvaluation.printerSN;
            labelValidated.printerName = printer.printerName;
            labelValidated.user = labelEvaluation.user;
            labelValidated.registryDateTime = labelEvaluation.registryLabelDate;
    }

    private bool validatePrinterSn(){
         if (printerSNtextBox.Text != "" && printerSNtextBox.Text.StartsWith("2302")){
            return true;
         }else if(printerSNtextBox.Text == "" && !printerSNtextBox.Text.StartsWith("2302") || printerSNtextBox.Text == ""){
            return false;
         }
         return false;
    }

    public void printButtonEvaluation_Click(object sender, EventArgs e){
        
        if (validatePrinterSn()){            
           labelEvaluation.print(printer.printerName);
           labelForEvaluationTabControl.SelectedTab = labelValidationTabPage;
        }else if(validatePrinterSn() == false){
            DialogResult dr = MessageBox.Show("O número de série que introduziu não é válido", "Número de série incorreto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            if (dr == DialogResult.OK){
                focusPrinterSNbox();
            }
        }
    }

    public void focusCallPrintButton_OnFocus(object sender, EventArgs e){
        if (checkPrintAutomatic() && validatePrinterSn()){
            generateLabelValidated();
            labelEvaluation.print(printer.printerName);
            labelForEvaluationTabControl.SelectedTab = labelValidationTabPage;
        }else{
            printerSNtextBox.Focus();
            DialogResult dr = MessageBox.Show("O número de série que introduziu não é válido", "Número de série incorreto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            if (dr == DialogResult.OK){
                focusPrinterSNbox();
            }
        }
    }

    private void focusPrinterSNbox(){
        printerSNtextBox.Focus();
        printerSNtextBox.SelectAll();
    }

    private bool validateValueBarcodeOne(){
        bool barcodeValidate;
    

        if (barcodeOneTextBox.Text == "iNET#" + labelEvaluation?.registryLabelDate.ToString("yyyyMMddHHmm#1")){
            barcodeValidate = true;
        }else{
            return false;
        }

        return barcodeValidate;
    }

    private bool validateValueBarcodeTwo(){
        bool barcodeValidate;

            if (barcodeTwoTextBox.Text == "iNET#" + labelEvaluation?.registryLabelDate.ToString("yyyyMMddHHmm#2")){
                barcodeValidate = true;
        }else{
            return false;
        }

        return barcodeValidate;
    }

    private bool validateValueBarcodeThree(){
        bool barcodeValidate;

            if (barcodeThreeTextBox.Text == "iNET#" + labelEvaluation?.registryLabelDate.ToString("yyyyMMddHHmm#3")){
                barcodeValidate = true;
        }else{
            return false;
        }

        return barcodeValidate;
    }

    private bool validateValueQRbarcode(){
        bool barcodeValidate;

            if (qrCodeTextBox.Text == "iNetceed Print Quality Test Printer sn " + labelEvaluation?.printerSN + "#" + labelEvaluation?.user + " " + labelEvaluation?.registryLabelDate.ToString("yyyyMMddHHmm#")){
                barcodeValidate = true;
        }else{
            return false;
        }

        return barcodeValidate;
    }


    public void validateButton_Click(object sender, EventArgs e){  
        if (barcodeOneTextBox.Text != "" && barcodeTwoTextBox.Text != "" && barcodeThreeTextBox.Text != "" &&
           qrCodeTextBox.Text != "" && isLineValidated.Checked == true)
           {
                    if (labelEvaluation != null && labelValidated != null &&
                        validateValueBarcodeOne() && validateValueBarcodeTwo() && validateValueBarcodeThree() && validateValueQRbarcode())
                    {
                            string filePath = @"C:\Program Files\printer-quality-test\files\records_register_qualtityPrinter.txt";
                            
                            labelValidated.print(printer.printerName);

                            using(StreamWriter sw = File.AppendText(filePath)){
                                sw.WriteLine(printerSNtextBox.Text + "," + labelValidated.user + "," + labelValidated.registryDateTime);
                            }
                        
                            barcodeOneTextBox.Text = "";
                            barcodeTwoTextBox.Text = "";
                            barcodeThreeTextBox.Text = "";
                            qrCodeTextBox.Text = "";
                            isLineValidated.Checked = false;

                            labelForEvaluationTabControl.SelectedTab = labelForEvaluationTabPage;
                            printerSNtextBox.Focus();
                            printerSNtextBox.SelectAll();
                    
                    }else{
                        MessageBox.Show("Campos inválidos. Por favor, tente novamente ! ", "Campos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }else if (barcodeOneTextBox.Text == "" && barcodeTwoTextBox.Text == "" || barcodeThreeTextBox.Text == "" && isLineValidated.Checked || isLineValidated.Checked){
                    MessageBox.Show("Obrigatório preencher os campos", "Campos em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }else if(barcodeOneTextBox.Text != "" && barcodeTwoTextBox.Text != "" && barcodeThreeTextBox.Text != "" && qrCodeTextBox.Text != "" && isLineValidated.Checked == false){
            MessageBox.Show("Obrigatório validar a linha ! ", "Validar linha", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }else if(barcodeOneTextBox.Text == "" || barcodeTwoTextBox.Text == "" || barcodeThreeTextBox.Text == "" || qrCodeTextBox.Text == "" 
                 && isLineValidated.Checked == false){
                    MessageBox.Show("Obrigatório preencher os campos/Validar linha", "Campos em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
    }
    
}
