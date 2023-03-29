using Class49.data;

namespace Class49.Web.Models
{
    public class IndexViewModel
    {
        public List<Person> People { get; set; }

        public IndexViewModel(List<Person> people)
        {
            People = people;
        }
        public IndexViewModel()
        { }
    }
}
