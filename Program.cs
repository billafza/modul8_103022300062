using System.Diagnostics.SymbolStore;
using modul8_103022300062;

class Program
{
    static void Main(string[] args)
    {
        BankTransferConfig config = new BankTransferConfig();
        
        UIConfig uIConfig = new UIConfig();
        int uang = 0;

        if (config.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer:");
        }
        else {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
        }
    }
}