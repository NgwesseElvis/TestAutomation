namespace BaseProject.IDrivers
{
    public interface IDrivers
    {
        void InitDriver();
        object Driver { get; set; }
        object DesiredCapabilities { get; }
    }
}
