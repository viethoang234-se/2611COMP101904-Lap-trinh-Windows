using Lab14.BLL;
using Lab14.DAL;
using Lab14.Data;
using Lab14.GUI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Lab14;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        string connectionString = configuration.GetConnectionString("EduManager")
            ?? throw new InvalidOperationException("Không tìm thấy ConnectionStrings:EduManager trong appsettings.json.");

        var options = new DbContextOptionsBuilder<EduManagerContext>()
            .UseSqlServer(connectionString)
            .Options;

        var dal = new MonHocDAL(options);
        var bll = new MonHocBLL(dal);

        Application.Run(new FrmMonHoc(bll));
    }
}
