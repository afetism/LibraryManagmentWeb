
namespace LibraryManagmentWeb.Database;

using LibraryManagmentWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



public partial class LibrarianBase:DbContext
{
    public LibrarianBase()
    {
        
    }

	public LibrarianBase(DbContextOptions<LibrarianBase> options) : base(options)
	{
	}

	public virtual DbSet<Librarian> Librarians { get; set; }

}
