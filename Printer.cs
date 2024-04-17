public class Printer{
    public string serialNumber {get; set;}
    public string printerName {get;set;}

    public Printer(){}

    public Printer(string sn, string printer){
        this.serialNumber = sn;
        this.printerName = printer;
    }
}