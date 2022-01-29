namespace wpf_basic_reports.Model
{
    internal class Town
    {
        public int DepartmentCode { get; }
        public int TownCode { get; }
        public string DepartmentName { get; }
        public string TownName { get; }
        public Town(int departmentCode, int townCode, string departmentName, string townName)
        {
            DepartmentCode = departmentCode;
            TownCode = townCode;
            DepartmentName = departmentName;
            TownName = townName;
        }
    }
}
