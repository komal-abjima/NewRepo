using System;

namespace College
{
    public class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Branch branch { get; set; } //Contains reference to object of branch class, that represents the
                                           //branch that the current student belongs to.
    }
}
