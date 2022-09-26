public class Course {
    string name;
    string domain;

    public Course(string courseName, string courseDomain) {
        name = courseName;
        domain = courseDomain;
    }

    public static Course[] createListOfCourses(string[] names, string[] courseDomain) {
        int len = names.Length;
        Course[] courses = {};

        for (int i = 0; i < len; i++)
            courses.Append(new Course(names[i], courseDomain[i]));

        return courses;
    }

    public static string[] extractDomains(Course[] courses) {
        string[] domains = {};

        foreach(Course course in courses)
            domains.Append(course.domain);

        return domains;
    }
}