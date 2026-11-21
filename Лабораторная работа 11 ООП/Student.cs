namespace Lab11
{
    // Класс наследник
    class Student : Person
    {
        public int Course { get; set; }
        public string Group { get; set; }

        public Student() : base()
        {
            Course = 1;
            Group = "нет";
        }

        public Student(string name, int age, int course, string group) : base(name, age)
        {
            Course = course;
            Group = group;
        }

        // возвращает объект базового класса
        public Person BasePerson
        {
            get { return new Person(Name, Age); }
        }

        public override string ToString()
        {
            return "Student: " + Name + ", возраст " + Age + ", курс " + Course + ", группа " + Group;
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;
            Student s = (Student)obj;
            return Course == s.Course && Group == s.Group;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ Course ^ Group.GetHashCode();
        }
    }
}
