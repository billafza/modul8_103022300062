using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_103022300062
{
    internal class BankTransferConfig
    {
        public string lang { get; set; }
        public class transfer {
            public transfer() { }
            public transfer(int threshold, int low_fee, int high_fee) 
            {
                this.threshold = threshold;
                this.low_fee = low_fee;
                this.high_fee = high_fee;
            }

            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }

        }
        public transfer tf { get; set; }

        public string methods { get; set; }
        public class confirmation
        {
            public confirmation() { }
            public confirmation(string en, string id)
            {
                this.en = en;
                this.id = id;
            }

            public string en { get; set; }
            public string id { get; set; }

        }
        public confirmation confirm { get; set; }

        public BankTransferConfig() { }

        public BankTransferConfig(string lang, transfer tf, string methods, confirmation confirm)
        {
            this.lang = lang;
            this.tf = tf;
            this.methods = methods;
            this.confirm = confirm;
        }
    }

    class UIConfig
    {
        public BankTransferConfig config;

        public const String filePath = "D:\\modul8_103022300062\\bank_transfer_config.json";

        public UIConfig() 
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }
        private BankTransferConfig ReadConfigFile() {
            String configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<BankTransferConfig>(configJsonData);
            return config;
        }

        private void SetDefault() 
        { 
            config = new BankTransferConfig();
            config.lang = "en";
            config.tf = new BankTransferConfig.transfer();
            config.tf.threshold = 25000000;
            config.tf.low_fee = 6500;
            config.tf.high_fee = 15000;

            config.methods = "RTO (real-time)”, “SKN”, “RTGS”, “BI FAST";
            config.confirm = new BankTransferConfig.confirmation();
            config.confirm.en = "en";
            config.confirm.id = "id";
        }

        private void WriteNewConfigFile() 
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);

        }
    }

}
