using TodoApi.Data;
namespace TodoApi.Models
{
    public static class DbInitializer
    {
        public static void Initialize(TodoContext context) 
        { 
           context.Database.EnsureCreated();
            //Look for any tables
            if(context.TodoItems.Any())
            {
                return;
            }
            //Seed the database with some test data
            var todos = new TodoItem[]
            {
                new TodoItem {Name = "Learn C#"},
                 new TodoItem {Name = "Learn ASP.NET Core"},
                  new TodoItem {Name = "Build a web app"}
            };
            foreach( var todo in todos ) 
            { 
                context.TodoItems.Add( todo );
            }
            context.SaveChanges();
        
        
        }
    }
}
