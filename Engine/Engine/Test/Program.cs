using Engine;

namespace Test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var t = new AncApplication(1000, 800, false, false))
            {
                t.Start(new scene1("Scene1"), new DefaultScene("Default"));
            }
        }
    }
}