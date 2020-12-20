using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public static class Analyzer
    {
        public enum Subjects
        {
            SQL = 300,
            Blender = 250,
            CSharp = 150
        }

        static LearnItem[] Items = new LearnItem[]
        {
            new LearnItem
            {
                Subject = Subjects.SQL,
                SubjectsID = new int[] { 4, 5, 22 }
            },
            new LearnItem
            {
                Subject = Subjects.Blender,
                SubjectsID = new int[] { 17, 18 }
            },
            new LearnItem
            {
                Subject = Subjects.CSharp,
                SubjectsID = new int[] { 1, 2, 3 }
            }
        };


        public static IEnumerable<Дисциплины> Analyze(Пользователь user, IEnumerable<Дисциплины> allOfSubjects)
        {
            var prefear = GetPrefear(user).ToList();
            prefear.AddRange(allOfSubjects.Where(x => !prefear.Contains(x)));

            return prefear;
        }

        private static IEnumerable<Дисциплины> GetPrefear(Пользователь user)
        {
            var subjects = user.Предпочтения_обучающегося.Select(x => x.Дисциплины);
            var result = new List<Дисциплины>();
            foreach (var item in Items)
            {
                result.AddRange(subjects.Where(x => item.SubjectsID.Contains(x.ID_дисциплины)));
            }

            return result;
        }

        class LearnItem
        {
            public Subjects Subject { get; set; }
            public int[] SubjectsID { get; set; }
        }
    }
}
