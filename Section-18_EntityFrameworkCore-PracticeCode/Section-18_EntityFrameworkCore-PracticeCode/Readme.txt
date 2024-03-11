EntityFrameworkCore is light-weight, extensible and cross-platform framework for accessing 
databases in .NET applications.It is the most-used database framework for Asp.Net Core Apps.

Pros &cons of :-

Shorter Code: The CRUD operations / calling stored procedures are done with shorter amount 
of code than ADO.NET.

Performance: EFCore performs slower than ADO.NET. So ADO.NET or its alternatives 
(such as Dapper) are recommended for larger & high-traffic applications.

Strongly-Typed: The columns as created as properties in model class.So the Intellisense 
offers columns of the table as properties, while writing the code. Plus, the developer need 
not convert data types of values; it's automatically done by EFCore itself.

EFCore Approaches:-
CodeFirstApproach							DbFirstApproach
- Suitable for newer  database.		        Suitable if you have an existing database or DB
											designed by DBAs, developed seperately.
-Manual changes to DB most probably lost    Manual changes to DB can done independently.
because your code defines the database.		

-Stored procedures are to be written as		Stored Procedures, indexes, triggers etc can be  
a part of C# code.				            created with T-SQL independently.

-Suitable for smaller applications or		Suitable for larger and high intense applications.
prototype level applications only but not
for larger or high data intense application.

//DbContext and DbSet
Custom DbContext class                              SQL Server
public class CustomDbContext: DbContext{   ----->   SQL Database
public DbSet<ModelClass1> dbSet1 {get; set;}   <------> Table 1
public DbSet<ModelClass2> dbSet2 {get; set;}   <------> Table 2
}

DbContext								  v\s	  DbSet
An instance of DbContext is responsible           Represents a single database table,
to hold a set of DbSet's and represent			  each column is represented as a model property.
a connection with database.


//seed Data
it adds initial data(initial rows) in tables, when the table is newly created.
modelBuilder.Entity<ModelClass>().HasData(entityObject);