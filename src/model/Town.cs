namespace wpf_basic_reports.src.model
{
    internal class Town
    {
        public int DepartmentCode { get; }
        public int TownCode { get; }
        public string DepartmentName { get; }
        public string TownName { get; }
        public string TownType { get; }
        public Town(int departmentCode, int townCode, string departmentName, string townName, string townType)
        {
            DepartmentCode = departmentCode;
            TownCode = townCode;
            DepartmentName = departmentName;
            TownName = townName;
            TownType = townType;
        }
    }
}
