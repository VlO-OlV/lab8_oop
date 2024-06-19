namespace Library
{
    public interface ISearch
    {
        List<Employee> searchEmployees(string keyWord);
        List<Department> searchDepartments(string keyWord);
        List<Job> searchJobs(string keyWord);
        List<Project> searchProjects(string keyWord);
    }
}
