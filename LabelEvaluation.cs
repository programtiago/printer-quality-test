using System.Drawing.Printing;
using GenCode128;
using QRCoder;

public class LabelEvaluation{
    public string user {get;set;}
    public DateTime registryLabelDate;
    public String barcodeOne {get;set;}
    public String barcodeTwo {get;set;}
    public String barcodeThree {get;set;}
    public String qrCode {get;set;}
    public String printerSN {get;set;}
    public LabelEvaluation(){}

    public LabelEvaluation(string user_acc, String barcode1, String barcode2, String barcode3, DateTime registryDateTime, String qr){

        this.user = user_acc;
        this.registryLabelDate = registryDateTime;
        this.barcodeOne = barcode1;
        this.barcodeTwo = barcode2;
        this.barcodeThree = barcode3;
        this.qrCode = qr;
    }

    public void renderAndPrint(object sender, PrintPageEventArgs e){

        Graphics g = e.Graphics;
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
        e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.GammaCorrected;
        e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

        Rectangle rectangleHeader = new Rectangle
        {
            Size = new Size(130, 38),
            Location = new Point(68, 20)
        };

        Font bodyFont = new Font("Arial", 8, FontStyle.Regular);
        Font barcodeFont = new Font("Arial", 5, FontStyle.Regular);
        Font titleFont = new Font("Arial", 8, FontStyle.Bold);

        SolidBrush brush = new SolidBrush(System.Drawing.Color.Black);
        
        Pen pen = new Pen(Color.Black, 12);
        Pen penRectangle = new Pen(Color.Black, 1);

        int startXline = 50; // Start x-coordinate
        int endXline = 360; // End x-coordinate
        int yCoordinate = 170; // Y-coordinate

        Image barcode1 = Code128Rendering.MakeBarcodeImage(this.barcodeOne, 1, false);
        float heightBarcode1 = barcode1.Height;
        float widthBarcode1  = barcode1.Width;

        Image barcode2 = Code128Rendering.MakeBarcodeImage(this.barcodeTwo, 1, false);
        float heightBarcode2 = barcode2.Height;
        float widthBarcode2 = barcode2.Width;

        Image barcode3 = Code128Rendering.MakeBarcodeImage(this.barcodeThree, 1, false);
        float heightBarcode3 = barcode3.Height;
        float widthBarcode3 = barcode3.Width;

        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //L - 7%  M - 15%  Q - 25%  H - 30%   densidade do qr code  consultei https://kazuhikoarase.github.io/qrcode-generator/js/demo/
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(transformQrCode(), QRCodeGenerator.ECCLevel.L);
        QRCode qrCode = new QRCode(qrCodeData);
        Image qrCodeImage = qrCode.GetGraphic(20);


        var qrCodeImageWidth = qrCodeImage.Width;
        var qrCodeImageHeight = qrCodeImage.Height;
        
        g.DrawRectangle(penRectangle, rectangleHeader);
        g.DrawString("iNetceed", titleFont, brush, new PointF(287,3));
        g.DrawString("User: " + user.ToUpper(), bodyFont, brush, new PointF(69.5f, 21.5f));
        g.DrawString("Time: " + registryLabelDate.ToString("yyyy-MM-dd HH:mm"), bodyFont, brush, new PointF(69.5f, 41.5f));
        g.DrawString("Printer s/n: ", bodyFont, brush, new PointF(279,21.5f));
        g.DrawString(printerSN,
         bodyFont, brush, new PointF(264.5f, 37.5f));
        g.DrawImage(barcode1, 67.5f, 67.5f, (float)(widthBarcode1*0.55), (float)(heightBarcode1*0.35));
        g.DrawString(barcodeOne, barcodeFont, brush, new PointF(67.5f,83));
        g.DrawImage(barcode2, 67.5f, 93.5f, (float)(widthBarcode2*0.67), (float)(heightBarcode2*0.45));
        g.DrawString(barcodeTwo, barcodeFont, brush, new PointF(67.5f,113.5f));
        g.DrawImage(barcode3, 67.5f, 123.5f, (float)(widthBarcode3*0.75), (float)(heightBarcode3*0.60));
        g.DrawString(barcodeThree, barcodeFont, brush, new PointF(67.5f,150));
        g.DrawImage(qrCodeImage, 275.5f, 58.5f, (float)(qrCodeImageWidth*0.08), (float)(qrCodeImageHeight*0.08)); 
        g.DrawLine(pen, startXline, yCoordinate, endXline, yCoordinate);

    }
    private String transformQrCode(){
        qrCode = "iNetceed Print Quality Test \nPrinter sn " + printerSN + "\n#" + user + " " + registryLabelDate.ToString("yyyyMMddHHmm#");
        return qrCode;
    }
    

    public void print(String printer){
        PrintDocument pd = new PrintDocument();

        try{
            pd.DefaultPageSettings.PrinterSettings.PrinterName = printer;
            pd.PrintPage += new PrintPageEventHandler(renderAndPrint);

            pd.Print();
        }catch(Exception ex){
            MessageBox.Show(ex.Message.ToString());
        }
    }
}