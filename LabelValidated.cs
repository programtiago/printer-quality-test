using System.Drawing.Printing;
using quality_testlabel;

public class LabelValidated{

    public LabelEvaluation labelEvaluation;
    public String printerName;
    public String printerSN;
    public String user;
    public DateTime registryDateTime;
    public LabelValidated(){}

    public LabelValidated(String printer, String serialPrinter, String user_acc, DateTime registryDate){
        this.printerName = printer;
        this.printerSN = serialPrinter;
        this.registryDateTime = registryDate;
        this.user = user_acc;
        labelEvaluation = new LabelEvaluation();
    }

    public void renderAndPrint(object sender, PrintPageEventArgs e){

        Graphics g = e.Graphics;

        Font titleFont = new Font("Arial", 8, FontStyle.Bold);
        Font bodyFont = new Font("Arial", 8, FontStyle.Regular);

        Rectangle rectangleBottom = new Rectangle
        {
            Size = new Size(135, 35),
            Location = new Point(67, 135)
        };

        Pen penRectangle = new Pen(Color.Black, 1);

        SolidBrush brush = new SolidBrush(System.Drawing.Color.Black);

        g.DrawString("PRINTER QUALITY TEST OK ", titleFont, brush, new PointF(67.5f, 19.5f));
        g.DrawString("Barcode 1: OK", bodyFont, brush, new PointF(67.5f, 49.5f));
        g.DrawString("Barcode 2: OK", bodyFont, brush, new PointF(67.5f, 63.5f));
        g.DrawString("Barcode 3: OK", bodyFont, brush, new PointF(67.5f, 77.5f));
        g.DrawString("QR Code: OK", bodyFont, brush, new PointF(67.5f, 91.5f));
        g.DrawString("Solid bar: No visible white lines", bodyFont, brush, new PointF(67.5f, 105.5f));
        g.DrawString("iNetceed", titleFont, brush, new PointF(287,3));
        g.DrawString("Printer s/n: ", bodyFont, brush, new PointF(279,19.5f));
        g.DrawString(printerSN, bodyFont, brush, new PointF(264.5f, 35.5f));
        g.DrawString("User: " + user, bodyFont, brush, new PointF(69, 138.5f));
        g.DrawString("Time: " + registryDateTime.ToString("yyyy-MM-dd HH:mm"), bodyFont, brush, new PointF(69, 155.5f));

        g.DrawRectangle(penRectangle, rectangleBottom);
       
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