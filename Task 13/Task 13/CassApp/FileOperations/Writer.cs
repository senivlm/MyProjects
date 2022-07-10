using CassApp;

namespace Task12_3
{
    internal class Writer
    {
        private string filePath;

        public string FilePAth
        {
            get => filePath;
            set
            {
                if (value != null) filePath = value;
            }
        }

        public Writer(string filePath)
        {
            this.filePath = filePath;
        }

        public Writer()
        {
            filePath = @"C:\Users\Временный\source\repos\CassApp\CassApp\Files\Person.txt";
        }

        public void WritePerson(Client client, string filePath = @"C:\Users\Временный\source\repos\CassApp\CassApp\Files\Person.txt")
        {
            if (filePath == null || filePath == "") throw new FileNotFoundException();
            if (!File.Exists(filePath)) File.Create(filePath);

            using (StreamWriter sw = new(filePath, true))
            {
                sw.WriteLine(client.ToString());
            }
        }
    }
}
