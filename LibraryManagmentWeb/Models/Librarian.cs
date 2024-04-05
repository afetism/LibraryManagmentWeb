namespace LibraryManagmentWeb.Models
{
	public class Librarian
	{
		public Librarian(string fullName, string email, string password)
		{
            FullName = fullName.ToLower();
			Email=email;
			Password=password;
			Id=Guid.NewGuid();
		}
		public Guid Id { get; set; }
		public string FullName { get; set; }
      

		public string UserName { get; set; }
        public string  Email { get; set; }
        public string Password { get; set; }



    }
}
