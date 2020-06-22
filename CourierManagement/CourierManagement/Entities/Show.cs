namespace CourierManagement.Entities
{
    class Show
    {
        public enum AdminShow
        {
            workerList =1,
            workerProblem,
            allBranch
        }
        public int adminShow;
        public enum EmployeeShow
        {
            Manager,
            Worker,
            Driver,
            Delivery_boy
        }
        public int employeeShow;
        public enum CustomerShow
        {
            Manager,
            Worker,
            Driver,
            Delivery_boy
        }
        public int customerShow;
    }
}
