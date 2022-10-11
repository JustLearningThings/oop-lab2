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

// Console.WriteLine("Projects:");
// foreach(var p in Mark.projects)
//     Console.WriteLine(" > " + p.name);



// Testing HR
// HR Aliona = new HR(
//     "Aliona",
//     "Sandu",
//     22,
//     3,
//     "Endava",
//     new string[] {"molda"},
//     new string[] {"python"},
//     new string[] {"machine learning"},
//     new string[] {"teamwork", "planning"}
// );

// Console.WriteLine("HR " + Aliona.firstName + ' ' + Aliona.lastName + " is looking for candidates that have these skills:");

// foreach(var s in Aliona.desiredSkills)
//     Console.WriteLine(" > " + s);

// Console.WriteLine("Projects:");
// foreach(var p in Aliona.projects)
//     Console.WriteLine(" > " + p.name);


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


// Testing Course
// Course DeepLearning = new Course(
//     "Deep Learning",
//     "Machine learning"
// );

// Console.WriteLine(DeepLearning.name + "  " + DeepLearning.domain);


// Testing ProgrammingLanguage
// ProgrammingLanguage C_reshotka = new ProgrammingLanguage(
//     "C#",
//     new string[] {"backend", "game dev", "windows"}
// );

// Console.WriteLine(C_reshotka + " is used in:");

// foreach (var d in C_reshotka.domains)
//     Console.WriteLine(" > " + d);


// Testing JobSite and Offer
// JobSite DeLucru = new JobSite(
//     "DeLucru",
//     new Offer[] {},
//     "delucru.md"
// );

// Console.WriteLine(DeLucru.name + " has url: " + DeLucru.url);

// Offer Pentalog = new Offer(
//     "Android developer",
//     10_000,
//     new Project("Driving app", "Kotlin", "android"),
//     "delucru.md/pentalog/android-dev"
// );

// Console.WriteLine(Pentalog.title + " has url: " + Pentalog.url + " from " + Pentalog.country);
// Console.WriteLine(Pentalog.numInteractions);





// Console.WriteLine("MAIN");

// string[][] PLDomains = new string[][] {
//     new string[] {"backend", "game dev"},
//     new string[] {"frontend", "backend"}
// };

// Employee Child = new Employee(
//     "Child Mark",
//     "Zuckerberg",
//     28,
//     10,
//     1_000_000,
//     new string[] {},
//     new int[] {},
//     new bool[] {},
//     new string[] {},
//     new string[] {},
//     PLDomains,
//     new string[] {},
//     new string[] {},
//     new string[] {},
//     new string[] {},
//     new string[] {},
//     new string[] {},
//     new DateTime[] {DateTime.Now, DateTime.Now},
//     new string[] {}
// );
// Person parent = Child;

// Child.show();
// parent.show();



// LAB 4 (SCENARIOS)

// 1) HR hires HR
Console.WriteLine("HR hires HR");

HR Aliona = new HR(
    "Aliona",
    "Sandu",
    22,
    3,
    "Endava",
    new string[] {"molda"},
    new string[] {"python"},
    new string[] {"machine learning"},
    new string[] {"teamwork", "planning"}
);
HR Maria = new HR(
    "Maria",
    "Gorbataia",
    20,
    1,
    "Simpals",
    new string[] {"999"},
    new string[] {"python"},
    new string[] {"web"},
    new string[] {"teamwork", "planning", "scrum"}
);

Console.Write("Aliona will hire Maria: ");
Console.WriteLine(Aliona.evaluate(Maria));

// 2) HR hires Employee
Console.WriteLine("\nHR hires Employee");

string[][] PLDomains = new string[][] {
    new string[] {"backend", "game dev"},
    new string[] {"frontend", "backend"}
};

Employee Mark = new Employee(
    "Mark",
    "Zuckerberg",
    28,
    10,
    1_000_000,
    new string[] {"planning", "teamwork"},
    new int[] {7, 4},
    new bool[] {true, false},
    new string[] {"soft", "soft"},
    new string[] {"c#", "Python"},
    PLDomains,
    new string[] {"Portfolio", "Recommendation system"},
    new string[] {"c#", "Python"},
    new string[] {"web dev", "machine learning"},
    new string[] {"DeepLearning", "Data Analysis"},
    new string[] {"machine learning", "machine learning"},
    new string[] {"AI Hackaton", "FAF Hackaton"},
    new DateTime[] {DateTime.Now, DateTime.Now},
    new string[] {"machine learning", "web dev"}
);

Console.Write("Aliona will hire Mark: ");
Console.WriteLine(Aliona.evaluate(Mark));

// 3) HR creates an Offer
Console.WriteLine("\nHR creates an Offer");
Aliona.createOffer("Data Engineer", 10_000);

Console.WriteLine("Aliona's offers:");
foreach(Offer offer in Aliona.offers)
    Console.WriteLine(" > " + offer.title);

// 4) HR posts an Offer on a JobSite
// create a JobSite first
Console.WriteLine("\nHR posts an Offer on a JobSite");

JobSite Rabota = new JobSite(
    "rabota",
    new List<Offer> {},
    "www.rabota.md"
);

Aliona.postOffer("Data Engineer", Rabota);

Console.WriteLine("Rabota's offers:");
foreach(Offer offer in Rabota.offers)
    Console.WriteLine(" > " + offer.title);