using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Google_AI_Helper
{
    public partial class Form1 : Form
    {
        private const string ApiKey = "YOUR_API"; // API Anahtarınızı buraya girin
        private const string ModelName = "gemini-1.5-flash"; // Model adını buraya girin
        private const string ApiEndpoint = $"https://generativelanguage.googleapis.com/v1beta/models/{ModelName}:generateContent?key={ApiKey}";

        public Form1()
        {
            InitializeComponent();
            responseTextBox.ReadOnly = true;
            responseTextBox.MouseClick += ResponseTextBox_MouseClick;

            // İşlem türlerini ComboBox'a ekleyin
            operationComboBox.Items.Add("Düzenle");
            operationComboBox.Items.Add("Özetle");
            operationComboBox.Items.Add("Çevir (İngilizce)");
            operationComboBox.Items.Add("Resmileştir");
            operationComboBox.SelectedIndex = 0; // Varsayılan olarak ilk öğeyi seç
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            string userInput = inputTextBox.Text.Trim();
            string operationType = operationComboBox.SelectedItem.ToString().ToLower();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                MessageBox.Show("Lütfen bir metin girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            responseTextBox.Clear();
            responseTextBox.Text = "Lütfen bekleyin...";

            try
            {
                // Dinamik olarak istem oluştur
                string prompt = CreatePrompt(operationType, userInput);

                // Yanıtı al
                string response = await GenerateResponseAsync(prompt);

                // Yanıtı stilize ederek RichTextBox'a yaz
                ProcessAndDisplayResponse(response);
            }
            catch (Exception ex)
            {
                responseTextBox.Text = $"Hata: {ex.Message}";
            }
        }

        private string CreatePrompt(string promptType, string userInput)
        {
            // Farklı işlem türleri için şablonlar
            switch (promptType)
            {
                case "düzenle":
                    return $"Lütfen aşağıdaki metni düzenle ve daha iyi bir şekilde yeniden yaz:\n\n{userInput}";
                case "özetle":
                    return $"Aşağıdaki metni özetle:\n\n{userInput}";
                case "çevir (i̇ngilizce)":
                    return $"Translate the following text to English:\n\n{userInput}";
                case "resmileştir":
                    return $"Lütfen aşağıdaki metni daha resmi bir şekilde yeniden yaz:\n\n{userInput}";
                default:
                    return $"Bilinmeyen işlem türü. Kullanıcı girdisi:\n\n{userInput}";
            }
        }

        private async Task<string> GenerateResponseAsync(string promptText)
        {
            using (HttpClient client = new HttpClient())
            {
                // İstek gövdesi
                var requestBody = new
                {
                    contents = new[]
                    {
                        new
                        {
                            parts = new[]
                            {
                                new { text = promptText }
                            }
                        }
                    },
                    generationConfig = new
                    {
                        temperature = 0.5,
                        maxOutputTokens = 1000
                    }
                };

                string jsonBody = JsonConvert.SerializeObject(requestBody);
                StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                // API isteği gönder
                HttpResponseMessage response = await client.PostAsync(ApiEndpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    dynamic responseObject = JsonConvert.DeserializeObject(responseJson);
                    return responseObject.candidates[0].content.parts[0].text;
                }
                else
                {
                    throw new Exception($"API Hatası: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }

        private void ProcessAndDisplayResponse(string response)
        {
            responseTextBox.Clear();

            string[] parts = response.Split(new[] { "**" }, StringSplitOptions.None);
            for (int i = 0; i < parts.Length; i++)
            {
                if (i % 2 == 0)
                {
                    // Düz metin
                    responseTextBox.AppendText(parts[i]);
                }
                else
                {
                    // Kalın metin
                    int start = responseTextBox.TextLength;
                    responseTextBox.AppendText(parts[i]);
                    responseTextBox.Select(start, parts[i].Length);
                    responseTextBox.SelectionFont = new System.Drawing.Font(responseTextBox.Font, System.Drawing.FontStyle.Bold);
                }
            }

            responseTextBox.AppendText(Environment.NewLine);
        }

        private void ResponseTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(responseTextBox.Text))
            {
                Clipboard.SetText(responseTextBox.Text);
                MessageBox.Show("Yanıt panoya kopyalandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}