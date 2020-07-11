using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace CodeFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow /*,INotifyPropertyChanged*/
    {
        //private ObservableCollection<Student> _studentModels=new ObservableCollection<Student>();
        //private ObservableCollection<Teacher> _teacherModels = new ObservableCollection<Teacher>();

  

        private Random random;
        private SQLContext sqlContext;

        //public ObservableCollection<Student> StudentModels
        //{

        //    get => _studentModels;
        //    set
        //    {
        //        _studentModels = value;
        //        OnPropertyChanged(nameof(StudentModels));
        //    }
        //}


        //public ObservableCollection<Teacher> TeacherModels
        //{

        //    get => _teacherModels;
        //    set
        //    {
        //        _teacherModels = value;
        //        OnPropertyChanged(nameof(TeacherModels));
        //    }
        //}

        public static readonly DependencyProperty StudentModelsProperty = DependencyProperty.Register(
            "StudentModels", typeof(ObservableCollection<Student>), typeof(MainWindow), new PropertyMetadata(default(ObservableCollection<Student>)));

        public ObservableCollection<Student> StudentModels
        {
            get { return (ObservableCollection<Student>) GetValue(StudentModelsProperty); }
            set { SetValue(StudentModelsProperty, value); }
        }

        public static readonly DependencyProperty TeacherModelsProperty = DependencyProperty.Register(
            "TeacherModels", typeof(ObservableCollection<Teacher>), typeof(MainWindow), new PropertyMetadata(default(ObservableCollection<Teacher>)));

        public ObservableCollection<Teacher> TeacherModels
        {
            get { return (ObservableCollection<Teacher>) GetValue(TeacherModelsProperty); }
            set { SetValue(TeacherModelsProperty, value); }
        }

        public MainWindow()
        {

            //示例
            // //获取Configuration对象
            //Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ////根据Key读取<add>元素的Value
            //string name = config.AppSettings.Settings["name"].Value;
            ////写入<add>元素的Value
            //config.AppSettings.Settings["name"].Value = "fx163";
            ////增加<add>元素
            // config.AppSettings.Settings.Add("url", "http://www.fx163.net");
            // //删除<add>元素
            // config.AppSettings.Settings.Remove("name");
            // //一定要记得保存，写不带参数的config.Save()也可以
            // config.Save(ConfigurationSaveMode.Modified);
            // //刷新，否则程序读取的还是之前的值（可能已装入内存）
            // System.Configuration.ConfigurationManager.RefreshSection("appSettings");


            //改变DB目录
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings[1].ConnectionString = "data source=D:\\CodeFiles\\VisualStudio Projects\\caddll\\sqLiteTestDB.db";
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            string str = ConfigurationManager.ConnectionStrings[1].ConnectionString;
            Debug.WriteLine(str);

            InitializeComponent();
            random = new Random();
            sqlContext = new SQLContext();
            StudentModels = new ObservableCollection<Student>();
            TeacherModels = new ObservableCollection<Teacher>();
        }

        private void AddStudent(object sender, RoutedEventArgs e)
        {
            sqlContext.Studentmodel.Add(new Student { Age = random.Next(10, 19), Grade = random.Next(0, 100) });
            sqlContext.SaveChanges();
            Console.WriteLine("数据添加成功");
            Debug.WriteLine("数据添加成功");
        }

        private void GetStudents(object sender, RoutedEventArgs e)
        {
            StudentModels.Clear();
            var queryable = from student in sqlContext.Studentmodel select student;
            foreach (var item in queryable)
            {
                StudentModels.Add(item);
            }

            var queryable1 = from student in sqlContext.Studentmodel select new{年龄= student.Age,成绩= student.Grade};
            foreach (var item in queryable1)
            {
                Console.WriteLine($"{nameof(item.年龄)} is {item.年龄},{nameof(item.成绩)} is {item.成绩}");
            }
           
        }

        private void AddTeacher(object sender, RoutedEventArgs e)
        {
            sqlContext.Teachertmodel.Add(new Teacher { Age = random.Next(10, 19), Salary = 3000 + random.Next(1, 20) * 100 });
            sqlContext.SaveChanges();
            Console.WriteLine("数据添加成功");
        }

        private void GetTeachers(object sender, RoutedEventArgs e)
        {
            TeacherModels.Clear();
            var queryable = sqlContext.Teachertmodel.Where((x) => true);
            foreach (var item in queryable)
            {
                TeacherModels.Add(item);
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
