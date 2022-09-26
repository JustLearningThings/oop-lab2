public class Course {
    string name;
    string[] domains;

    public Course(string courseName, string[] courseDomains) {
        name = courseName;
        domains = courseDomains;
    }

    public static Course[] createListOfCourses(string[] names, string[][] courseDomains) {
        int len = names.Length;
        Course[] courses = {};

        for (int i = 0; i < len; i++)
            courses.Append(new Course(names[i], courseDomains[i]));

        return courses;
    }

    public static string[] extractDomains(Course[] courses) {
        string[] domains = {};

        foreach(Course course in courses)
            domains.Append(course.domain);

        return domains;
    }
}