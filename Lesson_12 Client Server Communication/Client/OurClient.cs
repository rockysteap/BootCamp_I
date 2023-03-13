using System.Net.Sockets;
using System.Text;

namespace Client
{
    class OurClient
    {
            private TcpClient _client;
            private StreamWriter _sWriter;
            private StreamReader _sReader;
        

        public OurClient()
        {
            _client = new TcpClient("127.0.01", 5555);
            _sWriter = new StreamWriter(_client.GetStream(),Encoding.UTF8);
            _sReader = new StreamReader(_client.GetStream(),Encoding.UTF8);

            HandleCommunication();
        }

        void HandleCommunication()
        {
            while (true)
            {
                System.Console.Write("> ");
                string message = Console.ReadLine()!;
                _sWriter.WriteLine(message);
                _sWriter.Flush();

                string answerServer = _sReader.ReadLine()!;
                Console.WriteLine($"Сервер ответил -> {answerServer}");
            }
        }
    }
}