// // Testing Simulation
// Simulation sim = new Simulation();

// sim.printStats();



// Testing Employee
// string[][] PLDomains = new string[][] {
//     new string[] {"backend", "game dev"},
//     new string[] {"frontend", "backend"}
// };

// Employee Mark = new Employee(
//     "Mark",
//     "Zuckerberg",
//     28,
//     10,
//     1_000_000,
//     new string[] {"planning", "teamwork"},
//     new int[] {7, 4},
//     new bool[] {true, false},
//     new string[] {"c#", "Python"},
//     PLDomains,
//     new string[] {"Portfolio", "Recommendation system"},
//     new string[] {"c#", "Python"},
//     new string[] {"web dev", "machine learning"},
//     new string[] {"DeepLearning", "Data Analysis"},
//     new string[] {"machine learning", "machine learning"},
//     new string[] {"AI Hackaton", "FAF Hackaton"},
//     new DateTime[] {DateTime.Now, DateTime.Now},
//     new string[] {"machine learning", "web dev"}

// );

// Console.WriteLine(Mark.firstName + ' ' + Mark.lastName + " want a salary of " + Mark.desiredSalary + " USD");



// Testing HR
// HR Aliona = new HR(
//     "Aliona",
//     "Sandu",
//     22,
//     3,
//     "Endava",
//     new List<Project> {},
//     new string[] {"teamwork", "planning"}
// );

// Console.WriteLine("HR " + Aliona.firstName + ' ' + Aliona.lastName + " is looking for candidates that have these skills:");

// foreach(var s in Aliona.desiredSkills)
//     Console.WriteLine(" > " + s);



// Testing ProgrammingLanguage
// ProgrammingLanguage c_reshotka = new ProgrammingLanguage("c#", new string[] {"backend", "game dev"});

// Console.WriteLine(c_reshotka.name + " is used in:");

// foreach(var d in c_reshotka.domains)
//     Console.WriteLine(" > " + d);


// string[][] PLDomains = new string[][] {
//     new string[] {"backend", "game dev"},
//     new string[] {"frontend", "backend"}
// };

// List<ProgrammingLanguage> languages = ProgrammingLanguage.createListOfLanguages(new string[] {"c#", "js"}, PLDomains);

// foreach(var lang in languages)
//     Console.WriteLine(lang.name);