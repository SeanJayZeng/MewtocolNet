using MewtocolNet;
using MewtocolNet.Logging;

namespace Examples.ProgramReadWrite;

internal class Program {

    static void Main(string[] args) => run();

    public static void run()
    {
        var plc = Mewtocol.Ethernet("127.0.0.1", 9094).Build();
        plc.ConnectAsync().GetAwaiter().GetResult();
        //plc.Register.Bool("Y10").WriteAsync(false).GetAwaiter().GetResult();
        
        var data4 = plc.Register.Bool("Y10").ReadAsync().GetAwaiter().GetResult();
        Console.WriteLine("要输出的内容:"+ data4);

    }

    //MewtocolNet.ProgramParsing.PlcBinaryProgram.ParseFromFile(@"C:\Users\fwe\Documents\sps\FPXH_C30_Test1.fp").AnalyzeProgram();

    static async Task AsyncMain () {

        Logger.LogLevel = LogLevel.Error;

        using (var plc = Mewtocol.Ethernet("192.168.178.55").Build()) {

            await plc.ConnectAsync();
            var prog = await plc.ReadProgramAsync();

            if (prog != null) {

                prog.AnalyzeProgram();

            }

        }

    }

}
