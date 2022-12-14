public class Course : SelectionEntity {
    public Course(string courseName, string courseDomain)
            : base (courseName, courseDomain) {}

    public static List<Course> createListOfCourses(string[] names, string[] courseDomain) {
        int len = names.Length;
        List<Course> courses = new List<Course>();

        for (int i = 0; i < len; i++)
            courses.Add(new Course(names[i], courseDomain[i]));

        return courses;
    }

    public static string[] extractDomains(Course[] courses) {
        string[] domains = {};

        foreach(Course course in courses)
            domains.Append(course.domain);

        return domains;
    }
}