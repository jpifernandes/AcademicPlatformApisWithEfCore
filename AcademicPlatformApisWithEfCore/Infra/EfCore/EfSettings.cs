namespace AcademicPlatformApisWithEfCore.Infra.EfCore
{
    public class EfSettings
    {
        public string ConnectionString { get; set; }
        public bool EnableConsoleLog { get; set; }
        public bool RunMigrations { get; set; }
    }
}
