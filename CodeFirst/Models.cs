using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    //该实体类和表“Student”存在联系
    [Table("Student")]
    public class Student
    {
        //学号
        [Key]//主键
        public int Id { get; set; }
        //年龄
        public int Age { get; set; }
        //成绩
        public int Grade { get; set; }
    }

    [Table("Teacher")]
    public class Teacher
    {
        [Key]//主键
        public int Id { get; set; }
        //年龄
        public int Age { get; set; }
        //成绩
        public int Salary { get; set; }
    }
}
