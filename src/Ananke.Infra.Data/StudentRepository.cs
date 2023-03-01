using Ananke.Domain.Entities;
using Ananke.Domain.Repository;
using MongoDB.Driver;


namespace Ananke.Infra.Data
{
    public class StudentRepository : IStudentRepository
    {
        // private readonly IMongoClient _mongoClient;
        // private readonly IMongoDatabase _database;


        //public StudentRepository()
        //{
        //    var settings = MongoClientSettings.FromConnectionString("mongodb+srv://anjos:<password>@cluster00.oxy4mby.mongodb.net/?retryWrites=true&w=majority");
        //    settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        //    var client = new MongoClient(settings);
        //    _database = client.GetDatabase("test");
        //}


        public Task<bool> CreateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStudent(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetAllStudents()
        {
            var students = new List<Student>();
            //var studentsCollection = _database.GetCollection<Student>("students");
            //var filter = Builders<Student>.Filter.Empty;
            //var students = await studentsCollection.Find(filter).ToListAsync();
            return Task.FromResult(students);
        }

        public Task<Student> GetStudentByEmail(string email)
        {
            return Task.FromResult(new Student());
        }

        public Task<Student> GetStudentById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
